using PicoYPlacaPredictor.Business.Rules;
using PicoYPlacaPredictor.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PicoYPlacaPredictor.Tests.Rules
{
    public class ExemptionsRulesTests
    {
        private ExemptionsRules _validator;

        [SetUp]
        public void Setup()
        {
            _validator = new ExemptionsRules();
        }

        [Test]
        public void Should_Allow_Circulation_On_Saturday()
        {
            var vehicle = new Vehicle("ABC-1234", new DateTime(2025, 5, 10), new TimeSpan(9, 0, 0)); // Sábado
            Assert.IsTrue(_validator.CanCirculate(vehicle));
        }

        [Test]
        public void Should_Allow_Circulation_On_Christmas()
        {
            var vehicle = new Vehicle("ABC-1234", new DateTime(2025, 12, 25), new TimeSpan(9, 0, 0)); // Navidad
            Assert.IsTrue(_validator.CanCirculate(vehicle));
        }

        [Test]
        public void Should_Not_Allow_Circulation_On_Weekday_Without_Exception()
        {
            var vehicle = new Vehicle("ABC-1234", new DateTime(2025, 5, 6), new TimeSpan(9, 0, 0)); // Martes común
            Assert.IsFalse(_validator.CanCirculate(vehicle));
        }
    }
}
