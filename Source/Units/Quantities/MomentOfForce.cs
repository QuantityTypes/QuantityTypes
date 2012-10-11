﻿// --------------------------------------------------------------------------------------------------------------------
// <copyright file="MomentOfForce.cs" company="Forte">
//   http://forte.codeplex.com, license: Ms-PL
// </copyright>
// <summary>
//   Represents a MomentOfForce.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Forte
{
    using System;
    using System.ComponentModel;

    /// <summary>
    /// Represents a MomentOfForce.
    /// </summary>
    [Serializable]
    [TypeConverter(typeof(QuantityTypeConverter<MomentOfForce>))]
    public partial struct MomentOfForce : IQuantity<MomentOfForce>
    {
        /// <summary>
        /// The N*m unit.
        /// </summary>
        [Unit("N*m", true)]
        public static MomentOfForce NewtonMeter = new MomentOfForce(1);

        /// <summary>
        /// The value.
        /// </summary>
        private double value;

        /// <summary>
        /// Initializes a new instance of the <see cref="MomentOfForce"/> struct.
        /// </summary>
        /// <param name="value">
        /// The value.
        /// </param>
        public MomentOfForce(double value)
        {
            this.value = value;
        }

        /// <summary>
        /// Gets the value.
        /// </summary>
        internal double Value
        {
            get
            {
                return this.value;
            }

            private set
            {
                this.value = value;
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
        /// The <see cref="MomentOfForce"/> .
        /// </returns>
        public static MomentOfForce Parse(string input, IUnitProvider provider = null)
        {
            if (provider == null)
            {
                provider = UnitProvider.Default;
            }

            double value;
            MomentOfForce unit;
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
        public static MomentOfForce operator +(MomentOfForce x, MomentOfForce y)
        {
            return new MomentOfForce(x.Value + y.Value);
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
        public static MomentOfForce operator /(MomentOfForce x, double y)
        {
            return new MomentOfForce(x.Value / y);
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
        public static bool operator ==(MomentOfForce x, MomentOfForce y)
        {
            return x.Value.Equals(y.Value);
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
        public static bool operator >(MomentOfForce x, MomentOfForce y)
        {
            return x.Value > y.Value;
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
        public static bool operator >=(MomentOfForce x, MomentOfForce y)
        {
            return x.Value >= y.Value;
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
        public static bool operator !=(MomentOfForce x, MomentOfForce y)
        {
            return !x.Value.Equals(y.Value);
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
        public static bool operator <(MomentOfForce x, MomentOfForce y)
        {
            return x.Value < y.Value;
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
        public static bool operator <=(MomentOfForce x, MomentOfForce y)
        {
            return x.Value <= y.Value;
        }

        /// <summary>
        /// Implements the operator *.
        /// </summary>
        /// <param name="x">
        /// The x.
        /// </param>
        /// <param name="l">
        /// The l.
        /// </param>
        /// <returns>
        /// The result of the operator.
        /// </returns>
        public static MomentOfForce operator *(double x, MomentOfForce l)
        {
            return new MomentOfForce(x * l.Value);
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
        public static MomentOfForce operator -(MomentOfForce x, MomentOfForce y)
        {
            return new MomentOfForce(x.Value - y.Value);
        }

        /// <summary>
        /// Compares this instance to the specified <see cref="MomentOfForce"/> and returns an indication of their relative values.
        /// </summary>
        /// <param name="other">
        /// The other <see cref="MomentOfForce"/> .
        /// </param>
        /// <returns>
        /// A signed number indicating the relative values of this instance and the other value.
        /// </returns>
        public int CompareTo(MomentOfForce other)
        {
            return this.Value.CompareTo(other.Value);
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
        public double ConvertTo(MomentOfForce unit)
        {
            return this.Value / unit.Value;
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
            return this.Equals((MomentOfForce)obj);
        }

        /// <summary>
        /// Determines if the specified <see cref="MomentOfForce"/> is equal to this instance.
        /// </summary>
        /// <param name="other">
        /// The other <see cref="MomentOfForce"/> .
        /// </param>
        /// <returns>
        /// True if the values are equal.
        /// </returns>
        public bool Equals(MomentOfForce other)
        {
            return this.Value.Equals(other.Value);
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
            this.Value = Parse(s, provider).Value;
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