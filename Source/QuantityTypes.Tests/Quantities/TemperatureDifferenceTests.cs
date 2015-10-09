// --------------------------------------------------------------------------------------------------------------------
// <copyright file="TemperatureDifferenceTests.cs" company="QuantityTypes">
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
    public class TemperatureDifferenceTests
    {
        [Test]
        public void ConsistencyWithTemperature()
        {
            Assert.AreEqual(100 * TemperatureDifference.DegreeCelsius, 100 * Temperature.DegreeCelsius - 0 * Temperature.DegreeCelsius);
            Assert.AreEqual(180 * TemperatureDifference.DegreeFahrenheit, 212 * Temperature.DegreeFahrenheit - 32 * Temperature.DegreeFahrenheit);
            Assert.AreEqual(100 * TemperatureDifference.Kelvin, 100 * Temperature.Kelvin - 0 * Temperature.Kelvin);
        }

        [Test]
        public void ConvertTo()
        {
            Assert.AreEqual((100 * TemperatureDifference.DegreeCelsius).ConvertTo(TemperatureDifference.DegreeFahrenheit), 180);
            Assert.AreEqual((100 * TemperatureDifference.DegreeCelsius).ConvertTo(TemperatureDifference.Kelvin), 100);
        }
    }
}