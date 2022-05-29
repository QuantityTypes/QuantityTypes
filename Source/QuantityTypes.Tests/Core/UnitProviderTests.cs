// --------------------------------------------------------------------------------------------------------------------
// <copyright file="UnitProviderTests.cs" company="QuantityTypes">
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
    [SuppressMessage("StyleCop.CSharp.DocumentationRules", "SA1600:ElementsMustBeDocumented", Justification = "Reviewed. Suppression is OK here.")]
    // ReSharper disable InconsistentNaming
    public class UnitProviderTests
    {
        [Test]
        public void SetDisplayUnit()
        {
            var unitProvider = new UnitProvider(typeof(UnitProvider).GetTypeInfo().Assembly, CultureInfo.InvariantCulture);
            var unitSymbol = unitProvider.GetDisplayUnit(typeof(Length));

            // Change the display unit
            unitProvider.RegisterUnit(627.48 * Length.Millimetre, "alen");
            unitProvider.TrySetDisplayUnit<Length>("alen");
            Assert.AreEqual("1 alen", (0.62748 * Length.Metre).ToString(unitProvider));

            // Revert
            Assert.IsTrue(unitProvider.TrySetDisplayUnit<Length>(unitSymbol));
            Assert.AreEqual("1 m", Length.Metre.ToString(unitProvider));
        }

        [Test]
        public void RegisterUnit_ParseRegisteredUnit()
        {
            var unitProvider = new UnitProvider(CultureInfo.InvariantCulture);
            unitProvider.RegisterUnit(Length.Metre, "m");
            Assert.AreEqual(5 * Length.Metre, Length.Parse("5 m", unitProvider));
        }

        [Test]
        public void RegisterUnit_ParseUnregisteredUnit_ThrowsException()
        {
            var unitProvider = new UnitProvider(CultureInfo.InvariantCulture);
            unitProvider.RegisterUnit(Length.Metre, "m");
            Assert.Throws<FormatException>(() => Length.Parse("5 cm", unitProvider));
        }

        [Test]
        public void RegisterUnitsByType_ParseUnregisteredUnit_ThrowsException()
        {
            var unitProvider = new UnitProvider(CultureInfo.InvariantCulture);
            unitProvider.RegisterUnits(typeof(Length));
            Assert.Throws<FormatException>(() => Mass.Parse("5 kg", unitProvider));
        }

        [Test]
        public void RegisterUnitsByType_AndParseRegisteredUnit()
        {
            var unitProvider = new UnitProvider(CultureInfo.InvariantCulture);
            unitProvider.RegisterUnits(typeof(Length));
            Assert.AreEqual(5 * Length.Kilometre, Length.Parse("5 km", unitProvider));
        }

        [Test]
        public void RegisterUnitsByAssembly_AndParseRegisteredUnit()
        {
            var unitProvider = new UnitProvider(CultureInfo.InvariantCulture);
            unitProvider.RegisterUnits(typeof(Length).GetTypeInfo().Assembly);
            Assert.AreEqual(5 * Length.Kilometre, Length.Parse("5 km", unitProvider));
        }

        [Test]
        public void GetUnit_NotUniqueUnit_GetsFirstRegistered()
        {
            var unitProvider = new UnitProvider(CultureInfo.InvariantCulture);
            unitProvider.RegisterUnit(Length.Metre, "m");
            unitProvider.RegisterUnit(TypographicLength.Metre, "m");
            Assert.AreEqual(Length.Metre, unitProvider.GetUnit("m"));
        }

        [Test]
        public void TryGetUnit_NotUniqueUnit_GetsFirstRegistered()
        {
            var unitProvider = new UnitProvider(CultureInfo.InvariantCulture);
            unitProvider.RegisterUnit(Length.Metre, "m");
            unitProvider.RegisterUnit(TypographicLength.Metre, "m");
            Length unit;
            Assert.IsTrue(unitProvider.TryGetUnit("m", out unit));
            Assert.AreEqual(Length.Metre, unit);
        }

        [Test]
        public void TryGetUnit_GenericOutputAndNotUniqueUnit_GetsFirstRegistered()
        {
            var unitProvider = new UnitProvider(CultureInfo.InvariantCulture);
            unitProvider.RegisterUnit(Length.Metre, "m");
            unitProvider.RegisterUnit(TypographicLength.Metre, "m");
            IQuantity unit;
            Assert.IsTrue(unitProvider.TryGetUnit(typeof(Length), "m", out unit));
            Assert.AreEqual(Length.Metre, unit);
        }

        [Test]
        public void GetUnits_NotUniqueUnit()
        {
            var unitProvider = new UnitProvider(CultureInfo.InvariantCulture);
            unitProvider.RegisterUnit(Length.Metre, "m");
            unitProvider.RegisterUnit(TypographicLength.Metre, "m");
            var units = unitProvider.GetUnits(typeof(Length));
            Assert.AreEqual(1, units.Count);
            Assert.AreEqual(Length.Metre, units["m"]);
        }

        [Test]
        public void TrySetDisplayUnit_RegisteredUnit()
        {
            var unitProvider = new UnitProvider(CultureInfo.InvariantCulture);
            unitProvider.RegisterUnit(Length.Metre, "m");
            Assert.IsTrue(unitProvider.TrySetDisplayUnit<Length>("m"));
        }

        [Test]
        public void TrySetDisplayUnit_NotRegisteredUnit()
        {
            var unitProvider = new UnitProvider(CultureInfo.InvariantCulture);
            unitProvider.RegisterUnit(Length.Metre, "m");
            Assert.IsFalse(unitProvider.TrySetDisplayUnit<Length>("km"));
        }

        [Test]
        public void TryGetDisplayUnit_RegisteredUnit()
        {
            var unitProvider = new UnitProvider(CultureInfo.InvariantCulture);
            unitProvider.RegisterUnit(Length.Metre, "m");
            unitProvider.TrySetDisplayUnit<Length>("m");
            Length unit;
            string symbol;
            Assert.IsTrue(unitProvider.TryGetDisplayUnit(out unit, out symbol));
            Assert.AreEqual(Length.Metre, unit);
            Assert.AreEqual("m", symbol);
        }

        [Test]
        public void TryGetDisplayUnit_UnregisteredUnit()
        {
            var unitProvider = new UnitProvider(CultureInfo.InvariantCulture);
            unitProvider.RegisterUnit(TypographicLength.Metre, "m");
            unitProvider.TrySetDisplayUnit<TypographicLength>("m");
            Length unit;
            string symbol;
            Assert.IsFalse(unitProvider.TryGetDisplayUnit(out unit, out symbol));
        }

        [Test]
        public void GetDisplayUnit_RegisteredUnit()
        {
            var unitProvider = new UnitProvider(CultureInfo.InvariantCulture);
            unitProvider.RegisterUnit(Length.Metre, "m");
            unitProvider.TrySetDisplayUnit<Length>("m");
            Assert.AreEqual("m", unitProvider.GetDisplayUnit(typeof(Length)));
            string symbol;
            Assert.AreEqual(Length.Metre, unitProvider.GetDisplayUnit(typeof(Length), out symbol));
        }

        [Test]
        public void GetDisplayUnit_UnregisteredUnit()
        {
            var unitProvider = new UnitProvider(CultureInfo.InvariantCulture);
            unitProvider.RegisterUnit(TypographicLength.Metre, "m");
            unitProvider.TrySetDisplayUnit<TypographicLength>("m");
            Assert.Throws<InvalidOperationException>(() => unitProvider.GetDisplayUnit(typeof(Length)));
            string symbol;
            Assert.Throws<InvalidOperationException>(() => unitProvider.GetDisplayUnit(typeof(Length), out symbol));
        }

        [Test]
        public void InvariantCulture()
        {
            var up = new UnitProvider(typeof(Length).GetTypeInfo().Assembly, CultureInfo.InvariantCulture);
            Assert.AreEqual("1.2 m", (1.2 * Length.Metre).ToString(up));
        }

        [Test]
        public void LocalCulture()
        {
            var up = new UnitProvider(typeof(Length).GetTypeInfo().Assembly, CultureInfos.Norwegian);
            Assert.AreEqual("1,2 m", (1.2 * Length.Metre).ToString(up));
        }

        [Test]
        public void TryParse_InvalidSyntax()
        {
            Length q;
            var result = UnitProvider.Default.TryParse("100+200 m", CultureInfo.InvariantCulture, out q);
            Assert.IsFalse(result);
        }

        [Test]
        public void CustomFootUnit()
        {
            var unitProvider = new UnitProvider(CultureInfo.InvariantCulture);
            unitProvider.RegisterUnit(Length.Foot, "'");
            Assert.That(Length.Parse("3'", unitProvider).ConvertTo(Length.Foot), Is.EqualTo(3));
        }

        [Test]
        public void NumberGroup()
        {
            var culture = new CultureInfo("en-US");
            culture.NumberFormat.NumberDecimalSeparator = ".";
            culture.NumberFormat.NumberGroupSeparator = ",";
            var unitProvider = new UnitProvider(CultureInfo.InvariantCulture);
            unitProvider.RegisterUnit(Length.Metre, "metre");
            Assert.That(Length.Parse("300,000.00 metre", unitProvider).ConvertTo(Length.Metre), Is.EqualTo(300000));
        }
    }
}