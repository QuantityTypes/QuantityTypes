// --------------------------------------------------------------------------------------------------------------------
// <copyright file="CsvColumnAttribute.cs" company="QuantityTypes">
//   Copyright (c) 2014 QuantityTypes contributors
// </copyright>
// <summary>
//   Specifies the column index in a comma separated file file.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace QuantityTypes.Csv
{
    using System;
    using System.Linq;
    using System.Reflection;

    /// <summary>
    /// Specifies the column index in a comma separated file file.
    /// </summary>
    [AttributeUsage(AttributeTargets.Property)]
    public class CsvColumnAttribute : Attribute, IComparable<CsvColumnAttribute>, IComparable
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CsvColumnAttribute"/> class.
        /// </summary>
        /// <param name="column">
        /// The column.
        /// </param>
        public CsvColumnAttribute(int column)
        {
            this.Column = column;
        }

        /// <summary>
        /// Gets or sets the column.
        /// </summary>
        /// <value>
        /// The column.
        /// </value>
        public int Column { get; set; }

        /// <summary>
        /// Gets the column from the specified property descriptor.
        /// </summary>
        /// <param name="propertyInfo">The property info.</param>
        /// <returns>The column.</returns>
        public static object GetColumn(PropertyInfo propertyInfo)
        {
            var attributes = propertyInfo.GetCustomAttributes(typeof(CsvColumnAttribute), false).ToArray();
            return attributes.Length > 0 ? ((CsvColumnAttribute)attributes[0]).Column : 0;
        }

        /// <summary>
        /// Compares the current instance with another object of the same type and returns an integer that indicates whether the current instance precedes, follows, or occurs in the same position in the sort order as the other object.
        /// </summary>
        /// <param name="obj">
        /// An object to compare with this instance.
        /// </param>
        /// <returns>
        /// A value that indicates the relative order of the objects being compared. The return value has these meanings: Value Meaning Less than zero This instance precedes <paramref name="obj"/> in the sort order. Zero This instance occurs in the same position in the sort order as <paramref name="obj"/>. Greater than zero This instance follows <paramref name="obj"/> in the sort order.
        /// </returns>
        public int CompareTo(object obj)
        {
            return this.CompareTo(obj as CsvColumnAttribute);
        }

        /// <summary>
        /// Compares the current instance with another object of the same type and returns an integer that indicates whether the current instance precedes, follows, or occurs in the same position in the sort order as the other object.
        /// </summary>
        /// <param name="other">
        /// An object to compare with this instance.
        /// </param>
        /// <returns>
        /// A value that indicates the relative order of the objects being compared. The return value has these meanings: Value Meaning Less than zero This instance precedes <paramref name="other"/> in the sort order. Zero This instance occurs in the same position in the sort order as <paramref name="other"/>. Greater than zero This instance follows <paramref name="other"/> in the sort order.
        /// </returns>
        public int CompareTo(CsvColumnAttribute other)
        {
            if (other == null)
            {
                return -1;
            }

            return this.Column.CompareTo(other.Column);
        }
    }
}