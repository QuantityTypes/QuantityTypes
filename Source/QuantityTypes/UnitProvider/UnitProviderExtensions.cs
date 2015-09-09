// --------------------------------------------------------------------------------------------------------------------
// <copyright file="UnitProviderExtensions.cs" company="QuantityTypes">
//   Copyright (c) 2014 QuantityTypes contributors
// </copyright>
// <summary>
//   Provides extension methods for UnitProvider.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace QuantityTypes
{
    using System;
    using System.Collections.Generic;
    using System.Reflection;

    /// <summary>
    /// Provides extension methods for UnitProvider.
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
        /// <param name="unitSymbol">
        /// The unit symbol. 
        /// </param>
        /// <returns>
        /// The <see cref="bool"/> . 
        /// </returns>
        public static bool TryGetDisplayUnit<T>(this IUnitProvider unitProvider, out T unit, out string unitSymbol)
        {
            IQuantity quantity;
            if (!unitProvider.TryGetDisplayUnit(typeof(T), out quantity, out unitSymbol))
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
        /// <param name="symbol">
        /// The unit symbol. 
        /// </param>
        /// <param name="unit">
        /// The unit. 
        /// </param>
        /// <returns>
        /// <c>true</c> if the unit name was found, <c>false</c> otherwise 
        /// </returns>
        public static bool TryGetUnit<T>(this IUnitProvider unitProvider, string symbol, out T unit)
            where T : IQuantity<T>
        {
            IQuantity u;
            if (unitProvider.TryGetUnit(typeof(T), symbol, out u))
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
        /// <typeparam name="T">The type.</typeparam>
        /// <param name="unitProvider">The unit provider.</param>
        /// <param name="input">The input string.</param>
        /// <param name="provider">The numeric format provider.</param>
        /// <param name="unit">The unit (output).</param>
        /// <returns>True if the parsing was successful.</returns>
        public static bool TryParse<T>(this IUnitProvider unitProvider, string input, IFormatProvider provider, out T unit)
        {
            IQuantity quantity;
            if (!unitProvider.TryParse(typeof(T), input, provider, out quantity))
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
        /// <param name="symbol">
        /// The unit symbol (must be registered). 
        /// </param>
        /// <returns>
        /// <c>true</c> if the unit was set, <c>false</c> otherwise 
        /// </returns>
        public static bool TrySetDisplayUnit<T>(this IUnitProvider unitProvider, string symbol) where T : IQuantity<T>
        {
            return unitProvider.TrySetDisplayUnit(typeof(T), symbol);
        }

        /// <summary>
        /// Registers the units in the specified assembly.
        /// </summary>
        /// <param name="unitProvider">
        /// The unit provider. 
        /// </param>
        /// <param name="assembly">
        /// The assembly. 
        /// </param>
        public static void RegisterUnits(this IUnitProvider unitProvider, Assembly assembly)
        {
            foreach (var t in assembly.GetTypes())
            {
                if (typeof(IQuantity).IsAssignableFrom(t))
                {
                    unitProvider.RegisterUnits(t);
                }
            }
        }

        /// <summary>
        /// Registers the unit properties in the specified type.
        /// </summary>
        /// <param name="unitProvider">
        /// The unit provider. 
        /// </param>
        /// <param name="type">
        /// The type. 
        /// </param>
        public static void RegisterUnits(this IUnitProvider unitProvider, Type type)
        {
            foreach (var property in type.GetProperties(BindingFlags.Static | BindingFlags.Public))
            {
                foreach (UnitAttribute ua in property.GetCustomAttributes(typeof(UnitAttribute), false))
                {
                    unitProvider.RegisterUnit((IQuantity)property.GetValue(null, null), ua.Symbol);

                    if (ua.IsDefaultDisplayUnit)
                    {
                        var unit = (IQuantity)property.GetValue(null, null);
                        unitProvider.TrySetDisplayUnit(unit.GetType(), ua.Symbol);
                    }
                }
            }
        }

    }
}