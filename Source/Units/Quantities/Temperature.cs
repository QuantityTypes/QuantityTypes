namespace Units
{
    using System;

    public partial struct Temperature : IQuantity<Temperature>
    {
        /// <summary>
        /// The Kelvin unit.
        /// </summary>
        [Unit("K")]
        [Unit("degK")]
        public static Temperature Kelvin = new Temperature(-1);

        /// <summary>
        /// The Celsius unit.
        /// </summary>
        [Unit("°C", true)]
        [Unit("C")]
        [Unit("degC")]
        public static Temperature Celsius = new Temperature(-2);

        /// <summary>
        /// The Fahrenheit unit.
        /// </summary>
        [Unit("°F")]
        [Unit("F")]
        [Unit("degF")]
        public static Temperature Fahrenheit = new Temperature(-3);

        internal double value;

        /// <summary>
        /// Gets the temperature in the base unit.
        /// </summary>
        /// <value>The value.</value>
        public double Value
        {
            get
            {
                return value;
            }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Temperature"/> struct.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <remarks></remarks>
        public Temperature(double value)
        {
            this.value = value;
        }

        /// <summary>
        /// Converts to the specified unit.
        /// </summary>
        /// <param name="unit">The unit.</param>
        /// <returns>The value.</returns>
        /// <remarks></remarks>
        public double ConvertTo(Temperature unit)
        {
            if (unit.Equals(Kelvin))
            {
                return this.value;
            }

            if (unit.Equals(Celsius))
            {
                return this.value - 273.15;
            }

            if (unit.Equals(Fahrenheit))
            {
                var celsius = this.value - 273.15;
                return (celsius * 9 / 5) + 32;
            }

            throw new InvalidOperationException();
        }

        /// <summary>
        /// Implements the operator *.
        /// </summary>
        /// <param name="x">The x.</param>
        /// <param name="unit">The unit.</param>
        /// <returns>The result of the operator.</returns>
        /// <remarks></remarks>
        public static Temperature operator *(double x, Temperature unit)
        {
            if (unit.Equals(Kelvin))
            {
                return new Temperature(x);
            }
            if (unit.Equals(Celsius))
            {
                return new Temperature(x + 273.15);
            }
            if (unit.Equals(Fahrenheit))
            {
                var celsius = (x - 32) * 5 / 9;
                return new Temperature(celsius + 273.15);
            }

            throw new InvalidOperationException();
        }

        /// <summary>
        /// Parses the specified string.
        /// </summary>
        /// <param name="s">The string.</param>
        /// <param name="provider">The unit provider.</param>
        /// <returns>The temperature.</returns>
        /// <remarks></remarks>
        public static Temperature Parse(string s, IUnitProvider provider = null)
        {
            if (provider == null)
            {
                provider = UnitProvider.Default;
            }

            double value;
            Temperature unit;
            if (!provider.TryParse(s, out value, out unit))
            {
                throw new FormatException();
            }

            return value * unit;
        }

        /// <summary>
        /// Returns a <see cref="System.String"/> that represents this instance.
        /// </summary>
        /// <returns>A <see cref="System.String"/> that represents this instance.</returns>
        /// <remarks></remarks>
        public override string ToString()
        {
            return this.ToString(null, UnitProvider.Default);
        }

        /// <summary>
        /// Returns a <see cref="System.String"/> that represents this instance.
        /// </summary>
        /// <param name="format">The format to use.-or- A null reference (Nothing in Visual Basic) to use the default format defined for the type of the <see cref="T:System.IFormattable"/> implementation.</param>
        /// <param name="formatProvider">The provider to use to format the value.-or- A null reference (Nothing in Visual Basic) to obtain the numeric format information from the current locale setting of the operating system.</param>
        /// <returns>A <see cref="System.String"/> that represents this instance.</returns>
        /// <remarks></remarks>
        public string ToString(string format, IFormatProvider formatProvider = null)
        {
            var up = formatProvider as IUnitProvider ?? UnitProvider.Default;
            return up.Format(format, this);
        }

        /// <summary>
        /// Equalses the specified other.
        /// </summary>
        /// <param name="other">The other.</param>
        /// <returns></returns>
        /// <remarks></remarks>
        public bool Equals(Temperature other)
        {
            return this.value.Equals(other.value);
        }

        /// <summary>
        /// Compares to.
        /// </summary>
        /// <param name="other">The other.</param>
        /// <returns></returns>
        /// <remarks></remarks>
        public int CompareTo(Temperature other)
        {
            return this.value.CompareTo(other.value);
        }
    }
}