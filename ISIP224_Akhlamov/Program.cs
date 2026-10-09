using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISIP224_Akhlamov
{
    internal class Program
    {


        
        static void Fight(Player player, Enemy enemy)
        {
            bool dodged = false;
            bool frozen = false;
            double dd = 0.0;
            string user_choise = " ";
            double damage;
            Random random = new Random();

            Console.WriteLine($"Вы вступили в бой с {enemy.name} \nвыберите дейсвтие: 1 - атака  2 - защита");

            while (player.HP > 0 && enemy.HP > 0)
            {
                if (!frozen)
                {
                    Console.WriteLine($"выберите дейсвтие: 1 - атака  2 - защита\nИгрок : {player.HP}\nВраг : {enemy.HP}");

                    user_choise = Console.ReadLine();
                    if (String.IsNullOrWhiteSpace(user_choise))
                    {
                        continue;
                    }
                    else
                    {
                        if (user_choise == "1")
                        {
                            damage = player.weapon.Attack - player.weapon.Attack * enemy.Deffence;
                            enemy.HP -= damage;
                            Console.WriteLine($"Вы нанесли {enemy.name} {damage} урона\nХП врага: {enemy.HP}");
                        }

                    }
                }

                if (user_choise == "2")
                {
                    if (random.Next(1, 10) <= 4)
                    {
                        dodged = true;
                    }
                    else
                    {
                        dodged = false;
                        dd = 0.7 + random.NextDouble();
                    }
                }

                Console.WriteLine($"Атакует {enemy.name}!");
                if (dodged)
                {
                    Console.WriteLine("Ты увернулся");
                    continue;
                }
                else
                {

                    if (enemy is Goblin)
                    {

                        Goblin en = (Goblin)enemy;
                        if ((random.Next(1, 10) / 10) == en.krit_chance)
                        {
                            damage = enemy.Attack;
                            player.HP -= damage;
                            Console.WriteLine($"Получен урон {damage} осталось {player.HP} ХП");
                        }
                        else
                        {
                            damage = enemy.Attack - player.armor.Deffense + dd;
                            player.HP -= damage;
                            Console.WriteLine($"Получен урон {damage} осталось {player.HP} ХП");
                        }

                    }

                    else if (enemy is Magician)
                    {
                        damage = enemy.Attack - player.armor.Deffense + dd;
                        player.HP -= damage;
                        Console.WriteLine($"Получен урон {damage} осталось {player.HP} ХП");

                        Magician mg = (Magician)enemy;
                        if ((random.Next(1, 10)) / 10 == mg.freeze_chance)
                        {
                            Console.WriteLine("Игрок заморожен");
                            frozen = true;
                        }


                    }

                    else if(enemy is Skeleton)
                    {

                        damage = enemy.Attack;
                        player.HP -= damage;
                        Console.WriteLine($"Получен урон {damage} осталось {player.HP} ХП");
                    }
                }

                if(enemy.HP <= 0)
                {
                    Console.WriteLine($"{enemy.name} Повержен!");
                }
            }

        }




        static void Main(string[] args)
        {
            Player p = new Player(100, new Weapon("Sword", 12), new Armor("FFF", 0.5));
            Goblin g = new Goblin();

            Fight(p, g);

        }
    }

    public class Weapon
    {
        public string Name { get; private set; }
        public double Attack { get; private set; }

        public Weapon(string Name, double Attack)
        {
            this.Name = Name;
            this.Attack = Attack;
        }
    }

    public class Armor
    {
        public string Name { get; private set; }
        public double Deffense { get; private set; }

        public Armor(string Name, double Deffense)
        {
            this.Name = Name;
            this.Deffense = Deffense;
        }
    }

    public class Player
    {
        public double HP { get; set; }
        public Weapon weapon { get; private set; }
        public Armor armor { get; private set; }

        public Player(double HP, Weapon weapon, Armor armor)
        {
            this.HP = HP;
            this.weapon = weapon;
            this.armor = armor;
        }

    }

    public class Enemy
    {
        public double HP;
        public double Attack;
        public double Deffence;
        public string name;


    }

    public class Goblin : Enemy
    {
        public double krit_chance;

        public Goblin()
        {
            name = "Гоблин";
            this.HP = 40;
            this.Attack = 15;
            this.Deffence = 0.2;
            this.krit_chance = 0.15;
        }
    }

    public class Skeleton : Enemy
    {

        public Skeleton()
        {
            name = "Скелет";
            this.HP = 20;
            this.Attack = 10;
            this.Deffence = 0.1;
        }
    }

    public class Magician : Enemy
    {

        public double freeze_chance;
        public Magician()
        {
            name = "Маг";
            this.HP = 30;
            this.Attack = 17;
            this.Deffence = 0.2;
            this.freeze_chance = 0.3;
        }
    }


    public class VVG : Goblin
    {

        public VVG()
        {
            name = "ВВГ";
            this.HP = base.HP * 2;
            this.Attack = base.Attack * 1.5;
            this.Deffence = base.Deffence * 1.2;
            this.krit_chance = base.krit_chance + base.krit_chance * 0.1;

        }

    }

    public class Kovalskiy : Skeleton
    {
        public Kovalskiy()
        {
            name = "Ковальский";
            this.HP = base.HP * 2.5;
            this.Attack = base.Attack * 1.3;
            this.Deffence = base.Deffence * 1.4;
        }
    }

    public class ArchimagCPP : Magician
    {
        public ArchimagCPP()
        {
            name = "Архимаг С++";
            this.HP = base.HP * 1.8;
            this.Attack = base.Attack * 1.6;
            this.Deffence = base.Deffence * 1.1;
            this.freeze_chance = base.freeze_chance + base.freeze_chance * 0.1;
        }
    }

    public class Pestov : Skeleton
    {
        public double freeze_chance;
        public Pestov()
        {
            name = "Пестов С--";
            this.HP = base.HP * 1.3;
            this.Attack = base.Attack * 1.8;
            this.Deffence = base.Deffence * 0.6;
            this.freeze_chance = 0.3;
        }
    }





}
