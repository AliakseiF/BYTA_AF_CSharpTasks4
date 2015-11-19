using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace TaxiPark.CarHierarchy.CarClasses.Business.Models
{
    [Serializable]
    public class BMW : global::TaxiPark.CarClasses.Business
    {
        public BMW(string model, string color, string type, int price, int consumption, int rate, int number, string carclass="Business", string manufacturer="BMW") : base(color, type, price, consumption, rate, number, carclass)
        {
            this.carModel = model;
            this.carManufacturer = manufacturer;
        }

        public BMW() :base()
        { }

        [XmlElement("carModel")]
        public string carModel { get; set; }
        [XmlElement("carManufacturer")]
        public string carManufacturer { get; set; }
    }
}
