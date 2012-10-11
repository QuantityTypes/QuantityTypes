// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IQuantity.cs" company="Units.NET">
//   Copyright (c) 2012 Oystein Bjorke
// </copyright>
// <summary>
//   Defines a quantity.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace Units
{
    /// <summary>
    /// Defines a quantity.
    /// </summary>
    public interface IQuantity
    {
        /// <summary>
        /// Gets the amount of quantity in the base unit.
        /// </summary>
        /// <value> The value. </value>
        double Value { get; }

    }
}