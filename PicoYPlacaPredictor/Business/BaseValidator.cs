using PicoYPlacaPredictor.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PicoYPlacaPredictor.Business
{
    public abstract class BaseValidator
    {
        public abstract bool CanCirculate(Vehicle vehicle);

        protected bool IsWhthinRestrictedHours(Vehicle vehicle,(TimeSpan Start, TimeSpan End) morning, (TimeSpan Start, TimeSpan End) evening)
        {
            return (vehicle.Time >= morning.Start && vehicle.Time <= morning.End) 
                || (vehicle.Time >= evening.Start && vehicle.Time <= evening.End);
        }
    }
}
