using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Schema;

namespace WpfApp5
{
    internal class Check
    {
        public static Dictionary<string, Decimal> CarPriceList = new Dictionary<string, Decimal> { { "Lada Vesta", 4500000 }, { "Haval Jolion", 12000000 }, { "Tenet T7", 30000000 }, { "Lada Granta", 25000000 }, };
        public static Dictionary<string, Decimal> EngineTypePriceList = new Dictionary<string, Decimal> { { "Electric", 120000},{ "Hyprid", 240000 },{ "Gas", 23093 },{ "Dizel" , 12000}, { "Gasoline", 12000 } };
        public static Dictionary<string, Decimal> ColorPriceList = new Dictionary<string, Decimal> { { "Magenta", 12000 }, { "Yellow", 10000 }, { "Red", 20000 }, { "Black", 12000 }, { "White", 90000 } };
        public static Dictionary<string, Decimal> FeaturesPriceList = new Dictionary<string, Decimal> { { "Nitro", 30000 }, { "Display", 12000 }, { "Tonirovka", 2300 }, { "Climat control", 20000 }, { "Cruise control", 20001 } };
        public static Decimal Total = 0; 
    }
}
