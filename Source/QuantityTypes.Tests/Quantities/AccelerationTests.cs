namespace QuantityTypes.Tests
{
    using NUnit.Framework;

    public class AccelerationTests : Tests
    {
        [Test]
        public void Parse_MetrePerSecondSquaredSuperscriptAlias()
        {
            AssertAreEqual(Acceleration.MetrePerSecondSquared, Acceleration.Parse("1 m/s²"));
        }
    }
}
