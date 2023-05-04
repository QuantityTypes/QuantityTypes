// --------------------------------------------------------------------------------------------------------------------
// <copyright file="AngleTests.cs" company="QuantityTypes">
//   Copyright (c) 2014 QuantityTypes contributors
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace QuantityTypes.Tests
{
    using System;
    using System.Diagnostics.CodeAnalysis;

    using NUnit.Framework;

    [TestFixture]
    [SuppressMessage("StyleCop.CSharp.DocumentationRules", "SA1600:ElementsMustBeDocumented",
    Justification = "Reviewed. Suppression is OK here.")]
    // ReSharper disable InconsistentNaming
    public class AngularFrequencyTests
    {
        [Test]
        public void ParseStringWithSymbol()
        {
            Assert.AreEqual(5 * Math.PI / 180, AngularFrequency.Parse("5°/s").Value, 1e-6);
            Assert.AreEqual(5 * Math.PI / 180, AngularFrequency.Parse("5 deg/s").Value, 1e-6);
            Assert.AreEqual(5 * Math.PI / 180, AngularFrequency.Parse("5deg / s").Value, 1e-6);
        }

        [Test]
        public void ToStringWithSymbol()
        {
            Assert.AreEqual("5°/s", (5 * AngularFrequency.DegreesPerSecond).ToString("[°/s]"));
            Assert.AreEqual("5 deg/s", (5 * AngularFrequency.DegreesPerSecond).ToString("[deg/s]"));
        }

    }
}