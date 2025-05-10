using PicoYPlacaPredictor.Business.Interfaces;
using PicoYPlacaPredictor.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PicoYPlacaPredictor.Business.Rules;

namespace PicoYPlacaPredictor.Business.Validators
{
    public class CompositeCirculationValidator : ICirculationValidator
    {
        private readonly IEnumerable<ICirculationValidator> _exemptions;
        private readonly IEnumerable<ICirculationValidator> _rules;

        // Constructor por defecto que inicializa todo el sistema
        public CompositeCirculationValidator()
        {
            _exemptions = new List<ICirculationValidator>
            {
                new WeekendValidator(),
                new HolidayValidator()
            };

            _rules = new List<ICirculationValidator>
            {
                new PicoYPlacaRules()
            };
        }

       
        public CompositeCirculationValidator(
            IEnumerable<ICirculationValidator> exemptions,
            IEnumerable<ICirculationValidator> rules)
        {
            _exemptions = exemptions;
            _rules = rules;
        }

        public bool CanCirculate(Vehicle vehicle)
        {
            // 1. If the vehicle is exempted, it can circulate
            if (_exemptions.Any(e => e.CanCirculate(vehicle)))
                return true;

            // 2. If the vehicle is not exempted, check the rules
            return _rules.All(r => r.CanCirculate(vehicle));
        }
    }
}
