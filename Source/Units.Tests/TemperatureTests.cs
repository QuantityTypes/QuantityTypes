namespace Units.Tests
{
    using System;
    using System.Diagnostics.CodeAnalysis;

    using Units;

    using NUnit.Framework;

    [TestFixture]
    [SuppressMessage("StyleCop.CSharp.DocumentationRules", "SA1600:ElementsMustBeDocumented", Justification = "Reviewed. Suppression is OK here.")]
    // ReSharper disable InconsistentNaming
    public class TemperatureTests
    {
        [Test]
        public void Operators()
        {
            Assert.AreEqual(100 * Temperature.Celsius, 0 * Temperature.Celsius + 100 * TemperatureDifference.Celsius);
            Assert.AreEqual(20 * TemperatureDifference.Celsius, 30 * Temperature.Celsius - 10 * Temperature.Celsius);
        }

        [Test]
        public void ConvertTo()
        {
            Assert.AreEqual(100, (37.7777778 * Temperature.Celsius).ConvertTo(Temperature.Fahrenheit), 1e-4);
            Assert.AreEqual(0, (32 * Temperature.Fahrenheit).ConvertTo(Temperature.Celsius));
            Assert.AreEqual(273.15, (0 * Temperature.Celsius).ConvertTo(Temperature.Kelvin));
        }

        [Test]
        [ExpectedException(typeof(FormatException))]
        public void Parse_InvalidUnit()
        {
            Temperature.Parse("100 Metre");
        }

        [Test]
        public void Parse_ValidStrings()
        {
            Assert.AreEqual(100 * Temperature.Celsius, Temperature.Parse("100 C"));
            Assert.AreEqual(100 * Temperature.Celsius, Temperature.Parse("100 degC"));
            Assert.AreEqual(0 * Temperature.Celsius, Temperature.Parse("273.15 K"));
            Assert.AreEqual(0 * Temperature.Celsius, Temperature.Parse("32 F"));
            Assert.AreEqual(100 * Temperature.Celsius, Temperature.Parse("1e2"));
            Assert.AreEqual(100 * Temperature.Celsius, Temperature.Parse("1e2C"));
        }

        [Test]
        public void ToString_ValidFormatStrings()
        {
            var l = 100 * Temperature.Celsius;
            var l0 = 0 * Temperature.Celsius;
            Assert.AreEqual("100 °C", l.ToString());
            Assert.AreEqual("100.00 °C", l.ToString("0.00"));
            Assert.AreEqual("0100 °C", l.ToString("0000"));
            Assert.AreEqual("100.0 C", l.ToString("0.0 C"));
            Assert.AreEqual("100.0 C", l.ToString("0.0C"));
            Assert.AreEqual("32 F", l0.ToString("0.# F"));
            Assert.AreEqual("273 K", l0.ToString("0. K"));
        }

        [Test]
        [ExpectedException(typeof(FormatException))]
        public void ToString_InvalidFormatString()
        {
            var l = 100 * Temperature.Celsius;
            Console.WriteLine(l.ToString("0 m"));
        }
    }
}