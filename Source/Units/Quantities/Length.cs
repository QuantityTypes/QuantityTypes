// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Length.cs" company="Units.NET">
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
//   Represents the length quantity.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Units
{
    using System;
    using System.ComponentModel;
    using System.Globalization;
    using System.Runtime.Serialization;
    using System.Xml.Serialization;

    /// <summary>
    /// Represents the length quantity.
    /// </summary>
    [DataContract]
#if !PCL
    [Serializable]
    [TypeConverter(typeof(QuantityTypeConverter<Length>))]
#endif
    public partial struct Length : IQuantity<Length>
    {
        /// <summary>
        /// The backing field for the <see cref="Metre" /> property.
        /// </summary>
        private static readonly Length MetreField = new Length(1);

        /// <summary>
        /// The backing field for the <see cref="Decimetre" /> property.
        /// </summary>
        private static readonly Length DecimetreField = new Length(1e-1);

        /// <summary>
        /// The backing field for the <see cref="Centimetre" /> property.
        /// </summary>
        private static readonly Length CentimetreField = new Length(1e-2);

        /// <summary>
        /// The backing field for the <see cref="Millimetre" /> property.
        /// </summary>
        private static readonly Length MillimetreField = new Length(1e-3);

        /// <summary>
        /// The backing field for the <see cref="Kilometre" /> property.
        /// </summary>
        private static readonly Length KilometreField = new Length(1e3);

        /// <summary>
        /// The backing field for the <see cref="Yard" /> property.
        /// </summary>
        private static readonly Length YardField = new Length(0.9144);

        /// <summary>
        /// The backing field for the <see cref="Foot" /> property.
        /// </summary>
        private static readonly Length FootField = new Length(0.3048);

        /// <summary>
        /// The backing field for the <see cref="Inch" /> property.
        /// </summary>
        private static readonly Length InchField = new Length(0.0254);

        /// <summary>
        /// The backing field for the <see cref="Mile" /> property.
        /// </summary>
        private static readonly Length MileField = new Length(1609.344);

        /// <summary>
        /// The backing field for the <see cref="NauticalMile" /> property.
        /// </summary>
        private static readonly Length NauticalMileField = new Length(1852);

        /// <summary>
        /// The backing field for the <see cref="Ångström" /> property.
        /// </summary>
        private static readonly Length ÅngströmField = new Length(1e-10);

        /// <summary>
        /// The backing field for the <see cref="AstronomicalUnit" /> property.
        /// </summary>
        private static readonly Length AstronomicalUnitField = new Length(149597871464);

        /// <summary>
        /// The backing field for the <see cref="LightYear" /> property.
        /// </summary>
        private static readonly Length LightYearField = new Length(9.4607304725808e15);

        /// <summary>
        /// The value.
        /// </summary>
        private double value;

        /// <summary>
        /// Initializes a new instance of the <see cref="Length"/> struct.
        /// </summary>
        /// <param name="value">
        /// The value. 
        /// </param>
        public Length(double value)
        {
            this.value = value;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Length"/> struct.
        /// </summary>
        /// <param name="value">
        /// The value. 
        /// </param>
        /// <param name="unitProvider">
        /// The unit provider. 
        /// </param>
        public Length(string value, IUnitProvider unitProvider = null)
        {
            this.value = Parse(value, unitProvider ?? UnitProvider.Default).value;
        }

        /// <summary>
        /// Gets the "m" unit.
        /// </summary>
        [Unit("m", true)]
        public static Length Metre
        {
            get { return MetreField; }
        }

        /// <summary>
        /// Gets the "dm" unit.
        /// </summary>
        [Unit("dm")]
        public static Length Decimetre
        {
            get { return DecimetreField; }
        }

        /// <summary>
        /// Gets the "cm" unit.
        /// </summary>
        [Unit("cm")]
        public static Length Centimetre
        {
            get { return CentimetreField; }
        }

        /// <summary>
        /// Gets the "mm" unit.
        /// </summary>
        [Unit("mm")]
        public static Length Millimetre
        {
            get { return MillimetreField; }
        }

        /// <summary>
        /// Gets the "km" unit.
        /// </summary>
        [Unit("km")]
        public static Length Kilometre
        {
            get { return KilometreField; }
        }

        /// <summary>
        /// Gets the "yd" unit.
        /// </summary>
        [Unit("yd")]
        public static Length Yard
        {
            get { return YardField; }
        }

        /// <summary>
        /// Gets the "ft" unit.
        /// </summary>
        [Unit("ft")]
        public static Length Foot
        {
            get { return FootField; }
        }

        /// <summary>
        /// Gets the "in" unit.
        /// </summary>
        [Unit("in")]
        public static Length Inch
        {
            get { return InchField; }
        }

        /// <summary>
        /// Gets the "mi" unit.
        /// </summary>
        [Unit("mi")]
        public static Length Mile
        {
            get { return MileField; }
        }

        /// <summary>
        /// Gets the "nmi" unit.
        /// </summary>
        [Unit("nmi")]
        public static Length NauticalMile
        {
            get { return NauticalMileField; }
        }

        /// <summary>
        /// Gets the "Å" unit.
        /// </summary>
        [Unit("Å")]
        public static Length Ångström
        {
            get { return ÅngströmField; }
        }

        /// <summary>
        /// Gets the "AU" unit.
        /// </summary>
        [Unit("AU")]
        public static Length AstronomicalUnit
        {
            get { return AstronomicalUnitField; }
        }

        /// <summary>
        /// Gets the "ly" unit.
        /// </summary>
        [Unit("ly")]
        public static Length LightYear
        {
            get { return LightYearField; }
        }

        /// <summary>
        /// Gets or sets the length as a string.
        /// </summary>
        /// <value>The string.</value>
        /// <remarks>
        /// This property is used for XML serialization.
        /// </remarks>
        [XmlText]
        [DataMember]
        public string XmlValue
        {
            get
            {
                // Use round-trip format
                return this.ToString("R", CultureInfo.InvariantCulture);
            }

            set
            {
                this.value = Parse(value, CultureInfo.InvariantCulture).value;
            }
        }

        /// <summary>
        /// Gets the value of the length in the base unit.
        /// </summary>
        public double Value
        {
            get
            {
                return this.value;
            }
        }

        /// <summary>
        /// Parses the specified string.
        /// </summary>
        /// <param name="input">
        /// The input string. 
        /// </param>
        /// <param name="provider">
        /// The provider. 
        /// </param>
        /// <returns>
        /// The <see cref="Length"/> . 
        /// </returns>
        public static Length Parse(string input, IFormatProvider provider = null)
        {
            var unitProvider = provider as IUnitProvider ?? UnitProvider.Default;

            Length value;
            if (!unitProvider.TryParse(input, provider, out value))
            {
                throw new FormatException("Invalid format. Could not parse " + input + ".");
            }

            return value;
        }

        /// <summary>
        /// Parses the specified JSON string.
        /// </summary>
        /// <param name="json">The JSON input.</param>
        /// <returns>
        /// The <see cref="Length"/> .
        /// </returns>
        public static Length ParseJson(string json)
        {
            return Parse(json, CultureInfo.InvariantCulture);
        }

        /// <summary>
        /// Implements the operator +.
        /// </summary>
        /// <param name="x">
        /// The first value. 
        /// </param>
        /// <param name="y">
        /// The second value. 
        /// </param>
        /// <returns>
        /// The result of the operator. 
        /// </returns>
        public static Length operator +(Length x, Length y)
        {
            return new Length(x.value + y.value);
        }

        /// <summary>
        /// Implements the operator /.
        /// </summary>
        /// <param name="x">
        /// The x. 
        /// </param>
        /// <param name="y">
        /// The y. 
        /// </param>
        /// <returns>
        /// The result of the operator. 
        /// </returns>
        public static Length operator /(Length x, double y)
        {
            return new Length(x.value / y);
        }

        /// <summary>
        /// Implements the operator /.
        /// </summary>
        /// <param name="x">
        /// The x. 
        /// </param>
        /// <param name="y">
        /// The y. 
        /// </param>
        /// <returns>
        /// The result of the operator. 
        /// </returns>
        public static double operator /(Length x, Length y)
        {
            return x.value / y.value;
        }

        /// <summary>
        /// Implements the operator ==.
        /// </summary>
        /// <param name="x">
        /// The x. 
        /// </param>
        /// <param name="y">
        /// The y. 
        /// </param>
        /// <returns>
        /// The result of the operator. 
        /// </returns>
        public static bool operator ==(Length x, Length y)
        {
            return x.value.Equals(y.value);
        }

        /// <summary>
        /// Implements the operator &gt;.
        /// </summary>
        /// <param name="x">
        /// The x. 
        /// </param>
        /// <param name="y">
        /// The y. 
        /// </param>
        /// <returns>
        /// The result of the operator. 
        /// </returns>
        public static bool operator >(Length x, Length y)
        {
            return x.value > y.value;
        }

        /// <summary>
        /// Implements the operator &gt;=.
        /// </summary>
        /// <param name="x">
        /// The x. 
        /// </param>
        /// <param name="y">
        /// The y. 
        /// </param>
        /// <returns>
        /// The result of the operator. 
        /// </returns>
        public static bool operator >=(Length x, Length y)
        {
            return x.value >= y.value;
        }

        /// <summary>
        /// Implements the operator !=.
        /// </summary>
        /// <param name="x">
        /// The x. 
        /// </param>
        /// <param name="y">
        /// The y. 
        /// </param>
        /// <returns>
        /// The result of the operator. 
        /// </returns>
        public static bool operator !=(Length x, Length y)
        {
            return !x.value.Equals(y.value);
        }

        /// <summary>
        /// Implements the operator &lt;.
        /// </summary>
        /// <param name="x">
        /// The x. 
        /// </param>
        /// <param name="y">
        /// The y. 
        /// </param>
        /// <returns>
        /// The result of the operator. 
        /// </returns>
        public static bool operator <(Length x, Length y)
        {
            return x.value < y.value;
        }

        /// <summary>
        /// Implements the operator &lt;=.
        /// </summary>
        /// <param name="x">
        /// The x. 
        /// </param>
        /// <param name="y">
        /// The y. 
        /// </param>
        /// <returns>
        /// The result of the operator. 
        /// </returns>
        public static bool operator <=(Length x, Length y)
        {
            return x.value <= y.value;
        }

        /// <summary>
        /// Implements the operator *.
        /// </summary>
        /// <param name="x">
        /// The x. 
        /// </param>
        /// <param name="y">
        /// The y. 
        /// </param>
        /// <returns>
        /// The result of the operator. 
        /// </returns>
        public static Length operator *(double x, Length y)
        {
            return new Length(x * y.value);
        }

        /// <summary>
        /// Implements the operator *.
        /// </summary>
        /// <param name="x">
        /// The x. 
        /// </param>
        /// <param name="y">
        /// The y. 
        /// </param>
        /// <returns>
        /// The result of the operator. 
        /// </returns>
        public static Length operator *(Length x, double y)
        {
            return new Length(x.value * y);
        }

        /// <summary>
        /// Implements the operator -.
        /// </summary>
        /// <param name="x">
        /// The x. 
        /// </param>
        /// <param name="y">
        /// The y. 
        /// </param>
        /// <returns>
        /// The result of the operator. 
        /// </returns>
        public static Length operator -(Length x, Length y)
        {
            return new Length(x.value - y.value);
        }

        /// <summary>
        /// Compares this instance to the specified <see cref="Length"/> and returns an indication of their relative values.
        /// </summary>
        /// <param name="other">
        /// The other <see cref="Length"/> . 
        /// </param>
        /// <returns>
        /// A signed number indicating the relative values of this instance and the other value. 
        /// </returns>
        public int CompareTo(Length other)
        {
            return this.value.CompareTo(other.value);
        }

        /// <summary>
        /// Compares the current instance with another object of the same type and returns an integer that indicates whether the 
        /// current instance precedes, follows, or occurs in the same position in the sort order as the other object.
        /// </summary>
        /// <param name="obj">An object to compare with this instance.</param>
        /// <returns>
        /// A value that indicates the relative order of the objects being compared. The return value has these meanings: 
        /// Value Meaning Less than zero This instance is less than <paramref name="obj" />. Zero This instance is equal to 
        /// <paramref name="obj" />. Greater than zero This instance is greater than <paramref name="obj" />.
        /// </returns>
        public int CompareTo(object obj)
        {
            return this.CompareTo((Length)obj);
        }

        /// <summary>
        /// Converts the quantity to the specified unit.
        /// </summary>
        /// <param name="unit">The unit.</param>
        /// <returns>The amount of the specified unit.</returns>
        double IQuantity.ConvertTo(IQuantity unit)
        {
            return this.ConvertTo((Length)unit);
        }

        /// <summary>
        /// Converts to the specified unit.
        /// </summary>
        /// <param name="unit">
        /// The unit. 
        /// </param>
        /// <returns>
        /// The value in the specified unit. 
        /// </returns>
        public double ConvertTo(Length unit)
        {
            return this.value / unit.Value;
        }

        /// <summary>
        /// Determines whether the specified <see cref="System.Object"/> is equal to this instance.
        /// </summary>
        /// <param name="obj">
        /// The <see cref="System.Object"/> to compare with this instance. 
        /// </param>
        /// <returns>
        /// <c>true</c> if the specified <see cref="System.Object"/> is equal to this instance; otherwise, <c>false</c> . 
        /// </returns>
        public override bool Equals(object obj)
        {
            if (obj is Length)
            {
                return this.Equals((Length)obj);
            }

            return false;
        }

        /// <summary>
        /// Determines if the specified <see cref="Length"/> is equal to this instance.
        /// </summary>
        /// <param name="other">
        /// The other <see cref="Length"/> . 
        /// </param>
        /// <returns>
        /// True if the values are equal. 
        /// </returns>
        public bool Equals(Length other)
        {
            return this.value.Equals(other.value);
        }

        /// <summary>
        /// Returns a hash code for this instance.
        /// </summary>
        /// <returns>
        /// A hash code for this instance, suitable for use in hashing algorithms and data structures like a hash table. 
        /// </returns>
        public override int GetHashCode()
        {
            return this.Value.GetHashCode();
        }

        /// <summary>
        /// Multiplies by the specified number.
        /// </summary>
        /// <param name="x">The number.</param>
        /// <returns>The new quantity.</returns>
        public IQuantity MultiplyBy(double x)
        {
            return this * x;
        }

        /// <summary>
        /// Sets the value from the specified string.
        /// </summary>
        /// <param name="s">
        /// The s. 
        /// </param>
        /// <param name="provider">
        /// The provider. 
        /// </param>
        public void SetFromString(string s, IUnitProvider provider)
        {
            this.value = Parse(s, provider).value;
        }

        /// <summary>
        /// Returns a <see cref="System.String"/> that represents this instance.
        /// </summary>
        /// <returns>
        /// A <see cref="System.String"/> that represents this instance. 
        /// </returns>
        public override string ToString()
        {
            return this.ToString(null, UnitProvider.Default);
        }

        /// <summary>
        /// Returns a <see cref="System.String"/> that represents this instance.
        /// </summary>
        /// <param name="format">
        /// The format. 
        /// </param>
        /// <param name="formatProvider">
        /// The format provider. 
        /// </param>
        /// <returns>
        /// A <see cref="System.String"/> that represents this instance. 
        /// </returns>
        public string ToString(string format, IFormatProvider formatProvider = null)
        {
            var unitProvider = formatProvider as IUnitProvider ?? UnitProvider.Default;
            return unitProvider.Format(format, formatProvider, this);
        }
    }
}
