namespace QuantityTypes.Tests
{
    using NUnit.Framework;

    public class PressureTests : Tests
    {
        [Test]
        public void GigapascalUnit()
        {
            AssertAreEqual(1000 * Pressure.Megapascal, Pressure.Gigapascal);
        }
    }
}
