using ConsoleApp3;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp3
{
    internal class Program
    {

        static User CurrentAccount = null;

        static List<PickupPoint> pickupPoints = Core.Context.PickupPoint.ToList();
        static void Registration()
        {

            Console.WriteLine("Регистрация: ");

            String login = " ";
            while (String.IsNullOrWhiteSpace(login))
            {
                Console.WriteLine("Введите логин:");
                login = Console.ReadLine();

                if(Core.Context.User.FirstOrDefault(x => x.Login == login) != null)
                {
                    Console.WriteLine("Этот логин уже занят! Введите другой");
                    login = " ";
                    continue;

                }
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
                Core.Context.Cart.Add(new Cart { UserId = user.Id });
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


        static void ShowPickupPoints()
        {
            

            Console.WriteLine("    Name  | Adress");
            foreach (PickupPoint point in pickupPoints) { Console.WriteLine($"{point.Id}. {point.Name}  | {point.Address}"); }
        }

        static void ShowCart()
        {
            if (CurrentAccount == null)
            {
                Console.WriteLine("Вы не вошли в аккаунт.\n1 - Вход\n2 - Регистрация");
                string uc = Console.ReadLine();
                switch (uc)
                {
                    case "1":
                        Login();
                        break;

                    case "2":
                        Registration();
                        break;
                }
            }

            Console.WriteLine("\n КОРЗИНА: \n");
            Cart cart = Core.Context.Cart.ToList().FirstOrDefault(j => j.UserId == CurrentAccount.Id);
            List<CartItem> carti = Core.Context.CartItem.Where(i => i.CartId == cart.Id).ToList();

            for (int i = 0; i < carti.Count; i++)
            {
                CartItem c = carti[i];
                Product p = Core.Context.Product.FirstOrDefault(f => f.Id == c.ProductId);
                if (p != null)
                {
                    Console.WriteLine($"{c.Id}.{p.Name}    {p.Description}    {Core.Context.Category.ToList().FirstOrDefault(j => j.Id == p.CategoryId).Name}    {p.Price}    {p.Stock}");
                }
            }

            string user_input = " ";
            while (String.IsNullOrWhiteSpace(user_input))
            {
                Console.WriteLine("Введите номер товара который хотите заказать отдельно или введите В,чтобы заказать все товары из корзины  e - выход");
                user_input = Console.ReadLine().ToLower();

            }
            if(user_input == "e")
            {
                return;
            }
            PickupPoint pvz;
            string ppt = " ";
            ShowPickupPoints();
            while (String.IsNullOrWhiteSpace(ppt))
            {
                Console.WriteLine("Введите номер ПВЗ на который вы хотите сделать заказ");
                ppt = Console.ReadLine();

            }

            pvz = pickupPoints.FirstOrDefault(p => p.Id == Convert.ToInt32(ppt));

            if (user_input.Contains("B"))
            {
                decimal Totalprice = 0;
                for (int i = 0; i < carti.Count(); i++)
                {
                    CartItem c = carti[i];
                    Product p = Core.Context.Product.FirstOrDefault(f => f.Id == c.ProductId);
                    if (p != null)
                    {
                        Totalprice += p.Price;
                    }

                    Order order = new Order { UserId = CurrentAccount.Id, PickupPointId = pvz.Id, Status = "Delivered", TotalPrice = Totalprice, CreatedAt = DateTime.Now };
                    Core.Context.Order.Add(order);
                    Core.Context.SaveChanges();

                    OrderItem oi = new OrderItem { ProductId = c.ProductId, OrderId = order.Id, Quantity = c.Quantity };
                    Core.Context.OrderItem.Add(oi);
                    Core.Context.SaveChanges();

                    Core.Context.CartItem.Remove(c);
                    Core.Context.SaveChanges();

                    Console.WriteLine("Ваш заказ успешно оформлен!");

                }
            }
            else if (int.TryParse(user_input, out int result))
            {
                Console.WriteLine(result);
                if (carti.FirstOrDefault(c => c.Id == result) != null)
                {
                    CartItem c = carti.FirstOrDefault(j => j.Id == result);
                    Order order = new Order { UserId = CurrentAccount.Id, PickupPointId = pvz.Id, Status = "Delivered", TotalPrice = Core.Context.Product.ToList().FirstOrDefault(k => k.Id == c.ProductId).Price, CreatedAt = DateTime.Now };
                    Core.Context.Order.Add(order);
                    Core.Context.SaveChanges();

                    OrderItem oi = new OrderItem { ProductId = c.ProductId, OrderId = order.Id, Quantity = c.Quantity };
                    Core.Context.OrderItem.Add(oi);
                    Core.Context.SaveChanges();

                    Core.Context.CartItem.Remove(c);
                    Core.Context.SaveChanges();

                    Console.WriteLine("Ваш заказ успешно оформлен!");
                }
                else
                {
                    Console.WriteLine("Неправильное значение");
                    ShowCart();
                }
            }
            

            else
            {
                Console.WriteLine("Неправильное значение!");
                ShowCart();
            }




        }


        static void ShowProducts(List<Product> products)
        {


            string user_input = "";
            while (user_input != "e")
            {
                Console.WriteLine("Введите номер товара который хотите добавить в корзину или e если хоите выйти");
                Console.WriteLine("Name    Description    Category    Price    Stock");
                for (int i = 0; i < products.Count(); i++)
                {
                    Console.WriteLine($"{products[i].Id}.{products[i].Name}    {products[i].Description}    {Core.Context.Category.ToList().FirstOrDefault(j => j.Id == products[i].CategoryId).Name}    {products[i].Price}    {products[i].Stock}");
                }

                user_input = Console.ReadLine().ToLower();
                if (user_input != "e")
                {
                    if (CurrentAccount == null)
                    {
                        Console.WriteLine("Вы не вошли в аккаунт.\n1 - Вход\n2 - Регистрация");
                        string uc = Console.ReadLine();
                        switch (uc)
                        {
                            case "1":
                                Login();
                                break;

                            case "2":
                                Registration();
                                break;
                        }
                    }

                        int quantity = 0;
                        while (quantity <= 0)
                        {
                            Console.WriteLine("Введите количество:");
                            quantity = Convert.ToInt32(Console.ReadLine());

                        }

                        Core.Context.CartItem.Add(new CartItem { CartId = Core.Context.Cart.ToList().FirstOrDefault(i => i.UserId == CurrentAccount.Id).Id, ProductId = Convert.ToInt32(user_input), Quantity = quantity });
                        Console.WriteLine("Товар добавлен в корзину");
                        Core.Context.SaveChanges();
                    }

                }
            }

        
        static void ShowOrders()
        {
            if (CurrentAccount == null)
            {
                Console.WriteLine("Вы не вошли в аккаунт.\n1 - Вход\n2 - Регистрация");
                string uc = Console.ReadLine();
                switch (uc)
                {
                    case "1":
                        Login();
                        break;

                    case "2":
                        Registration();
                        break;
                }
            }

            List<Order> orders = Core.Context.Order.Where(p => p.UserId == CurrentAccount.Id).ToList();

            Console.WriteLine("Заказы: ");
            for (int i = 0; i < orders.Count(); i++)
            {
                Console.WriteLine(" №   |                  ПВЗ                     |  Дата Заказа   |  Сумма   |   Статус    ");
                Console.WriteLine($"{orders[i].Id} | {pickupPoints.FirstOrDefault(p => p.Id == orders[i].PickupPointId).Address}| {orders[i].CreatedAt} | {orders[i].TotalPrice} | {orders[i].Status}");
            }


            string user_input = " ";
            while (user_input != "e")
            {
                Console.WriteLine("Введите номер заказа чтобы посмотреть его состав или Е если хотите выйти");
                user_input = Console.ReadLine().ToLower();

                if (int.TryParse(user_input, out int res) && !(String.IsNullOrWhiteSpace(user_input)))
                    {
                        OrderItem c = Core.Context.OrderItem.FirstOrDefault(j => j.OrderId == res);
                        Product p = null;
                        if (c != null)
                        {
                            Console.WriteLine("pesdd");
                            p = Core.Context.Product.FirstOrDefault(f => f.Id == c.ProductId);

                        }
                        if (p != null)
                        {
                            Console.WriteLine($"{c.Id}.{p.Name}    {p.Description}    {Core.Context.Category.ToList().FirstOrDefault(j => j.Id == p.CategoryId).Name}    {p.Price}    {p.Stock}");
                        }
                    Console.ReadKey();
                }
            }


        }
        static void Main(string[] args)
        {

            //Login();

            string user_input = " ";
            while (user_input != "e")
            {
                Console.WriteLine($"Меню:\n1 - каталог товаров\n2 - Корзина\n3 - Заказы\n4 - Все ПВЗ\ne - Выход");
                user_input = Console.ReadLine();

                switch (user_input) 
                {
                    case "1":
                        ShowProducts(Core.Context.Product.ToList());
                        break;

                    case "2":
                        ShowCart();
                        break;

                    case "3":
                        ShowOrders();
                        break;

                    case "4":
                        ShowPickupPoints();
                        break;
                }
            }


            

        }
    }
}
