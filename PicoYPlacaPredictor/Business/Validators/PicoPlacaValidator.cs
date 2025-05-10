using PicoYPlacaPredictor.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace PicoYPlacaPredictor.Business
{
    public class PicoPlacaValidator : BaseValidator

    {
        private static readonly Dictionary<DayOfWeek, List<int>> restrictionMap = new()
        {
            { DayOfWeek.Monday,    new() { 1, 2 } },
            { DayOfWeek.Tuesday,   new() { 3, 4 } },
            { DayOfWeek.Wednesday, new() { 5, 6 } },
            { DayOfWeek.Thursday,  new() { 7, 8 } },
            { DayOfWeek.Friday,    new() { 9, 0 } }
        };

        private static readonly (TimeSpan Start, TimeSpan End) MorningRestriction = (new TimeSpan(7, 0, 0), new TimeSpan(9, 30, 0));
        private static readonly (TimeSpan Start, TimeSpan End) EveningRestriction = (new TimeSpan(16, 0, 0), new TimeSpan(19, 30, 0));

        public override bool CanCirculate(Vehicle vehicle)
        {
            var day = vehicle.Date.DayOfWeek;
            var lastDigit = GetLastDigit(vehicle.LicensePlate);
            var time = vehicle.Time;

            if (IsWeekend(day) || IsExemptFromRestriction(day, lastDigit))
                return true;

            return !IsWhthinRestrictedHours(vehicle, MorningRestriction, EveningRestriction);
        }

        public int GetLastDigit(string licensePlate)
        {
            var digits = licensePlate.Where(char.IsDigit).ToArray();

            if (digits.Length == 0) 
                throw new InvalidOperationException("License plate must contain at least one digit.");

            return int.Parse(digits[^1].ToString());
        }

        private bool IsWeekend(DayOfWeek day) => 
            day == DayOfWeek.Saturday || day == DayOfWeek.Sunday;

        private bool IsExemptFromRestriction(DayOfWeek day, int lastDigit) => 
            !restrictionMap.TryGetValue(day, out var restrictedDigits) || !restrictedDigits.Contains(lastDigit);

    }
}
