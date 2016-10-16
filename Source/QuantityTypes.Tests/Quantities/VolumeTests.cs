// --------------------------------------------------------------------------------------------------------------------
// <copyright file="VolumeTests.cs" company="QuantityTypes">
//   Copyright (c) 2014 QuantityTypes contributors
// </copyright>
// <summary>
//   Provides unit test for the Volume class.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using System.Globalization;

namespace QuantityTypes.Tests
{
    using NUnit.Framework;

    /// <summary>
    /// Provides unit test for the <see cref="Volume" /> class.
    /// </summary>
    public class VolumeTests
    {
        [Test]
        public void ImperialUnits()
        {
            var imperialUnitProvider = new UnitProvider(CultureInfo.InvariantCulture);
            imperialUnitProvider.RegisterUnits(typeof(Imperial));

            Assert.AreEqual(Imperial.Gallon, Volume.Parse("1 gal", imperialUnitProvider));
            Assert.AreEqual(Imperial.FluidOunce, Volume.Parse("1 floz", imperialUnitProvider));

            Assert.AreNotEqual(Imperial.Gallon, Volume.Gallon);
        }
    }
}