using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using Newtonsoft.Json;
using TaxiPark.CarClasses;
using TaxiPark.CarHierarchy.CarClasses.Business.Models;


namespace TaxiPark
{
    [Serializable]
    [XmlInclude(typeof(Business)), XmlInclude(typeof(BMW))]
    public class Car
    {
        [XmlElement("carColor")]
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]

        public string carColor { get; set; }
        [XmlElement("carType")]
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]

        public string carType { get; set; }
        [XmlElement("carPrice")]
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]

        public int carPrice { get; set; }
        [XmlElement("carFuelConsumption")]
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]

        public int carFuelConsumption { get; set; }
        [XmlElement("carRate")]
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]

        public int carRate { get; set; }
        [XmlElement("carNumber")]
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]

        public int carNumber { get; set; }

        public Car()
        {
        }

        public Car(string color, string type, int price, int consumption, int rate, int number)
        {
            carColor = color;
            carType = type;
            carPrice = price;
            carFuelConsumption = consumption;
            carRate = rate;
            carNumber = number;
        }
    }
}
