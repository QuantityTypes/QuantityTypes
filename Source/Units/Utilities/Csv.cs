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
        #region Public Methods and Operators

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
        /// Loads from the specified path.
        /// </summary>
        /// <typeparam name="T">
        /// The type of the output items.
        /// </typeparam>
        /// <param name="path">
        /// The path.
        /// </param>
        /// <param name="cultureInfo">
        /// The culture info.
        /// </param>
        /// <returns>
        /// An enumeration of the specified type.
        /// </returns>
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
        /// Loads items from the specified stream reader.
        /// </summary>
        /// <typeparam name="T">
        /// The type of the output items.
        /// </typeparam>
        /// <param name="r">
        /// The reader.
        /// </param>
        /// <param name="cultureInfo">
        /// The culture info.
        /// </param>
        /// <returns>
        /// An enumeration of the specified type.
        /// </returns>
        /// <exception cref="System.FormatException">
        /// Unit  + unit +  not recognized
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
            var properties = TypeDescriptor.GetProperties(type);
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
                    propertyDescriptors[i].SetValue(item, value);
                }

                items.Add(item);
            }

            return items;
        }

        /// <summary>
        /// Loads a list of quantities from the specified path.
        /// </summary>
        /// <typeparam name="T">
        /// The type of the output items.
        /// </typeparam>
        /// <param name="path">
        /// The path.
        /// </param>
        /// <param name="cultureInfo">
        /// The culture info.
        /// </param>
        /// <returns>
        /// An enumeration of the specified type.
        /// </returns>
        public static IList<T> LoadQuantities<T>(string path, CultureInfo cultureInfo = null) where T : IQuantity
        {
            using (var r = new StreamReader(path))
            {
                return LoadQuantities<T>(r, cultureInfo);
            }
        }

        /// <summary>
        /// Loads a list of quantities from the specified stream.
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
        /// Loads quantities from the specified stream reader.
        /// </summary>
        /// <typeparam name="T">
        /// The type of the output items.
        /// </typeparam>
        /// <param name="r">
        /// The reader.
        /// </param>
        /// <param name="cultureInfo">
        /// The culture info.
        /// </param>
        /// <returns>
        /// An enumeration of the specified type.
        /// </returns>
        /// <exception cref="System.FormatException">
        /// Unit  + unit +  not recognized
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
        /// Saves the specified items to the specified file.
        /// </summary>
        /// <typeparam name="T">
        /// The type of the items
        /// </typeparam>
        /// <param name="items">
        /// The items.
        /// </param>
        /// <param name="path">
        /// The path.
        /// </param>
        /// <param name="cultureInfo">
        /// The culture info.
        /// </param>
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
        /// Saves the items to the specified stream writer.
        /// </summary>
        /// <typeparam name="T">
        /// The type of the items
        /// </typeparam>
        /// <param name="items">
        /// The items.
        /// </param>
        /// <param name="streamWriter">
        /// The stream writer.
        /// </param>
        /// <param name="cultureInfo">
        /// The culture info.
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
                TypeDescriptor.GetProperties(type)
                              .Cast<PropertyDescriptor>()
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
        /// Saves the specified items to the specified file.
        /// </summary>
        /// <typeparam name="T">
        /// The type of the items
        /// </typeparam>
        /// <param name="items">
        /// The items.
        /// </param>
        /// <param name="path">
        /// The path.
        /// </param>
        /// <param name="cultureInfo">
        /// The culture info.
        /// </param>
        public static void SaveQuantities<T>(IEnumerable<T> items, string path, CultureInfo cultureInfo = null)
            where T : IQuantity
        {
            using (var w = new StreamWriter(path))
            {
                SaveQuantities(items, w, cultureInfo);
            }
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
        public static void SaveQuantities<T>(IEnumerable<T> items, Stream stream, CultureInfo cultureInfo = null)
            where T : IQuantity
        {
            var writer = new StreamWriter(stream);
            SaveQuantities(items, writer, cultureInfo);
            writer.Flush();
        }

        /// <summary>
        /// Saves the quantities to the specified stream writer.
        /// </summary>
        /// <typeparam name="T">
        /// The type of the items
        /// </typeparam>
        /// <param name="items">
        /// The items.
        /// </param>
        /// <param name="streamWriter">
        /// The stream writer.
        /// </param>
        /// <param name="cultureInfo">
        /// The culture info.
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

                streamWriter.Write(
                    q != null
                        ? string.Format(cultureInfo, "{0}", q.ConvertTo(displayUnit))
                        : string.Format(cultureInfo, "{0}", q));
            }
        }

        #endregion

        #region Methods

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

            var underlyingType = Nullable.GetUnderlyingType(type);
            if (underlyingType != null)
            {
                type = underlyingType;
            }

            if (CsvFile.QuantityType.IsAssignableFrom(type))
            {
                if (string.IsNullOrWhiteSpace(s) && underlyingType != null)
                {
                    return null;
                }

                double value = !string.IsNullOrWhiteSpace(s) ? double.Parse(s, provider) : 0;
                return unit.MultiplyBy(value);
            }

            return Convert.ChangeType(s, type);
        }

        #endregion
    }
}