using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PicoYPlacaPredictor.Business.Validators;
using PicoYPlacaPredictor.Entities;

namespace PicoYPlacaPredictor.Tests.Validators
{
    public class HolidayValidatorTests
    {
        private HolidayValidator _validator;

        [SetUp]
        public void Setup()
        {
            _validator = new HolidayValidator();
        }

        [Test]
        public void Should_Allow_Circulation_On_Christmas()
        {
            var date = new DateTime(2025, 12, 25); // Navidad
            var vehicle = new Vehicle("ABC-1234", date, new TimeSpan(8, 0, 0));
            Assert.IsTrue(_validator.CanCirculate(vehicle));
        }

        [Test]
        public void Should_Allow_Circulation_On_NewYear()
        {
            var date = new DateTime(2025, 1, 1); // Año Nuevo
            var vehicle = new Vehicle("ABC-1234", date, new TimeSpan(8, 0, 0));
            Assert.IsTrue(_validator.CanCirculate(vehicle));
        }

        [Test]
        public void Should_Not_Allow_Circulation_On_Regular_Day()
        {
            var date = new DateTime(2025, 5, 8); // Normal weekday
            var vehicle = new Vehicle("ABC-1234", date, new TimeSpan(8, 0, 0));
            Assert.IsFalse(_validator.CanCirculate(vehicle));
        }
    }
}
