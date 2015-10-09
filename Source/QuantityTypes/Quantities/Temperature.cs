// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Temperature.cs" company="QuantityTypes">
//   Copyright (c) 2014 QuantityTypes contributors
// </copyright>
// <summary>
//   Represents a thermodynamic temperature.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace QuantityTypes
{
    using System;

    /// <summary>
    ///   Represents a thermodynamic temperature.
    /// </summary>
    public partial struct Temperature : IQuantity<Temperature>
    {
        /// <summary>
        ///   The Celsius degree backing field.
        /// </summary>
        private static readonly Temperature DegreeCelsiusField = new Temperature(-2);

        /// <summary>
        ///   The Fahrenheit degree backing field.
        /// </summary>
        private static readonly Temperature DegreeFahrenheitField = new Temperature(-3);

        /// <summary>
        ///   The Kelvin backing field.
        /// </summary>
        private static readonly Temperature KelvinField = new Temperature(-1);

        /// <summary>
        ///   The value backing field.
        /// </summary>
        private readonly double value;

        /// <summary>
        /// Initializes a new instance of the <see cref="Temperature"/> struct.
        /// </summary>
        /// <param name="value">
        /// The value. 
        /// </param>
        public Temperature(double value)
        {
            this.value = value;
        }

        /// <summary>
        ///   Gets the DegreeCelsius unit.
        /// </summary>
        [Unit("°C", true)]
        [Unit("C")]
        [Unit("degC")]
        public static Temperature DegreeCelsius
        {
            get
            {
                return DegreeCelsiusField;
            }
        }

        /// <summary>
        ///   Gets the DegreeFahrenheit unit.
        /// </summary>
        [Unit("°F")]
        [Unit("F")]
        [Unit("degF")]
        public static Temperature DegreeFahrenheit
        {
            get
            {
                return DegreeFahrenheitField;
            }
        }

        /// <summary>
        ///   Gets the Kelvin unit.
        /// </summary>
        [Unit("K")]
        public static Temperature Kelvin
        {
            get
            {
                return KelvinField;
            }
        }

        /// <summary>
        ///   Gets the numeric value of the temperature in the base unit.
        /// </summary>
        /// <value> The value. </value>
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
        /// <param name="s">
        /// The string. 
        /// </param>
        /// <param name="provider">
        /// The unit provider. 
        /// </param>
        /// <returns>
        /// The temperature. 
        /// </returns>
        public static Temperature Parse(string s, IFormatProvider provider = null)
        {
            var unitProvider = provider as IUnitProvider ?? UnitProvider.Default;

            Temperature value;
            if (!unitProvider.TryParse(s, provider, out value))
            {
                throw new FormatException();
            }

            return value;
        }

        /// <summary>
        ///   Implements the operator *.
        /// </summary>
        /// <param name="x"> The x. </param>
        /// <param name="unit"> The unit. </param>
        /// <returns> The result of the operator. </returns>
        public static Temperature operator *(double x, Temperature unit)
        {
            if (unit.Equals(Kelvin))
            {
                return new Temperature(x);
            }

            if (unit.Equals(DegreeCelsius))
            {
                return new Temperature(x + 273.15);
            }

            if (unit.Equals(DegreeFahrenheit))
            {
                double celsius = (x - 32) * 5 / 9;
                return new Temperature(celsius + 273.15);
            }

            throw new InvalidOperationException();
        }

        /// <summary>
        /// Compares the temperature to the specified temperature.
        /// </summary>
        /// <param name="other">
        /// The other temperature. 
        /// </param>
        /// <returns>
        /// A 32-bit signed integer that indicates the relative order of the comparands. 
        /// </returns>
        public int CompareTo(Temperature other)
        {
            return this.value.CompareTo(other.value);
        }

        /// <summary>
        /// Compares the current instance with another object of the same type and returns an integer that indicates whether the current instance precedes, follows, or occurs in the same position in the sort order as the other object.
        /// </summary>
        /// <param name="obj">
        /// An object to compare with this instance. 
        /// </param>
        /// <returns>
        /// A value that indicates the relative order of the objects being compared. The return value has these meanings: Value Meaning Less than zero This instance is less than <paramref name="obj"/> . Zero This instance is equal to <paramref name="obj"/> . Greater than zero This instance is greater than <paramref name="obj"/> . 
        /// </returns>
        public int CompareTo(object obj)
        {
            return this.CompareTo((Temperature)obj);
        }

        /// <summary>
        /// Converts to the specified unit.
        /// </summary>
        /// <param name="unit">
        /// The unit. 
        /// </param>
        /// <returns>
        /// The value. 
        /// </returns>
        public double ConvertTo(Temperature unit)
        {
            if (unit.Equals(Kelvin))
            {
                return this.value;
            }

            if (unit.Equals(DegreeCelsius))
            {
                return this.value - 273.15;
            }

            if (unit.Equals(DegreeFahrenheit))
            {
                double celsius = this.value - 273.15;
                return (celsius * 9 / 5) + 32;
            }

            throw new InvalidOperationException();
        }

        /// <summary>
        /// Determines whether two Object instances are equal.
        /// </summary>
        /// <param name="other">
        /// The other temperature. 
        /// </param>
        /// <returns>
        /// <c>true</c> if equal, <c>false</c> otherwise 
        /// </returns>
        public bool Equals(Temperature other)
        {
            return this.value.Equals(other.value);
        }

        /// <summary>
        /// Multiplies by the specified number.
        /// </summary>
        /// <param name="x">
        /// The number. 
        /// </param>
        /// <returns>
        /// The new quantity. 
        /// </returns>
        /// <exception cref="System.InvalidOperationException">
        /// Cannot multiply a temperature.
        /// </exception>
        public IQuantity MultiplyBy(double x)
        {
            return x * this;
        }


        /// <summary>
        /// Adds the specified quantity.
        /// </summary>
        /// <param name="x">The quantity to add.</param>
        /// <returns>The sum.</returns>
        public IQuantity Add(IQuantity x)
        {
            if (!(x is Temperature))
            {
                throw new InvalidOperationException("Can only add quantities of the same types.");
            }

            return new Temperature(this.value + x.Value);
        }

        /// <summary>
        /// Returns a <see cref="System.String"/> that represents this instance.
        /// </summary>
        /// <param name="format">
        /// The format to use.-or- A null reference (Nothing in Visual Basic) to use the default format defined for the type of the <see cref="T:System.IFormattable"/> implementation. 
        /// </param>
        /// <param name="formatProvider">
        /// The provider to use to format the value.-or- A null reference (Nothing in Visual Basic) to obtain the numeric format information from the current locale setting of the operating system. 
        /// </param>
        /// <returns>
        /// A <see cref="System.String"/> that represents this instance. 
        /// </returns>
        public string ToString(string format, IFormatProvider formatProvider = null)
        {
            var unitProvider = formatProvider as IUnitProvider ?? UnitProvider.Default;
            return unitProvider.Format(format, formatProvider, this);
        }

        /// <summary>
        ///   Returns a <see cref="System.String" /> that represents this instance.
        /// </summary>
        /// <returns> A <see cref="System.String" /> that represents this instance. </returns>
        public override string ToString()
        {
            return this.ToString(null, UnitProvider.Default);
        }

        /// <summary>
        /// Converts the quantity to the specified unit.
        /// </summary>
        /// <param name="unit">
        /// The unit. 
        /// </param>
        /// <returns>
        /// The amount of the specified unit. 
        /// </returns>
        double IQuantity.ConvertTo(IQuantity unit)
        {
            return this.ConvertTo((Temperature)unit);
        }
    }
}