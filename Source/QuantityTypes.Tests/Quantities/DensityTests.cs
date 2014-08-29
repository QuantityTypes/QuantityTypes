// --------------------------------------------------------------------------------------------------------------------
// <copyright file="DensityTests.cs" company="QuantityTypes">
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
namespace QuantityTypes.Tests
{
    using System;
    using System.Diagnostics.CodeAnalysis;

    using NUnit.Framework;

    [TestFixture]
    [SuppressMessage("StyleCop.CSharp.DocumentationRules", "SA1600:ElementsMustBeDocumented",
        Justification = "Reviewed. Suppression is OK here.")]
    // ReSharper disable InconsistentNaming
    public class DensityTests
    {
        [Test]
        public void Constructors()
        {
            Assert.AreEqual(2, new Density(2).Value);
            Assert.AreEqual(2, new Density("2Kg/M^3").Value);
        }

        [Test]
        public void Operator()
        {
            Assert.AreEqual(Density.KilogramPerCubicMetre, Mass.Kilogram / Volume.CubicMetre);
            Assert.AreEqual(Density.KilogramPerCubicMetre, Mass.Kilogram / (Length.Metre * Length.Metre * Length.Metre));
        }

        [Test]
        [ExpectedException(typeof(FormatException))]
        public void Parse_InvalidString()
        {
            Assert.AreEqual(2, Density.Parse("2kg").Value);
        }

        [Test]
        public void Parse_ValidStrings()
        {
            Assert.AreEqual(2, Density.Parse("2kg/m^3").Value, "correct unit");
            Assert.AreEqual(2, Density.Parse("2Kg/M^3").Value, "wrong case");
            Assert.AreEqual(2, Density.Parse("2").Value, "no unit");
        }

        [Test]
        public void Parse_Emptytrings()
        {
            Assert.AreEqual(0, Density.Parse(string.Empty).Value, "empty");
            Assert.AreEqual(0, Density.Parse(null).Value, "null");
        }
    }
}