// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ForceTests.cs" company="QuantityTypes">
//   Copyright (c) 2014 QuantityTypes contributors
// </copyright>
// <summary>
//   Provides unit test for the Force class.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace QuantityTypes.Tests
{
    using NUnit.Framework;

    /// <summary>
    /// Provides unit test for the <see cref="Force" /> class.
    /// </summary>
    public class ForceTests : Tests
    {
        [Test]
        public void Units()
        {
            AssertAreEqual(Force.Kilonewton, 1000 * Force.Newton);
        }

        [Test]
        public void Parse()
        {
            AssertAreEqual(Force.Newton, Force.Parse("1 N"), "N");
            AssertAreEqual(Force.Kilonewton, Force.Parse("1 kN"), "kN");
        }
    }
}