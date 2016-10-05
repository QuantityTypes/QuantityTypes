// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Csv.cs" company="QuantityTypes">
//   Copyright (c) 2014 QuantityTypes contributors
// </copyright>
// <summary>
//   Provides methods to read and write comma separated files with support for units.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace QuantityTypes.Csv
{
    using System;
    using System.Collections.Generic;
    using System.Globalization;
    using System.IO;
    using System.Linq;
    using System.Reflection;

    /// <summary>
    /// Provides methods to read and write comma separated files with support for units.
    /// </summary>
    public static class Csv
    {
        /// <summary>
        /// Determines whether the specified value is undefined.
        /// </summary>
        /// <param name="value">
        /// The value.
        /// </param>
        /// <returns>
        /// <c>true</c> if the specified value is undefined; otherwise, <c>false</c>.
        /// </returns>
        public static bool IsUndefined(object value)
        {
            if (value is double && double.IsNaN((double)value))
            {
                return true;
            }

            if (value is IQuantity && double.IsNaN(((IQuantity)value).Value))
            {
                return true;
            }

            return false;
        }

        /// <summary>
        /// Loads from the specified stream.
        /// </summary>
        /// <typeparam name="T">
        /// The type of the output items.
        /// </typeparam>
        /// <param name="stream">
        /// The stream.
        /// </param>
        /// <param name="cultureInfo">
        /// The culture info.
        /// </param>
        /// <returns>
        /// An enumeration of the specified type.
        /// </returns>
        public static IList<T> Load<T>(Stream stream, CultureInfo cultureInfo = null)
        {
            return Load<T>(new StreamReader(stream), cultureInfo);
        }

        /// <summary>
        /// Loads items from the specified <see cref="StreamReader"/>.
        /// </summary>
        /// <typeparam name="T">
        /// The type of the output items.
        /// </typeparam>
        /// <param name="r">
        /// The input <see cref="StreamReader"/>.
        /// </param>
        /// <param name="cultureInfo">
        /// The input culture.
        /// </param>
        /// <returns>
        /// A list of items.
        /// </returns>
        /// <exception cref="System.FormatException">
        /// Unit not recognized
        /// </exception>
        public static IList<T> Load<T>(StreamReader r, CultureInfo cultureInfo = null)
        {
            if (cultureInfo == null)
            {
                cultureInfo = CultureInfo.InvariantCulture;
            }

            var separator = cultureInfo.TextInfo.ListSeparator;
            var type = typeof(T);

            // Get the properties from the type
            var properties = type.GetTypeInfo().DeclaredProperties.ToArray();
            var header = r.ReadLine();
            if (header == null)
            {
                return null;
            }

            // Parse the header
            var headers = CsvFile.SplitLine(header, separator[0]);
            int n = headers.Length;
            var propertyDescriptors = new PropertyInfo[n];
            var units = new IQuantity[n];
            for (int i = 0; i < n; i++)
            {
                string name, unit;
                CsvFile.SplitHeader(headers[i], out name, out unit);
                propertyDescriptors[i] = properties.First(pi => pi.Name == name);
                var quantityType = CsvFile.GetQuantityType(propertyDescriptors[i].PropertyType);

                // Set the unit if it is a IQuantity based property
                if (quantityType != null)
                {
                    IQuantity displayUnit;
                    if (UnitProvider.Default.TryGetUnit(quantityType, unit, out displayUnit))
                    {
                        units[i] = displayUnit;
                    }
                    else
                    {
                        throw new FormatException("Unit " + unit + " not recognized");
                    }
                }
            }

            // Read the rows
            var items = new List<T>();
            int lineNumber = 1;
            while (!r.EndOfStream)
            {
                lineNumber++;
                var line = r.ReadLine();
                if (line == null)
                {
                    continue;
                }

                var values = CsvFile.SplitLine(line, separator[0]);
                if (values.Length != n)
                {
                    throw new FormatException("Wrong number of columns on line " + lineNumber);
                }

                var item = Activator.CreateInstance<T>();
                for (int i = 0; i < headers.Length; i++)
                {
                    var value = ChangeType(values[i], propertyDescriptors[i].PropertyType, units[i], cultureInfo);
                    propertyDescriptors[i].SetValue(item, value, null);
                }

                items.Add(item);
            }

            return items;
        }

        /// <summary>
        /// Loads a list of quantities from the specified <see cref="Stream"/>.
        /// </summary>
        /// <typeparam name="T">
        /// The type of the output items.
        /// </typeparam>
        /// <param name="stream">
        /// The stream.
        /// </param>
        /// <param name="cultureInfo">
        /// The culture info.
        /// </param>
        /// <returns>
        /// An enumeration of the specified type.
        /// </returns>
        public static IList<T> LoadQuantities<T>(Stream stream, CultureInfo cultureInfo = null) where T : IQuantity
        {
            return LoadQuantities<T>(new StreamReader(stream), cultureInfo);
        }

        /// <summary>
        /// Loads quantities from the specified <see cref="StreamReader"/>.
        /// </summary>
        /// <typeparam name="T">
        /// The type of the output items.
        /// </typeparam>
        /// <param name="r">
        /// The input <see cref="StreamReader"/>.
        /// </param>
        /// <param name="cultureInfo">
        /// The culture.
        /// </param>
        /// <returns>
        /// A list of items.
        /// </returns>
        /// <exception cref="System.FormatException">
        /// Unit not recognized
        /// </exception>
        public static IList<T> LoadQuantities<T>(StreamReader r, CultureInfo cultureInfo = null) where T : IQuantity
        {
            if (cultureInfo == null)
            {
                cultureInfo = CultureInfo.InvariantCulture;
            }

            var type = typeof(T);

            // Get the properties from the type
            var header = r.ReadLine();
            if (header == null)
            {
                return null;
            }

            // Parse the header
            string name, unit;
            CsvFile.SplitHeader(header, out name, out unit);

            IQuantity displayUnit;
            if (UnitProvider.Default.TryGetUnit(type, unit, out displayUnit))
            {
            }
            else
            {
                throw new FormatException("Unit " + unit + " not recognized");
            }

            // Read the rows
            var items = new List<T>();
            while (!r.EndOfStream)
            {
                var line = r.ReadLine();
                if (line == null)
                {
                    continue;
                }

                var value = ChangeType(line, type, displayUnit, cultureInfo);
                items.Add((T)value);
            }

            return items;
        }

        /// <summary>
        /// Saves the specified items to the specified stream.
        /// </summary>
        /// <typeparam name="T">
        /// The type of the items
        /// </typeparam>
        /// <param name="items">
        /// The items.
        /// </param>
        /// <param name="stream">
        /// The stream.
        /// </param>
        /// <param name="cultureInfo">
        /// The culture info.
        /// </param>
        public static void Save<T>(IEnumerable<T> items, Stream stream, CultureInfo cultureInfo = null)
        {
            var writer = new StreamWriter(stream);
            Save(items, writer, cultureInfo);
            writer.Flush();
        }

        /// <summary>
        /// Saves the items to the specified <see cref="StreamWriter"/>.
        /// </summary>
        /// <typeparam name="T">
        /// The type of the items
        /// </typeparam>
        /// <param name="items">
        /// The items.
        /// </param>
        /// <param name="streamWriter">
        /// The <see cref="StreamWriter"/>.
        /// </param>
        /// <param name="cultureInfo">
        /// The output culture.
        /// </param>
        public static void Save<T>(IEnumerable<T> items, StreamWriter streamWriter, CultureInfo cultureInfo = null)
        {
            if (cultureInfo == null)
            {
                cultureInfo = CultureInfo.InvariantCulture;
            }

            var separator = cultureInfo.TextInfo.ListSeparator;

            var type = typeof(T);
            var properties =
                type.GetTypeInfo().DeclaredProperties
                              .Where(CsvIgnoreAttribute.IsNotIgnored)
                              .OrderBy(CsvColumnAttribute.GetColumn)
                              .ToList();
            int n = properties.Count;
            var displayUnits = new IQuantity[n];

            for (int i = 0; i < n; i++)
            {
                if (i > 0)
                {
                    streamWriter.Write(separator);
                }

                streamWriter.Write(properties[i].Name);
                var quantityType = CsvFile.GetQuantityType(properties[i].PropertyType);

                if (quantityType != null)
                {
                    string unitSymbol;
                    displayUnits[i] = UnitProvider.Default.GetDisplayUnit(quantityType, out unitSymbol);
                    streamWriter.Write(" [{0}]", unitSymbol);
                }
            }

            streamWriter.WriteLine();

            int j = 0;
            foreach (var item in items)
            {
                if (j++ > 0)
                {
                    streamWriter.WriteLine();
                }

                for (int i = 0; i < n; i++)
                {
                    if (i > 0)
                    {
                        streamWriter.Write(separator);
                    }

                    var value = properties[i].GetValue(item, null);

                    var q = value as IQuantity;
                    if (q != null && displayUnits[i] != null)
                    {
                        streamWriter.Write(string.Format(cultureInfo, "{0}", q.ConvertTo(displayUnits[i])));
                    }
                    else
                    {
                        streamWriter.Write(string.Format(cultureInfo, "{0}", value));
                    }
                }
            }
        }

        /// <summary>
        /// Saves the specified items to the specified <see cref="Stream"/>.
        /// </summary>
        /// <typeparam name="T">
        /// The type of the items
        /// </typeparam>
        /// <param name="items">
        /// The items.
        /// </param>
        /// <param name="stream">
        /// The output <see cref="Stream"/>.
        /// </param>
        /// <param name="cultureInfo">
        /// The output culture.
        /// </param>
        public static void SaveQuantities<T>(IEnumerable<T> items, Stream stream, CultureInfo cultureInfo = null)
            where T : IQuantity
        {
            var writer = new StreamWriter(stream);
            SaveQuantities(items, writer, cultureInfo);
            writer.Flush();
        }

        /// <summary>
        /// Saves the quantities to the specified <see cref="StreamWriter"/>.
        /// </summary>
        /// <typeparam name="T">
        /// The type of the items
        /// </typeparam>
        /// <param name="items">
        /// The items.
        /// </param>
        /// <param name="streamWriter">
        /// The output <see cref="StreamWriter"/>.
        /// </param>
        /// <param name="cultureInfo">
        /// The output culture.
        /// </param>
        public static void SaveQuantities<T>(
            IEnumerable<T> items, StreamWriter streamWriter, CultureInfo cultureInfo = null) where T : IQuantity
        {
            if (cultureInfo == null)
            {
                cultureInfo = CultureInfo.InvariantCulture;
            }

            var type = typeof(T);

            // Header
            streamWriter.Write(type.Name);
            string unitSymbol;
            var displayUnit = UnitProvider.Default.GetDisplayUnit(type, out unitSymbol);
            streamWriter.Write(" [{0}]", unitSymbol);
            streamWriter.WriteLine();

            // Items
            int k = 0;
            foreach (var item in items)
            {
                if (k++ > 0)
                {
                    streamWriter.WriteLine();
                }

                var q = item as IQuantity;
                if (IsUndefined(q))
                {
                    continue;
                }

                if (q != null)
                {
                    streamWriter.Write(string.Format(cultureInfo, "{0}", q.ConvertTo(displayUnit)));
                }
            }
        }

        /// <summary>
        /// Converts a string to the specified type.
        /// </summary>
        /// <param name="s">
        /// The input string.
        /// </param>
        /// <param name="type">
        /// The target type.
        /// </param>
        /// <param name="unit">
        /// The unit (only used if type is an IQuantity).
        /// </param>
        /// <param name="provider">
        /// The provider.
        /// </param>
        /// <returns>
        /// The converted value.
        /// </returns>
        private static object ChangeType(string s, Type type, IQuantity unit, IFormatProvider provider)
        {
            if (type == typeof(int))
            {
                return int.Parse(s);
            }

            if (type == typeof(double))
            {
                return double.Parse(s, provider);
            }

            var underlyingType = Nullable.GetUnderlyingType(type);
            if (underlyingType != null)
            {
                type = underlyingType;
            }

            if (CsvFile.QuantityType.GetTypeInfo().IsAssignableFrom(type.GetTypeInfo()))
            {
                if (string.IsNullOrEmpty(s) && underlyingType != null)
                {
                    return null;
                }

                double value = !string.IsNullOrEmpty(s) ? double.Parse(s, provider) : 0;
                return unit.MultiplyBy(value);
            }

            return Convert.ChangeType(s, type, provider);
        }
    }
}