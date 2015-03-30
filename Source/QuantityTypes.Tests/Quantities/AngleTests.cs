// --------------------------------------------------------------------------------------------------------------------
// <copyright file="AngleTests.cs" company="QuantityTypes">
//   Copyright (c) 2014 QuantityTypes contributors
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

using System;
using System.Globalization;

namespace QuantityTypes.Tests
{
    using System.Diagnostics.CodeAnalysis;
    using System.Globalization;

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
        public void ParseStringToAngleType()
        {
            const string Value = "50";
            var parseMethod = typeof(Angle).GetMethod("Parse", new[] { Value.GetType(), typeof(IFormatProvider) });
            Assert.IsNotNull(parseMethod);
            var convertedValue = parseMethod.Invoke(null, new object[] { Value, CultureInfo.CurrentCulture });
            Assert.AreEqual(50, (convertedValue is Angle ? (Angle)convertedValue : new Angle()).ConvertTo(Angle.Radian));
        }
    }
}