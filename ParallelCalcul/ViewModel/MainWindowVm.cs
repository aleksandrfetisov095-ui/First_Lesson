using ParallelCalcul.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace ParallelCalcul.ViewModel
{
    public class MainWindowVm : BaseVm
    {
        public RelayCommand OpenSumWindowCommand { get; }
        public RelayCommand OpenDifferenceWindowCommand { get; }
        public RelayCommand OpenBothCommand { get; }

        public MainWindowVm()
        {
            OpenSumWindowCommand = new RelayCommand(OpenSumWindow);
            OpenDifferenceWindowCommand = new RelayCommand(OpenDifferenceWindow);
            OpenBothCommand = new RelayCommand(OpenBothWindows);
        }

        private void OpenSumWindow(object parameter)
        {
            var sumWindow = new View.SumWindow();
            sumWindow.Show();
        }

        private void OpenDifferenceWindow(object parameter)
        {
            var diffWindow = new View.DifferenceWindow();
            diffWindow.Show();
        }

        private void OpenBothWindows(object parameter)
        {
            OpenSumWindow(null);
            OpenDifferenceWindow(null);
        }

        private void ShowMessage(string message)
        {
            MessageBox.Show(message, "Информация", MessageBoxButton.OK);
        }
    }
}
