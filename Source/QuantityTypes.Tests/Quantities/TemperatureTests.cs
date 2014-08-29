namespace QuantityTypes.Tests
{
    using System;
    using System.Diagnostics.CodeAnalysis;
    using System.Globalization;

    using NUnit.Framework;
    using QuantityTypes;


    [TestFixture]
    [SuppressMessage("StyleCop.CSharp.DocumentationRules", "SA1600:ElementsMustBeDocumented", Justification = "Reviewed. Suppression is OK here.")]
    // ReSharper disable InconsistentNaming
    public class TemperatureTests
    {
        [Test]
        public void Operators()
        {
            Assert.AreEqual(100 * Temperature.DegreeCelsius, 0 * Temperature.DegreeCelsius + 100 * TemperatureDifference.DegreeCelsius);
            Assert.AreEqual(20 * TemperatureDifference.DegreeCelsius, 30 * Temperature.DegreeCelsius - 10 * Temperature.DegreeCelsius);
        }

        [Test]
        public void ConvertTo()
        {
            Assert.AreEqual(100, (37.7777778 * Temperature.DegreeCelsius).ConvertTo(Temperature.DegreeFahrenheit), 1e-4);
            Assert.AreEqual(0, (32 * Temperature.DegreeFahrenheit).ConvertTo(Temperature.DegreeCelsius));
            Assert.AreEqual(273.15, (0 * Temperature.DegreeCelsius).ConvertTo(Temperature.DegreeKelvin));
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
            Assert.AreEqual(100 * Temperature.DegreeCelsius, Temperature.Parse("100 C"));
            Assert.AreEqual(100 * Temperature.DegreeCelsius, Temperature.Parse("100 degC"));
            Assert.AreEqual(0 * Temperature.DegreeCelsius, Temperature.Parse("273.15 K", CultureInfo.InvariantCulture));
            Assert.AreEqual(0 * Temperature.DegreeCelsius, Temperature.Parse("32 F"));
            Assert.AreEqual(100 * Temperature.DegreeCelsius, Temperature.Parse("1e2"));
            Assert.AreEqual(100 * Temperature.DegreeCelsius, Temperature.Parse("1e2C"));
        }

        [Test]
        public void ToString_ValidFormatStrings()
        {
            var l = 100 * Temperature.DegreeCelsius;
            var l0 = 0 * Temperature.DegreeCelsius;
            Assert.AreEqual("100 °C", l.ToString());
            Assert.AreEqual("100", l.ToString("[]"));
            Assert.AreEqual("100.00 °C", l.ToString("0.00", CultureInfo.InvariantCulture));
            Assert.AreEqual("0100 °C", l.ToString("0000"));
            Assert.AreEqual("100.0 C", l.ToString("0.0 [C]", CultureInfo.InvariantCulture));
            Assert.AreEqual("100.0 C", l.ToString("0.0[C]", CultureInfo.InvariantCulture));
            Assert.AreEqual("32 F", l0.ToString("0.# [F]"));
            Assert.AreEqual("273 K", l0.ToString("0. [K]"));
        }

        [Test]
        [ExpectedException(typeof(FormatException))]
        public void ToString_InvalidFormatString()
        {
            var l = 100 * Temperature.DegreeCelsius;
            Console.WriteLine(l.ToString("0 [m]"));
        }
    }
}