using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PicoYPlacaPredictor.Business.Interfaces;
using PicoYPlacaPredictor.Business.Validators;
using PicoYPlacaPredictor.Entities;

namespace PicoYPlacaPredictor.Business.Rules
{
    public class PicoYPlacaRules : ICirculationValidator
    {
        private readonly ExemptionByDigitValidator _digitValidator = new();
        private readonly TimeRestrictionValidator _timeValidator = new();

        public bool CanCirculate(Vehicle vehicle)
        {

            bool isRestrictedDigit = !_digitValidator.CanCirculate(vehicle);
            bool isRestrictedTime = !_timeValidator.CanCirculate(vehicle);

            // If the vehicle is restricted by digit and time, it cannot circulate
            return !(isRestrictedDigit && isRestrictedTime);
        }

       
    }
}