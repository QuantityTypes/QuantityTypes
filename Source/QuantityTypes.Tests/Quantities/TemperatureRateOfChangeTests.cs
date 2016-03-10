// --------------------------------------------------------------------------------------------------------------------
// <copyright file="TemperatureRateOfChangeTests.cs" company="QuantityTypes">
//   Copyright (c) 2014 QuantityTypes contributors
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace QuantityTypes.Tests
{
    using System.Diagnostics.CodeAnalysis;

    using NUnit.Framework;

    [TestFixture]
    [SuppressMessage("StyleCop.CSharp.DocumentationRules", "SA1600:ElementsMustBeDocumented", Justification = "Reviewed. Suppression is OK here.")]
    // ReSharper disable InconsistentNaming
    public class TemperatureRateOfChangeTests
    {
        [Test]
        public void Operators()
        {
            TemperatureDifference deltaT = 100*TemperatureDifference.DegreeCelsius;
            Time dt = Time.Hour;
            TemperatureRateOfChange roc = 100*TemperatureRateOfChange.DegreeCelsiusPerHour;

            Assert.AreEqual(deltaT/dt, roc);
            Assert.AreEqual(roc * dt, deltaT);
        }

        [Test]
        public void ConvertTo()
        {
            Assert.AreEqual(60 * TemperatureRateOfChange.KelvinPerMinute, TemperatureRateOfChange.KelvinPerSecond);
            Assert.AreEqual(60 * TemperatureRateOfChange.KelvinPerHour, TemperatureRateOfChange.KelvinPerMinute);

            Assert.AreEqual(60 * TemperatureRateOfChange.DegreeCelsiusPerMinute, TemperatureRateOfChange.DegreeCelsiusPerSecond);
            Assert.AreEqual(60 * TemperatureRateOfChange.DegreeCelsiusPerHour, TemperatureRateOfChange.DegreeCelsiusPerMinute);

            Assert.AreEqual(60 * TemperatureRateOfChange.DegreeFahrenheitPerMinute, TemperatureRateOfChange.DegreeFahrenheitPerSecond);
            Assert.AreEqual(60 * TemperatureRateOfChange.DegreeFahrenheitPerHour, TemperatureRateOfChange.DegreeFahrenheitPerMinute);

            Assert.AreEqual(TemperatureRateOfChange.KelvinPerSecond, TemperatureRateOfChange.DegreeCelsiusPerSecond);
            Assert.AreEqual(TemperatureRateOfChange.KelvinPerSecond, 1.8 * TemperatureRateOfChange.DegreeFahrenheitPerSecond);
        }
    }
}