// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Temperature.cs" company="Units.NET">
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
// --------------------------------------------------------------------------------------------------------------------
namespace Units
{
    using System;

    /// <summary>
    ///     Represents a temperature quantity.
    /// </summary>
    /// <remarks>
    ///     This quantity type must be handled specially.
    /// </remarks>
    public partial struct Temperature : IQuantity<Temperature>
    {
        /// <summary>
        /// The celsius backing field.
        /// </summary>
        private static readonly Temperature CelsiusField = new Temperature(-2);

        /// <summary>
        /// The fahrenheit backing field.
        /// </summary>
        private static readonly Temperature FahrenheitField = new Temperature(-3);

        /// <summary>
        /// The kelvin backing field.
        /// </summary>
        private static readonly Temperature KelvinField = new Temperature(-1);

        /// <summary>
        ///     The Celsius unit.
        /// </summary>
        [Unit("°C", true)]
        [Unit("C")]
        [Unit("degC")]
        public static Temperature Celsius
        {
            get { return CelsiusField; }
        }

        /// <summary>
        ///     The Fahrenheit unit.
        /// </summary>
        [Unit("°F")]
        [Unit("F")]
        [Unit("degF")]
        public static Temperature Fahrenheit
        {
            get { return FahrenheitField; }
        }

        /// <summary>
        ///     The Kelvin unit.
        /// </summary>
        [Unit("K")]
        [Unit("degK")]
        public static Temperature Kelvin
        {
            get { return KelvinField; }
        }

        /// <summary>
        ///     The value
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
        ///     Gets the temperature in the base unit.
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

            if (unit.Equals(Celsius))
            {
                return this.value - 273.15;
            }

            if (unit.Equals(Fahrenheit))
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
            IUnitProvider up = formatProvider as IUnitProvider ?? UnitProvider.Default;
            return up.Format(format, this);
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
        ///     Implements the operator *.
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

            if (unit.Equals(Celsius))
            {
                return new Temperature(x + 273.15);
            }

            if (unit.Equals(Fahrenheit))
            {
                double celsius = (x - 32) * 5 / 9;
                return new Temperature(celsius + 273.15);
            }

            throw new InvalidOperationException();
        }

        /// <summary>
        ///     Returns a <see cref="System.String" /> that represents this instance.
        /// </summary>
        /// <returns> A <see cref="System.String" /> that represents this instance. </returns>
        public override string ToString()
        {
            return this.ToString(null, UnitProvider.Default);
        }
    }
}