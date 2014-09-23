// --------------------------------------------------------------------------------------------------------------------
// <copyright file="QuantityExtensions.cs" company="QuantityTypes">
//   Copyright (c) 2014 QuantityTypes contributors
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