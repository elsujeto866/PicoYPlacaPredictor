using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PicoYPlacaPredictor.Entities
{
    public class Vehicle
    {
        public string LicensePlate { get; }
        public DateTime Date { get; }
        public TimeSpan Time{ get; }

        public Vehicle(string licensePlate, DateTime date, TimeSpan time)
        {          
            LicensePlate = licensePlate;
            Date = date;
            Time = time;
        }
    }
}
