// --------------------------------------------------------------------------------------------------------------------
// <copyright file="VelocityTests.cs" company="QuantityTypes">
//   Copyright (c) 2014 QuantityTypes contributors
// </copyright>
// <summary>
//   Provides unit test for the Velocity class.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace QuantityTypes.Tests
{
    using NUnit.Framework;

    /// <summary>
    /// Provides unit test for the <see cref="Velocity" /> class.
    /// </summary>
    public class VelocityTests
    {
        /// <summary>
        /// Tests the product of <see cref="Velocity" /> and <see cref="Velocity" />.
        /// </summary>
        [Test]
        public void KineticEnergy()
        {
            // E = 0.5*m*v^2
            var e = 0.5 * Mass.Kilogram * (Velocity.MetrePerSecond * Velocity.MetrePerSecond);
            Assert.AreEqual(0.5 * Energy.Joule, e);
        }

        /// <summary>
        /// Tests the second power of <see cref="Velocity" />.
        /// </summary>
        [Test]
        public void KineticEnergy2()
        {
            // E = 0.5*m*v^2
            var e = 0.5 * Mass.Kilogram * (Velocity.MetrePerSecond ^ 2);
            Assert.AreEqual(0.5 * Energy.Joule, e);
        }

        /// <summary>
        /// Tests the square root of the product of <see cref="Acceleration" /> and <see cref="Length" />.
        /// </summary>
        [Test]
        public void FinalSpeed()
        {
            // 2as = vf^2 - vi^2
            var vf2 = 2 * (5 * Acceleration.MetrePerSecondSquared) * (10 * Length.Metre);
            var v2 = Mathematics.Sqrt(vf2);
            Assert.AreEqual(10 * Velocity.MetrePerSecond, v2);
        }
    }
}