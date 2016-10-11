// --------------------------------------------------------------------------------------------------------------------
// <copyright file="DensityTests.cs" company="QuantityTypes">
//   Copyright (c) 2014 QuantityTypes contributors
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace QuantityTypes.Tests
{
    using System;
    using System.Diagnostics.CodeAnalysis;

    using NUnit.Framework;

    [TestFixture]
    [SuppressMessage("StyleCop.CSharp.DocumentationRules", "SA1600:ElementsMustBeDocumented",
        Justification = "Reviewed. Suppression is OK here.")]
    // ReSharper disable InconsistentNaming
    public class DensityTests
    {
        [Test]
        public void Constructors()
        {
            Assert.AreEqual(2, new Density(2).Value);
            Assert.AreEqual(2, new Density("2kg/m^3").Value);
        }

        [Test]
        public void Operator()
        {
            Assert.AreEqual(Density.KilogramPerCubicMetre, Mass.Kilogram / Volume.CubicMetre);
            Assert.AreEqual(Density.KilogramPerCubicMetre, Mass.Kilogram / (Length.Metre * Length.Metre * Length.Metre));
        }

        [Test]
        public void Parse_InvalidString()
        {
            Assert.Throws<FormatException>(() => Density.Parse("2kg"));
        }

        [Test]
        public void Parse_InvalidUnitPrefixCaseString()
        {
            Assert.Throws<FormatException>(() => Density.Parse("2Kg/m^3"), "wrong case in unit prefix");
        }

        [Test]
        public void Parse_InvalidUnitCaseString()
        {
            Assert.Throws<FormatException>(() => Density.Parse("2kg/M^3"), "wrong case");
        }

        [Test]
        public void Parse_ValidStrings()
        {
            Assert.AreEqual(2, Density.Parse("2kg/m^3").Value, "correct unit");
            Assert.AreEqual(2, Density.Parse("2").Value, "no unit");
        }

        [Test]
        public void Parse_Emptytrings()
        {
            Assert.AreEqual(0, Density.Parse(string.Empty).Value, "empty");
            Assert.AreEqual(0, Density.Parse(null).Value, "null");
        }
    }
}