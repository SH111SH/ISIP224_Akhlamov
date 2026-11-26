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
    /// Логика взаимодействия для RegistrationPage.xaml
    /// </summary>
    public partial class RegistrationPage : Page
    {
        public RegistrationPage()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (!String.IsNullOrWhiteSpace(Login.Text) && !String.IsNullOrWhiteSpace(Password1.Password) && !String.IsNullOrWhiteSpace(Password1.Password) && Password1.Password == Password2.Password)
            {
                Core.Context.User.Add(new User { Login = Login.Text, Password = Password1.Password });
                Core.Context.SaveChanges();
                NavigationService.Navigate(new LoginPage());
            }
            else if (String.IsNullOrWhiteSpace(Login.Text))
            {
                MessageBox.Show("Логин не введен");
            }
            else if(Password1.Password != Password2.Password)
            {
                MessageBox.Show("Пароли не совпадают");
            }
            else if(String.IsNullOrWhiteSpace(Password1.Password))
            {
                MessageBox.Show("Пароль не введен");
            }
        }
    }
}
