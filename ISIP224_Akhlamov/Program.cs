using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISIP224_Akhlamov
{
    internal class Program
    {
        static void Main(string[] args)
        {

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
        public double HP { get; private set; }
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


    }

    public class Goblin : Enemy
    {
        public double krit_chance;

        public Goblin()
        {
            this.HP = 40;
            this.Attack = 15;
            this.Deffence = 5;
            this.krit_chance = 0.15;
        }
    }

    public class Skeleton : Enemy
    {
        public Skeleton()
        {
            this.HP = 20;
            this.Attack = 10;
            this.Deffence = 3;
        }
    }

    public class Magician : Enemy
    {
        public double freeze_chance;
        public Magician()
        {
            this.HP = 30;
            this.Attack = 17;
            this.Deffence = 10;
            this.freeze_chance = 0.2;
        }
    }


    public class VVG : Goblin
    {
        public VVG()
        {
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
            this.HP = base.HP * 2.5;
            this.Attack = base.Attack * 1.3;
            this.Deffence = base.Deffence * 1.4;
        }
    }

    public class ArchimagCPP : Magician
    {
        public ArchimagCPP()
        {
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
            this.HP = base.HP * 1.3;
            this.Attack = base.Attack * 1.8;
            this.Deffence = base.Deffence * 0.6;
            this.freeze_chance = 0.3;
        }
    }





}
