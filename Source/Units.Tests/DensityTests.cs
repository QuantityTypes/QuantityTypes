namespace Units.Tests
{
    using System;
    using System.Diagnostics.CodeAnalysis;

    using NUnit.Framework;

    using Units;

    [TestFixture]
    [SuppressMessage("StyleCop.CSharp.DocumentationRules", "SA1600:ElementsMustBeDocumented", Justification = "Reviewed. Suppression is OK here.")]
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
        public void Parse_ValidStrings()
        {
            Assert.AreEqual(2, Density.Parse("2kg/m^3").Value, "correct unit");
            Assert.AreEqual(2, Density.Parse("2Kg/M^3").Value, "wrong case");
            Assert.AreEqual(2, Density.Parse("2").Value, "no unit");
            Assert.AreEqual(0, Density.Parse(string.Empty).Value, "empty");
            Assert.AreEqual(0, Density.Parse(null).Value, "null");
        }
        [Test, ExpectedException(typeof(FormatException))]
        public void Parse_InvalidString()
        {
            Assert.AreEqual(2, Density.Parse("2kg").Value);
        }
    }
}