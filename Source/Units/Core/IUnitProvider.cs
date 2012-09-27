namespace Units
{
    using System;
    using System.Collections.Generic;

    /// <summary>
    /// Provides units for parsing and formatting.
    /// </summary>
    public interface IUnitProvider : IFormatProvider
    {
        /// <summary>
        /// Sets the display unit.
        /// </summary>
        /// <param name="unit">The unit.</param>
        /// <param name="name">The name.</param>
        void SetDisplayUnit(IQuantity unit, string name);
        
        /// <summary>
        /// Registers the unit.
        /// </summary>
        /// <param name="unit">The unit.</param>
        /// <param name="name">The name.</param>
        void RegisterUnit(IQuantity unit, string name);

        /// <summary>
        /// Gets the display unit for the specified type.
        /// </summary>
        /// <typeparam name="T">The type</typeparam>
        /// <param name="unit">The unit (output).</param>
        /// <param name="name">The unit symbol (output).</param>
        /// <returns>True if the display unit was found.</returns>
        bool TryGetDisplayUnit<T>(out T unit, out string name);

        /// <summary>
        /// Parses a string.
        /// </summary>
        /// <typeparam name="T">The type.</typeparam>
        /// <param name="input">The input string.</param>
        /// <param name="value">The value (output).</param>
        /// <param name="unit">The unit (output).</param>
        /// <returns>True if the parsing was successful.</returns>
        bool TryParse<T>(string input, out double value, out T unit);

        /// <summary>
        /// Formats the quantity by the specified format string.
        /// </summary>
        /// <typeparam name="T">The quantity type.</typeparam>
        /// <param name="format">The format string.</param>
        /// <param name="quantity">The quantity.</param>
        /// <returns>The formatted string.</returns>
        string Format<T>(string format, T quantity) where T : IQuantity<T>;

        /// <summary>
        /// Gets the registered units of the specified type.
        /// </summary>
        /// <returns>The registered units.</returns>
        Dictionary<string, IQuantity> GetUnits(Type type);

        /// <summary>
        /// Gets the first registered unit (of any quantity type) that matches the specified name.
        /// </summary>
        /// <param name="name">The name.</param>
        /// <returns>The unit.</returns>
        IQuantity GetUnit(string name);
    }
}