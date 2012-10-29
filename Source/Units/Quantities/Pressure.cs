// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Pressure.cs" company="Units.NET">
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
//   Represents the pressure quantity.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Units
{
    using System;
    using System.ComponentModel;
    using System.Runtime.Serialization;
    using System.Xml.Serialization;

    /// <summary>
    /// Represents the pressure quantity.
    /// </summary>
    [Serializable]
    [DataContract]
    [TypeConverter(typeof(QuantityTypeConverter<Pressure>))]
    public partial struct Pressure : IQuantity<Pressure>
    {
        /// <summary>
        /// The backing field for the <see cref="Pascal" /> property.
        /// </summary>
        private static readonly Pressure PascalField = new Pressure(1);

        /// <summary>
        /// The backing field for the <see cref="Kilopascal" /> property.
        /// </summary>
        private static readonly Pressure KilopascalField = new Pressure(1000);

        /// <summary>
        /// The backing field for the <see cref="PoundPerSquareInch" /> property.
        /// </summary>
        private static readonly Pressure PoundPerSquareInchField = new Pressure(6.894757e3);

        /// <summary>
        /// The backing field for the <see cref="KilopoundPerSquareInch" /> property.
        /// </summary>
        private static readonly Pressure KilopoundPerSquareInchField = new Pressure(6.8947572931783e6);

        /// <summary>
        /// The backing field for the <see cref="MillimetreOfMercury" /> property.
        /// </summary>
        private static readonly Pressure MillimetreOfMercuryField = new Pressure(133.3224);

        /// <summary>
        /// The backing field for the <see cref="Bar" /> property.
        /// </summary>
        private static readonly Pressure BarField = new Pressure(1e5);

        /// <summary>
        /// The backing field for the <see cref="Megapascal" /> property.
        /// </summary>
        private static readonly Pressure MegapascalField = new Pressure(1000000);

        /// <summary>
        /// The backing field for the <see cref="Atmosphere" /> property.
        /// </summary>
        private static readonly Pressure AtmosphereField = new Pressure(101325);

        /// <summary>
        /// The value.
        /// </summary>
        private double value;

        /// <summary>
        /// Initializes a new instance of the <see cref="Pressure"/> struct.
        /// </summary>
        /// <param name="value">
        /// The value. 
        /// </param>
        public Pressure(double value)
        {
            this.value = value;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Pressure"/> struct.
        /// </summary>
        /// <param name="value">
        /// The value. 
        /// </param>
        /// <param name="unitProvider">
        /// The unit provider. 
        /// </param>
        public Pressure(string value, IUnitProvider unitProvider = null)
        {
            this.value = Parse(value, unitProvider ?? UnitProvider.Default).value;
        }

        /// <summary>
        /// Gets the "Pa" unit.
        /// </summary>
        [Unit("Pa", true)]
        public static Pressure Pascal 
        { 
            get { return PascalField; } 
        }

        /// <summary>
        /// Gets the "kPa" unit.
        /// </summary>
        [Unit("kPa")]
        public static Pressure Kilopascal 
        { 
            get { return KilopascalField; } 
        }

        /// <summary>
        /// Gets the "psi" unit.
        /// </summary>
        [Unit("psi")]
        public static Pressure PoundPerSquareInch 
        { 
            get { return PoundPerSquareInchField; } 
        }

        /// <summary>
        /// Gets the "ksi" unit.
        /// </summary>
        [Unit("ksi")]
        public static Pressure KilopoundPerSquareInch 
        { 
            get { return KilopoundPerSquareInchField; } 
        }

        /// <summary>
        /// Gets the "mmHg" unit.
        /// </summary>
        [Unit("mmHg")]
        public static Pressure MillimetreOfMercury 
        { 
            get { return MillimetreOfMercuryField; } 
        }

        /// <summary>
        /// Gets the "bar" unit.
        /// </summary>
        [Unit("bar")]
        public static Pressure Bar 
        { 
            get { return BarField; } 
        }

        /// <summary>
        /// Gets the "Megapascal" unit.
        /// </summary>
        [Unit("Megapascal")]
        public static Pressure Megapascal 
        { 
            get { return MegapascalField; } 
        }

        /// <summary>
        /// Gets the "atm" unit.
        /// </summary>
        [Unit("atm")]
        public static Pressure Atmosphere 
        { 
            get { return AtmosphereField; } 
        }

        /// <summary>
        /// Gets or sets the pressure as a string.
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
        /// Gets the value of the pressure in the base unit.
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
        /// The <see cref="Pressure"/> . 
        /// </returns>
        public static Pressure Parse(string input, IUnitProvider provider = null)
        {
            if (provider == null)
            {
                provider = UnitProvider.Default;
            }

            Pressure value;
            if (!provider.TryParse(input, out value))
            {
                throw new FormatException("Invalid format.");
            }

            return value;
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
        public static Pressure operator +(Pressure x, Pressure y)
        {
            return new Pressure(x.value + y.value);
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
        public static Pressure operator /(Pressure x, double y)
        {
            return new Pressure(x.value / y);
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
        public static double operator /(Pressure x, Pressure y)
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
        public static bool operator ==(Pressure x, Pressure y)
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
        public static bool operator >(Pressure x, Pressure y)
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
        public static bool operator >=(Pressure x, Pressure y)
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
        public static bool operator !=(Pressure x, Pressure y)
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
        public static bool operator <(Pressure x, Pressure y)
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
        public static bool operator <=(Pressure x, Pressure y)
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
        public static Pressure operator *(double x, Pressure y)
        {
            return new Pressure(x * y.value);
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
        public static Pressure operator *(Pressure x, double y)
        {
            return new Pressure(x.value * y);
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
        public static Pressure operator -(Pressure x, Pressure y)
        {
            return new Pressure(x.value - y.value);
        }

        /// <summary>
        /// Compares this instance to the specified <see cref="Pressure"/> and returns an indication of their relative values.
        /// </summary>
        /// <param name="other">
        /// The other <see cref="Pressure"/> . 
        /// </param>
        /// <returns>
        /// A signed number indicating the relative values of this instance and the other value. 
        /// </returns>
        public int CompareTo(Pressure other)
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
            return this.CompareTo((Pressure)obj);
        }


        /// <summary>
        /// Converts the quantity to the specified unit.
        /// </summary>
        /// <param name="unit">The unit.</param>
        /// <returns>The amount of the specified unit.</returns>
        double IQuantity.ConvertTo(IQuantity unit)
        {
            return this.ConvertTo((Pressure)unit);
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
        public double ConvertTo(Pressure unit)
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
            return this.Equals((Pressure)obj);
        }

        /// <summary>
        /// Determines if the specified <see cref="Pressure"/> is equal to this instance.
        /// </summary>
        /// <param name="other">
        /// The other <see cref="Pressure"/> . 
        /// </param>
        /// <returns>
        /// True if the values are equal. 
        /// </returns>
        public bool Equals(Pressure other)
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
            var up = formatProvider as IUnitProvider ?? UnitProvider.Default;
            return up.Format(format, this);
        }
    }
}
