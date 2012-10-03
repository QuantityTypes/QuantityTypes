// --------------------------------------------------------------------------------------------------------------------
// <copyright file="MassMomentOfInertia.cs" company="Units for .NET">
//   http://units.codeplex.com, license: Ms-PL
// </copyright>
// <summary>
//   Represents a MassMomentOfInertia quantity.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Units
{
    using System;
    using System.ComponentModel;
    using System.Runtime.Serialization;
    using System.Xml.Serialization;

    /// <summary>
    /// Represents a MassMomentOfInertia quantity.
    /// </summary>
    [Serializable]
	[DataContract]
    [TypeConverter(typeof(QuantityTypeConverter<MassMomentOfInertia>))]
    public partial struct MassMomentOfInertia : IQuantity<MassMomentOfInertia>
    {
        #region Constants and Fields

        /// <summary>
        /// The kg*m^2 unit.
        /// </summary>
        [Unit("kg*m^2", true)]
        public static MassMomentOfInertia KilogramMetreSquared = new MassMomentOfInertia(1);

        /// <summary>
        /// The lb*in^2 unit.
        /// </summary>
        [Unit("lb*in^2")]
        public static MassMomentOfInertia PoundInchSquared = new MassMomentOfInertia(0.0002926396534292);

        /// <summary>
        /// The lb*ft^2 unit.
        /// </summary>
        [Unit("lb*ft^2")]
        public static MassMomentOfInertia PoundFootSquared = new MassMomentOfInertia(0.0421401100938048);

        /// <summary>
        /// The lbf*in*s^2 unit.
        /// </summary>
        [Unit("lbf*in*s^2")]
        public static MassMomentOfInertia PoundforceInchSecondSquared = new MassMomentOfInertia(0.112984829027604);

        /// <summary>
        /// Gets or sets the MassMomentOfInertia as a string.
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
        /// The value.
        /// </summary>
#if PublicFields
        public double value;
#else
        private double value;
#endif
        #endregion

        #region Constructors and Destructors

        /// <summary>
        /// Initializes a new instance of the <see cref="MassMomentOfInertia"/> struct.
        /// </summary>
        /// <param name="value">
        /// The value. 
        /// </param>
        public MassMomentOfInertia(double value)
        {
            this.value = value;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="MassMomentOfInertia"/> struct.
        /// </summary>
        /// <param name="value">
        /// The value. 
        /// </param>
        /// <param name="unitProvider">
        /// The unit provider. 
        /// </param>
        public MassMomentOfInertia(string value, IUnitProvider unitProvider = null)
        {
            this.value = Parse(value, unitProvider ?? UnitProvider.Default).value;
        }

        #endregion

        #region Properties

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

        #endregion

        #region Public Methods and Operators

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
        /// The <see cref="MassMomentOfInertia"/> . 
        /// </returns>
        public static MassMomentOfInertia Parse(string input, IUnitProvider provider = null)
        {
            if (provider == null)
            {
                provider = UnitProvider.Default;
            }

            double value;
            MassMomentOfInertia unit;
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
        public static MassMomentOfInertia operator +(MassMomentOfInertia x, MassMomentOfInertia y)
        {
            return new MassMomentOfInertia(x.value + y.value);
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
        public static MassMomentOfInertia operator /(MassMomentOfInertia x, double y)
        {
            return new MassMomentOfInertia(x.value / y);
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
        public static double operator /(MassMomentOfInertia x, MassMomentOfInertia y)
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
        public static bool operator ==(MassMomentOfInertia x, MassMomentOfInertia y)
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
        public static bool operator >(MassMomentOfInertia x, MassMomentOfInertia y)
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
        public static bool operator >=(MassMomentOfInertia x, MassMomentOfInertia y)
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
        public static bool operator !=(MassMomentOfInertia x, MassMomentOfInertia y)
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
        public static bool operator <(MassMomentOfInertia x, MassMomentOfInertia y)
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
        public static bool operator <=(MassMomentOfInertia x, MassMomentOfInertia y)
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
        public static MassMomentOfInertia operator *(double x, MassMomentOfInertia y)
        {
            return new MassMomentOfInertia(x * y.value);
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
        public static MassMomentOfInertia operator -(MassMomentOfInertia x, MassMomentOfInertia y)
        {
            return new MassMomentOfInertia(x.value - y.value);
        }

        /// <summary>
        /// Compares this instance to the specified <see cref="MassMomentOfInertia"/> and returns an indication of their relative values.
        /// </summary>
        /// <param name="other">
        /// The other <see cref="MassMomentOfInertia"/> . 
        /// </param>
        /// <returns>
        /// A signed number indicating the relative values of this instance and the other value. 
        /// </returns>
        public int CompareTo(MassMomentOfInertia other)
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
        public double ConvertTo(MassMomentOfInertia unit)
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
            return this.Equals((MassMomentOfInertia)obj);
        }

        /// <summary>
        /// Determines if the specified <see cref="MassMomentOfInertia"/> is equal to this instance.
        /// </summary>
        /// <param name="other">
        /// The other <see cref="MassMomentOfInertia"/> . 
        /// </param>
        /// <returns>
        /// True if the values are equal. 
        /// </returns>
        public bool Equals(MassMomentOfInertia other)
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

        #endregion
    }
}
