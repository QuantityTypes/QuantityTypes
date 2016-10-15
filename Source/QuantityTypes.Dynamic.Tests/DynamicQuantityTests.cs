// --------------------------------------------------------------------------------------------------------------------
// <copyright file="DynamicQuantityTests.cs" company="QuantityTypes">
//   Copyright (c) 2014 QuantityTypes contributors
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace QuantityTypes.Dynamic.Tests
{
    using System;
    using System.Globalization;

    using NUnit.Framework;

    [TestFixture]
    public class DynamicQuantityTests
    {

        [Test]
        public void MultiplyOperator()
        {
            var km = 1000 * SI.Metre;
            var hour = 3600 * SI.Second;
            var speed = 36 * km / hour;
            Assert.AreEqual(10, speed.Value);
            Assert.AreEqual(1, speed.Dimensions.Length);
            Assert.AreEqual(-1, speed.Dimensions.Time);
        }

        [Test]
        public void Parse_Speed()
        {
            var up = new DynamicUnitProvider(CultureInfo.InvariantCulture, typeof(SI));

            var speed = DynamicQuantity.Parse("3.6 km/h", up);
            Assert.AreEqual(1, speed.Value);
            Assert.AreEqual(1, speed.Dimensions.Length);
            Assert.AreEqual(-1, speed.Dimensions.Time);
        }

        [Test]
        public void ToString_Speed()
        {
            var speed = 10 * SI.Metre / SI.Second;
            Assert.AreEqual("10 L*T^-1", speed.ToString());
        }

        [Test]
        public void ToString_UnitProvider()
        {
            var up = new DynamicUnitProvider(CultureInfo.InvariantCulture, typeof(SI));

            var speed = 10 * SI.Metre / SI.Second;
            Assert.AreEqual("10 m/s", speed.ToString(up));
        }

        [Test]
        public void ToString_SetDisplayUnit()
        {
            var up = new DynamicUnitProvider(CultureInfo.InvariantCulture);
            up.Register(typeof(SI));
            up.SetDisplayUnit("km/h", SI.KilometrePerHour);

            var speed = 10 * SI.Metre / SI.Second;
            Assert.AreEqual("36 km/h", speed.ToString(up));
        }

        [Test]
        public void ConvertTo()
        {
            var speed = 10 * SI.Metre / SI.Second;
            Assert.AreEqual(36, speed.ConvertTo(SI.KilometrePerHour));
        }

        [Test]
        public void Add_LengthAndTime_ThrowsException()
        {
            Assert.Throws<InvalidOperationException>(() => { var x = SI.Metre + SI.Second; });
        }

        [Test]
        public void Test()
        {
            var speed = 100.0 * SI.KilometrePerHour;
            var reactionTime = 1.0 * SI.Second;
            var deceleration = 6.0 * SI.MetrePerSecondSquared;

            var distance = (speed * reactionTime) + ((speed * speed) / (2.0 * deceleration));

            Assert.AreEqual(92.07, distance.Value, 1e-2);
            Assert.AreEqual(new Dimensions(0, 1), distance.Dimensions);
        }
    }
}