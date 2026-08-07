namespace QuantityTypes.Tests
{
    using NUnit.Framework;

    public class PowerTests : Tests
    {
        [Test]
        public void HorsePowerVariants()
        {
            AssertAreEqual(Power.HorsePower, Power.MetricHorsePower);
            Assert.AreEqual(745.69987158227, Power.MechanicalHorsePower.ConvertTo(Power.Watt), 1e-9);
        }
    }
}
