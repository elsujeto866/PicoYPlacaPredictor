using PicoYPlacaPredictor.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PicoYPlacaPredictor.Business.Validators
{
    public class HolidayValidator : BaseValidator
    {
        private readonly List<DateTime> holidays = new()
        {
            new DateTime(2025, 1, 1),   // Año Nuevo (miércoles)
            new DateTime(2025, 2, 28),  // Carnaval (viernes)
            new DateTime(2025, 3, 3),   // Carnaval (lunes)
            new DateTime(2025, 4, 18),  // Viernes Santo
            new DateTime(2025, 5, 1),   // Día del Trabajo (jueves)
            new DateTime(2025, 5, 26),  // Batalla de Pichincha (trasladado al lunes)
            new DateTime(2025, 8, 11),  // Primer Grito de Independencia (trasladado al lunes)
            new DateTime(2025, 10, 10), // Independencia de Guayaquil (trasladado al viernes)
            new DateTime(2025, 11, 3),  // Día de Difuntos (trasladado al lunes)
            new DateTime(2025, 11, 4),  // Independencia de Cuenca (martes)
            new DateTime(2025, 12, 25)  // Navidad (jueves)
           
        };
        public override bool CanCirculate(Vehicle vehicle)
        {
            return holidays.Contains(vehicle.Date.Date);
        }
    }
}
