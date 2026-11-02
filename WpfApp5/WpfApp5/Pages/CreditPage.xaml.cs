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
        }

        private void DownPaymenSlider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            DownPaymentSliDerValueDisplay.Text = Convert.ToString(DownPaymenSlider.Value);
            DownPaymentSumDisplay.Text = Convert.ToString(DownPaymenSlider.Value * 50000);

        }

        private void PaymentDeadline_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            if(PaymentDeadlineDisplay != null)
            {
                PaymentDeadlineDisplay.Text = Convert.ToString(PaymentDeadline.Value);

            }
        }
    }
}
