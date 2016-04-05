// --------------------------------------------------------------------------------------------------------------------
// <copyright file="DensityTests.cs" company="QuantityTypes">
//   Copyright (c) 2014 QuantityTypes contributors
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace QuantityTypes.Tests
{
    using System.Diagnostics.CodeAnalysis;

    using NUnit.Framework;

    [TestFixture]
    [SuppressMessage("StyleCop.CSharp.DocumentationRules", "SA1600:ElementsMustBeDocumented",
        Justification = "Reviewed. Suppression is OK here.")]
    // ReSharper disable InconsistentNaming
    public class MassConcentrationInWaterTests
    {
        [Test]
        public void Constructor_Double()
        {
            Assert.AreEqual(0.5d, new MassConcentrationInWater(0.5).Value);
        }

        [Test]
        public void Constructor_String()
        {
            Assert.AreEqual(2e-2d, new MassConcentrationInWater("20mg/L").Value, 1e-9);
            Assert.AreEqual(3e-5d, new MassConcentrationInWater("30ug/L").Value, 1e-9);
            Assert.AreEqual(4e-5d, new MassConcentrationInWater("40 µg/L").Value, 1e-9);
        }

        [Test]
        public void OperatorFraction()
        {
           Fraction expected = new Fraction("10ppm");
           Fraction actual = (Fraction)new MassConcentrationInWater("10mg/L");
           Assert.AreEqual(expected, actual);
        }

    }
}