using PicoYPlacaPredictor.Business.Validators;
using PicoYPlacaPredictor.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PicoYPlacaPredictor.Tests.Validators
{
    public class TimeRestrictionValidatorTests
    {
        private TimeRestrictionValidator _validator;

        [SetUp]
        public void Setup()
        {
            _validator = new TimeRestrictionValidator();
        }

        [Test]
        public void Should_Not_Allow_Circulation_At_8AM()
        {
            var vehicle = new Vehicle("ABC-1234", new DateTime(2025, 5, 9), new TimeSpan(8, 0, 0));
            Assert.IsFalse(_validator.CanCirculate(vehicle));
        }

        [Test]
        public void Should_Allow_Circulation_At_10AM()
        {
            var vehicle = new Vehicle("ABC-1234", new DateTime(2025, 5, 9), new TimeSpan(10, 0, 0));
            Assert.IsTrue(_validator.CanCirculate(vehicle));
        }

        [Test]
        public void Should_Not_Allow_Circulation_At_17_00()
        {
            var vehicle = new Vehicle("ABC-1234", new DateTime(2025, 5, 9), new TimeSpan(17, 0, 0));
            Assert.IsFalse(_validator.CanCirculate(vehicle));
        }

        [Test]
        public void Should_Allow_Circulation_At_21_00()
        {
            var vehicle = new Vehicle("ABC-1234", new DateTime(2025, 5, 9), new TimeSpan(21, 0, 0));
            Assert.IsTrue(_validator.CanCirculate(vehicle));
        }

        [Test]
        public void Should_Not_Allow_Circulation_At_6_00()
        {
            var vehicle = new Vehicle("ABC-1234", new DateTime(2025, 5, 9), new TimeSpan(6, 0, 0));
            Assert.IsTrue(_validator.CanCirculate(vehicle));
        }

        [Test]
        public void Should_Allow_Circulation_At_5_59()
        {
            var vehicle = new Vehicle("ABC-1234", new DateTime(2025, 5, 9), new TimeSpan(5, 59, 0));
            Assert.IsTrue(_validator.CanCirculate(vehicle));
        }
    }
}
