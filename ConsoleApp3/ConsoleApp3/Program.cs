using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp3
{

    internal class Program
    {
        static void Main(string[] args)
        {

            int user_input = -1;

            while (user_input != 0)
            {
                Console.WriteLine("Menu: \n 1 - create new product \n 2 - remove product \n 3 - order product \n 4 - sell product \n 5 - search \n 0 - exit");
                user_input = Convert.ToInt32(Console.ReadLine());
                switch (user_input)
                {
                    case 1:
                        Console.WriteLine("Enter new product's name: ");
                        string name = Console.ReadLine();
                        Console.WriteLine("Enter new product's price: ");
                        double price = Convert.ToDouble(Console.ReadLine());
                        Console.WriteLine("Enter quanity of your product:");
                        int quanity = Convert.ToInt32(Console.ReadLine());
                        Console.WriteLine("Enter category: 0 - food, 1 - tecnical, 2 - for house, 3 - alcohol");
                        int category = Convert.ToInt32(Console.ReadLine());
                        switch (category)
                            {
                            case 0:
                                Product.new_product(name, price, quanity, categories.food);
                                break;
                            case 1:
                                Product.new_product(name, price, quanity, categories.tecnical);
                                break;
                            case 2:
                                Product.new_product(name, price, quanity, categories.for_house);
                                break;
                            case 3:
                                Product.new_product(name, price, quanity, categories.alcohol);
                                break;

                        }
                        break;

                    case 2:
                        Console.WriteLine("Enter Product ID or Product Name:");
                        string query = Console.ReadLine();
                        Product.delete(query);
                        break;

                    case 3:
                        Console.WriteLine("Enter Product ID:");
                        int id = Convert.ToInt32(Console.ReadLine());
                        Console.WriteLine("Enter product quanity:");
                        int quantity = Convert.ToInt32(Console.ReadLine());
                        Product.order_new(id, quantity);

                        break;

                    case 4:
                        Console.WriteLine("Enter Product ID:");
                        int Id = Convert.ToInt32(Console.ReadLine());
                        Console.WriteLine("Enter product quanity:");
                        int Quantity = Convert.ToInt32(Console.ReadLine());
                        Product.sell(Id, Quantity);
                        break;
                    case 5:
                        Console.WriteLine("Enter your query:");
                        string Query = Console.ReadLine();
                        Product.search(Query);

                        break;
                        
                }

                


            }   }
    }
    public enum categories
    {
        food = 0,
        tecnical = 1,
        for_house = 2,
        alcohol = 3,
    }


    public class Product
    {
        public static List<Product> products = new List<Product>();
        private static int MaxID = 1;
        private int ProductID;
        private string Name;
        private double Price;
        private int Count;
        private bool aviability;
        private categories category;


        public Product(string name, double price, int count, categories category)
        {
            ProductID = MaxID;
            MaxID++;
            Name = name;
            Price = price;
            Count = count;
            if (Count > 0)
            {
                aviability = true;
            }
            else
            {
                aviability = false;
            }

            this.category = category;
        }

        public static void new_product(string name, double price, int count, categories category)
        {
            products.Add(new Product(name, price, count, category));
            Console.WriteLine("Product added sucsessfully!");

        }
        public static void delete(string query)
        {
            bool parsed = int.TryParse(query, out int result);
            if (parsed)
            {
                for (int i = 0; i < products.Count; i++)
                {
                    if (products[i].ProductID == result)
                    {
                        products.RemoveAt(i);
                        Console.WriteLine("Product Deleted sucsess!");
                    }
                }
            }
            else
            {
                for (int i = 0; i < products.Count; i++)
                {
                    if (products[i].Name.ToLower() == query.ToLower())
                    {
                        products.RemoveAt(i);
                        Console.WriteLine("Product Deleted sucsess!");
                    }
                }
            }
        }

        public static void order_new(int id, int count)
        {
            for (int i = 0; i < products.Count; i++)
            {
                if (products[i].ProductID == id)
                {
                    products[i].Count += count;
                    if (products[i].Count > 0)
                    {
                        products[i].aviability = true;
                    }
                    Console.WriteLine($"You ordered {count} {products[i].Name}s");
                }

            }

        }

        public static void sell(int id, int count)
        {
            for (int i = 0; i < products.Count; i++)
            {
                if (products[i].ProductID == id && products[i].Count >= count)
                {
                    products[i].Count -= count;
                    if (products[i].Count <= 0)
                    {
                        products[i].aviability = false;
                    }
                    Console.WriteLine($"You sold {count} {products[i].Name}s");
                }

            }

        }

        public static void search(string query)
        {
            bool parsed = int.TryParse(query, out int result);
            if (parsed)
            {
                for (int i = 0; i < products.Count; i++)
                {
                    if (products[i].ProductID == result)
                    {
                        Console.WriteLine($"ID: {products[i].ProductID} | Name: {products[i].Name} | Price: {products[i].Price} | Count: {products[i].Count} | Category: {products[i].category}");
                    }
                }
            }
            else
            {
                for (int i = 0; i < products.Count; i++)
                {
                    if (products[i].Name.ToLower().Contains(query))
                    {
                        Console.WriteLine($"ID: {products[i].ProductID} | Name: {products[i].Name} | Price: {products[i].Price} | Count: {products[i].Count} | Category: {products[i].category}");
                    }
                }
            }
        }



    }
}