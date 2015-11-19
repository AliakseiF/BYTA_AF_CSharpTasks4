using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaxiPark.CarHierarchy.CarClasses.Business.Models
{
    public class Mercedes : global::TaxiPark.CarClasses.Business
    {
        public Mercedes(string model, string color, string type, int price, int consumption, int rate, int number, string carclass = "Business", string manufacturer = "Mercedes") : base(color, type, price, consumption, rate, number, carclass)
        {
            this.carModel = model;
            this.carManufacturer = manufacturer;
        }

        public string carModel { get; private set; }
        public string carManufacturer { get; private set; }
    }
}
