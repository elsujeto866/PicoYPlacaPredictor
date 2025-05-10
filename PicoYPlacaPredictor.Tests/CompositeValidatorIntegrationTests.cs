using PicoYPlacaPredictor.Business.Validators;
using PicoYPlacaPredictor.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PicoYPlacaPredictor.Tests
{
    public class CompositeValidatorIntegrationTests
    {
        private CompositeCirculationValidator _validator;

        [SetUp]
        public void Setup()
        {
            _validator = new CompositeCirculationValidator(); 
        }

        [Test]
        public void Should_Allow_Circulation_On_Saturday()
        {
            var vehicle = new Vehicle("ABC-1231", new DateTime(2025, 5, 10), new TimeSpan(8, 0, 0)); 
            Assert.IsTrue(_validator.CanCirculate(vehicle));
        }

        [Test]
        public void Should_Allow_Circulation_On_Holiday()
        {
            var vehicle = new Vehicle("ABC-1231", new DateTime(2025, 12, 25), new TimeSpan(8, 0, 0)); 
            Assert.IsTrue(_validator.CanCirculate(vehicle));
        }

        [Test]
        public void Should_Not_Allow_Circulation_When_All_Rules_Applied()
        {
            var vehicle = new Vehicle("ABC-1231", new DateTime(2025, 5, 5), new TimeSpan(8, 0, 0)); 
            Assert.IsFalse(_validator.CanCirculate(vehicle));
        }

        [Test]
        public void Should_Allow_Circulation_When_Restricted_Digit_But_Free_Time()
        {
            var vehicle = new Vehicle("ABC-1231", new DateTime(2025, 5, 5), new TimeSpan(10, 0, 0)); 
            Assert.IsTrue(_validator.CanCirculate(vehicle));
        }

        [Test]
        public void Should_Allow_Circulation_When_Free_Digit_But_Restricted_Time()
        {
            var vehicle = new Vehicle("ABC-1235", new DateTime(2025, 5, 6), new TimeSpan(8, 0, 0)); 
            Assert.IsTrue(_validator.CanCirculate(vehicle));
        }
    }
}
