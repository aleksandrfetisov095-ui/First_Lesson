using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace FirstExample
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class SumW : Window
    {
        public SumW()
        {
            InitializeComponent();
        }


        private void CalculateButton_Click(object sender, RoutedEventArgs e)
        {
            //  Проверка на ввод
            if (!double.TryParse(InputTextBox.Text, out double number))
            {
                MessageBox.Show("Введите число!");
                return;
            }

            //  начало вычисления
            ProgressBar.Visibility = Visibility.Visible;
            CalculateButton.IsEnabled = false;

            //  запуск вычисления
            ThreadPool.QueueUserWorkItem(_ =>
            {
                
                double result = SimpleSum(number);

                //  обновление
                Dispatcher.Invoke(() =>
                {
                    ResultTextBox.Text = result.ToString();
                    ProgressBar.Visibility = Visibility.Collapsed;
                    CalculateButton.IsEnabled = true;
                });
            });
        }

        // функция суммы
        private double SimpleSum(double number)
        {
            Thread.Sleep(1000); //1 секк

            
            double sum = number + 1 + 2;

            return sum;
        }
    }
}
