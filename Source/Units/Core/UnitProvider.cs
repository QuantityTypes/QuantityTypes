// --------------------------------------------------------------------------------------------------------------------
// <copyright file="UnitProvider.cs" company="Units.NET">
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
//   Implements a unit provider.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace Units
{
    using System;
    using System.Collections.Generic;
    using System.Globalization;
    using System.Reflection;
    using System.Text.RegularExpressions;

    /// <summary>
    ///     Implements a unit provider.
    /// </summary>
    public class UnitProvider : IUnitProvider
    {
        /// <summary>
        ///     The format expression.
        /// </summary>
        private static readonly Regex FormatExpression = new Regex(
            @"([0#]*\.?[0#]*)\s*([a-z\*\/]*)", RegexOptions.Compiled | RegexOptions.IgnoreCase);

        /// <summary>
        ///     The parser expression.
        /// </summary>
        private static readonly Regex ParserExpression =
            new Regex(
                @"([-+]?[0-9]*\.?[0-9]+([eE][-+]?[0-9]+)?)\s*([^0-9.\s].*)?",
                RegexOptions.Compiled | RegexOptions.IgnoreCase);

        /// <summary>
        ///     The display units.
        /// </summary>
        private readonly Dictionary<Type, UnitDefinition> displayUnits;

        /// <summary>
        ///     The units.
        /// </summary>
        private readonly Dictionary<Type, Dictionary<string, IQuantity>> units;

        /// <summary>
        ///     Initializes static members of the <see cref="UnitProvider" /> class.
        /// </summary>
        static UnitProvider()
        {
            var up = new UnitProvider(typeof(Length).Assembly);
            Default = up;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="UnitProvider"/> class.
        /// </summary>
        /// <param name="a">
        /// A. 
        /// </param>
        /// <param name="culture">
        /// The culture. 
        /// </param>
        public UnitProvider(Assembly a, CultureInfo culture = null)
            : this(culture)
        {
            RegisterUnits(a);
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
                culture = CultureInfo.CurrentUICulture;
            }

            this.Culture = culture;
            this.displayUnits = new Dictionary<Type, UnitDefinition>();
            this.units = new Dictionary<Type, Dictionary<string, IQuantity>>();
        }

        /// <summary>
        ///     Gets the default unit provider.
        /// </summary>
        public static IUnitProvider Default { get; private set; }

        /// <summary>
        ///     Gets or sets the culture.
        /// </summary>
        /// <value> The culture. </value>
        public CultureInfo Culture { get; set; }

        /// <summary>
        ///     Gets or sets the separator.
        /// </summary>
        /// <value> The separator. </value>
        public string Separator { get; set; }

        /// <summary>
        /// Formats the specified format.
        /// </summary>
        /// <typeparam name="T">
        /// </typeparam>
        /// <param name="format">
        /// The format. 
        /// </param>
        /// <param name="length">
        /// The length. 
        /// </param>
        /// <returns>
        /// The <see cref="string"/> . 
        /// </returns>
        public string Format<T>(string format, T length) where T : IQuantity<T>
        {
            T q;
            var unit = default(string);
            if (!string.IsNullOrEmpty(format))
            {
                var m = FormatExpression.Match(format);
                if (m.Success)
                {
                    format = m.Groups[1].Value;
                    unit = m.Groups[2].Value;
                }
            }

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

            string s = length.ConvertTo(q).ToString(format, this);
            return string.Format("{0}{1}{2}", s, this.Separator, unit);
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
        /// Registers the unit.
        /// </summary>
        /// <param name="unit">
        /// The unit. 
        /// </param>
        /// <param name="name">
        /// The name. 
        /// </param>
        public void RegisterUnit(IQuantity unit, string name)
        {
            Type type = unit.GetType();
            if (!this.units.ContainsKey(type))
            {
                this.units.Add(type, new Dictionary<string, IQuantity>(StringComparer.OrdinalIgnoreCase));
            }

            if (this.units[type].ContainsKey(name))
            {
                throw new InvalidOperationException(string.Format("{0} is already added to {1}", name, type));
            }

            this.units[type].Add(name, unit);
        }

        /// <summary>
        /// Sets the display unit.
        /// </summary>
        /// <param name="q">
        /// The q. 
        /// </param>
        /// <param name="name">
        /// The name. 
        /// </param>
        public void SetDisplayUnit(IQuantity q, string name)
        {
            this.displayUnits[q.GetType()] = new UnitDefinition { Name = name, Unit = q };
        }

        /// <summary>
        /// Tries the get display unit.
        /// </summary>
        /// <typeparam name="T">
        /// </typeparam>
        /// <param name="q">
        /// The q. 
        /// </param>
        /// <param name="unit">
        /// The unit. 
        /// </param>
        /// <returns>
        /// The <see cref="bool"/> . 
        /// </returns>
        public bool TryGetDisplayUnit<T>(out T q, out string unit)
        {
            UnitDefinition ud;
            if (!this.displayUnits.TryGetValue(typeof(T), out ud))
            {
                q = default(T);
                unit = null;
                return false;
            }

            unit = ud.Name;
            q = (T)ud.Unit;
            return true;
        }

        /// <summary>
        /// Parses a string.
        /// </summary>
        /// <typeparam name="T">
        /// The type. 
        /// </typeparam>
        /// <param name="input">
        /// The input string. 
        /// </param>
        /// <param name="value">
        /// The value (output). 
        /// </param>
        /// <param name="unit">
        /// The unit (output). 
        /// </param>
        /// <returns>
        /// True if the parsing was successful. 
        /// </returns>
        public bool TryParse<T>(string input, out double value, out T unit)
        {
            if (string.IsNullOrWhiteSpace(input))
            {
                value = 0;
                unit = default(T);
                return true;
            }

            input = input.Replace(',', '.');

            Match m = ParserExpression.Match(input);
            if (!m.Success)
            {
                value = double.NaN;
                unit = default(T);
                return false;
            }

            value = double.Parse(m.Groups[1].Value, this);
            unit = this.GetUnit<T>(m.Groups[3].Value);
            return true;
        }

        /// <summary>
        ///     Gets the units.
        /// </summary>
        /// <typeparam name="T"> The type of units to get. </typeparam>
        /// <returns> A dictionary of units. </returns>
        public Dictionary<string, IQuantity> GetUnits<T>()
        {
            return this.GetUnits(typeof(T));
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
        /// <exception cref="InvalidOperationException">
        /// </exception>
        /// <exception cref="FormatException">
        /// </exception>
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
        /// Registers the units.
        /// </summary>
        /// <param name="a">
        /// The assembly. 
        /// </param>
        private void RegisterUnits(Assembly a)
        {
            foreach (Type t in a.GetTypes())
            {
                if (typeof(IQuantity).IsAssignableFrom(t))
                {
                    RegisterUnits(t);
                }
            }
        }

        /// <summary>
        /// Registers the static unit properties in the spedified type.
        /// </summary>
        /// <param name="t">
        /// The type. 
        /// </param>
        private void RegisterUnits(Type t)
        {
            foreach (var property in t.GetProperties(BindingFlags.Static | BindingFlags.Public))
            {
                foreach (UnitAttribute ua in property.GetCustomAttributes(typeof(UnitAttribute), false))
                {
                    this.RegisterUnit((IQuantity)property.GetValue(null, null), ua.Name);

                    if (ua.IsDefaultDisplayUnit)
                    {
                        this.SetDisplayUnit((IQuantity)property.GetValue(null, null), ua.Name);
                    }
                }
            }
        }

        /// <summary>
        ///     The unit definition.
        /// </summary>
        private struct UnitDefinition
        {
            /// <summary>
            ///     Gets or sets the name.
            /// </summary>
            public string Name { get; set; }

            /// <summary>
            ///     Gets or sets the unit.
            /// </summary>
            public object Unit { get; set; }
        }
    }
}