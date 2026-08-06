// --------------------------------------------------------------------------------------------------------------------
// <copyright file="MomentTests.cs" company="QuantityTypes">
//   Copyright (c) 2014 QuantityTypes contributors
// </copyright>
// <summary>
//   Provides unit test for the Moment class.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace QuantityTypes.Tests
{
    using NUnit.Framework;

    /// <summary>
    /// Provides unit test for the <see cref="Moment" /> class.
    /// </summary>
    public class MomentTests : Tests
    {
        [Test]
        public void MultiplicationOperatorAndImplicitConversion()
        {
            AssertAreEqual(Moment.NewtonMetre, Force.Newton * Length.Metre);
        }

        [Test]
        public void Units()
        {
            AssertAreEqual(Moment.KilonewtonMetre, Force.Kilonewton * Length.Metre);
        }

        [Test]
        public void DivisionOperator()
        {
            AssertAreEqual(Length.Metre, Moment.NewtonMetre / Force.Newton);
        }

        [Test]
        public void InchOunceForce()
        {
            // 1 in·ozf = 0.0254 m · 0.0283495231 kg · 9.80665 m/s² (NIST SP 811 conversion factors)
            Assert.AreEqual(7.06155180799882e-3, Moment.InchOunceForce.ConvertTo(Moment.NewtonMetre), 1e-12);
        }

        [Test]
        public void Parse()
        {
            AssertAreEqual(Moment.NewtonMetre, Moment.Parse("1 N*m"));
            AssertAreEqual(Moment.KilonewtonMetre, Moment.Parse("1 kN*m"));
        }
    }
}