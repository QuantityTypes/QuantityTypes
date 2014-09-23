// --------------------------------------------------------------------------------------------------------------------
// <copyright file="FractionTests.cs" company="QuantityTypes">
//   Copyright (c) 2014 QuantityTypes contributors
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace QuantityTypes.Tests
{
    using System.Diagnostics.CodeAnalysis;
    using System.Globalization;

    using NUnit.Framework;

    [TestFixture]
    [SuppressMessage("StyleCop.CSharp.DocumentationRules", "SA1600:ElementsMustBeDocumented", Justification = "Reviewed. Suppression is OK here.")]
    // ReSharper disable InconsistentNaming
    public class FractionTests
    {
        [Test]
        public void ToString_Fraction()
        {
            Assert.AreEqual("1", Fraction.Frac.ToString());
        }

        [Test]
        public void ToString_Percent()
        {
            Assert.AreEqual("100.0 %", Fraction.Frac.ToString("0.0 [%]", CultureInfo.InvariantCulture));
            Assert.AreEqual("100 %", Fraction.Frac.ToString("[%]"));
        }

        [Test]
        public void Parse_Percent()
        {
            Assert.AreEqual(0.5 * Fraction.Frac, Fraction.Parse("50 %"));
            UnitProvider.Default.TrySetDisplayUnit<Fraction>("%");
            Assert.AreEqual(0.5 * Fraction.Frac, Fraction.Parse("50"));
            UnitProvider.Default.TrySetDisplayUnit<Fraction>(string.Empty);
        }

        [Test]
        public void CompareTo()
        {
            IQuantity f1 = 100 * Fraction.Percent;
            object f2 = 0.5 * Fraction.Frac;
            Assert.AreEqual(1, f1.CompareTo(f2));
        }
    }
}