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
    public class MomentTests
    {
        [Test]
        public void MultiplicationOperatorAndImplicitConversion()
        {
            Moment m = Force.Newton * Length.Metre;
            Assert.AreEqual(Moment.NewtonMetre, m);
        }

        [Test]
        public void DivisionOperator()
        {
            Assert.AreEqual(Length.Metre, Moment.NewtonMetre / Force.Newton);
        }

        [Test]
        public void Parse()
        {
            Assert.AreEqual(Moment.NewtonMetre, Moment.Parse("1 N*m"));
        }
    }
}