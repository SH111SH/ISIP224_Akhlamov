using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp5
{


    internal class Car
    {
        
        public string Model { get; set; }
        public string EngineType { get; set; }
        public string color { get; set; }

        public List<String> Features = new List<String>();

        public static Car CarInstance = new Car();

    }

}
