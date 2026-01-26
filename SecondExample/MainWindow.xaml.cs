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

namespace SecondExample
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class DiffW : Window
    {
        public DiffW()
        {
            InitializeComponent();
        }


        private void CalculateButton_Click(object sender, RoutedEventArgs e)
        {
            // Проверка ввода
            if (!double.TryParse(InputTextBox.Text, out double number))
            {
                MessageBox.Show("Введите число!");
                return;
            }

            
            ProgressBar.Visibility = Visibility.Visible;
            CalculateButton.IsEnabled = false;

            //  запуск в фоне
            ThreadPool.QueueUserWorkItem(_ =>
            {
                
                double result = SimpleDifference(number);

                // 5. возвращение в гл. поток
                Dispatcher.Invoke(() =>
                {
                    ResultTextBox.Text = result.ToString();
                    ProgressBar.Visibility = Visibility.Collapsed;
                    CalculateButton.IsEnabled = true;
                });
            });
        }

        private double SimpleDifference(double number)
        {
            Thread.Sleep(1000); // 1сек

            
            double diff = (number * 10) - 3;

            return diff;
        }
    }
}
