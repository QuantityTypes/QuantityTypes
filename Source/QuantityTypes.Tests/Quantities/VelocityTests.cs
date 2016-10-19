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
    using System.Globalization;

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

        /// <summary>
        /// Tests multiplying velocity by velocity.
        /// </summary>
        [Test]
        public void VelocityMultipliedByVelocity()
        {
            var mySpeed = 100 * Velocity.KilometrePerHour;
            Assert.That((mySpeed * Velocity.KilometrePerHour).ToString("0.00", CultureInfo.InvariantCulture), Is.EqualTo("7.72 m^2/s^2"));
            Assert.That(mySpeed * Velocity.KilometrePerHour, QuantityIs.EqualTo(100 / 3.6 / 3.6 * VelocitySquared.MetreSquaredPerSecondSquared).Within(1e-8));
            mySpeed = 100 * Velocity.MetrePerSecond;
            Assert.That(mySpeed * Velocity.KilometrePerHour, QuantityIs.EqualTo(100 / 3.6 * VelocitySquared.MetreSquaredPerSecondSquared).Within(1e-8));
            Assert.That((mySpeed * Velocity.KilometrePerHour).ToString("0.00", CultureInfo.InvariantCulture), Is.EqualTo("27.78 m^2/s^2"));
        }


        [Test]
        public void ToString_ConvertButDoNotShowUnit()
        {
            Assert.AreEqual("100.0 kmph", (100 * Velocity.KilometrePerHour).ToString("0.0[!km/h] kmph", CultureInfo.InvariantCulture));
        }
    }
}