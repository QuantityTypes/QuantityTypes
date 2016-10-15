// --------------------------------------------------------------------------------------------------------------------
// <copyright file="UnitProvider.cs" company="QuantityTypes">
//   Copyright (c) 2014 QuantityTypes contributors
// </copyright>
// <summary>
//   Implements a unit provider.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace QuantityTypes
{
    using System;
    using System.Collections.Generic;
    using System.Globalization;
    using System.Reflection;

    /// <summary>
    /// Implements a unit provider.
    /// </summary>
    public class UnitProvider : IUnitProvider
    {
        /// <summary>
        ///   The display units.
        /// </summary>
        private readonly Dictionary<Type, UnitDefinition> displayUnits;

        /// <summary>
        ///   The units.
        /// </summary>
        private readonly Dictionary<Type, Dictionary<string, IQuantity>> units;

        /// <summary>
        ///   Initializes static members of the <see cref="UnitProvider" /> class.
        /// </summary>
        static UnitProvider()
        {
            var up = new UnitProvider(typeof(Length).GetTypeInfo().Assembly);
            Default = up;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="UnitProvider"/> class and initialize with the units found in the specified assembly.
        /// </summary>
        /// <param name="a">
        /// The assembly containing unit definitions. 
        /// </param>
        /// <param name="culture">
        /// The culture. 
        /// </param>
        public UnitProvider(Assembly a, CultureInfo culture = null)
            : this(culture)
        {
            this.RegisterUnits(a);
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="UnitProvider"/> class.
        /// </summary>
        /// <param name="culture">
        /// The culture. 
        /// </param>
        public UnitProvider(CultureInfo culture = null)
        {
            this.Separator = " ";
            if (culture == null)
            {
                culture = CultureInfo.CurrentCulture;
            }

            this.Culture = culture;
            this.displayUnits = new Dictionary<Type, UnitDefinition>();
            this.units = new Dictionary<Type, Dictionary<string, IQuantity>>();
        }

        /// <summary>
        ///   Gets or sets the default unit provider.
        /// </summary>
        public static IUnitProvider Default { get; set; }

        /// <summary>
        ///   Gets or sets the culture.
        /// </summary>
        /// <value> The culture. </value>
        public CultureInfo Culture { get; set; }

        /// <summary>
        ///   Gets or sets the separator.
        /// </summary>
        /// <value> The separator. </value>
        public string Separator { get; set; }

        /// <summary>
        /// Formats the specified quantity.
        /// </summary>
        /// <typeparam name="T">The quantity type.</typeparam>
        /// <param name="format">The format.</param>
        /// <param name="provider">The numeric format provider.</param>
        /// <param name="quantity">The quantity.</param>
        /// <returns>The <see cref="string" /> .</returns>
        public string Format<T>(string format, IFormatProvider provider, T quantity) where T : IQuantity<T>
        {
            if (double.IsNaN(quantity.Value))
            {
                return double.NaN.ToString(provider);
            }

            if (double.IsPositiveInfinity(quantity.Value))
            {
                return double.PositiveInfinity.ToString(provider);
            }

            if (double.IsNegativeInfinity(quantity.Value))
            {
                return double.NegativeInfinity.ToString(provider);
            }

            var unit = default(string);
            var showUnit = true;
            if (!string.IsNullOrEmpty(format))
            {
                var unitStart = format.IndexOf('[');
                if (unitStart >= 0)
                {
                    var unitEnd = format.IndexOf(']', unitStart + 1);
                    if (unitEnd < 0)
                    {
                        throw new FormatException("Unmatched [ in format string.");
                    }

                    unit = format.Substring(unitStart + 1, unitEnd - unitStart - 1);

                    if (unit.StartsWith("!"))
                    {
                        showUnit = false;
                        unit = unit.Substring(1);
                    }

                    if (unit == string.Empty)
                    {
                        showUnit = false;
                    }

                    format = format.Remove(unitStart, unitEnd - unitStart + 1).Trim();
                }
            }

            // unit=null: convert to display unit, show display unit
            // unit=empty: convert to display unit, but do not show
            // unit starts with !: convert to specified unit, do not show specified unit
            // otherwise: convert to specified unit, show specified unit

            // find the conversion unit
            T q;
            if (!string.IsNullOrEmpty(unit))
            {
                q = this.GetUnit<T>(unit);
            }
            else
            {
                if (!this.TryGetDisplayUnit(out q, out unit))
                {
                    return null;
                }
            }

            // Convert the value to a string
            string s = quantity.ConvertTo(q).ToString(format, provider ?? this);

            if (!showUnit)
            {
                // Return the value only
                return s;
            }

            // Temperatures should have a space before the unit
            // Angles should not have a space before ° symbol
            var separator = this.Separator;
            // ReSharper disable once CSharpWarnings::CS0184
            var isTemperature = quantity is Temperature;
            // ReSharper disable once ConditionIsAlwaysTrueOrFalse
            if (!isTemperature && (string.IsNullOrEmpty(unit) || unit.StartsWith("°")))
            {
                separator = string.Empty;
            }

            return string.Concat(s, separator, unit).Trim();
        }

        /// <summary>
        /// Gets the display unit for the specified type.
        /// </summary>
        /// <param name="type">
        /// The unit type. 
        /// </param>
        /// <returns>
        /// The name. 
        /// </returns>
        public string GetDisplayUnit(Type type)
        {
            UnitDefinition ud;
            if (!this.displayUnits.TryGetValue(type, out ud))
            {
                throw new InvalidOperationException("No display unit defined for " + type);
            }

            return ud.Name;
        }

        /// <summary>
        /// Gets the display unit for the specified type.
        /// </summary>
        /// <param name="type">
        /// The type. 
        /// </param>
        /// <param name="unitName">
        /// Name of the unit. 
        /// </param>
        /// <returns>
        /// A quantity. 
        /// </returns>
        /// <exception cref="System.InvalidOperationException">
        /// No display unit defined for  + type
        /// </exception>
        public IQuantity GetDisplayUnit(Type type, out string unitName)
        {
            UnitDefinition ud;
            if (!this.displayUnits.TryGetValue(type, out ud))
            {
                throw new InvalidOperationException("No display unit defined for " + type);
            }

            unitName = ud.Name;
            return ud.Unit;
        }

        /// <summary>
        /// Returns an object that provides formatting services for the specified type.
        /// </summary>
        /// <param name="formatType">
        /// An object that specifies the type of format object to return. 
        /// </param>
        /// <returns>
        /// An instance of the object specified by <paramref name="formatType"/> , if the <see cref="T:System.IFormatProvider"/> implementation can supply that type of object; otherwise, null. 
        /// </returns>
        public object GetFormat(Type formatType)
        {
            return this.Culture.GetFormat(formatType);
        }

        /// <summary>
        /// Gets the first registered unit (of any quantity type) that matches the specified name.
        /// </summary>
        /// <param name="name">
        /// The name. 
        /// </param>
        /// <returns>
        /// The unit. 
        /// </returns>
        public IQuantity GetUnit(string name)
        {
            foreach (var u in this.units.Values)
            {
                IQuantity v;
                if (u.TryGetValue(name, out v))
                {
                    return v;
                }
            }

            return null;
        }

        /// <summary>
        /// Gets the registered units of the specified type.
        /// </summary>
        /// <param name="type">
        /// The type. 
        /// </param>
        /// <returns>
        /// The registered units. 
        /// </returns>
        public Dictionary<string, IQuantity> GetUnits(Type type)
        {
            return this.units[type];
        }

        /// <summary>
        /// Registers the specified unit.
        /// </summary>
        /// <param name="unit">
        /// The unit. 
        /// </param>
        /// <param name="name">
        /// The name. 
        /// </param>
        public void RegisterUnit(IQuantity unit, string name)
        {
            var type = unit.GetType();
            if (!this.units.ContainsKey(type))
            {
                this.units.Add(type, new Dictionary<string, IQuantity>());
            }

            if (this.units[type].ContainsKey(name))
            {
                throw new InvalidOperationException(string.Format("{0} is already added to {1}", name, type));
            }

            this.units[type].Add(name, unit);
        }

        /// <summary>
        /// Gets the display unit for the specified type.
        /// </summary>
        /// <param name="type">
        /// The unit type. 
        /// </param>
        /// <param name="unit">
        /// The unit (output). 
        /// </param>
        /// <param name="unitName">
        /// The unit symbol (output). 
        /// </param>
        /// <returns>
        /// True if the display unit was found. 
        /// </returns>
        public bool TryGetDisplayUnit(Type type, out IQuantity unit, out string unitName)
        {
            UnitDefinition ud;
            if (!this.displayUnits.TryGetValue(type, out ud))
            {
                unit = null;
                unitName = null;
                return false;
            }

            unitName = ud.Name;
            unit = ud.Unit;
            return true;
        }

        /// <summary>
        /// Gets the unit that matches the specified name.
        /// </summary>
        /// <param name="type">
        /// The type. 
        /// </param>
        /// <param name="name">
        /// The name of the unit. 
        /// </param>
        /// <param name="unit">
        /// The unit. 
        /// </param>
        /// <returns>
        /// <c>true</c> if the unit name was found, <c>false</c> otherwise 
        /// </returns>
        public bool TryGetUnit(Type type, string name, out IQuantity unit)
        {
            Dictionary<string, IQuantity> d;
            if (!this.units.TryGetValue(type, out d))
            {
                unit = default(IQuantity);
                return false;
            }

            IQuantity u;
            if (name == null || !d.TryGetValue(name, out u))
            {
                unit = default(IQuantity);
                return false;
            }

            unit = u;
            return true;
        }

        /// <summary>
        /// Parses the specified string.
        /// </summary>
        /// <param name="unitType">Type of the unit.</param>
        /// <param name="input">The input.</param>
        /// <param name="provider">The numeric format provider.</param>
        /// <param name="quantity">The quantity.</param>
        /// <returns><c>true</c> if the parsing was successful, <c>false</c> otherwise</returns>
        public bool TryParse(Type unitType, string input, IFormatProvider provider, out IQuantity quantity)
        {
            unitType = Nullable.GetUnderlyingType(unitType) ?? unitType;

            if (string.IsNullOrEmpty(input))
            {
                quantity = (IQuantity)Activator.CreateInstance(unitType);
                return true;
            }

            if (string.Equals(input, double.NaN.ToString(provider)))
            {
                quantity = (IQuantity)Activator.CreateInstance(unitType, double.NaN);
                return true;
            }

            if (string.Equals(input, double.PositiveInfinity.ToString(provider)))
            {
                quantity = (IQuantity)Activator.CreateInstance(unitType, double.PositiveInfinity);
                return true;
            }

            if (string.Equals(input, double.NegativeInfinity.ToString(provider)))
            {
                quantity = (IQuantity)Activator.CreateInstance(unitType, double.NegativeInfinity);
                return true;
            }

            string unitString;
            double value;
            if (!Utilities.TrySplit(input, provider, out value, out unitString))
            {
                quantity = null;
                return false;
            }

            IQuantity unit;
            if (string.IsNullOrEmpty(unitString))
            {
                // No unit was provided - use the display unit
                string name;
                if (!this.TryGetDisplayUnit(unitType, out unit, out name))
                {
                    quantity = null;
                    return false;
                }
            }
            else
            {
                // Find the unit
                if (!this.TryGetUnit(unitType, unitString, out unit))
                {
                    quantity = null;
                    return false;
                }
            }

            quantity = unit.MultiplyBy(value);
            return true;
        }

        /// <summary>
        /// Sets the display unit.
        /// </summary>
        /// <param name="type">
        /// The type. 
        /// </param>
        /// <param name="name">
        /// The unit name (must be registered). 
        /// </param>
        /// <returns>
        /// <c>true</c> if the unit was set, <c>false</c> otherwise 
        /// </returns>
        public bool TrySetDisplayUnit(Type type, string name)
        {
            IQuantity unit;
            if (!this.TryGetUnit(type, name, out unit))
            {
                return false;
            }

            this.displayUnits[type] = new UnitDefinition { Name = name, Unit = unit };
            return true;
        }

        /// <summary>
        /// Gets the unit of the specified name and type.
        /// </summary>
        /// <param name="name">
        /// The name. 
        /// </param>
        /// <typeparam name="T">
        /// The type of unit. 
        /// </typeparam>
        /// <returns>
        /// The unit. 
        /// </returns>
        private T GetUnit<T>(string name)
        {
            Dictionary<string, IQuantity> typeUnits;
            if (!this.units.TryGetValue(typeof(T), out typeUnits))
            {
                throw new InvalidOperationException(string.Format("No units registered for {0}.", typeof(T)));
            }

            IQuantity unit;
            if (!typeUnits.TryGetValue(name, out unit))
            {
                if (string.IsNullOrEmpty(name))
                {
                    T displayUnit;
                    string displayUnitName;
                    if (this.TryGetDisplayUnit(out displayUnit, out displayUnitName))
                    {
                        return displayUnit;
                    }
                }

                throw new FormatException(string.Format("Unit '{0}' not found in type {1}.", name, typeof(T)));
            }

            return (T)unit;
        }

        /// <summary>
        ///   The unit definition.
        /// </summary>
        private struct UnitDefinition
        {
            /// <summary>
            ///   Gets or sets the name.
            /// </summary>
            public string Name { get; set; }

            /// <summary>
            ///   Gets or sets the unit.
            /// </summary>
            public IQuantity Unit { get; set; }
        }
    }
}