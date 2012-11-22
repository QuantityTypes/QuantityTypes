// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IUnitProvider.cs" company="Units.NET">
//   The MIT License (MIT)
//   
//   Copyright (c) 2012 Oystein Bjorke
//   
//   Permission is hereby granted, free of charge, to any person obtaining a
//   copy of this software and associated documentation files (the
//   "Software"), to deal in the Software without restriction, including
//   without limitation the rights to use, copy, modify, merge, publish,
//   distribute, sublicense, and/or sell copies of the Software, and to
//   permit persons to whom the Software is furnished to do so, subject to
//   the following conditions:
//   
//   The above copyright notice and this permission notice shall be included
//   in all copies or substantial portions of the Software.
//   
//   THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS
//   OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF
//   MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT.
//   IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY
//   CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER IN AN ACTION OF CONTRACT,
//   TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN CONNECTION WITH THE
//   SOFTWARE OR THE USE OR OTHER DEALINGS IN THE SOFTWARE.
// </copyright>
// <summary>
//   Provides units for parsing and formatting.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace Units
{
    using System;
    using System.Collections.Generic;
    using System.Globalization;

    /// <summary>
    ///     Provides units for parsing and formatting.
    /// </summary>
    public interface IUnitProvider : IFormatProvider
    {
        /// <summary>
        /// Gets the culture.
        /// </summary>
        /// <value>The culture.</value>
        CultureInfo Culture { get; }

        /// <summary>
        /// Formats the quantity by the specified format string.
        /// </summary>
        /// <typeparam name="T">
        /// The quantity type. 
        /// </typeparam>
        /// <param name="format">
        /// The format string. 
        /// </param>
        /// <param name="quantity">
        /// The quantity. 
        /// </param>
        /// <returns>
        /// The formatted string. 
        /// </returns>
        string Format<T>(string format, T quantity) where T : IQuantity<T>;

        /// <summary>
        /// Gets the first registered unit (of any quantity type) that matches the specified symbol.
        /// </summary>
        /// <param name="symbol">
        /// The unit symbol. 
        /// </param>
        /// <returns>
        /// The unit. 
        /// </returns>
        IQuantity GetUnit(string symbol);

        /// <summary>
        /// Gets the unit that matches the specified symbol.
        /// </summary>
        /// <param name="type">The type.</param>
        /// <param name="symbol">The symbol of the unit.</param>
        /// <param name="unit">The unit.</param>
        /// <returns><c>true</c> if the unit symbol was found, <c>false</c> otherwise</returns>
        bool TryGetUnit(Type type, string symbol, out IQuantity unit);

        /// <summary>
        /// Gets the registered units of the specified type.
        /// </summary>
        /// <param name="type">
        /// The type. 
        /// </param>
        /// <returns>
        /// The registered units. 
        /// </returns>
        Dictionary<string, IQuantity> GetUnits(Type type);

        /// <summary>
        /// Registers the unit.
        /// </summary>
        /// <param name="unit">
        /// The unit. 
        /// </param>
        /// <param name="symbol">
        /// The name. 
        /// </param>
        void RegisterUnit(IQuantity unit, string symbol);

        /// <summary>
        /// Sets the display unit.
        /// </summary>
        /// <param name="type">The type.</param>
        /// <param name="symbol">The unit name (must be registered).</param>
        /// <returns><c>true</c> if the unit was set, <c>false</c> otherwise</returns>
        bool TrySetDisplayUnit(Type type, string symbol);

        /// <summary>
        /// Gets the display unit for the specified type.
        /// </summary>
        /// <param name="type">The type.</param>
        /// <param name="symbol">The unit symbol.</param>
        /// <returns>The unit quantity.</returns>
        IQuantity GetDisplayUnit(Type type, out string symbol);

        /// <summary>
        /// Gets the display unit for the specified type.
        /// </summary>
        /// <param name="type">The unit type.</param>
        /// <returns>The name.</returns>
        string GetDisplayUnit(Type type);

        /// <summary>
        /// Gets the display unit for the specified type.
        /// </summary>
        /// <param name="type">The unit type.</param>
        /// <param name="unit">The unit (output).</param>
        /// <param name="unitSymbol">The unit symbol (output).</param>
        /// <returns>True if the display unit was found.</returns>
        bool TryGetDisplayUnit(Type type, out IQuantity unit, out string unitSymbol);

        /// <summary>
        /// Parses the specified string.
        /// </summary>
        /// <param name="unitType">Type of the unit.</param>
        /// <param name="input">The input.</param>
        /// <param name="quantity">The quantity.</param>
        /// <returns><c>true</c> if the parsing was successful, <c>false</c> otherwise</returns>
        bool TryParse(Type unitType, string input, out IQuantity quantity);
    }
}