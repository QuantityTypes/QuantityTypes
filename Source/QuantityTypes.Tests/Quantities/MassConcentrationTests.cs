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
    public class MassConcentrationTests
    {
        [Test]
        public void Constructor_Double()
        {
            Assert.AreEqual(2d, new MassConcentration(2).Value);
        }

        [Test]
        public void Constructor_String()
        {
            Assert.AreEqual(2d, new MassConcentration("2kg/m^3").Value);
            Assert.AreEqual(3e-6d, new MassConcentration("3 ug/L").Value, 1e-9);
            Assert.AreEqual(4e-6d, new MassConcentration("4µg/L").Value, 1e-9);
        }

        [Test]
        public void Operator()
        {
            Assert.AreEqual(MassConcentration.KilogramPerCubicMetre, (MassConcentration)(Mass.Gram / Volume.Litre));
        }

        [Test]
        public void ConvertTo()
        {
            var wv = 1 * MassConcentration.MicrogramPerLitre;
            Assert.AreEqual(0.001d, wv.ConvertTo(MassConcentration.MilligramPerLitre));
        }

    }
}