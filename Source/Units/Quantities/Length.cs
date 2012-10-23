// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Length.cs" company="Units.NET">
//   Copyright (c) 2012 Oystein Bjorke
// </copyright>
// <summary>
//   Represents the length quantity.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Units
{
    using System;
    using System.ComponentModel;
    using System.Runtime.Serialization;
    using System.Xml.Serialization;

    /// <summary>
    /// Represents the length quantity.
    /// </summary>
    [Serializable]
    [DataContract]
    [TypeConverter(typeof(QuantityTypeConverter<Length>))]
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
                return this.ToString();
            }

            set
            {
                this.value = Parse(value).value;
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
        public static Length Parse(string input, IUnitProvider provider = null)
        {
            if (provider == null)
            {
                provider = UnitProvider.Default;
            }

            double value;
            Length unit;
            if (!provider.TryParse(input, out value, out unit))
            {
                throw new FormatException();
            }

            return value * unit;
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
            return this.Equals((Length)obj);
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
            var up = formatProvider as IUnitProvider ?? UnitProvider.Default;
            return up.Format(format, this);
        }
    }
}
