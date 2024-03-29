﻿// --------------------------------------------------------------------------------------------------------------------
// <copyright file="AngleTests.cs" company="QuantityTypes">
//   Copyright (c) 2014 QuantityTypes contributors
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace QuantityTypes.Tests
{
    using System;
    using System.Diagnostics.CodeAnalysis;
    using System.Globalization;
    using System.Reflection;

    using NUnit.Framework;

    [TestFixture]
    [SuppressMessage("StyleCop.CSharp.DocumentationRules", "SA1600:ElementsMustBeDocumented",
        Justification = "Reviewed. Suppression is OK here.")]
    // ReSharper disable InconsistentNaming
    public class AngleTests
    {
        [Test]
        public void UnaryPlusOperator()
        {
            Assert.AreEqual(90 * Angle.Degree, +(90 * Angle.Degree));
        }

        [Test]
        public void UnaryMinusOperator()
        {
            Assert.AreEqual(-90 * Angle.Degree, -(90 * Angle.Degree));
        }

        [Test]
        public void AdditionAssignmentOperator()
        {
            var a = 0 * Angle.Degree;
            a += 90 * Angle.Degree;
            Assert.AreEqual(90 * Angle.Degree, a);
        }

        [Test]
        public void ToString_CheckSpaces()
        {
            var a = 90 * Angle.Degree;
            Assert.AreEqual("90.0°", a.ToString("0.0 [°]", CultureInfo.InvariantCulture));
            Assert.AreEqual("90°", a.ToString("0[°]", CultureInfo.InvariantCulture));
        }

        [Test]
        public void ToString_NorwegianCulture_CheckSpaces()
        {
            var a = 90 * Angle.Degree;
            Assert.AreEqual("90,0°", a.ToString("0.0 [°]", CultureInfos.Norwegian));
        }

        [Test]
        public void ToString_30deg_CheckFormat()
        {
            var a = 30 * Angle.Degree;
            Assert.AreEqual("30 deg", a.ToString("0[deg]"));
        }

        [Test]
        public void ToDegrees_30deg_Returns30()
        {
            var a = 30 * Angle.Degree;
            Assert.AreEqual(30, a.ToDegrees(), 1e-10);
        }

        [Test]
        public void ParseStringWithSymbol()
        {
            Assert.AreEqual(50, Angle.Parse("50°").ToDegrees(), 1e-6);
            Assert.AreEqual(50, Angle.Parse("50 deg").ToDegrees(), 1e-6);
        }

        [Test]
        public void ToStringWithSymbol()
        {
            Assert.AreEqual("50°", (50 * Angle.Degree).ToString("[°]"));
            Assert.AreEqual("50 deg", (50 * Angle.Degree).ToString("[deg]"));
        }

        [Test]
        public void ParseStringWithInvalidSymbol()
        {
            Assert.Throws<FormatException>(() => Angle.Parse("50 degrees"));
        }

        [Test]
        public void ParseStringToAngleType()
        {
            const string Value = "50";
            var parseMethod = typeof(Angle).GetTypeInfo().GetMethod("Parse", new[] { Value.GetType(), typeof(IFormatProvider) });
            Assert.IsNotNull(parseMethod);
            var convertedValue = parseMethod.Invoke(null, new object[] { Value, CultureInfo.CurrentCulture });
            Assert.AreEqual(50, (convertedValue is Angle ? (Angle)convertedValue : new Angle()).ConvertTo(Angle.Radian));
        }
    }
}