// --------------------------------------------------------------------------------------------------------------------
// <copyright file="DynamicUnitProvider.cs" company="QuantityTypes">
//   Copyright (c) 2014 QuantityTypes contributors
// </copyright>
// <summary>
//   Provides units for the dynamic quantities.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace QuantityTypes.Dynamic
{
    using System;
    using System.Collections.Generic;
    using System.Globalization;
    using System.Linq;
    using System.Reflection;

    /// <summary>
    /// Provides units for the dynamic quantities.
    /// </summary>
    public class DynamicUnitProvider : IDynamicUnitProvider
    {
        /// <summary>
        /// The format provider.
        /// </summary>
        private readonly IFormatProvider provider;

        /// <summary>
        /// The units
        /// </summary>
        private readonly Dictionary<string, DynamicQuantity> units = new Dictionary<string, DynamicQuantity>();

        /// <summary>
        /// The display units
        /// </summary>
        private readonly Dictionary<Dimensions, string> displayUnits = new Dictionary<Dimensions, string>();

        /// <summary>
        /// Initializes a new instance of the <see cref="DynamicUnitProvider"/> class.
        /// </summary>
        /// <param name="provider">The provider.</param>
        /// <param name="types">The types.</param>
        public DynamicUnitProvider(IFormatProvider provider = null, params Type[] types)
        {
            this.provider = provider;
            foreach (var type in types)
            {
                this.Register(type);
            }
        }

        /// <summary>
        /// Registers the specified unit.
        /// </summary>
        /// <param name="s">The symbol.</param>
        /// <param name="q">The unit.</param>
        public void Register(string s, DynamicQuantity q)
        {
            this.units[s] = q;
        }

        /// <summary>
        /// Tries to get the unit for the specified symbol.
        /// </summary>
        /// <param name="s">The symbol.</param>
        /// <param name="q">The unit.</param>
        /// <returns><c>true</c> if the unit was found, <c>false</c> otherwise.</returns>
        public bool TryGetUnit(string s, out DynamicQuantity q)
        {
            return this.units.TryGetValue(s, out q);
        }

        /// <summary>
        /// Tries to get the display unit for the specified dimension.
        /// </summary>
        /// <param name="d">The dimension.</param>
        /// <param name="symbol">The symbol.</param>
        /// <param name="q">The unit.</param>
        /// <returns><c>true</c> if the unit was found, <c>false</c> otherwise.</returns>
        public bool TryGetDisplayUnit(Dimensions d, out string symbol, out DynamicQuantity q)
        {
            if (this.displayUnits.TryGetValue(d, out symbol))
            {
                if (this.units.TryGetValue(symbol, out q))
                {
                    return true;
                }
            }

            symbol = null;
            q = default(DynamicQuantity);
            return false;
        }

        /// <summary>
        /// Returns an object that provides formatting services for the specified type.
        /// </summary>
        /// <param name="formatType">An object that specifies the type of format object to return.</param>
        /// <returns>An instance of the object specified by <paramref name="formatType" />, if the <see cref="T:System.IFormatProvider" /> implementation can supply that type of object; otherwise, null.</returns>
        public object GetFormat(Type formatType)
        {
            var p = this.provider ?? CultureInfo.CurrentCulture;
            return p.GetFormat(formatType);
        }

        /// <summary>
        /// Registers the units declared in the specified type.
        /// </summary>
        /// <param name="type">The type.</param>
        public void Register(Type type)
        {
            var props = type.GetTypeInfo().DeclaredProperties;
            foreach (var p in props)
            {
                var q = (DynamicQuantity)p.GetValue(null, null);
                foreach (var ua in p.GetCustomAttributes(typeof(UnitAttribute), false).Cast<UnitAttribute>())
                {
                    this.Register(ua.Symbol, q);
                    if (ua.IsDefaultDisplayUnit)
                    {
                        this.SetDisplayUnit(ua.Symbol, q);
                    }
                }
            }
        }

        /// <summary>
        /// Sets the display unit.
        /// </summary>
        /// <param name="symbol">The symbol.</param>
        /// <param name="dynamicQuantity">The dynamic quantity.</param>
        public void SetDisplayUnit(string symbol, DynamicQuantity dynamicQuantity)
        {
            this.displayUnits[dynamicQuantity.Dimensions] = symbol;
        }
    }
}