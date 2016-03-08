// --------------------------------------------------------------------------------------------------------------------
// <copyright file="TemperatureTests.cs" company="QuantityTypes">
//   Copyright (c) 2014 QuantityTypes contributors
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

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
            Temperature a = 0*Temperature.DegreeCelsius;
            Temperature b = 100*Temperature.DegreeCelsius;
            TemperatureDifference delta = 100*TemperatureDifference.DegreeCelsius;
            Assert.AreEqual(b, a + delta);
            Assert.AreEqual(a, b - delta);
            Assert.AreEqual(delta, b - a);
        }

        [Test]
        public void Comparisons()
        {
            Temperature a = 0 * Temperature.DegreeFahrenheit;
            Temperature b = 0 * Temperature.DegreeCelsius;
            Temperature c = 273.15*Temperature.Kelvin;
            Assert.True(a != b);
            Assert.True(b == c);
            Assert.True(b.Equals(c));
            Assert.True(b.CompareTo(c) == 0);
            Assert.True(a <= b);
            Assert.True(a < b);
            Assert.True(a.CompareTo(b) == -1);
            Assert.True(b >= a);
            Assert.True(b > a);
            Assert.True(b.CompareTo(a) == 1);
        }

        [Test]
        public void ConvertTo()
        {
            Assert.AreEqual(100, (37.7777778 * Temperature.DegreeCelsius).ConvertTo(Temperature.DegreeFahrenheit), 1e-4);
            Assert.AreEqual(0, (32 * Temperature.DegreeFahrenheit).ConvertTo(Temperature.DegreeCelsius));
            Assert.AreEqual(273.15, (0 * Temperature.DegreeCelsius).ConvertTo(Temperature.Kelvin));
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
            Assert.AreEqual(100 * Temperature.DegreeCelsius, Temperature.Parse("100 °C"));
            Assert.AreEqual(100 * Temperature.DegreeCelsius, Temperature.Parse("100 degC"));
            Assert.AreEqual(0 * Temperature.DegreeCelsius, Temperature.Parse("273.15 K", CultureInfo.InvariantCulture));
            Assert.AreEqual(0 * Temperature.DegreeCelsius, Temperature.Parse("32 F"));
            Assert.AreEqual(0 * Temperature.DegreeCelsius, Temperature.Parse("32 °F"));
            Assert.AreEqual(0 * Temperature.DegreeCelsius, Temperature.Parse("32 degF"));
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