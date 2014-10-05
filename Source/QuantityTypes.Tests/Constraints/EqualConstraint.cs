// --------------------------------------------------------------------------------------------------------------------
// <copyright file="EqualConstraint.cs" company="QuantityTypes">
//   Copyright (c) 2014 QuantityTypes contributors
// </copyright>
// <summary>
//   EqualConstraint is able to compare an actual quantity value with the expected quantity value provided in its constructor.
//   Two objects are considered equal if both have the same value or is within a given tolerance.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace QuantityTypes.Tests
{
    using System;

    using NUnit.Framework.Constraints;

    /// <summary>
    /// EqualConstraint is able to compare an actual quantity value with the expected quantity value provided in its constructor. 
    /// Two objects are considered equal if both have the same value or is within a given tolerance. 
    /// </summary>
    /// <typeparam name="T">The type of the quantities to compare.</typeparam>
    public class EqualConstraint<T> : Constraint where T : IQuantity
    {
        /// <summary>
        /// The expected value.
        /// </summary>
        private readonly T expected;

        /// <summary>
        /// The tolerance-
        /// </summary>
        private T tolerance;

        /// <summary>
        /// Initializes a new instance of the <see cref="EqualConstraint{T}"/> class.
        /// </summary>
        /// <param name="expectedValue">The expected value.</param>
        public EqualConstraint(T expectedValue)
        {
            this.expected = expectedValue;
        }

        /// <summary>
        /// Flags the constraint to use a tolerance when determining equality.
        /// </summary>
        /// <param name="amount">The tolerance.</param>
        /// <returns>The constraint itself.</returns>
        public EqualConstraint<T> Within(T amount)
        {
            this.tolerance = amount;
            return this;
        }

        /// <summary>
        /// Flags the constraint to use a tolerance when determining equality.
        /// </summary>
        /// <param name="amount">The tolerance (in base unit of the quantity).</param>
        /// <returns>The constraint itself.</returns>
        public EqualConstraint<T> Within(double amount)
        {
            this.tolerance = (T)Activator.CreateInstance(typeof(T), amount);
            return this;
        }

        /// <summary>
        /// Tests whether the constraint is satisfied by a given value
        /// </summary>
        /// <param name="actualValue">The value to be tested</param>
        /// <returns>
        /// True for success, false for failure
        /// </returns>
        public override bool Matches(object actualValue)
        {
            this.actual = actualValue;
            var actualQuantity = (IQuantity)actualValue;
            var negativeTolerance = this.tolerance.MultiplyBy(-1);
            var lowerBound = this.expected.Add(negativeTolerance);
            var upperBound = this.expected.Add(this.tolerance);
            var lowerComparison = actualQuantity.CompareTo(lowerBound);
            var upperComparison = actualQuantity.CompareTo(upperBound);
            return lowerComparison > 0 && upperComparison < 0;
        }

        /// <summary>
        /// Write the constraint description to a MessageWriter
        /// </summary>
        /// <param name="writer">The writer on which the description is displayed</param>
        public override void WriteDescriptionTo(MessageWriter writer)
        {
            writer.WriteExpectedValue(this.expected);
            writer.WriteConnector("+/-");
            writer.WriteExpectedValue(this.tolerance);
        }
    }
}