using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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

namespace FSLesson
{
    public partial class MainWindow : Window
    {
        
        private FirstExample.SumW sumForm;
        private SecondExample.DiffW differenceForm;

        public MainWindow()
        {
            InitializeComponent();
        }

        private void OpenSumFormButton_Click(object sender, RoutedEventArgs e)
        {
            if (sumForm == null || sumForm.IsVisible)
            {
                sumForm = new FirstExample.SumW();  
                sumForm.Owner = this;
                sumForm.Show();
            }
            else
            {
                sumForm.Activate();
            }
        }

        private void OpenDifferenceFormButton_Click(object sender, RoutedEventArgs e)
        {
            if (differenceForm == null || !differenceForm.IsVisible)
            {
                differenceForm = new SecondExample.DiffW();  
                differenceForm.Owner = this;
                differenceForm.Show();
            }
            else
            {
                differenceForm.Activate();
            }
        }

        private void OpenBothFormsButton_Click(object sender, RoutedEventArgs e)
        {
            OpenSumFormButton_Click(sender, e);
            OpenDifferenceFormButton_Click(sender, e);
        }
    }
}
