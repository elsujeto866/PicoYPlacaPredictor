using PicoYPlacaPredictor.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PicoYPlacaPredictor.Business.Interfaces;

namespace PicoYPlacaPredictor.Business
{
    public abstract class BaseValidator : ICirculationValidator
    {
        public abstract bool CanCirculate(Vehicle vehicle);

        
    }
}
