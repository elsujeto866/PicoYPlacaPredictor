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
        private readonly ICirculationValidator _exemptions;
        private readonly ICirculationValidator _rules;

        // Constructor por defecto que inicializa todo el sistema
        public CompositeCirculationValidator()
        {
            _exemptions = new ExemptionsRules();

            _rules = new PicoYPlacaRules();
        }

       

        public bool CanCirculate(Vehicle vehicle)
        {
            // 1. If the vehicle is exempted, it can circulate
            if(_exemptions.CanCirculate(vehicle))
            return true;

            // 2. If the vehicle is not exempted, check the rules
            return _rules.CanCirculate(vehicle);
        }
    }
}
