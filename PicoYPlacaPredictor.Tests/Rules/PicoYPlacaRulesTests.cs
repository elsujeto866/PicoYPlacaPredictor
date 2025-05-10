using PicoYPlacaPredictor.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PicoYPlacaPredictor.Business.Rules;

namespace PicoYPlacaPredictor.Tests.Rules
{
    public class PicoYPlacaRulesTests
    {
        private PicoYPlacaRules _validator;

        [SetUp]
        public void Setup()
        {
            _validator = new PicoYPlacaRules();
        }

        [Test]
        public void Should_Not_Allow_Circulation_When_Digit_Is_Restricted_And_Time_Is_Restricted()
        {
            var vehicle = new Vehicle("ABC-1231", new DateTime(2025, 5, 5), new TimeSpan(8, 0, 0)); 
            Assert.IsFalse(_validator.CanCirculate(vehicle));
        }

        [Test]
        public void Should_Allow_Circulation_When_Digit_Is_Restricted_But_Time_Is_Free()
        {
            var vehicle = new Vehicle("ABC-1231", new DateTime(2025, 5, 5), new TimeSpan(10, 30, 0)); 
            Assert.IsTrue(_validator.CanCirculate(vehicle));
        }

        [Test]
        public void Should_Allow_Circulation_When_Time_Is_Restricted_But_Digit_Is_Not()
        {
            var vehicle = new Vehicle("ABC-1233", new DateTime(2025, 5, 5), new TimeSpan(8, 0, 0)); 
            Assert.IsTrue(_validator.CanCirculate(vehicle));
        }

        [Test]
        public void Should_Allow_Circulation_On_Saturday()
        {
            var vehicle = new Vehicle("ABC-1231", new DateTime(2025, 5, 10), new TimeSpan(8, 0, 0)); 
            Assert.IsTrue(_validator.CanCirculate(vehicle));
        }

        [Test]
        public void Should_Not_Allow_Circulation_On_Friday_At_16_30_With_Digit_0()
        {
            var vehicle = new Vehicle("ABC-1230", new DateTime(2025, 5, 9), new TimeSpan(16, 30, 0)); 
            Assert.IsFalse(_validator.CanCirculate(vehicle));
        }
    }
}
