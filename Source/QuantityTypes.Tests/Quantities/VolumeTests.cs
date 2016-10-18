// --------------------------------------------------------------------------------------------------------------------
// <copyright file="VolumeTests.cs" company="QuantityTypes">
//   Copyright (c) 2014 QuantityTypes contributors
// </copyright>
// <summary>
//   Provides unit test for the Volume class.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace QuantityTypes.Tests
{
    using System.Globalization;

    using NUnit.Framework;

    /// <summary>
    /// Provides unit test for the <see cref="Volume" /> class.
    /// </summary>
    [TestFixture]
    public class VolumeTests : Tests
    {
        [Test]
        public void Units()
        {
            AssertAreEqual(Length.Decimetre * Length.Decimetre * Length.Decimetre, Volume.CubicDecimetre);
            AssertAreEqual(Length.Centimetre * Length.Centimetre * Length.Centimetre, Volume.CubicCentimetre);
            AssertAreEqual(Length.Millimetre * Length.Millimetre * Length.Millimetre, Volume.CubicMillimetre);
        }

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