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
            var pixels = typographicLength * resolution;
            Assert.That(pixels, Is.EqualTo(1500).Within(1e-6));
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