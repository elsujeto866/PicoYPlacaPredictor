using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PicoYPlacaPredictor.Entities;


namespace PicoYPlacaPredictor.Business.Validators
{
    public class TimeRestrictionValidator : BaseValidator
    {
        private static readonly (TimeSpan Start, TimeSpan End) morning = (new TimeSpan(7, 0, 0), new TimeSpan(9, 30, 0));
        private static readonly (TimeSpan Start, TimeSpan End) evening = (new TimeSpan(16, 0, 0), new TimeSpan(19, 30, 0));

        public override bool CanCirculate(Vehicle vehicle)
        {
            return !IsWhthinRestrictedHours(vehicle, morning, evening);
        }
    }   
}
