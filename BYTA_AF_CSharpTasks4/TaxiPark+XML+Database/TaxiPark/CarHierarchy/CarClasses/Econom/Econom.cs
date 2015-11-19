using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaxiPark.CarClasses
{
    public class Econom : Car
    {
        public Econom(string color, string type, int price, int consumption, int rate, int number, string carclass = "Econom") : base(color, type, price, consumption, rate, number)
        {
            this.carClass = carclass;
        }

        public string carClass { get; private set; }
    }
}
