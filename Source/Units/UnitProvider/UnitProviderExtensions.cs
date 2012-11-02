// --------------------------------------------------------------------------------------------------------------------
// <copyright file="UnitProviderExtensions.cs" company="Units.NET">
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
// --------------------------------------------------------------------------------------------------------------------

namespace Units
{
    using System.Collections.Generic;

    /// <summary>
    ///   Provides extension methods for UnitProvider.
    /// </summary>
    public static class UnitProviderExtensions
    {
        /// <summary>
        /// Gets the units of the specified type.
        /// </summary>
        /// <typeparam name="T">
        /// The type of units to get. 
        /// </typeparam>
        /// <param name="unitProvider">
        /// The unit provider. 
        /// </param>
        /// <returns>
        /// A dictionary of units. 
        /// </returns>
        public static Dictionary<string, IQuantity> GetUnits<T>(this IUnitProvider unitProvider) where T : IQuantity<T>
        {
            return unitProvider.GetUnits(typeof(T));
        }

        /// <summary>
        /// Gets the display unit for the specified type.
        /// </summary>
        /// <typeparam name="T">
        /// The unit type. 
        /// </typeparam>
        /// <param name="unitProvider">
        /// The unit provider. 
        /// </param>
        /// <param name="unit">
        /// The unit. 
        /// </param>
        /// <param name="unitName">
        /// The unit symbol. 
        /// </param>
        /// <returns>
        /// The <see cref="bool"/> . 
        /// </returns>
        public static bool TryGetDisplayUnit<T>(this IUnitProvider unitProvider, out T unit, out string unitName)
        {
            IQuantity quantity;
            if (!unitProvider.TryGetDisplayUnit(typeof(T), out quantity, out unitName))
            {
                unit = default(T);
                return false;
            }

            unit = (T)quantity;
            return true;
        }

        /// <summary>
        /// Gets the unit that matches the specified name.
        /// </summary>
        /// <typeparam name="T">
        /// The unit type. 
        /// </typeparam>
        /// <param name="unitProvider">
        /// The unit provider. 
        /// </param>
        /// <param name="name">
        /// The name. 
        /// </param>
        /// <param name="unit">
        /// The unit. 
        /// </param>
        /// <returns>
        /// <c>true</c> if the unit name was found, <c>false</c> otherwise 
        /// </returns>
        public static bool TryGetUnit<T>(this IUnitProvider unitProvider, string name, out T unit)
            where T : IQuantity<T>
        {
            IQuantity u;
            if (unitProvider.TryGetUnit(typeof(T), name, out u))
            {
                unit = (T)u;
                return true;
            }

            unit = default(T);
            return false;
        }

        /// <summary>
        /// Parses a string.
        /// </summary>
        /// <typeparam name="T">
        /// The type. 
        /// </typeparam>
        /// <param name="unitProvider">
        /// The unit provider. 
        /// </param>
        /// <param name="input">
        /// The input string. 
        /// </param>
        /// <param name="unit">
        /// The unit (output). 
        /// </param>
        /// <returns>
        /// True if the parsing was successful. 
        /// </returns>
        public static bool TryParse<T>(this IUnitProvider unitProvider, string input, out T unit)
        {
            IQuantity quantity;
            if (!unitProvider.TryParse(typeof(T), input, out quantity))
            {
                unit = default(T);
                return false;
            }

            unit = (T)quantity;
            return true;
        }

        /// <summary>
        /// Sets the display unit.
        /// </summary>
        /// <typeparam name="T">
        /// The quantity type. 
        /// </typeparam>
        /// <param name="unitProvider">
        /// The unit provider. 
        /// </param>
        /// <param name="name">
        /// The unit name (must be registered). 
        /// </param>
        /// <returns>
        /// <c>true</c> if the unit was set, <c>false</c> otherwise 
        /// </returns>
        public static bool TrySetDisplayUnit<T>(this IUnitProvider unitProvider, string name) where T : IQuantity<T>
        {
            return unitProvider.TrySetDisplayUnit(typeof(T), name);
        }
    }
}