using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace TaxiPark.CarClasses
{
    [Serializable]

    public class Business : Car
    {
        public Business(string color, string type, int price, int consumption, int rate, int number, string carclass="Business") : base(color, type, price, consumption, rate, number)
        {
            this.carClass = carclass;
        }

        public Business() :base()
        { }

        [XmlElement("carClass")]
        public string carClass { get; set; }
    }
}
