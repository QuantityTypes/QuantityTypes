// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ElectricCharge.cs" company="Units.NET">
//   Copyright (c) 2012 Oystein Bjorke
// </copyright>
// <summary>
//   Represents the electric charge quantity.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Units
{
    using System;
    using System.ComponentModel;
    using System.Runtime.Serialization;
    using System.Xml.Serialization;

    /// <summary>
    /// Represents the electric charge quantity.
    /// </summary>
    [Serializable]
    [DataContract]
    [TypeConverter(typeof(QuantityTypeConverter<ElectricCharge>))]
    public partial struct ElectricCharge : IQuantity<ElectricCharge>
    {
        /// <summary>
        /// The backing field for the <see cref="Coulomb" /> property.
        /// </summary>
        private static readonly ElectricCharge CoulombField = new ElectricCharge(1);

        /// <summary>
        /// The backing field for the <see cref="Faraday" /> property.
        /// </summary>
        private static readonly ElectricCharge FaradayField = new ElectricCharge(96485.3383);

        /// <summary>
        /// The backing field for the <see cref="AtomicUnitOfCharge" /> property.
        /// </summary>
        private static readonly ElectricCharge AtomicUnitOfChargeField = new ElectricCharge(1.602176462e-19);

        /// <summary>
        /// The value.
        /// </summary>
        private double value;

        /// <summary>
        /// Initializes a new instance of the <see cref="ElectricCharge"/> struct.
        /// </summary>
        /// <param name="value">
        /// The value. 
        /// </param>
        public ElectricCharge(double value)
        {
            this.value = value;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ElectricCharge"/> struct.
        /// </summary>
        /// <param name="value">
        /// The value. 
        /// </param>
        /// <param name="unitProvider">
        /// The unit provider. 
        /// </param>
        public ElectricCharge(string value, IUnitProvider unitProvider = null)
        {
            this.value = Parse(value, unitProvider ?? UnitProvider.Default).value;
        }

        /// <summary>
        /// Gets the "C" unit.
        /// </summary>
        [Unit("C", true)]
        public static ElectricCharge Coulomb 
        { 
            get { return CoulombField; } 
        }

        /// <summary>
        /// Gets the "F" unit.
        /// </summary>
        [Unit("F")]
        public static ElectricCharge Faraday 
        { 
            get { return FaradayField; } 
        }

        /// <summary>
        /// Gets the "au" unit.
        /// </summary>
        [Unit("au")]
        public static ElectricCharge AtomicUnitOfCharge 
        { 
            get { return AtomicUnitOfChargeField; } 
        }

        /// <summary>
        /// Gets or sets the electric charge as a string.
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
        /// Gets the value of the electric charge in the base unit.
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
        /// The <see cref="ElectricCharge"/> . 
        /// </returns>
        public static ElectricCharge Parse(string input, IUnitProvider provider = null)
        {
            if (provider == null)
            {
                provider = UnitProvider.Default;
            }

            double value;
            ElectricCharge unit;
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
        public static ElectricCharge operator +(ElectricCharge x, ElectricCharge y)
        {
            return new ElectricCharge(x.value + y.value);
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
        public static ElectricCharge operator /(ElectricCharge x, double y)
        {
            return new ElectricCharge(x.value / y);
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
        public static double operator /(ElectricCharge x, ElectricCharge y)
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
        public static bool operator ==(ElectricCharge x, ElectricCharge y)
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
        public static bool operator >(ElectricCharge x, ElectricCharge y)
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
        public static bool operator >=(ElectricCharge x, ElectricCharge y)
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
        public static bool operator !=(ElectricCharge x, ElectricCharge y)
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
        public static bool operator <(ElectricCharge x, ElectricCharge y)
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
        public static bool operator <=(ElectricCharge x, ElectricCharge y)
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
        public static ElectricCharge operator *(double x, ElectricCharge y)
        {
            return new ElectricCharge(x * y.value);
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
        public static ElectricCharge operator *(ElectricCharge x, double y)
        {
            return new ElectricCharge(x.value * y);
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
        public static ElectricCharge operator -(ElectricCharge x, ElectricCharge y)
        {
            return new ElectricCharge(x.value - y.value);
        }

        /// <summary>
        /// Compares this instance to the specified <see cref="ElectricCharge"/> and returns an indication of their relative values.
        /// </summary>
        /// <param name="other">
        /// The other <see cref="ElectricCharge"/> . 
        /// </param>
        /// <returns>
        /// A signed number indicating the relative values of this instance and the other value. 
        /// </returns>
        public int CompareTo(ElectricCharge other)
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
        public double ConvertTo(ElectricCharge unit)
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
            return this.Equals((ElectricCharge)obj);
        }

        /// <summary>
        /// Determines if the specified <see cref="ElectricCharge"/> is equal to this instance.
        /// </summary>
        /// <param name="other">
        /// The other <see cref="ElectricCharge"/> . 
        /// </param>
        /// <returns>
        /// True if the values are equal. 
        /// </returns>
        public bool Equals(ElectricCharge other)
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
