namespace QuantityTypes.Tests
{
    using NUnit.Framework;

    public class TypographicLengthTests
    {
        [Test]
        public void Operators()
        {
            var resolution = 300 * TypographicResolution.DotsPerInch;
            var typographicLength = 5 * TypographicLength.Inch;
            var length = 5 * Length.Inch;
            Assert.That(typographicLength * resolution, Is.EqualTo(1500).Within(1e-6));
            Assert.That(resolution * typographicLength , Is.EqualTo(1500).Within(1e-6));
            Assert.That(length * resolution, Is.EqualTo(1500).Within(1e-6));
            Assert.That(resolution * length, Is.EqualTo(1500).Within(1e-6));
            Assert.That(1500d / (5 * TypographicLength.Inch), QuantityIs.EqualTo(300 * TypographicResolution.DotsPerInch).Within(1e-6 * TypographicResolution.DotsPerInch));
            Assert.That(1500d / (5 * Length.Inch), QuantityIs.EqualTo(300 * TypographicResolution.DotsPerInch).Within(1e-6 * TypographicResolution.DotsPerInch));
            Assert.That(1500d / (300 * TypographicResolution.DotsPerInch), QuantityIs.EqualTo(5 * TypographicLength.Inch).Within(1e-6 * TypographicLength.Inch));
        }

        [Test]
        public void ImplicitFromLength()
        {
            var length = 5 * Length.Inch;
            TypographicLength typographicLength = length;
            Assert.That(typographicLength, QuantityIs.EqualTo(5 * TypographicLength.Inch).Within(1e-6));
        }

        [Test]
        public void ImplicitToLength()
        {
            var typographicLength = 5 * TypographicLength.Inch;
            Length length = typographicLength;
            Assert.That(length, QuantityIs.EqualTo(5 * Length.Inch).Within(1e-6));
        }
    }
}