// --------------------------------------------------------------------------------------------------------------------
// <copyright file="LengthTests.cs" company="Units">
//   http://Units.codeplex.com, license: Ms-PL
// </copyright>
// <summary>
//   Unit tests for the Density type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Units.Tests
{
    using System;
    using System.ComponentModel;
    using System.Diagnostics.CodeAnalysis;

    using Units;

    using NUnit.Framework;

    [TestFixture]
    [SuppressMessage("StyleCop.CSharp.DocumentationRules", "SA1600:ElementsMustBeDocumented", Justification = "Reviewed. Suppression is OK here.")]
    // ReSharper disable InconsistentNaming
    public class DensityTests
    {
        [Test]
        public void Constructors()
        {
            Assert.AreEqual(2, new Density(2).Value);
            Assert.AreEqual(2, new Density("2kg/m^3").Value);
        }

    }
}