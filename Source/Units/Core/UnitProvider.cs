namespace Units
{
    using System;
    using System.Collections.Generic;
    using System.Globalization;
    using System.Reflection;
    using System.Text.RegularExpressions;

    /// <summary>
    /// Implements a unit provider.
    /// </summary>
    /// <remarks></remarks>
    public class UnitProvider : IUnitProvider
    {
        /// <summary>
        /// Gets the default unit provider.
        /// </summary>
        /// <remarks></remarks>
        public static IUnitProvider Default { get; private set; }

        /// <summary>
        /// Gets or sets the culture.
        /// </summary>
        /// <value>The culture.</value>
        /// <remarks></remarks>
        public CultureInfo Culture { get; set; }

        /// <summary>
        /// Gets or sets the separator.
        /// </summary>
        /// <value>The separator.</value>
        /// <remarks></remarks>
        public string Separator { get; set; }

        /// <summary>
        /// Initializes the <see cref="UnitProvider"/> class.
        /// </summary>
        /// <remarks></remarks>
        static UnitProvider()
        {
            var up = new UnitProvider(typeof(Length).Assembly);
            Default = up;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="UnitProvider"/> class.
        /// </summary>
        /// <param name="a">A.</param>
        /// <param name="culture">The culture.</param>
        /// <remarks></remarks>
        public UnitProvider(Assembly a, CultureInfo culture = null)
            : this(culture)
        {
            RegisterUnits(a);
        }

        /// <summary>
        /// Registers the units.
        /// </summary>
        /// <param name="a">A.</param>
        /// <remarks></remarks>
        private void RegisterUnits(Assembly a)
        {
            foreach (var t in a.GetTypes())
            {
                if (typeof(IQuantity).IsAssignableFrom(t))
                    RegisterUnits(t);
            }
        }

        /// <summary>
        /// Registers the units.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <remarks></remarks>
        private void RegisterUnits<T>() where T : IQuantity
        {
            RegisterUnits(typeof(T));
        }

        /// <summary>
        /// Registers the units.
        /// </summary>
        /// <param name="t">The t.</param>
        /// <remarks></remarks>
        private void RegisterUnits(Type t)
        {
            foreach (var field in t.GetFields(BindingFlags.Static | BindingFlags.Public))
            {
                foreach (UnitAttribute ua in field.GetCustomAttributes(typeof(UnitAttribute), false))
                {
                    this.RegisterUnit((IQuantity)field.GetValue(null), ua.Name);

                    if (ua.IsDefaultDisplayUnit)
                    {
                        this.SetDisplayUnit((IQuantity)field.GetValue(null), ua.Name);
                    }
                }
            }
        }

        /// <summary>
        /// Registers the unit.
        /// </summary>
        /// <param name="unit">The unit.</param>
        /// <param name="name">The name.</param>
        /// <remarks></remarks>
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

        private Dictionary<Type, UnitDefinition> displayUnits;

        private Dictionary<Type, Dictionary<string, IQuantity>> units;

        /// <summary>
        /// Initializes a new instance of the <see cref="UnitProvider"/> class.
        /// </summary>
        /// <param name="culture">The culture.</param>
        /// <remarks></remarks>
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
        /// Sets the display unit.
        /// </summary>
        /// <param name="q">The q.</param>
        /// <param name="name">The name.</param>
        /// <remarks></remarks>
        public void SetDisplayUnit(IQuantity q, string name)
        {
            this.displayUnits[q.GetType()] = new UnitDefinition { Name = name, Unit = q };
        }

        /// <summary>
        /// Tries the get display unit.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="q">The q.</param>
        /// <param name="unit">The unit.</param>
        /// <returns></returns>
        /// <remarks></remarks>
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

        private static Regex parserExpression = new Regex(@"([-+]?[0-9]*\.?[0-9]+([eE][-+]?[0-9]+)?)\s*([a-z\*\/]*)", RegexOptions.Compiled);
        private static Regex formatExpression = new Regex(@"([0#]*\.?[0#]*)\s*([a-z\*\/]*)", RegexOptions.Compiled);

        /// <summary>
        /// Parses a string.
        /// </summary>
        /// <typeparam name="T">The type.</typeparam>
        /// <param name="input">The input string.</param>
        /// <param name="value">The value (output).</param>
        /// <param name="unit">The unit (output).</param>
        /// <returns>True if the parsing was successful.</returns>
        /// <remarks></remarks>
        public bool TryParse<T>(string input, out double value, out T unit)
        {
            input = input.Replace(',', '.');

            var m = parserExpression.Match(input);
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
        /// Formats the specified format.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="format">The format.</param>
        /// <param name="length">The length.</param>
        /// <returns></returns>
        /// <remarks></remarks>
        public string Format<T>(string format, T length) where T : IQuantity<T>
        {
            T q = default(T);
            string unit = default(string);
            if (!string.IsNullOrEmpty(format))
            {
                var m = formatExpression.Match(format);
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

            var s = length.ConvertTo(q).ToString(format, this);
            return string.Format("{0}{1}{2}", s, this.Separator, unit);
        }

        /// <summary>
        /// Gets the units.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        /// <remarks></remarks>
        public Dictionary<string, IQuantity> GetUnits<T>()
        {
            return GetUnits(typeof(T));
        }

        /// <summary>
        /// Gets the registered units of the specified type.
        /// </summary>
        /// <param name="type">The type.</param>
        /// <returns>The registered units.</returns>
        /// <remarks></remarks>
        public Dictionary<string, IQuantity> GetUnits(Type type)
        {
            return units[type];
        }

        /// <summary>
        /// Gets the first registered unit (of any quantity type) that matches the specified name.
        /// </summary>
        /// <param name="name">The name.</param>
        /// <returns>The unit.</returns>
        /// <remarks></remarks>
        public IQuantity GetUnit(string name)
        {
            foreach (var u in units.Values)
            {
                IQuantity v;
                if (u.TryGetValue(name, out v)) return v;
            }

            return null;
        }

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
        /// Returns an object that provides formatting services for the specified type.
        /// </summary>
        /// <param name="formatType">An object that specifies the type of format object to return.</param>
        /// <returns>An instance of the object specified by <paramref name="formatType"/>, if the <see cref="T:System.IFormatProvider"/> implementation can supply that type of object; otherwise, null.</returns>
        /// <remarks></remarks>
        public object GetFormat(Type formatType)
        {
            return Culture.GetFormat(formatType);
        }

        private struct UnitDefinition
        {
            public string Name { get; set; }
            public object Unit { get; set; }
        }

    }
}