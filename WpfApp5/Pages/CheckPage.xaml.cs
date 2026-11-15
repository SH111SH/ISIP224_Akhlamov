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
    /// Логика взаимодействия для CheckPage.xaml
    /// </summary>
    public partial class CheckPage : Page
    {
        public int PbValue => 60;
        public CheckPage()
        {
            InitializeComponent();

            Model.Text = Car.CarInstance.Model;
            ModelPrice.Text = $"{Convert.ToString(Check.CarPriceList[Car.CarInstance.Model])}$";

            EngineType.Text = Car.CarInstance.EngineType;
            EngineTypePrice.Text = $"{Convert.ToString(Check.EngineTypePriceList[Car.CarInstance.EngineType])}$";

            Color.Text = Car.CarInstance.color;
            ColorPrice.Text = $"{Convert.ToString(Check.ColorPriceList[Car.CarInstance.color])}$";

            if(Car.CarInstance.Features.Contains("CruiseControl"))
            {
                CruiseControl.Text = "Yes";
                CruiseControlPrice.Text = $"{Convert.ToString(Check.FeaturesPriceList["CruiseControl"])}$";
            }
            else 
            {
                CruiseControl.Text = "No";
                CruiseControlPrice.Text = "0$";
            }
            if (Car.CarInstance.Features.Contains("ClimatControl"))
            {
                ClimatControl.Text = "Yes";
                ClimatControlPrice.Text = $"{Convert.ToString(Check.FeaturesPriceList["ClimatControl"])}$";
            }
            else 
            {
                ClimatControl.Text = "No";
                ClimatControlPrice.Text = $"0$";
            }
            if (Car.CarInstance.Features.Contains("Tonirovka"))
            {
                Tonirovka.Text = "Yes";
                TonirovkaPrice.Text = $"{Convert.ToString(Check.FeaturesPriceList["Tonirovka"])}$";
            }
            else
            {
                Tonirovka.Text = "No";
                TonirovkaPrice.Text = $"0$";
            }
            if(Car.CarInstance.Features.Contains("Display"))
            {
                Display.Text = "Yes";
                DisplayPrice.Text = $"{Convert.ToString(Check.FeaturesPriceList["Display"])}$";
            }
            else
            {
                Display.Text = "No";
                DisplayPrice.Text = $"0$";
            }
            if(Car.CarInstance.Features.Contains("Nitro"))
            {
                Nitro.Text = "Yes";
               NitroPrice.Text = $"{Convert.ToString(Check.FeaturesPriceList["Nitro"])}$";
            }
            else
            {
                Nitro.Text = "No";
                NitroPrice.Text = $"0$";
            }

            Total.Text = $"{Convert.ToString(Check.Total)}$";

        }


        private void NextButton_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new CreditPage());
        }

        private void FBackButton_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();
        }
    }
}
