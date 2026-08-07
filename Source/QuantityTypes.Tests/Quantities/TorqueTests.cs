// --------------------------------------------------------------------------------------------------------------------
// <copyright file="TorqueTests.cs" company="QuantityTypes">
//   Copyright (c) 2014 QuantityTypes contributors
// </copyright>
// <summary>
//   Provides unit test for the Torque class.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace QuantityTypes.Tests
{
    using NUnit.Framework;

    /// <summary>
    /// Provides unit test for the <see cref="Torque" /> class.
    /// </summary>
    public class TorqueTests : Tests
    {
        [Test]
        public void Units()
        {
            AssertAreEqual(Torque.NewtonMetre, Force.Newton * Length.Metre);
            AssertAreEqual(Torque.KilonewtonMetre, Force.Kilonewton * Length.Metre);
            AssertAreEqual(Torque.JoulePerRadian, Torque.NewtonMetre);
        }

        [Test]
        public void InchOunceForce()
        {
            // 1 in·ozf = 0.0254 m · 0.0283495231 kg · 9.80665 m/s² (NIST SP 811 conversion factors)
            Assert.AreEqual(7.06155180799882e-3, Torque.InchOunceForce.ConvertTo(Torque.NewtonMetre), 1e-12);
        }

        [Test]
        public void Parse()
        {
            AssertAreEqual(Torque.NewtonMetre, Torque.Parse("1 N*m"));
            AssertAreEqual(Torque.NewtonMetre, Torque.Parse("1 N·m"));
            AssertAreEqual(Torque.JoulePerRadian, Torque.Parse("1 J/rad"));

            // legacy (incorrect) symbol is kept as an alias for backwards compatibility
            AssertAreEqual(Torque.JoulePerRadian, Torque.Parse("1 J/m"));
        }

        [Test]
        public void ToString_JoulePerRadian()
        {
            Assert.AreEqual("1 J/rad", Torque.JoulePerRadian.ToString("0 [J/rad]"));
        }
    }
}
