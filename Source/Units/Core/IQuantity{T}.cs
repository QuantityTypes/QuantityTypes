namespace Units
{
    using System;

    /// <summary>
    /// Defines functionality for unit conversion.
    /// </summary>
    /// <typeparam name="T">The quantity type.</typeparam>
    /// <remarks></remarks>
    public interface IQuantity<T> : IQuantity, IFormattable, IEquatable<T>, IComparable<T>
    {
        /// <summary>
        /// Converts the quantity to the specified unit.
        /// </summary>
        /// <param name="unit">The unit.</param>
        /// <returns>The amount of the specified unit.</returns>
        /// <remarks></remarks>
        double ConvertTo(T unit);
    }
}