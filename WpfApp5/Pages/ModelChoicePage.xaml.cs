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

       

        private void BackButton_Click(object sender, RoutedEventArgs e)
        {

            NavigationService.GoBack();
            
        }

        private void NextButton_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new FeaturesPage());
        }
    }
}
