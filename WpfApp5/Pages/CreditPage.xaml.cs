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

namespace WpfApp5.Pages
{
    /// <summary>
    /// Логика взаимодействия для CreditPage.xaml
    /// </summary>
    public partial class CreditPage : Page
    {

        
        public CreditPage()
        {
            InitializeComponent();
            TotalCheckSumDisplay.Text = Convert.ToString(Check.Total);
            PaymentDeadline.Value = 12;
        }

        

        private void DownPaymenSlider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            DownPaymentSliDerValueDisplay.Text = Convert.ToString(DownPaymenSlider.Value);
            DownPaymentSumDisplay.Text = $"{Convert.ToString(Check.Total * (Convert.ToDecimal(DownPaymenSlider.Value)/100) )}$";
            DownPaymentDisplay.Text = $"{DownPaymentSumDisplay.Text}";
            UpdatePayment();

        }



        private void PaymentDeadline_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            if (PaymentDeadlineSliderDisplay != null)
            {
                PaymentDeadlineSliderDisplay.Text = Convert.ToString(PaymentDeadline.Value);
                PaymentDeadlineDisplay.Text = $"{Convert.ToString(PaymentDeadline.Value)} mnths";
                UpdatePayment();

            }
        }
        private void UpdatePayment()
        {
            double r = 14.0 / 12.0 / 100.0;
            double n = PaymentDeadline.Value;
            double monthlyPayment = Convert.ToDouble(Check.Total) * ((r * Math.Pow(1 + r, n)) / (Math.Pow(1 + r, n) - 1));
            EverymonthPaymentDisplay.Text = monthlyPayment.ToString("F2");
        }

        private void NextButton_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new CreditFormPage());
        }

        private void FBackButton_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();
        }
    }
}
