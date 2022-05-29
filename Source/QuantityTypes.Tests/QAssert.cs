// --------------------------------------------------------------------------------------------------------------------
// <copyright file="QAssert.cs" company="QuantityTypes">
//   Copyright (c) 2014 QuantityTypes contributors
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace QuantityTypes.Tests
{
    using NUnit.Framework;

    public static class QAssert
    {
        public static void AreEqual(string expected, string actual) => Assert.AreEqual(expected.Replace("\r", ""), actual.Replace("\r", ""));
    }

}