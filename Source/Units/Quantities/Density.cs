// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Density.cs" company="Units.NET">
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
//   Represents the density quantity.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Units
{
    using System;
    using System.ComponentModel;
    using System.Runtime.Serialization;
    using System.Xml.Serialization;

    /// <summary>
    /// Represents the density quantity.
    /// </summary>
    [Serializable]
    [DataContract]
    [TypeConverter(typeof(QuantityTypeConverter<Density>))]
    public partial struct Density : IQuantity<Density>
    {
        /// <summary>
        /// The backing field for the <see cref="KilogramPerCubicMetre" /> property.
        /// </summary>
        private static readonly Density KilogramPerCubicMetreField = new Density(1);

        /// <summary>
        /// The backing field for the <see cref="KilogramPerCubicDecimetre" /> property.
        /// </summary>
        private static readonly Density KilogramPerCubicDecimetreField = new Density(1000);

        /// <summary>
        /// The backing field for the <see cref="GramPerCubicCentietre" /> property.
        /// </summary>
        private static readonly Density GramPerCubicCentietreField = new Density(1000);

        /// <summary>
        /// The backing field for the <see cref="KilogramPerLitre" /> property.
        /// </summary>
        private static readonly Density KilogramPerLitreField = new Density(1000);

        /// <summary>
        /// The backing field for the <see cref="GramPerMillilitre" /> property.
        /// </summary>
        private static readonly Density GramPerMillilitreField = new Density(1000);

        /// <summary>
        /// The backing field for the <see cref="PoundPerCubicFoot" /> property.
        /// </summary>
        private static readonly Density PoundPerCubicFootField = new Density(16.01846337396);

        /// <summary>
        /// The backing field for the <see cref="PoundPerCubicInch" /> property.
        /// </summary>
        private static readonly Density PoundPerCubicInchField = new Density(27679.9047102031);

        /// <summary>
        /// The backing field for the <see cref="PoundPerGallon" /> property.
        /// </summary>
        private static readonly Density PoundPerGallonField = new Density(99.7763287677);

        /// <summary>
        /// The value.
        /// </summary>
        private double value;

        /// <summary>
        /// Initializes a new instance of the <see cref="Density"/> struct.
        /// </summary>
        /// <param name="value">
        /// The value. 
        /// </param>
        public Density(double value)
        {
            this.value = value;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Density"/> struct.
        /// </summary>
        /// <param name="value">
        /// The value. 
        /// </param>
        /// <param name="unitProvider">
        /// The unit provider. 
        /// </param>
        public Density(string value, IUnitProvider unitProvider = null)
        {
            this.value = Parse(value, unitProvider ?? UnitProvider.Default).value;
        }

        /// <summary>
        /// Gets the "kg/m^3" unit.
        /// </summary>
        [Unit("kg/m^3", true)]
        public static Density KilogramPerCubicMetre 
        { 
            get { return KilogramPerCubicMetreField; } 
        }

        /// <summary>
        /// Gets the "kg/dm^3" unit.
        /// </summary>
        [Unit("kg/dm^3")]
        public static Density KilogramPerCubicDecimetre 
        { 
            get { return KilogramPerCubicDecimetreField; } 
        }

        /// <summary>
        /// Gets the "g/cm^3" unit.
        /// </summary>
        [Unit("g/cm^3")]
        public static Density GramPerCubicCentietre 
        { 
            get { return GramPerCubicCentietreField; } 
        }

        /// <summary>
        /// Gets the "kg/L" unit.
        /// </summary>
        [Unit("kg/L")]
        public static Density KilogramPerLitre 
        { 
            get { return KilogramPerLitreField; } 
        }

        /// <summary>
        /// Gets the "g/mL" unit.
        /// </summary>
        [Unit("g/mL")]
        public static Density GramPerMillilitre 
        { 
            get { return GramPerMillilitreField; } 
        }

        /// <summary>
        /// Gets the "lb/ft^3" unit.
        /// </summary>
        [Unit("lb/ft^3")]
        public static Density PoundPerCubicFoot 
        { 
            get { return PoundPerCubicFootField; } 
        }

        /// <summary>
        /// Gets the "lb/in^3" unit.
        /// </summary>
        [Unit("lb/in^3")]
        public static Density PoundPerCubicInch 
        { 
            get { return PoundPerCubicInchField; } 
        }

        /// <summary>
        /// Gets the "lb/gal" unit.
        /// </summary>
        [Unit("lb/gal")]
        public static Density PoundPerGallon 
        { 
            get { return PoundPerGallonField; } 
        }

        /// <summary>
        /// Gets or sets the density as a string.
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
        /// Gets the value of the density in the base unit.
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
        /// The <see cref="Density"/> . 
        /// </returns>
        public static Density Parse(string input, IUnitProvider provider = null)
        {
            if (provider == null)
            {
                provider = UnitProvider.Default;
            }

            double value;
            Density unit;
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
        public static Density operator +(Density x, Density y)
        {
            return new Density(x.value + y.value);
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
        public static Density operator /(Density x, double y)
        {
            return new Density(x.value / y);
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
        public static double operator /(Density x, Density y)
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
        public static bool operator ==(Density x, Density y)
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
        public static bool operator >(Density x, Density y)
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
        public static bool operator >=(Density x, Density y)
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
        public static bool operator !=(Density x, Density y)
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
        public static bool operator <(Density x, Density y)
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
        public static bool operator <=(Density x, Density y)
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
        public static Density operator *(double x, Density y)
        {
            return new Density(x * y.value);
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
        public static Density operator *(Density x, double y)
        {
            return new Density(x.value * y);
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
        public static Density operator -(Density x, Density y)
        {
            return new Density(x.value - y.value);
        }

        /// <summary>
        /// Compares this instance to the specified <see cref="Density"/> and returns an indication of their relative values.
        /// </summary>
        /// <param name="other">
        /// The other <see cref="Density"/> . 
        /// </param>
        /// <returns>
        /// A signed number indicating the relative values of this instance and the other value. 
        /// </returns>
        public int CompareTo(Density other)
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
        public double ConvertTo(Density unit)
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
            return this.Equals((Density)obj);
        }

        /// <summary>
        /// Determines if the specified <see cref="Density"/> is equal to this instance.
        /// </summary>
        /// <param name="other">
        /// The other <see cref="Density"/> . 
        /// </param>
        /// <returns>
        /// True if the values are equal. 
        /// </returns>
        public bool Equals(Density other)
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
