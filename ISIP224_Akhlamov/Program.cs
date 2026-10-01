using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISIP224_Akhlamov
{


    internal class Program
    {
        static List<Book> books = new List<Book>();


        static Book CreateNew()
        {
            Console.WriteLine("Enter the Book name: ");
            string name = Console.ReadLine();
            Console.WriteLine("Enter the author name: ");
            string author = Console.ReadLine();
            Console.WriteLine("Choose genre (0 - detective | 1 - psychology | 2 - since | 3 - novel)");
            int genr = Convert.ToInt32(Console.ReadLine());
            genre g = genre.detective;
            switch (genr)
            {
                case 0:
                    g = genre.detective;
                    break;
                case 1:
                    g = genre.psychology;
                    break;

                case 2:
                    g = genre.since;
                    break;

                case 3:
                    g = genre.novel;
                    break;
            }
            Console.WriteLine("Enter the year of publication: ");
            int pub_year = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter the price:");
            decimal price = Convert.ToDecimal(Console.ReadLine());

            Book b = new Book(name, author, g, pub_year, price);
            books.Add(b);

            return b;



        }

        static void Delete()
        {
            Console.WriteLine("Enter Book ID: ");
            int ID = Convert.ToInt32(Console.ReadLine());
            for (int i = 0; i < books.Count(); i++)
            {
                if (ID == books[i].id)
                {
                    books.Remove(books[i]);
                    return;
                }
                Console.WriteLine("No items to remove! maybe you wrote a wrong id");
            }

        }

        static List<Book> FindByAuthor()
        {
            Console.WriteLine("Enter the author name:");
            string author = Console.ReadLine();
            List<Book> founded = books.Where(p => p.author == author).ToList();
            Console.WriteLine("Results: ");
            foreach (Book f in founded)
            {
                Console.WriteLine($"ID {f.id} | Name {f.name} | Author {f.author} | Genre {f.genr} | Year of publication {f.pub_year} | Price {f.price}");
            }
            return founded;

        }

        static List<Book> FindByName()
        {
            Console.WriteLine("Enter the name:");
            string name = Console.ReadLine();
            List<Book> founded = books.Where(p => p.name == name).ToList();
            Console.WriteLine("Results: ");
            foreach (Book f in founded)
            {
                Console.WriteLine($"ID {f.id} | Name {f.name} | Author {f.author} | Genre {f.genr} | Year of publication {f.pub_year} | Price {f.price}");
            }
            return founded;

        }

        static List<Book> FindByGenre()
        {
            Console.WriteLine("Enter the genre(0 - detective | 1 - psychology | 2 - since | 3 - novel):");
            int genr = Convert.ToInt32(Console.ReadLine());
            genre g = genre.detective;
            switch (genr)
            {
                case 0:
                    g = genre.detective;
                    break;
                case 1:
                    g = genre.psychology;
                    break;

                case 2:
                    g = genre.since;
                    break;

                case 3:
                    g = genre.novel;
                    break;
            }
            List<Book> founded = books.Where(p => p.genr == g).ToList();
            Console.WriteLine("Results: ");
            foreach (Book f in founded)
            {
                Console.WriteLine($"ID {f.id} | Name {f.name} | Author {f.author} | Genre {f.genr} | Year of publication {f.pub_year} | Price {f.price}");
            }
            return founded;

        }

        static void SortByName()
        {
            books = books.OrderBy(p => p.name).ToList();
            Console.WriteLine("Sorted List: ");
            foreach (Book f in books)
            {
                Console.WriteLine($"ID {f.id} | Name {f.name} | Author {f.author} | Genre {f.genr} | Year of publication {f.pub_year} | Price {f.price}");
            }
        }

        static void SortByYear()
        {
            books = books.OrderBy(p => p.pub_year).ToList();
            foreach (Book f in books)
            {
                Console.WriteLine($"ID {f.id} | Name {f.name} | Author {f.author} | Genre {f.genr} | Year of publication {f.pub_year} | Price {f.price}");
            }
        }

        static void MoreExpensive()
        {
            List<Book> s = books.OrderByDescending(p => p.price).ToList();
            Console.WriteLine($"More Expensive: ID {s[0].id} | Name {s[0].name} | Author {s[0].author} | Genre {s[0].genr} | Year of publication {s[0].pub_year} | Price {s[0].price}");
        }

        static void LessExpensive()
        {
            List<Book> s = books.OrderBy(p => p.price).ToList();
            Console.WriteLine($"Less Expensive: ID {s[0].id} | Name {s[0].name} | Author {s[0].author} | Genre {s[0].genr} | Year of publication {s[0].pub_year} | Price {s[0].price}");
        }

        static void AuthorsBooks()
        {
            var authorStats = books.GroupBy(p => p.author).Select(g => new { author = g.Key, count = g.Count() });
            foreach(var stat in authorStats)
            {
                Console.WriteLine($"{stat.author} - {stat.count}");
            }
        }


        static void Main(string[] args)
        {
            string user_input = " ";

            while (user_input != "e")
            {
                Console.WriteLine("Your books: ");
                foreach (var f in books)
                {
                    Console.WriteLine($"ID {f.id} | Name {f.name} | Author {f.author} | Genre {f.genr} | Year of publication {f.pub_year} | Price {f.price}");
                }

                Console.WriteLine("Menu\n 1 - Create new book\n 2 - Delete book by ID\n 3 - Find book by name\n 4 - Find book by author\n 5 - Find book by genre\n 6 - Sort books by name\n 7 - Sort books by year\n 8 - More expensive book\n 9 - Less expensivce book\n 10 - Group books by authors\n e - exit");

                user_input = Console.ReadLine();

                switch(user_input)
                {
                    case "1":
                        CreateNew();
                        break;

                    case "2":
                        Delete();
                        break;

                    case "3":
                        FindByName();
                        break;

                    case "4":
                        FindByAuthor();
                        break;

                    case "5":
                        FindByGenre();
                        break;

                    case "6":
                        SortByName();
                        break;

                    case "7":
                        SortByYear();
                        break;

                    case "8":
                        MoreExpensive();
                        break;

                    case "9":
                        LessExpensive();
                        break;

                    case "10":
                        AuthorsBooks();
                        break;

                    case "e":
                        return;

                }
            }


        }
    }

    public enum genre
    {
        detective = 0,
        psychology = 1,
        since = 2,
        novel = 3

    };

    public class Book
    {
        private static int count_of_books = 0;
        public int id { get; private set; }
        public string name { get; private set; }
        public string author { get; private set; }
        public genre genr { get; private set; }
        public int pub_year { get; private set; }
        public decimal price { get; private set; }


        public Book(string name, string author, genre genr, int pub_year, decimal price)
        {
            count_of_books++;
            id = 100 + count_of_books;
            this.name = name;
            this.author = author;
            this.genr = genr;
            this.pub_year = pub_year;
            this.price = price;
        }




    }
}
