// --------------------------------------------------------------------------------------------------------------------
// <copyright file="AngleTests.cs" company="Units.NET">
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
            Assert.AreEqual("90,0°", a.ToString("0.0 [°]", new CultureInfo("nb-NO")));
        }
    }
}