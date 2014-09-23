// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Length1.cs" company="QuantityTypes">
//   Copyright (c) 2014 QuantityTypes contributors
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace UnitDemo
{
    using System;
    using System.IO;

    public partial struct Length : IQuantity<Length>
    {
        [Unit("m", true)]
        public static Length Meter = new Length(1);

        [Unit("mm")]
        public static Length Millimeter = new Length(1e-3);

        internal double value;

        public Length(double value)
        {
            this.value = value;
        }

        public static Length operator +(Length l1, Length l2)
        {
            return new Length(l1.value + l2.value);
        }

        public static Length operator -(Length l1, Length l2)
        {
            return new Length(l1.value - l2.value);
        }

        public static Length operator *(double x, Length l)
        {
            return new Length(x * l.value);
        }

        public static Length operator /(Length l, double x)
        {
            return new Length(l.value / x);
        }

        public static bool operator <(Length l1, Length l2)
        {
            return l1.value < l2.value;
        }

        public static bool operator >(Length l1, Length l2)
        {
            return l1.value > l2.value;
        }

        public static bool operator <=(Length l1, Length l2)
        {
            return l1.value <= l2.value;
        }

        public static bool operator >=(Length l1, Length l2)
        {
            return l1.value >= l2.value;
        }

        public static bool operator ==(Length l1, Length l2)
        {
            return l1.value == l2.value;
        }

        public static bool operator !=(Length l1, Length l2)
        {
            return l1.value != l2.value;
        }

        public override bool Equals(object obj)
        {
            return this.Equals((Length)obj);
        }

        public override int GetHashCode()
        {
            return this.value.GetHashCode();
        }

        public double ConvertTo(Length unit)
        {
            return this.value / unit.value;
        }

        public bool Equals(Length other)
        {
            return this.value.Equals(other.value);
        }

        public int CompareTo(Length other)
        {
            return this.value.CompareTo(other.value);
        }

        public override string ToString()
        {
            return this.ToString(null, UnitProvider.Default);
        }

        public string ToString(string format, IFormatProvider formatProvider = null)
        {
            var up = formatProvider as IUnitProvider ?? UnitProvider.Default;
            return up.Format(format, this);
        }

        public static Length Parse(string s, IUnitProvider provider = null)
        {
            if (provider == null)
            {
                provider = UnitProvider.Default;
            }

            double value;
            Length unit;
            if (!provider.TryParse(s, out value, out unit))
            {
                throw new FormatException();
            }

            return value * unit;
        }
    }
}