// --------------------------------------------------------------------------------------------------------------------
// <copyright file="UnitProviderTests.cs" company="Units.NET">
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
    using System.Globalization;

    using NUnit.Framework;

    [TestFixture]
    [SuppressMessage("StyleCop.CSharp.DocumentationRules", "SA1600:ElementsMustBeDocumented", Justification = "Reviewed. Suppression is OK here.")]
    // ReSharper disable InconsistentNaming
    public class UnitProviderTests
    {
        [Test]
        public void SetDisplayUnit()
        {
            string unitSymbol;
            var unit = UnitProvider.Default.GetDisplayUnit(typeof(Length), out unitSymbol);

            // Change the display unit
            UnitProvider.Default.RegisterUnit(627.48 * Length.Millimetre, "alen");
            UnitProvider.Default.TrySetDisplayUnit<Length>("alen");
            Assert.AreEqual("1 alen", (0.62748 * Length.Metre).ToString());

            // Revert
            UnitProvider.Default.TrySetDisplayUnit<Length>(unitSymbol);
            Assert.AreEqual("1 m", Length.Metre.ToString());
        }

        [Test]
        public void InvariantCulture()
        {
            var up = new UnitProvider(typeof(Length).Assembly, CultureInfo.InvariantCulture);
            Assert.AreEqual("1.2 m", (1.2 * Length.Metre).ToString(null, up));
        }

        [Test]
        public void LocalCulture()
        {
            var up = new UnitProvider(typeof(Length).Assembly, new CultureInfo("no"));
            Assert.AreEqual("1,2 m", (1.2 * Length.Metre).ToString(null, up));
        }
    }
}