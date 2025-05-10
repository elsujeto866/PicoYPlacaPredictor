using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PicoYPlacaPredictor.Entities
{ 
    public record TimeRestrictionPeriod(
        (TimeSpan Start, TimeSpan End) Morning,
        (TimeSpan Start, TimeSpan End) Evening);
   
}
