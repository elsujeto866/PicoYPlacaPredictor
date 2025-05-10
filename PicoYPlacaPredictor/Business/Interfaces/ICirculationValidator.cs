using PicoYPlacaPredictor.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PicoYPlacaPredictor.Business.Interfaces
{
    public interface ICirculationValidator
    {
        bool CanCirculate(Vehicle vehicle);
    }
}
