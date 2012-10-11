// --------------------------------------------------------------------------------------------------------------------
// <copyright file="AmountOfSubstance.cs" company="Units.NET">
//   Copyright (c) 2012 Oystein Bjorke
// </copyright>
// <summary>
//   Represents a AmountOfSubstance quantity.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Units
{
    using System;
    using System.ComponentModel;
    using System.Runtime.Serialization;
    using System.Xml.Serialization;

    /// <summary>
    /// Represents a AmountOfSubstance quantity.
    /// </summary>
    [Serializable]
    [DataContract]
    [TypeConverter(typeof(QuantityTypeConverter<AmountOfSubstance>))]
    public partial struct AmountOfSubstance : IQuantity<AmountOfSubstance>
    {
        /// <summary>
        /// The mol unit.
        /// </summary>
        [Unit("mol", true)]
        public static AmountOfSubstance Mole = new AmountOfSubstance(1);

        /// <summary>
        /// The value.
        /// </summary>
#if PublicFields
        public double value;
#else
        private double value;
#endif

        /// <summary>
        /// Initializes a new instance of the <see cref="AmountOfSubstance"/> struct.
        /// </summary>
        /// <param name="value">
        /// The value.
        /// </param>
        public AmountOfSubstance(double value)
        {
            this.value = value;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="AmountOfSubstance"/> struct.
        /// </summary>
        /// <param name="value">
        /// The value.
        /// </param>
        /// <param name="unitProvider">
        /// The unit provider.
        /// </param>
        public AmountOfSubstance(string value, IUnitProvider unitProvider = null)
        {
            this.value = Parse(value, unitProvider ?? UnitProvider.Default).value;
        }

        /// <summary>
        /// Gets or sets the AmountOfSubstance as a string.
        /// </summary>
        /// <value>The string.</value>
        /// <remarks>
        /// This property is used for XML serialization.
        /// </remarks>
        [XmlText]
        [DataMember]
        public string Data
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
        /// Gets the value of the quantity in the base unit.
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
        /// The <see cref="AmountOfSubstance"/> .
        /// </returns>
        public static AmountOfSubstance Parse(string input, IUnitProvider provider = null)
        {
            if (provider == null)
            {
                provider = UnitProvider.Default;
            }

            double value;
            AmountOfSubstance unit;
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
        public static AmountOfSubstance operator +(AmountOfSubstance x, AmountOfSubstance y)
        {
            return new AmountOfSubstance(x.value + y.value);
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
        public static AmountOfSubstance operator /(AmountOfSubstance x, double y)
        {
            return new AmountOfSubstance(x.value / y);
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
        public static double operator /(AmountOfSubstance x, AmountOfSubstance y)
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
        public static bool operator ==(AmountOfSubstance x, AmountOfSubstance y)
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
        public static bool operator >(AmountOfSubstance x, AmountOfSubstance y)
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
        public static bool operator >=(AmountOfSubstance x, AmountOfSubstance y)
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
        public static bool operator !=(AmountOfSubstance x, AmountOfSubstance y)
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
        public static bool operator <(AmountOfSubstance x, AmountOfSubstance y)
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
        public static bool operator <=(AmountOfSubstance x, AmountOfSubstance y)
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
        public static AmountOfSubstance operator *(double x, AmountOfSubstance y)
        {
            return new AmountOfSubstance(x * y.value);
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
        public static AmountOfSubstance operator -(AmountOfSubstance x, AmountOfSubstance y)
        {
            return new AmountOfSubstance(x.value - y.value);
        }

        /// <summary>
        /// Compares this instance to the specified <see cref="AmountOfSubstance"/> and returns an indication of their relative values.
        /// </summary>
        /// <param name="other">
        /// The other <see cref="AmountOfSubstance"/> .
        /// </param>
        /// <returns>
        /// A signed number indicating the relative values of this instance and the other value.
        /// </returns>
        public int CompareTo(AmountOfSubstance other)
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
        public double ConvertTo(AmountOfSubstance unit)
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
            return this.Equals((AmountOfSubstance)obj);
        }

        /// <summary>
        /// Determines if the specified <see cref="AmountOfSubstance"/> is equal to this instance.
        /// </summary>
        /// <param name="other">
        /// The other <see cref="AmountOfSubstance"/> .
        /// </param>
        /// <returns>
        /// True if the values are equal.
        /// </returns>
        public bool Equals(AmountOfSubstance other)
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