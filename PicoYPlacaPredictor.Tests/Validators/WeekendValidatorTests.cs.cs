using PicoYPlacaPredictor.Business.Validators;
using PicoYPlacaPredictor.Entities;

namespace PicoYPlacaPredictor.Tests.Validators
{
    public class WeekendValidatorTests
    {
        private WeekendValidator _validator;

        [SetUp]
        public void Setup()
        {
            _validator = new WeekendValidator();
        }

        [Test]
        public void Should_Allow_Circulation_On_Saturday()
        {
            var vehicle = new Vehicle("ABC-1234", new DateTime(2025, 5, 10), new TimeSpan(10, 0, 0)); // Saturday
            Assert.IsFalse(_validator.CanCirculate(vehicle));
        }

        [Test]
        public void Should_Allow_Circulation_On_Sunday()
        {
            var vehicle = new Vehicle("ABC-1234", new DateTime(2025, 5, 11), new TimeSpan(10, 0, 0)); // Sunday
            Assert.IsFalse(_validator.CanCirculate(vehicle));
        }

        [Test]
        public void Should_Not_Apply_On_Weekdays()
        {
            var vehicle = new Vehicle("ABC-1234", new DateTime(2025, 5, 9), new TimeSpan(10, 0, 0)); // Friday
            Assert.IsTrue(_validator.CanCirculate(vehicle));
        }
    }
}