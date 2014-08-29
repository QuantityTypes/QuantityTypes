// --------------------------------------------------------------------------------------------------------------------
// <copyright file="QuantityExtensions.cs" company="QuantityTypes">
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
//   Provides extension methods for quantities.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace QuantityTypes
{
    using System;

    /// <summary>
    /// Provides extension methods for quantities.
    /// </summary>
    public static class QuantityExtensions
    {
        /// <summary>
        /// Converts the input value to the specified unit or returns the converted default value if the input value is null.
        /// </summary>
        /// <typeparam name="T">
        /// The type of the quantity.
        /// </typeparam>
        /// <param name="value">
        /// The input quantity value.
        /// </param>
        /// <param name="unit">
        /// The unit.
        /// </param>
        /// <param name="defaultValue">
        /// The default value.
        /// </param>
        /// <returns>
        /// The converted quantity.
        /// </returns>
        public static double ConvertOrDefault<T>(this T? value, T unit, T defaultValue) where T : struct, IQuantity
        {
            if (!value.HasValue)
            {
                return defaultValue.ConvertTo(unit);
            }

            return value.Value.ConvertTo(unit);
        }

        /// <summary>
        /// Converts the input value to the specified unit or returns the default value if the input value is null.
        /// </summary>
        /// <typeparam name="T">
        /// The type of the quantity.
        /// </typeparam>
        /// <param name="value">
        /// The input quantity value.
        /// </param>
        /// <param name="unit">
        /// The unit.
        /// </param>
        /// <param name="defaultValue">
        /// The default value.
        /// </param>
        /// <returns>
        /// The converted quantity.
        /// </returns>
        public static double ConvertOrDefault<T>(this T? value, T unit, double defaultValue) where T : struct, IQuantity
        {
            if (!value.HasValue)
            {
                return defaultValue;
            }

            return value.Value.ConvertTo(unit);
        }

        /// <summary>
        /// Converts the input value to the specified unit or returns NaN if the input value is null.
        /// </summary>
        /// <typeparam name="T">
        /// The type of the quantity.
        /// </typeparam>
        /// <param name="value">
        /// The input quantity value.
        /// </param>
        /// <param name="unit">
        /// The unit.
        /// </param>
        /// <returns>
        /// The converted quantity.
        /// </returns>
        public static double ConvertTo<T>(this T? value, T unit) where T : struct, IQuantity
        {
            return ConvertOrDefault(value, unit, double.NaN);
        }

        /// <summary>
        /// Converts the specified value to the specified unit or throws an exception if the input value is null.
        /// </summary>
        /// <typeparam name="T">
        /// The type of the quantity.
        /// </typeparam>
        /// <param name="value">
        /// The input quantity value.
        /// </param>
        /// <param name="unit">
        /// The unit.
        /// </param>
        /// <returns>
        /// The converted quantity.
        /// </returns>
        /// <exception cref="Exception">
        /// Cannot convert <c>null</c> quantity.
        /// </exception>
        public static double ConvertOrThrow<T>(this T? value, T unit) where T : struct, IQuantity
        {
            if (!value.HasValue)
            {
                throw new Exception("Cannot convert null quantity.");
            }

            return value.Value.ConvertTo(unit);
        }
    }
}