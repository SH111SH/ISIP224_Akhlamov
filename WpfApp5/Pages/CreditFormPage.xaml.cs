using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
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

namespace WpfApp5.Pages
{
    /// <summary>
    /// Логика взаимодействия для CreditFormPage.xaml
    /// </summary>
    public partial class CreditFormPage : Page
    {
        public CreditFormPage()
        {
            InitializeComponent();
        }

        public static int PbValue = 100;


        
        private void TextChanged(object sender, TextChangedEventArgs e)
        {
            if (InfoValidation())
            {
                DoneButton.IsEnabled = true;
            }
            else
            {
                DoneButton.IsEnabled = false;
            }
                    
        }

        private void FBackButton_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult result = MessageBox.Show(
    "Are you sure you want to cancel?",
    "Exit",
    MessageBoxButton.YesNo,
    MessageBoxImage.Question
);

            if (result == MessageBoxResult.Yes)
            {
                NavigationService.GoBack();
                Check.Total = 0;
            }
            else
            {

            }
        }

        private void NextButton_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new MainPage());
        }
        private bool InfoValidation()
            {
            if (String.IsNullOrWhiteSpace(FullnameInput.Text))
            {
                ErrorDisplay1.Visibility = Visibility.Visible;
                return false;
            }
            else
            {
                ErrorDisplay1.Visibility = Visibility.Hidden;
            }
            if (EmailInput.Text.Length <= 0 || !(EmailInput.Text.Contains("@")))
            {
                ErrorDisplay2.Visibility = Visibility.Visible;
                return false;
            }
            else
            {
                ErrorDisplay2.Visibility = Visibility.Hidden;
            }
            if (!(int.TryParse(PhoneInput.Text,out int result)))
              {
                ErrorDisplay3.Visibility = Visibility.Visible;
                return false;
            }
            else
            {
                ErrorDisplay3.Visibility = Visibility.Hidden;
            }

            return true;


            }
    }

    } 
