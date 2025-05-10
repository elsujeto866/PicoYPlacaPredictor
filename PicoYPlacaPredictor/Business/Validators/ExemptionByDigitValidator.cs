using PicoYPlacaPredictor.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PicoYPlacaPredictor.Business.Validators
{
    public class ExemptionByDigitValidator : BaseValidator
    {
        private static readonly Dictionary<DayOfWeek, List<int>> restrictionMap = new()
        {
            { DayOfWeek.Monday,    new() { 1, 2 } },
            { DayOfWeek.Tuesday,   new() { 3, 4 } },
            { DayOfWeek.Wednesday, new() { 5, 6 } },
            { DayOfWeek.Thursday,  new() { 7, 8 } },
            { DayOfWeek.Friday,    new() { 9, 0 } }
        };

        public override bool CanCirculate(Vehicle vehicle)
        {
            var day = vehicle.Date.DayOfWeek;
            var lastDigit = GetLastDigit(vehicle.LicensePlate);

            if (!restrictionMap.TryGetValue(day, out var restrictedDigits))
                return true;

            return !restrictedDigits.Contains(lastDigit);
        }

        private int GetLastDigit(string licensePlate)
        {
            var digits = licensePlate.Where(char.IsDigit).ToArray();

            if (digits.Length == 0)
                throw new InvalidOperationException("License plate must contain at least one digit.");

            return int.Parse(digits[^1].ToString());
        }
    }
}
