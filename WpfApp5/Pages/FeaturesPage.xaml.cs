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
    /// Логика взаимодействия для FeaturesPage.xaml
    /// </summary>
    public partial class FeaturesPage : Page
    {
        public FeaturesPage()
        {
            InitializeComponent();
        }

        public static int PbValue = 40;
        private void NextButton_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new CheckPage());
        }

        private void FBackButton_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();
        }

        private void ColorRadioButtonChecked(object sender, RoutedEventArgs e)
        {
            if(White.IsChecked == true)
            {
                Car.CarInstance.color = "White";
            }
            else if(Black != null && Black.IsChecked == true)
            {
                Car.CarInstance.color = "Black";
            }
            else if(Red != null && Red.IsChecked == true)
            {
                Car.CarInstance.color = "Red";
            }
            else if(Yellow != null && Yellow.IsChecked == true)
            {
                Car.CarInstance.color = "Yellow";
            }
            else if( Magenta != null && Magenta.IsChecked == true)
            {
                Car.CarInstance.color = "Magenta";
            }

            Check.Calculate();
        }

        
        private void FeatureCheckBox_Checked(object sender, RoutedEventArgs e)
        {
            Car.CarInstance.Features.Clear();
            if (CruiseControl.IsChecked == true)
            {
                Car.CarInstance.Features.Add("CruiseControl");
            }
            if (ClimatControl.IsChecked == true)
            {
                Car.CarInstance.Features.Add("ClimatControl");
            }
            if (Display.IsChecked == true)
            {
                Car.CarInstance.Features.Add("Display");
            }
            if (Tonirovka.IsChecked == true)
            {
                Car.CarInstance.Features.Add("Tonirovka");
            }
            if (Nitro.IsChecked == true)
            {
                Car.CarInstance.Features.Add("Nitro");
            }

            Check.Calculate();
        }
    }
}
