// --------------------------------------------------------------------------------------------------------------------
// <copyright file="CsvFile.cs" company="QuantityTypes">
//   Copyright (c) 2014 QuantityTypes contributors
// </copyright>
// <summary>
//   Represents a comma separated file that supports units and reflection of the rows.
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
    using System.Text.RegularExpressions;

    /// <summary>
    /// Represents a comma separated file that supports units and reflection of the rows.
    /// </summary>
    /// <remarks>
    /// See <a href="http://en.wikipedia.org/wiki/Comma-separated_values">Comma-separated values</a>.
    /// </remarks>
    public class CsvFile
    {
        /// <summary>
        /// The quantity type
        /// </summary>
        internal static readonly Type QuantityType = typeof(IQuantity);

        /// <summary>
        /// Prevents a default instance of the <see cref="CsvFile" /> class from being created.
        /// </summary>
        private CsvFile()
        {
            this.Columns = new List<CsvColumn>();
            this.Rows = new List<CsvRow>();
        }

        /// <summary>
        /// Gets the columns.
        /// </summary>
        /// <value>The columns.</value>
        public List<CsvColumn> Columns { get; private set; }

        /// <summary>
        /// Gets the rows.
        /// </summary>
        /// <value>The rows.</value>
        public List<CsvRow> Rows { get; private set; }

        /// <summary>
        /// Loads the specified items into a <see cref="CsvFile" />.
        /// </summary>
        /// <typeparam name="T">The type of the items</typeparam>
        /// <param name="items">The items.</param>
        /// <param name="unitProvider">The unit provider.</param>
        /// <returns>A <see cref="CsvFile" />.</returns>
        public static CsvFile Load<T>(IEnumerable<T> items, IUnitProvider unitProvider = null)
        {
            var type = typeof(T);
            var properties = type.GetTypeInfo().DeclaredProperties.OrderBy(CsvColumnAttribute.GetColumn).ToList();

            var file = new CsvFile();
            foreach (var p in properties)
            {
                file.Columns.Add(new CsvColumn(p.Name, string.Empty, p.PropertyType, unitProvider));
            }

            foreach (var item in items)
            {
                var csvRow = new CsvRow(file);
                for (int i = 0; i < properties.Count; i++)
                {
                    csvRow.Values[i] = properties[i].GetValue(item, null);
                }

                file.Rows.Add(csvRow);
            }

            return file;
        }

        /// <summary>
        /// Loads from the specified stream.
        /// </summary>
        /// <param name="s">The stream.</param>
        /// <param name="cultureInfo">The culture info.</param>
        /// <returns>
        /// A <see cref="CsvFile" />.
        /// </returns>
        public static CsvFile Load(Stream s, CultureInfo cultureInfo = null)
        {
            return Load(new StreamReader(s), cultureInfo);
        }

        /// <summary>
        /// Loads from the specified stream reader.
        /// </summary>
        /// <param name="s">The stream reader.</param>
        /// <param name="cultureInfo">The culture info.</param>
        /// <returns>
        /// A <see cref="CsvFile" />.
        /// </returns>
        /// <exception cref="System.ArgumentNullException">s;The stream reader must be specified.</exception>
        /// <exception cref="System.InvalidOperationException">Invalid header.</exception>
        /// <exception cref="System.FormatException">Wrong number of columns on line  + lineNumber</exception>
        public static CsvFile Load(StreamReader s, CultureInfo cultureInfo = null)
        {
            if (s == null)
            {
                throw new ArgumentNullException("s", "The stream reader must be specified.");
            }

            if (cultureInfo == null)
            {
                cultureInfo = CultureInfo.InvariantCulture;
            }

            var separator = cultureInfo.TextInfo.ListSeparator;

            var headerLine = s.ReadLine();
            if (headerLine == null)
            {
                throw new InvalidOperationException("Invalid header.");
            }

            var headers = SplitLine(headerLine, separator[0]);
            int n = headers.Length;

            // Create a string collection for each column
            var items = new ValueList[n];
            for (int i = 0; i < n; i++)
            {
                items[i] = new ValueList();
            }

            // Read all rows
            int lineNumber = 1;
            while (!s.EndOfStream)
            {
                lineNumber++;
                var line = s.ReadLine();
                if (line == null)
                {
                    continue;
                }

                var fields = SplitLine(line, separator[0]);
                if (fields.Length != n)
                {
                    throw new FormatException("Wrong number of columns on line " + lineNumber);
                }

                for (int i = 0; i < n; i++)
                {
                    items[i].Add(fields[i]);
                }
            }

            var file = new CsvFile();

            // Determine the type of each column from the data
            for (int i = 0; i < n; i++)
            {
                string name, unit;
                SplitHeader(headers[i], out name, out unit);

                file.Columns.Add(new CsvColumn(name, unit, items[i].GetSmallestCommonType(cultureInfo)));
            }

            // Parse the values (and box them)
            for (int j = 0; j < items[0].Count; j++)
            {
                var item = new CsvRow(file);
                for (int i = 0; i < file.Columns.Count; i++)
                {
                    item.Values[i] = file.Columns[i].Convert(items[i][j], cultureInfo);
                }

                file.Rows.Add(item);
            }

            return file;
        }

        /// <summary>
        /// Gets the (underlying) quantity type or null if the type is not a quantity type.
        /// </summary>
        /// <param name="type">The type.</param>
        /// <returns>The quantity type, or null.</returns>
        public static Type GetQuantityType(Type type)
        {
            type = Nullable.GetUnderlyingType(type) ?? type;
            return QuantityType.GetTypeInfo().IsAssignableFrom(type.GetTypeInfo()) ? type : null;
        }

        /// <summary>
        /// Saves the csv file to the specified <see cref="Stream"/>.
        /// </summary>
        /// <param name="stream">The output <see cref="Stream"/>.</param>
        /// <param name="cultureInfo">The output culture.</param>
        /// <param name="unitProvider">The unit provider.</param>
        public void Save(Stream stream, CultureInfo cultureInfo = null, IUnitProvider unitProvider = null)
        {
            var writer = new StreamWriter(stream);
            this.Save(writer, cultureInfo, unitProvider);
            writer.Flush();
        }

        /// <summary>
        /// Saves the csv file to the specified <see cref="StreamWriter"/>.
        /// </summary>
        /// <param name="streamWriter">The output <see cref="StreamWriter"/>.</param>
        /// <param name="cultureInfo">The output culture.</param>
        /// <param name="unitProvider">The unit provider.</param>
        public void Save(StreamWriter streamWriter, CultureInfo cultureInfo = null, IUnitProvider unitProvider = null)
        {
            if (unitProvider == null)
            {
                unitProvider = UnitProvider.Default;
            }

            if (cultureInfo == null)
            {
                cultureInfo = unitProvider.Culture ?? CultureInfo.InvariantCulture;
            }

            var separator = cultureInfo.TextInfo.ListSeparator;

            for (int i = 0; i < this.Columns.Count; i++)
            {
                if (i > 0)
                {
                    streamWriter.Write(separator);
                }

                streamWriter.Write(this.Columns[i]);
            }

            var displayUnit =
                this.Columns.Select(
                    c =>
                        {
                            var qt = GetQuantityType(c.Type);
                            string symbol;
                            return qt != null ? unitProvider.GetDisplayUnit(qt, out symbol) : null;
                        }).ToList();

            streamWriter.WriteLine();

            for (int j = 0; j < this.Rows.Count; j++)
            {
                if (j > 0)
                {
                    streamWriter.WriteLine();
                }

                for (int i = 0; i < this.Columns.Count; i++)
                {
                    if (i > 0)
                    {
                        streamWriter.Write(separator);
                    }

                    var value = this.Rows[j].Values[i];
                    if (Csv.IsUndefined(value))
                    {
                        continue;
                    }

                    var q = value as IQuantity;
                    streamWriter.Write(
                        q != null
                            ? string.Format(cultureInfo, "{0}", q.ConvertTo(displayUnit[i]))
                            : string.Format(cultureInfo, "{0}", value));
                }
            }
        }

        /// <summary>
        /// Splits a line by the specified separator.
        /// </summary>
        /// <param name="line">
        /// The line.
        /// </param>
        /// <param name="separator">
        /// The separator.
        /// </param>
        /// <returns>
        /// An array of strings.
        /// </returns>
        internal static string[] SplitLine(string line, char separator)
        {
            return line.Split(separator);
        }

        /// <summary>
        /// Splits a header string in property name and unit.
        /// </summary>
        /// <param name="header">
        /// The header.
        /// </param>
        /// <param name="name">
        /// The property name.
        /// </param>
        /// <param name="unit">
        /// The unit.
        /// </param>
        internal static void SplitHeader(string header, out string name, out string unit)
        {
            if (header == null)
            {
                throw new ArgumentNullException("header", "The header should be specified.");
            }

            var m = Regex.Match(header, @"^(.*?)\s*(\[(.*)\])?$");
            if (m.Success)
            {
                name = m.Groups[1].Value;
                unit = m.Groups[3].Value;
            }
            else
            {
                name = header;
                unit = string.Empty;
            }
        }

        /// <summary>
        /// Represents a column in the <see cref="CsvFile"/>.
        /// </summary>
        public class CsvColumn
        {
            /// <summary>
            /// Initializes a new instance of the <see cref="CsvColumn" /> class.
            /// </summary>
            /// <param name="name">The name.</param>
            /// <param name="unit">The unit.</param>
            /// <param name="type">The type.</param>
            /// <param name="unitProvider">The unit provider.</param>
            public CsvColumn(string name, string unit, Type type, IUnitProvider unitProvider = null)
            {
                this.Name = name;
                this.Type = type;
                var qt = GetQuantityType(type);
                this.Unit = qt != null ? (unitProvider ?? UnitProvider.Default).GetDisplayUnit(qt) : unit;
            }

            /// <summary>
            /// Gets the unit.
            /// </summary>
            /// <value>
            /// The unit.
            /// </value>
            public string Unit { get; private set; }

            /// <summary>
            /// Gets the type.
            /// </summary>
            /// <value>
            /// The type.
            /// </value>
            public Type Type { get; private set; }

            /// <summary>
            /// Gets or sets the name.
            /// </summary>
            /// <value>
            /// The name.
            /// </value>
            public string Name { get; set; }

            /// <summary>
            /// Returns a <see cref="System.String" /> that represents this instance.
            /// </summary>
            /// <returns>
            /// A <see cref="System.String" /> that represents this instance.
            /// </returns>
            public override string ToString()
            {
                if (string.IsNullOrEmpty(this.Unit))
                {
                    return this.Name;
                }

                return string.Format("{0} [{1}]", this.Name, this.Unit);
            }

            /// <summary>
            /// Converts the specified string to the type specified in this column.
            /// </summary>
            /// <param name="input">
            /// The input string.
            /// </param>
            /// <param name="provider">
            /// The provider.
            /// </param>
            /// <returns>
            /// The converted value.
            /// </returns>
            public object Convert(string input, IFormatProvider provider)
            {
                if (this.Type == typeof(int))
                {
                    return int.Parse(input, provider);
                }

                if (this.Type == typeof(double))
                {
                    return double.Parse(input, provider);
                }

                return input;
            }
        }

#if NET45
        /// <summary>
        /// Provides a property descriptor for an object in the <see cref="CsvRow" />.
        /// </summary>
        public class CsvPropertyDescriptor : PropertyDescriptor
        {
            /// <summary>
            /// The column
            /// </summary>
            private readonly CsvColumn column;

            /// <summary>
            /// The index
            /// </summary>
            private readonly int index;

            /// <summary>
            /// Initializes a new instance of the <see cref="CsvPropertyDescriptor"/> class.
            /// </summary>
            /// <param name="column">
            /// The column.
            /// </param>
            /// <param name="index">
            /// The index.
            /// </param>
            public CsvPropertyDescriptor(CsvColumn column, int index)
                : base(column.Name, null)
            {
                this.column = column;
                this.index = index;
            }

            /// <summary>
            /// When overridden in a derived class, gets the type of the component this property is bound to.
            /// </summary>
            /// <value> </value>
            /// <returns> A <see cref="T:System.Type" /> that represents the type of component this property is bound to. When the <see
            /// cref="M:System.ComponentModel.PropertyDescriptor.GetValue(System.Object)" /> or <see
            /// cref="M:System.ComponentModel.PropertyDescriptor.SetValue(System.Object,System.Object)" /> methods are invoked, the object specified might be an instance of this type. </returns>
            public override Type ComponentType
            {
                get
                {
                    return typeof(CsvRow);
                }
            }

            /// <summary>
            /// When overridden in a derived class, gets a value indicating whether this property is read-only.
            /// </summary>
            /// <value> </value>
            /// <returns> true if the property is read-only; otherwise, false. </returns>
            public override bool IsReadOnly
            {
                get
                {
                    return false;
                }
            }

            /// <summary>
            /// When overridden in a derived class, gets the type of the property.
            /// </summary>
            /// <value> </value>
            /// <returns> A <see cref="T:System.Type" /> that represents the type of the property. </returns>
            public override Type PropertyType
            {
                get
                {
                    return this.column.Type;
                }
            }

            /// <summary>
            /// When overridden in a derived class, returns whether resetting an object changes its value.
            /// </summary>
            /// <param name="component">
            /// The component to test for reset capability.
            /// </param>
            /// <returns>
            /// true if resetting the component changes its value; otherwise, false.
            /// </returns>
            public override bool CanResetValue(object component)
            {
                return false;
            }

            /// <summary>
            /// When overridden in a derived class, gets the current value of the property on a component.
            /// </summary>
            /// <param name="component">
            /// The component with the property for which to retrieve the value.
            /// </param>
            /// <returns>
            /// The value of a property for a given component.
            /// </returns>
            public override object GetValue(object component)
            {
                return ((CsvRow)component).Values[this.index];
            }

            /// <summary>
            /// When overridden in a derived class, resets the value for this property of the component to the default value.
            /// </summary>
            /// <param name="component">
            /// The component with the property value that is to be reset to the default value.
            /// </param>
            public override void ResetValue(object component)
            {
            }

            /// <summary>
            /// When overridden in a derived class, sets the value of the component to a different value.
            /// </summary>
            /// <param name="component">
            /// The component with the property value that is to be set.
            /// </param>
            /// <param name="value">
            /// The new value.
            /// </param>
            public override void SetValue(object component, object value)
            {
                ((CsvRow)component).Values[this.index] = value;
            }

            /// <summary>
            /// When overridden in a derived class, determines a value indicating whether the value of this property needs to be persisted.
            /// </summary>
            /// <param name="component">
            /// The component with the property to be examined for persistence.
            /// </param>
            /// <returns>
            /// true if the property should be persisted; otherwise, false.
            /// </returns>
            public override bool ShouldSerializeValue(object component)
            {
                return false;
            }
        }

        /// <summary>
        /// Provides a custom TypeDescriptionProvider for <see cref="CsvRow" />.
        /// </summary>
        public class CsvTypeDescriptionProvider : TypeDescriptionProvider
        {
            /// <summary>
            /// Gets a custom type descriptor for the given type and object.
            /// </summary>
            /// <param name="objectType">
            /// The type of object for which to retrieve the type descriptor.
            /// </param>
            /// <param name="instance">
            /// An instance of the type. Can be null if no instance was passed to the <see cref="T:System.ComponentModel.TypeDescriptor"/> .
            /// </param>
            /// <returns>
            /// An <see cref="T:System.ComponentModel.ICustomTypeDescriptor"/> that can provide metadata for the type.
            /// </returns>
            public override ICustomTypeDescriptor GetTypeDescriptor(Type objectType, object instance)
            {
                return instance == null ? base.GetTypeDescriptor(objectType, null) : new CsvRowTypeDescriptor(instance);
            }
        }

        /// <summary>
        /// Provides a custom type descriptor for the <see cref="CsvRow" />.
        /// </summary>
        public class CsvRowTypeDescriptor : CustomTypeDescriptor
        {
            /// <summary>
            /// The row.
            /// </summary>
            private readonly CsvRow row;

            /// <summary>
            /// Initializes a new instance of the <see cref="CsvRowTypeDescriptor"/> class.
            /// </summary>
            /// <param name="instance">
            /// The instance.
            /// </param>
            public CsvRowTypeDescriptor(object instance)
            {
                this.row = (CsvRow)instance;
            }

            /// <summary>
            /// Gets the properties of the <see cref="CsvRow"/>.
            /// </summary>
            /// <returns> The property descriptor collection. </returns>
            public override PropertyDescriptorCollection GetProperties()
            {
                var result = new List<PropertyDescriptor>(this.row.File.Columns.Count);
                for (int i = 0; i < this.row.File.Columns.Count; i++)
                {
                    result.Add(new CsvPropertyDescriptor(this.row.File.Columns[i], i));
                }

                return new PropertyDescriptorCollection(result.ToArray());
            }
        }
#endif

        /// <summary>
        /// Represents a row in the <see cref="CsvFile"/>.
        /// </summary>
#if NET45
        [TypeDescriptionProvider(typeof(CsvTypeDescriptionProvider))]
#endif
        public class CsvRow
        {
            /// <summary>
            /// Initializes a new instance of the <see cref="CsvRow"/> class.
            /// </summary>
            /// <param name="file">
            /// The file.
            /// </param>
            public CsvRow(CsvFile file)
            {
                this.File = file;
                this.Values = new object[file.Columns.Count];
            }

            /// <summary>
            /// Gets the file.
            /// </summary>
            /// <value>The file.</value>
            public CsvFile File { get; private set; }

            /// <summary>
            /// Gets the values.
            /// </summary>
            /// <value>The values.</value>
            /// <remarks>
            /// The indices corresponds to the columns in the parent <see cref="CsvFile"/>.
            /// </remarks>
            public object[] Values { get; private set; }
        }

        /// <summary>
        /// Represents a list of values.
        /// </summary>
        private class ValueList : List<string>
        {
            /// <summary>
            /// Gets the smallest common type (<see cref="int"/>, <see cref="double"/> or <see cref="string"/>).
            /// </summary>
            /// <param name="provider">
            /// The format provider.
            /// </param>
            /// <returns>
            /// The smallest type (<see cref="int"/>, <see cref="double"/> or <see cref="string"/>) of the list.
            /// </returns>
            public Type GetSmallestCommonType(IFormatProvider provider)
            {
                Type type = null;
                foreach (var item in this)
                {
                    int i;
                    if (int.TryParse(item, NumberStyles.Integer, provider, out i))
                    {
                        if (type == null || type == typeof(int))
                        {
                            type = typeof(int);
                            continue;
                        }
                    }

                    double d;
                    if (double.TryParse(item, NumberStyles.Any, provider, out d))
                    {
                        if (type == null || type == typeof(int) || type == typeof(double))
                        {
                            type = typeof(double);
                            continue;
                        }
                    }

                    type = typeof(string);
                }

                return type;
            }
        }
    }
}