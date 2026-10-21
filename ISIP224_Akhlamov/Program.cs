using ConsoleApp1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    internal class Program
    {

        static User CurrentAccount = null;
        static void Registration()
        {

            Console.WriteLine("Регистрация: ");

            String login = " ";
            while (String.IsNullOrWhiteSpace(login))
            {
                Console.WriteLine("Введите логин:");
                login = Console.ReadLine();
            }


            String paswd1 = "  ";
            String paswd2 = " ";



            while (String.IsNullOrWhiteSpace(paswd1))
            {
                Console.WriteLine("Введите пароль:");
                paswd1 = Console.ReadLine();
            }

            while (String.IsNullOrWhiteSpace(paswd2))
            {
                Console.WriteLine("Введите пароль повторно:");
                paswd2 = Console.ReadLine();
            }

            if (paswd2 == paswd1)
            {
                User user = new User { Login = login, PasswordHash = paswd1, CreatedAt = DateTime.Now };
                Core.Context.User.Add(user);
                Core.Context.SaveChanges();
            }
            else
            {
                Console.WriteLine("пароли не совпадают");
            }




        }


        static void Login()
        {
            Console.WriteLine("Вход:");
            string login = " ";
            string passwd = " ";

            while (String.IsNullOrWhiteSpace(login))
            {
                Console.WriteLine("Введите логин:");
                login = Console.ReadLine();

            }

            while (String.IsNullOrWhiteSpace(passwd))
            {
                Console.WriteLine("Введите пароль");
                passwd = Console.ReadLine();
            }

            List<User> users = Core.Context.User.ToList();

            User user = users.FirstOrDefault(i => i.Login == login && i.PasswordHash == passwd);

            if (user != null)
            {
                Console.WriteLine("Успешный вход");
                CurrentAccount = user;
            }
            else { Console.WriteLine("Неверный логин или пароль"); }
        }



        static void Main(string[] args)
        {
            //Registration();
            Login();

            Console.WriteLine($"Меню:\n1 - каталог товаров\n2 - Корзина\n3 - Заказы");


        }
    }
}
