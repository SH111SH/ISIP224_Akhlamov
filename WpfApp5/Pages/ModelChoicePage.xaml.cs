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
    /// Логика взаимодействия для ModelChoicePage.xaml
    /// </summary>
    public partial class ModelChoicePage : Page
    {
        public ModelChoicePage()
        {
            InitializeComponent();
        }
        public static int PbValue = 20;


        private void BackButton_Click(object sender, RoutedEventArgs e)
        {

            NavigationService.GoBack();
            
        }

        private void NextButton_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new FeaturesPage());
        }

        private void ModelRadioButton_Checked(object sender, RoutedEventArgs e)
        {
            if(Granta.IsChecked == true)
            {
                Car.CarInstance.Model = "Lada Granta";
            }
            else if(T7.IsChecked == true)
            {
                Car.CarInstance.Model = "Tenet T7";
            }
            else if(Vesta.IsChecked == true)
            {
                Car.CarInstance.Model = "Lada Vesta";
            }
            else if(Jolion.IsChecked == true)
            {
                Car.CarInstance.Model = "Haval Jolion";
            }


            Check.Calculate();
        }

        private void EnigneTypeRadioButton_Checked(object sender, RoutedEventArgs e)
        {
            if (Gasoline.IsChecked == true)
            {
                Car.CarInstance.EngineType = "Gasoline";
            }
            else if (Gas.IsChecked == true)
            {
                Car.CarInstance.EngineType = "Gas";
            }
            else if (Dizel.IsChecked == true)
            {
                Car.CarInstance.EngineType = "Dizel";
            }
            else if (Hyprid.IsChecked == true)
            {
                Car.CarInstance.EngineType = "Hyprid";
            }
            else if (Electric.IsChecked == true)
            {
                Car.CarInstance.EngineType = "Electric";
            }

            Check.Calculate();
            
        }
    }
}