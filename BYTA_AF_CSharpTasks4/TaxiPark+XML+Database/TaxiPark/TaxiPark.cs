using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaxiPark
{
    public class TaxiPark
    {
        static void Main(string[] args)
        {
            TaxiParkCars taxiPark = new TaxiParkCars();
            //XML implemented only for Car:Business:BMW
            taxiPark.SerializeToXML();
            taxiPark.DeserializeFromXML();

            //json
            taxiPark.SerializeToJson();
            taxiPark.DeserializeFromJson();

            //taxiPark.ParkTotalprice();
            //taxiPark.OrderCarsByfuelConsumption();
            //taxiPark.FindCarByParameters();
            Console.ReadKey();
        }
    }
}
