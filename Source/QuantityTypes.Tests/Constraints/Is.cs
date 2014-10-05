// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Is.cs" company="QuantityTypes">
//   Copyright (c) 2014 QuantityTypes contributors
// </copyright>
// <summary>
//   Helper class with properties and methods that supply a number of quantity based constraints used in Asserts.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace QuantityTypes.Tests
{
    /// <summary>
    /// Helper class with properties and methods that supply a number of quantity based constraints used in Asserts.
    /// </summary>
    public static class Is
    {
        /// <summary>
        /// Returns a constraint that tests two items for equality
        /// </summary>
        /// <typeparam name="T">The type of the items.</typeparam>
        /// <param name="expected">The expected value.</param>
        /// <returns>The constraint.</returns>
        public static EqualConstraint<T> EqualTo<T>(T expected) where T : IQuantity
        {
            return new EqualConstraint<T>(expected);
        }
    }
}