namespace Units.Dynamic
{
    using System;
    using System.Diagnostics.CodeAnalysis;

    //public struct Unit
    //{
    //    public double Factor { get; set; }
    //    public double Symbol { get; set; }
    //    public Dimensions Dimensions { get; set; }
    //}

    [SuppressMessage("StyleCop.CSharp.DocumentationRules", "SA1600:ElementsMustBeDocumented", Justification = "Experimental code...")]
    public struct DynamicQuantity : IFormattable, IComparable, IComparable<DynamicQuantity>, IEquatable<DynamicQuantity>
    {
        private readonly double value;

        private readonly Dimensions dim;

        static DynamicQuantity()
        {
            var up = new DynamicUnitProvider();
            up.Register(typeof(SI));
            UnitProvider = up;
        }

        public DynamicQuantity(double value, Dimensions dim)
        {
            this.value = value;
            this.dim = dim;
        }

        public static IDynamicUnitProvider UnitProvider { get; set; }

        public Dimensions Dimensions
        {
            get
            {
                return this.dim;
            }
        }

        public double Value
        {
            get
            {
                return this.value;
            }
        }

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

        public static DynamicQuantity operator -(DynamicQuantity q1)
        {
            return new DynamicQuantity(-q1.Value, q1.dim);
        }

        public static DynamicQuantity operator *(DynamicQuantity q1, DynamicQuantity q2)
        {
            return new DynamicQuantity(q1.Value * q2.Value, q1.dim + q2.dim);
        }

        public static DynamicQuantity operator *(double q1, DynamicQuantity q2)
        {
            return new DynamicQuantity(q1 * q2.Value, q2.dim);
        }

        public static DynamicQuantity operator /(DynamicQuantity q1, DynamicQuantity q2)
        {
            return new DynamicQuantity(q1.Value / q2.Value, q1.dim - q2.dim);
        }

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

        public static DynamicQuantity Parse(string s, IFormatProvider provider = null)
        {
            DynamicQuantity q;
            if (!TryParse(s, out q, provider))
            {
                throw new FormatException("Could not parse " + s);
            }

            return q;
        }

        public int CompareTo(DynamicQuantity other)
        {
            if (!other.dim.Equals(this.dim))
            {
                throw new InvalidOperationException("Cannot compare different dimensions.");
            }

            return other.value.CompareTo(this.value);
        }

        public bool Equals(DynamicQuantity other)
        {
            return other.value.Equals(this.value) && other.dim.Equals(this.dim);
        }

        public override string ToString()
        {
            return this.ToString(null, UnitProvider);
        }

        public int CompareTo(object obj)
        {
            return this.CompareTo((DynamicQuantity)obj);
        }

        public double ConvertTo(DynamicQuantity unit)
        {
            return (this / unit).value;
        }

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

        public string ToString(IFormatProvider formatProvider)
        {
            return this.ToString(null, formatProvider);
        }
    }
}