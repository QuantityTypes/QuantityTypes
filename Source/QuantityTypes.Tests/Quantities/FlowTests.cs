// --------------------------------------------------------------------------------------------------------------------
// <copyright file="FlowTests.cs" company="QuantityTypes">
//   Copyright (c) 2014 QuantityTypes contributors
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace QuantityTypes.Tests
{
    using System.Diagnostics.CodeAnalysis;
    using NUnit.Framework;

    using QuantityTypes;

    [TestFixture]
    [SuppressMessage("StyleCop.CSharp.DocumentationRules", "SA1600:ElementsMustBeDocumented", Justification = "Reviewed. Suppression is OK here.")]
    // ReSharper disable InconsistentNaming
    public class FlowTests
    {
        [Test]
        public void ConvertTo()
        {
            Assert.AreEqual(60000 * Flow.LitrePerMinute, 1 * Flow.CubicMetrePerSecond);
            Assert.AreEqual(3600 * Flow.CubicMetrePerHour, 1 * Flow.CubicMetrePerSecond);
        }
    }
}
