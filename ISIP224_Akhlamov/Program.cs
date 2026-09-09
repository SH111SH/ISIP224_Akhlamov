using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISIP224_Akhlamov
{
    internal class Program
    {
        static void Main(string[] args)
        {

            Dictionary<string,int> wastes = new Dictionary<string,int>();
            List<int> Total_money = new List<int>();
            int count_of_operatons = 0;
            while (count_of_operatons < 2 || count_of_operatons > 40)
            {
                count_of_operatons = Convert.ToInt32(Console.ReadLine());
            }
            for (int i = 0; i < count_of_operatons; i++)
            {
                
                Console.WriteLine("Напишите товар и потраченные деньги Пример: Влажные салфетки Лента; 235");
                string user_input = Console.ReadLine();
                wastes.Add(user_input.Split(';')[0], Convert.ToInt32(user_input.Split(';')[1]));
                Total_money.Add(Convert.ToInt32(user_input.Split(';')[1]));
                
            }


        }
    }
}
