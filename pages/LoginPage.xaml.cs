using Cinemma;
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

namespace Cinema.Pages
{
    /// <summary>
    /// Логика взаимодействия для LoginPage.xaml
    /// </summary>
    public partial class LoginPage : Page
    {
        public LoginPage()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new RegistrationPage());
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            if(Core.Context.User.FirstOrDefault(i=> i.Login == Login.Text && i.Password == Password.Password) != null)
            {
                MessageBox.Show("Успешный вход");
                
            }
            else
            {
                MessageBox.Show("Неверный логин или пароль");
                Login.Text = "";
                Password.Password = "";
            }
        }
    }
}
