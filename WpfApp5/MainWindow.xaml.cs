using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
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
using WpfApp5.Pages;

namespace WpfApp5
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            
        }



        private void MainFrame_Navigated(object sender, NavigationEventArgs e)
        {
            
            Page currentPage = MainFrame.Content as Page;
            if(currentPage is ModelChoicePage)
            {
                GlobalProgressBar.Value = 20;
                TotalSumDisplay.Text = $"Total Sum { Convert.ToString(Check.Total)}$";

            }
            else if(currentPage is FeaturesPage)
            {
                GlobalProgressBar.Value = 40;
                TotalSumDisplay.Text = $"Total Sum {Convert.ToString(Check.Total)}$";
            }
            else if(currentPage is CheckPage)
            {
                GlobalProgressBar.Value = 60;
                TotalSumDisplay.Text = $"Total Sum {Convert.ToString(Check.Total)}$";
            }
            else if(currentPage is CreditPage)
            {
                GlobalProgressBar.Value = 80;
                TotalSumDisplay.Text = $"Total Sum {Convert.ToString(Check.Total)}$";
            }
            else if(currentPage is CreditFormPage)
            {
                GlobalProgressBar.Value = 100;
                TotalSumDisplay.Text = $"Total Sum {Convert.ToString(Check.Total)}$";
            }
            else
            {
                GlobalProgressBar.Value = 0;
                TotalSumDisplay.Text = $"Total Sum {Convert.ToString(Check.Total)}$";
            }

            
        }
    }
}