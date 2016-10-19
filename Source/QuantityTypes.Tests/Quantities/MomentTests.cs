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
        public void Parse()
        {
            AssertAreEqual(Moment.NewtonMetre, Moment.Parse("1 N*m"));
            AssertAreEqual(Moment.KilonewtonMetre, Moment.Parse("1 kN*m"));
        }
    }
}