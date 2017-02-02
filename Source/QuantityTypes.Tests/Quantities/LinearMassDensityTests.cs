using NUnit.Framework;

namespace QuantityTypes.Tests
{
    [TestFixture]
    public class LinearMassDensityTests : Tests
    {
        [Test]
        public void Units()
        {
            AssertAreEqual(Mass.Kilogram / Length.Metre, LinearMassDensity.KilogramPerMetre);
        }

        [Test]
        public void Operators()
        {
            AssertAreEqual(10 * Mass.Kilogram / (5 * Length.Metre), 2 * LinearMassDensity.KilogramPerMetre);
            AssertAreEqual(10 * Mass.Kilogram, (2 * LinearMassDensity.KilogramPerMetre) * (5 * Length.Metre));
            AssertAreEqual(10 * Mass.Kilogram / (2 * LinearMassDensity.KilogramPerMetre), 5 * Length.Metre);
        }
    }
}