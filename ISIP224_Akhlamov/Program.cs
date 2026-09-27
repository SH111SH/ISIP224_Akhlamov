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
            List<Text> texts = new List<Text>();

            string user_input = " ";

            while (user_input != "e")
            {
                Console.WriteLine($"Добавленные тексты");
                for (int i = 0; i < texts.Count(); i++)
                {
                    Console.WriteLine($"{i + 1} - {texts[i].text}");
                }
                Console.WriteLine("Введите номер текста чтобы увидеть его статистику e - выход, n - ввести новый текст");
                user_input = Console.ReadLine();

                switch (user_input)
                {
                    case "e":
                        break;

                    case "n":
                        string text = "";
                        while (text.Length < 100)
                        {
                            Console.WriteLine("Введите текст(минимум 100 символов): ");
                            text = Console.ReadLine();
                        }
                        Text txt = new Text(text);
                        texts.Add(txt);
                        txt.Stats();

                        break;

                    default:
                        texts[Convert.ToInt32(user_input) - 1].Stats();
                        break;
                }

            }






        }
    }

    public class Text
    {


        public List<string> words { get; private set; }
        public List<string> sentences { get; private set; }


        public string text;
        public int count_of_words { get; private set; }
        public int count_of_sentences { get; private set; }
        public string shortest_word { get; private set; }
        public string longest_word { get; private set; }
        public int count_of_vowels { get; private set; }
        public int count_of_consonants { get; private set; }
        private Dictionary<char, int> letters;

        public Text(string txt)
        {
            text = txt;
            words = txt.Split(new char[] { ' ', ',', '.', '!', '?', '—', ':' }, StringSplitOptions.RemoveEmptyEntries).ToList();
            sentences = txt.Split(new char[] { '.', '!', '?' }).ToList();
            letters = new Dictionary<char, int>();



            count_of_words = words.Count();
            count_of_sentences = sentences.Count();

            count_of_vowels = 0;
            count_of_consonants = 0;

            string vowels = "аеёиоуыэюя";
            string consonants = "бвгджзйклмнпрстфхцчшщ";

            int shortest = words[0].Length;

            foreach (string word in words)
            {
                if (word.Length < shortest)
                {
                    shortest = word.Length;
                    shortest_word = word;
                }

                foreach (char letter in word)
                {
                    if (letters.ContainsKey(letter))
                    {
                        letters[letter] = letters[letter] + 1;
                    }
                    else
                    {
                        letters[letter] = 1;
                    }



                    if (vowels.Contains(letter))
                    {
                        count_of_vowels += 1;
                    }
                    else if (consonants.Contains(letter))
                    {
                        count_of_consonants += 1;
                    }
                }

            }


            int bigiest = 0;
            foreach (string word in words)
            {
                if (word.Length > bigiest)
                {
                    bigiest = word.Length;
                    longest_word = word;
                }
            }




        }


        public void Stats()
        {
            Console.WriteLine("Статистика: ");
            Console.WriteLine($"Количество слов: {count_of_words} \nКоличество предложений: {count_of_sentences} \nСамое короткое слово: {shortest_word} \nСамое длинное слово: {longest_word} \nКол-во гласных букв: {count_of_vowels} \nКол-во согласных букв: {count_of_consonants}");

            Console.WriteLine("Статистика встречаемости букв: ");
            foreach(KeyValuePair<char,int> kvp in letters)
            {
                Console.WriteLine($"{kvp.Key} - {kvp.Value}");
            }

        }




    }

}
