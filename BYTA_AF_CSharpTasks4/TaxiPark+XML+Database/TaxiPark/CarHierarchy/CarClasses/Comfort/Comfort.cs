using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaxiPark.CarClasses
{
    public class Comfort : Car
    {
        public Comfort(string color, string type, int price, int consumption, int rate, int number, string carclass = "Comfort") : base(color, type, price, consumption, rate, number)
        {
            this.carClass = carclass;
        }

        public string carClass { get; private set; }
    }
}
