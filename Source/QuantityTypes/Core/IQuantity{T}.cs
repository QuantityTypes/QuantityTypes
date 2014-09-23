// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IQuantity{T}.cs" company="QuantityTypes">
//   Copyright (c) 2014 QuantityTypes contributors
// </copyright>
// <summary>
//   Defines functionality for unit conversion.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace QuantityTypes
{
    using System;

    /// <summary>
    /// Defines functionality for unit conversion.
    /// </summary>
    /// <typeparam name="T">The quantity type.</typeparam>
    public interface IQuantity<T> : IQuantity, IEquatable<T>, IComparable<T>
    {
        /// <summary>
        /// Converts the quantity to the specified unit.
        /// </summary>
        /// <param name="unit">The unit.</param>
        /// <returns>The amount of the specified unit.</returns>
        double ConvertTo(T unit);
    }
}