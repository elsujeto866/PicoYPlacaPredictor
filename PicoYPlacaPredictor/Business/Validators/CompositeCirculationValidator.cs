using PicoYPlacaPredictor.Business.Interfaces;
using PicoYPlacaPredictor.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PicoYPlacaPredictor.Business.Validators
{
    public class CompositeCirculationValidator :BaseValidator
    {
        private readonly IEnumerable<ICirculationValidator> _validators;

        public CompositeCirculationValidator(IEnumerable<ICirculationValidator> validators)
        {
            _validators = validators;
        }

        public override bool CanCirculate(Vehicle vehicle)
        {
            return _validators.All(v => v.CanCirculate(vehicle));
        }
    }
}
