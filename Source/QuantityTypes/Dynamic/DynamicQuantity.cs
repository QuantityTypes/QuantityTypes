// --------------------------------------------------------------------------------------------------------------------
// <copyright file="DynamicQuantity.cs" company="QuantityTypes">
//   Copyright (c) 2014 QuantityTypes contributors
// </copyright>
// <summary>
//   Represents a dynamic quantity with value and dimensions.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace QuantityTypes.Dynamic
{
    using System;

    /// <summary>
    /// Represents a dynamic quantity with value and dimensions.
    /// </summary>
    public struct DynamicQuantity : IFormattable, IComparable, IComparable<DynamicQuantity>, IEquatable<DynamicQuantity>
    {
        /// <summary>
        /// The value of the quantity.
        /// </summary>
        private readonly double value;

        /// <summary>
        /// The dimensions of the quantity.
        /// </summary>
        private readonly Dimensions dim;

        /// <summary>
        /// Initializes static members of the <see cref="DynamicQuantity"/> struct.
        /// </summary>
        static DynamicQuantity()
        {
            var up = new DynamicUnitProvider();
            up.Register(typeof(SI));
            UnitProvider = up;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="DynamicQuantity"/> struct.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <param name="dim">The dimensions.</param>
        public DynamicQuantity(double value, Dimensions dim)
        {
            this.value = value;
            this.dim = dim;
        }

        /// <summary>
        /// Gets or sets the unit provider.
        /// </summary>
        /// <value>The unit provider.</value>
        public static IDynamicUnitProvider UnitProvider { get; set; }

        /// <summary>
        /// Gets the dimensions.
        /// </summary>
        /// <value>The dimensions.</value>
        public Dimensions Dimensions
        {
            get
            {
                return this.dim;
            }
        }

        /// <summary>
        /// Gets the value.
        /// </summary>
        /// <value>The value.</value>
        public double Value
        {
            get
            {
                return this.value;
            }
        }

        /// <summary>
        /// Implements the + operator.
        /// </summary>
        /// <param name="q1">The q1.</param>
        /// <param name="q2">The q2.</param>
        /// <returns>The result of the operator.</returns>
        /// <exception cref="System.InvalidOperationException">Not compatible dimensions</exception>
        public static DynamicQuantity operator +(DynamicQuantity q1, DynamicQuantity q2)
        {
            if (q1.value.Equals(0))
            {
                return q2;
            }

            if (q2.value.Equals(0))
            {
                return q1;
            }

            if (!q1.dim.Equals(q2.dim))
            {
                throw new InvalidOperationException("Not compatible dimensions");
            }

            return new DynamicQuantity(q1.Value + q2.Value, q1.dim);
        }

        /// <summary>
        /// Implements the - operator.
        /// </summary>
        /// <param name="q1">The q1.</param>
        /// <param name="q2">The q2.</param>
        /// <returns>The result of the operator.</returns>
        /// <exception cref="System.InvalidOperationException">Not compatible dimensions</exception>
        public static DynamicQuantity operator -(DynamicQuantity q1, DynamicQuantity q2)
        {
            if (q1.value.Equals(0))
            {
                return -q2;
            }

            if (q2.value.Equals(0))
            {
                return q1;
            }

            if (!q1.dim.Equals(q2.dim))
            {
                throw new InvalidOperationException("Not compatible dimensions");
            }

            return new DynamicQuantity(q1.Value - q2.Value, q1.dim);
        }

        /// <summary>
        /// Implements the -.
        /// </summary>
        /// <param name="q1">The q1.</param>
        /// <returns>The result of the operator.</returns>
        public static DynamicQuantity operator -(DynamicQuantity q1)
        {
            return new DynamicQuantity(-q1.Value, q1.dim);
        }

        /// <summary>
        /// Implements the *.
        /// </summary>
        /// <param name="q1">The q1.</param>
        /// <param name="q2">The q2.</param>
        /// <returns>The result of the operator.</returns>
        public static DynamicQuantity operator *(DynamicQuantity q1, DynamicQuantity q2)
        {
            return new DynamicQuantity(q1.Value * q2.Value, q1.dim + q2.dim);
        }

        /// <summary>
        /// Implements the *.
        /// </summary>
        /// <param name="q1">The q1.</param>
        /// <param name="q2">The q2.</param>
        /// <returns>The result of the operator.</returns>
        public static DynamicQuantity operator *(double q1, DynamicQuantity q2)
        {
            return new DynamicQuantity(q1 * q2.Value, q2.dim);
        }

        /// <summary>
        /// Implements the /.
        /// </summary>
        /// <param name="q1">The q1.</param>
        /// <param name="q2">The q2.</param>
        /// <returns>The result of the operator.</returns>
        public static DynamicQuantity operator /(DynamicQuantity q1, DynamicQuantity q2)
        {
            return new DynamicQuantity(q1.Value / q2.Value, q1.dim - q2.dim);
        }

        /// <summary>
        /// Tries to parse the specified string.
        /// </summary>
        /// <param name="s">The string to parse.</param>
        /// <param name="q">The output quantity.</param>
        /// <param name="provider">The provider.</param>
        /// <returns><c>true</c> if parsing was successful, <c>false</c> otherwise.</returns>
        public static bool TryParse(string s, out DynamicQuantity q, IFormatProvider provider = null)
        {
            double value;
            string unit;
            if (!Utilities.TrySplit(s, provider, out value, out unit))
            {
                q = default(DynamicQuantity);
                return false;
            }

            var unitProvider = provider as IDynamicUnitProvider ?? UnitProvider;
            DynamicQuantity uq;
            if (!unitProvider.TryGetUnit(unit, out uq))
            {
                q = default(DynamicQuantity);
                return false;
            }

            q = value * uq;

            return true;
        }

        /// <summary>
        /// Parses the specified string.
        /// </summary>
        /// <param name="s">The string to parse.</param>
        /// <param name="provider">The provider.</param>
        /// <returns>A DynamicQuantity.</returns>
        /// <exception cref="System.FormatException">Could not parse  + s</exception>
        public static DynamicQuantity Parse(string s, IFormatProvider provider = null)
        {
            DynamicQuantity q;
            if (!TryParse(s, out q, provider))
            {
                throw new FormatException("Could not parse " + s);
            }

            return q;
        }

        /// <summary>
        /// Compares the current object with another object of the same type.
        /// </summary>
        /// <param name="other">An object to compare with this object.</param>
        /// <returns>A value that indicates the relative order of the objects being compared. The return value has the following meanings: Value Meaning Less than zero This object is less than the <paramref name="other" /> parameter.Zero This object is equal to <paramref name="other" />. Greater than zero This object is greater than <paramref name="other" />.</returns>
        /// <exception cref="System.InvalidOperationException">Cannot compare different dimensions.</exception>
        public int CompareTo(DynamicQuantity other)
        {
            if (!other.dim.Equals(this.dim))
            {
                throw new InvalidOperationException("Cannot compare different dimensions.");
            }

            return other.value.CompareTo(this.value);
        }

        /// <summary>
        /// Indicates whether the current object is equal to another object of the same type.
        /// </summary>
        /// <param name="other">An object to compare with this object.</param>
        /// <returns>true if the current object is equal to the <paramref name="other" /> parameter; otherwise, false.</returns>
        public bool Equals(DynamicQuantity other)
        {
            return other.value.Equals(this.value) && other.dim.Equals(this.dim);
        }

        /// <summary>
        /// Returns a <see cref="System.String" /> that represents this instance.
        /// </summary>
        /// <returns>A <see cref="System.String" /> that represents this instance.</returns>
        public override string ToString()
        {
            return this.ToString(null, UnitProvider);
        }

        /// <summary>
        /// Compares the current instance with another object of the same type and returns an integer that indicates whether the current instance precedes, follows, or occurs in the same position in the sort order as the other object.
        /// </summary>
        /// <param name="obj">An object to compare with this instance.</param>
        /// <returns>A value that indicates the relative order of the objects being compared. The return value has these meanings: Value Meaning Less than zero This instance precedes <paramref name="obj" /> in the sort order. Zero This instance occurs in the same position in the sort order as <paramref name="obj" />. Greater than zero This instance follows <paramref name="obj" /> in the sort order.</returns>
        public int CompareTo(object obj)
        {
            return this.CompareTo((DynamicQuantity)obj);
        }

        /// <summary>
        /// Converts to the specified unit.
        /// </summary>
        /// <param name="unit">The unit.</param>
        /// <returns>The value in the specified unit.</returns>
        public double ConvertTo(DynamicQuantity unit)
        {
            // TODO: dimensions and this and unit must be equal?
            return (this / unit).value;
        }

        /// <summary>
        /// Returns a <see cref="System.String" /> that represents this instance.
        /// </summary>
        /// <param name="format">The format to use.-or- A null reference (Nothing in Visual Basic) to use the default format defined for the type of the <see cref="T:System.IFormattable" /> implementation.</param>
        /// <param name="formatProvider">The provider to use to format the value.-or- A null reference (Nothing in Visual Basic) to obtain the numeric format information from the current locale setting of the operating system.</param>
        /// <returns>A <see cref="System.String" /> that represents this instance.</returns>
        public string ToString(string format, IFormatProvider formatProvider)
        {
            var unitProvider = formatProvider as IDynamicUnitProvider ?? UnitProvider;
            string s;
            DynamicQuantity displayUnit;
            if (!unitProvider.TryGetDisplayUnit(this.Dimensions, out s, out displayUnit))
            {
                return string.Format("{0} {1}", this.value, this.dim);
            }

            var numericValue = this.ConvertTo(displayUnit);

            if (s.Length > 0)
            {
                s = " " + s;
            }

            if (format == null || !format.Contains("{0"))
            {
                format = "{0:" + format + "}";
            }

            return string.Format(formatProvider, format, numericValue) + s;
        }

        /// <summary>
        /// Returns a <see cref="System.String" /> that represents this instance.
        /// </summary>
        /// <param name="formatProvider">The format provider.</param>
        /// <returns>A <see cref="System.String" /> that represents this instance.</returns>
        public string ToString(IFormatProvider formatProvider)
        {
            return this.ToString(null, formatProvider);
        }
    }
}