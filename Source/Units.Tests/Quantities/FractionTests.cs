// --------------------------------------------------------------------------------------------------------------------
// <copyright file="FractionTests.cs" company="Units.NET">
//   The MIT License (MIT)
//   
//   Copyright (c) 2012 Oystein Bjorke
//   
//   Permission is hereby granted, free of charge, to any person obtaining a
//   copy of this software and associated documentation files (the
//   "Software"), to deal in the Software without restriction, including
//   without limitation the rights to use, copy, modify, merge, publish,
//   distribute, sublicense, and/or sell copies of the Software, and to
//   permit persons to whom the Software is furnished to do so, subject to
//   the following conditions:
//   
//   The above copyright notice and this permission notice shall be included
//   in all copies or substantial portions of the Software.
//   
//   THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS
//   OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF
//   MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT.
//   IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY
//   CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER IN AN ACTION OF CONTRACT,
//   TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN CONNECTION WITH THE
//   SOFTWARE OR THE USE OR OTHER DEALINGS IN THE SOFTWARE.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------
namespace Units.Tests
{
    using System.Diagnostics.CodeAnalysis;

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
            Assert.AreEqual("100.0 %", Fraction.Frac.ToString("0.0 %"));
            Assert.AreEqual("100 %", Fraction.Frac.ToString("%"));
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