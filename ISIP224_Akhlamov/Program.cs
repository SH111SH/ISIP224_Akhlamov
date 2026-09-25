using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string text = "";
            while(text.Length < 100)
            {
                Console.WriteLine("Введите текст(минимум 100 символов): ");
                text = Console.ReadLine();
            }

            List<string> words = text.Split(new char[] { ' ', ',', '.', '!', '?', '—', ':' }, StringSplitOptions.RemoveEmptyEntries).ToList();
            List<string> sentenses = text.Split(new char[] { '.','!','?'}).ToList();

            string shortest_word;
            int shortest = words[0].Length;

            foreach (string word in words)
            {
                if (word.Length < shortest)
                {
                    shortest = word.Length;
                    shortest_word = word;
                }
            }

            string bigiest_word;
            int bigiest = 0;
            foreach (string word in words)
            {
                if(word.Length > bigiest)
                {
                    bigiest = word.Length;
                    bigiest_word = word; 
                }
            }

            
        }
    }

}
