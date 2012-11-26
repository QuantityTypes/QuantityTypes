// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Csv.cs" company="Units.NET">
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
//   Provides methods to read Csv files.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Units
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Globalization;
    using System.IO;
    using System.Linq;

    /// <summary>
    /// Provides methods to read comma separated files with support for units.
    /// </summary>
    public static class Csv
    {
        /// <summary>
        /// Loads from the specified path.
        /// </summary>
        /// <typeparam name="T">The type of the output items.</typeparam>
        /// <param name="path">The path.</param>
        /// <param name="cultureInfo">The culture info.</param>
        /// <returns>An enumeration of the specified type.</returns>
        public static IList<T> Load<T>(string path, CultureInfo cultureInfo = null)
        {
            using (var r = new StreamReader(path))
            {
                return Load<T>(r, cultureInfo);
            }
        }

        /// <summary>
        /// Loads from the specified stream.
        /// </summary>
        /// <typeparam name="T">The type of the output items.</typeparam>
        /// <param name="stream">The stream.</param>
        /// <param name="cultureInfo">The culture info.</param>
        /// <returns>An enumeration of the specified type.</returns>
        public static IList<T> Load<T>(Stream stream, CultureInfo cultureInfo = null)
        {
            return Load<T>(new StreamReader(stream), cultureInfo);
        }

        /// <summary>
        /// Loads the specified stream reader.
        /// </summary>
        /// <typeparam name="T">The type of the output items.</typeparam>
        /// <param name="r">The reader.</param>
        /// <param name="cultureInfo">The culture info.</param>
        /// <returns>
        /// An enumeration of the specified type.
        /// </returns>
        /// <exception cref="System.FormatException">Unit  + unit +  not recognized</exception>
        public static IList<T> Load<T>(StreamReader r, CultureInfo cultureInfo = null)
        {
            if (cultureInfo == null)
            {
                cultureInfo = CultureInfo.InvariantCulture;
            }

            var separator = cultureInfo.TextInfo.ListSeparator;

            // Get the properties from the type
            var properties = TypeDescriptor.GetProperties(typeof(T));
            var header = r.ReadLine();
            if (header == null)
            {
                return null;
            }

            // Parse the header
            var headers = CsvFile.SplitLine(header, separator[0]);
            int n = headers.Length;
            var propertyDescriptors = new PropertyDescriptor[n];
            var units = new IQuantity[n];
            for (int i = 0; i < n; i++)
            {
                string name, unit;
                CsvFile.SplitHeader(headers[i], out name, out unit);
                propertyDescriptors[i] = properties.Find(name, false);

                // Set the unit if it is a IQuantity based property
                if (CsvFile.QuantityType.IsAssignableFrom(propertyDescriptors[i].PropertyType))
                {
                    IQuantity displayUnit;
                    if (UnitProvider.Default.TryGetUnit(propertyDescriptors[i].PropertyType, unit, out displayUnit))
                    {
                        units[i] = displayUnit;
                    }
                    else
                    {
                        throw new FormatException("Unit " + unit + " not recognized");
                    }
                }
            }

            var items = new List<T>();
            // Read the rows
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
                    propertyDescriptors[i].SetValue(item, value);
                }

                items.Add(item);
            }

            return items;
        }

        /// <summary>
        /// Saves the specified items to the specified file.
        /// </summary>
        /// <typeparam name="T">The type of the items</typeparam>
        /// <param name="items">The items.</param>
        /// <param name="path">The path.</param>
        /// <param name="cultureInfo">The culture info.</param>
        public static void Save<T>(IEnumerable<T> items, string path, CultureInfo cultureInfo = null)
        {
            using (var w = new StreamWriter(path))
            {
                Save(items, w, cultureInfo);
            }
        }

        /// <summary>
        /// Saves the specified items to the specified stream.
        /// </summary>
        /// <typeparam name="T">The type of the items</typeparam>
        /// <param name="items">The items.</param>
        /// <param name="stream">The stream.</param>
        /// <param name="cultureInfo">The culture info.</param>
        public static void Save<T>(IEnumerable<T> items, Stream stream, CultureInfo cultureInfo = null)
        {
            var writer = new StreamWriter(stream);
            Save(items, writer, cultureInfo);
            writer.Flush();
        }

        /// <summary>
        /// Saves the items to the specified stream writer.
        /// </summary>
        /// <typeparam name="T">The type of the items</typeparam>
        /// <param name="items">The items.</param>
        /// <param name="streamWriter">The stream writer.</param>
        /// <param name="cultureInfo">The culture info.</param>
        public static void Save<T>(IEnumerable<T> items, StreamWriter streamWriter, CultureInfo cultureInfo = null)
        {
            if (cultureInfo == null)
            {
                cultureInfo = CultureInfo.InvariantCulture;
            }

            var separator = cultureInfo.TextInfo.ListSeparator;

            var type = typeof(T);
            var properties = TypeDescriptor.GetProperties(type).Cast<PropertyDescriptor>().OrderBy(CsvColumnAttribute.GetColumn).ToList();
            int n = properties.Count;
            var displayUnits = new IQuantity[n];

            for (int i = 0; i < n; i++)
            {
                if (i > 0)
                {
                    streamWriter.Write(separator);
                }

                streamWriter.Write(properties[i].Name);
                if (CsvFile.QuantityType.IsAssignableFrom(properties[i].PropertyType))
                {
                    string unitSymbol;
                    displayUnits[i] = UnitProvider.Default.GetDisplayUnit(properties[i].PropertyType, out unitSymbol);
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

                    var value = properties[i].GetValue(item);
                    if (IsUndefined(value))
                    {
                        continue;
                    }

                    var q = value as IQuantity;
                    streamWriter.Write(
                        q != null
                            ? string.Format(cultureInfo, "{0}", q.ConvertTo(displayUnits[i]))
                            : string.Format(cultureInfo, "{0}", value));
                }
            }
        }

        /// <summary>
        /// Determines whether the specified value is undefined.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <returns><c>true</c> if the specified value is undefined; otherwise, <c>false</c>.</returns>
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
        /// Converts a string to the specified type.
        /// </summary>
        /// <param name="s">
        /// The input string.
        /// </param>
        /// <param name="type">
        /// The type.
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

            if (CsvFile.QuantityType.IsAssignableFrom(type))
            {
                double value = double.Parse(s, provider);
                return unit.MultiplyBy(value);
            }

            return Convert.ChangeType(s, type);
        }
    }
}