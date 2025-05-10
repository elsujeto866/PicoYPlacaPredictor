using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PicoYPlacaPredictor.Entities;
using PicoYPlacaPredictor.Business.Interfaces;

namespace PicoYPlacaPredictor.Business.Validators
{
    public class WeekendValidator : ICirculationValidator
    {
        public bool CanCirculate(Vehicle vehicle)
        {
            var day = vehicle.Date.DayOfWeek;
            return day == DayOfWeek.Saturday || day == DayOfWeek.Sunday;
        }
    }


}

