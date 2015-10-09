// --------------------------------------------------------------------------------------------------------------------
// <copyright file="EnergyTests.cs" company="QuantityTypes">
//   Copyright (c) 2015 QuantityTypes contributors
// </copyright>
// <summary>
//   Provides unit test for the Energy class.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace QuantityTypes.Tests
{
    using NUnit.Framework;

    /// <summary>
    /// Provides unit test for the <see cref="Energy" /> class.
    /// </summary>
    public class EnergyTests
    {
        /// <summary>
        /// Tests the division of <see cref="Energy" /> and <see cref="Time" />.
        /// </summary>
        [Test]
        public void EnergyTimeDivision()
        {
            Power p = (0.1 * Energy.KilowattHour) / (10.0*Time.Second);
            Assert.AreEqual(36000.0 * Power.Watt, p);
        }
     

    }
}