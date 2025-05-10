using PicoYPlacaPredictor.Business.Validators;
using PicoYPlacaPredictor.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PicoYPlacaPredictor.Tests.Validators
{
    public class ExemptionByDigitValidatorTests
    {
        private ExemptionByDigitValidator _validator;

        [SetUp]
        public void Setup()
        {
            _validator = new ExemptionByDigitValidator();
        }

        [Test]
        public void Should_Not_Allow_Circulation_When_Digit_Is_Restricted_On_Monday()
        {
            var vehicle = new Vehicle("ABC-1231", new DateTime(2025, 5, 5), new TimeSpan(8, 0, 0)); 
            Assert.IsFalse(_validator.CanCirculate(vehicle));
        }

        [Test]
        public void Should_Allow_Circulation_When_Digit_Is_Not_Restricted_On_Monday()
        {
            var vehicle = new Vehicle("ABC-1233", new DateTime(2025, 5, 5), new TimeSpan(8, 0, 0)); 
            Assert.IsTrue(_validator.CanCirculate(vehicle));
        }

        [Test]
        public void Should_Not_Allow_Circulation_When_Digit_Is_Restricted_On_Friday()
        {
            var vehicle = new Vehicle("ABC-1230", new DateTime(2025, 5, 9), new TimeSpan(8, 0, 0)); 
            Assert.IsFalse(_validator.CanCirculate(vehicle));
        }

        [Test]
        public void Should_Allow_Circulation_On_Saturday()
        {
            var vehicle = new Vehicle("ABC-1231", new DateTime(2025, 5, 10), new TimeSpan(8, 0, 0)); 
            Assert.IsTrue(_validator.CanCirculate(vehicle));
        }

        [Test]
        public void Should_Allow_Circulation_When_Digit_Is_Not_Restricted_On_Wednesday()
        {
            var vehicle = new Vehicle("ABC-1237", new DateTime(2025, 5, 7), new TimeSpan(8, 0, 0)); 
            Assert.IsTrue(_validator.CanCirculate(vehicle));
        }
    }
}
