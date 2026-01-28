using ParallelCalcul.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;

namespace ParallelCalcul.ViewModel
{
    public class DifferenceWindowVm : BaseVm
    {
        private double _inputNumber;
        public double InputNumber
        {
            get => _inputNumber;
            set
            {
                _inputNumber = value;
                OnPropertyChanged();
            }
        }

        private double _result;
        public double Result
        {
            get => _result;
            set
            {
                _result = value;
                OnPropertyChanged();
            }
        }
        // вычисляется ли что то сейчас
        private bool _isCalculating;
        public bool IsCalculating
        {
            get => _isCalculating;
            set
            {
                _isCalculating = value;
                OnPropertyChanged();
                CalculateCommand.RaiseCanExecuteChanged();
                CancelCommand.RaiseCanExecuteChanged();
            }
        }

        public RelayCommand CalculateCommand { get; }
        public RelayCommand CancelCommand { get; }

        private readonly Action<string> _showMessage;
        private CancellationTokenSource _cancellationTokenSource;

        public DifferenceWindowVm(Action<string> showMessage)
        {
            _showMessage = showMessage;

            CalculateCommand = new RelayCommand(Calculate, _ => !IsCalculating);
            CancelCommand = new RelayCommand(Cancel, _ => IsCalculating);
        }

        private void Calculate(object parameter)
        {
            if (InputNumber == 0)
            {
                _showMessage?.Invoke("Введите число! Поле не может быть пустым или нулем.");
                return;
            }


            if (InputNumber < 0)
            {
                _showMessage?.Invoke("Отрицательное цисло!");
                return;
            }

            IsCalculating = true;
            _cancellationTokenSource = new CancellationTokenSource();
            var token = _cancellationTokenSource.Token;

            ThreadPool.QueueUserWorkItem(_ =>
            {
                try
                {
                    Calculator.GetDifference(InputNumber, OnCalculationComplete, token);
                }
                catch (OperationCanceledException)
                {
                    Application.Current.Dispatcher.Invoke(() =>
                    {
                        Result = 0;
                        _showMessage?.Invoke("Вычисление разности отменено!");
                    });
                }
                catch (Exception ex)
                {
                    Application.Current.Dispatcher.Invoke(() =>
                    {
                        _showMessage?.Invoke($"Ошибка: {ex.Message}");
                    });
                }
                finally
                {
                    Application.Current.Dispatcher.Invoke(() =>
                    {
                        IsCalculating = false;
                    });
                }
            });
        }

        private void OnCalculationComplete(double result)
        {
            Application.Current.Dispatcher.Invoke(() =>
            {
                Result = result;
            });
        }

        private void Cancel(object parameter)
        {
            _cancellationTokenSource?.Cancel();
        }
    }
}
