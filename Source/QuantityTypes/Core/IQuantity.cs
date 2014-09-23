// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IQuantity.cs" company="QuantityTypes">
//   Copyright (c) 2014 QuantityTypes contributors
// </copyright>
// <summary>
//   Defines a quantity.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace QuantityTypes
{
    using System;

    /// <summary>
    /// Defines a quantity.
    /// </summary>
    public interface IQuantity : IComparable, IFormattable
    {
        /// <summary>
        /// Gets the amount of quantity in the base unit.
        /// </summary>
        /// <value>The value.</value>
        double Value { get; }

        /// <summary>
        /// Converts the quantity to the specified unit.
        /// </summary>
        /// <param name="unit">The unit.</param>
        /// <returns>The amount of the specified unit.</returns>
        double ConvertTo(IQuantity unit);

        /// <summary>
        /// Multiplies by the specified number.
        /// </summary>
        /// <param name="x">The number.</param>
        /// <returns>The new quantity.</returns>
        IQuantity MultiplyBy(double x);
    }
}