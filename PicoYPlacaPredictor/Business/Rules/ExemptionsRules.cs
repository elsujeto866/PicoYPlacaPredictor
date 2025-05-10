using PicoYPlacaPredictor.Business.Interfaces;
using PicoYPlacaPredictor.Business.Validators;
using PicoYPlacaPredictor.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PicoYPlacaPredictor.Business.Rules
{
    public class ExemptionsRules : ICirculationValidator
    {
        private readonly IEnumerable<ICirculationValidator> _exemptions;

        public ExemptionsRules()
        {
            _exemptions = new List<ICirculationValidator>
            {
                new WeekendValidator(),
                new HolidayValidator()
                
            };
        }

        public bool CanCirculate(Vehicle vehicle)
        {
            return _exemptions.Any(e => e.CanCirculate(vehicle));
        }
    }
}
