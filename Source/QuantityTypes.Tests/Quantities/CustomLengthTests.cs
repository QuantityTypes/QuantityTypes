using System;
using System.Globalization;
using System.Xml;
using System.Xml.Schema;
using System.Xml.Serialization;
using NUnit.Framework;

namespace QuantityTypes.Tests
{
    public class CustomLengthTests
    {
        [Test]
        public void Unit()
        {
            UnitProvider.Default.RegisterUnits(typeof(CustomLength));

            Assert.AreEqual("0.001 m", Length.Millimetre.ToString(CultureInfo.InvariantCulture));
            Assert.AreEqual("1 mm", CustomLength.Millimetre.ToString(CultureInfo.InvariantCulture));
            Assert.AreEqual(CustomLength.Millimetre, (CustomLength)Length.Millimetre);
            Assert.AreEqual(Length.Millimetre, (Length)CustomLength.Millimetre);
            Assert.AreEqual(CustomLength.Millimetre, CustomLength.Parse("1 mm"));
        }
    }

    public struct CustomLength : IQuantity<CustomLength>
    {
        /// <summary>
        /// The value.
        /// </summary>
        private double value;

        /// <summary>
        /// Initializes a new instance of the <see cref="CustomLength"/> struct.
        /// </summary>
        /// <param name="value">
        /// The value. 
        /// </param>
        public CustomLength(double value)
        {
            this.value = value;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="CustomLength"/> struct.
        /// </summary>
        /// <param name="value">
        /// The value. 
        /// </param>
        /// <param name="unitProvider">
        /// The unit provider. 
        /// </param>
        public CustomLength(string value, IUnitProvider unitProvider = null)
        {
            this.value = Parse(value, unitProvider ?? UnitProvider.Default).value;
        }

        /// <summary>
        /// Gets the "mm" unit.
        /// </summary>
        [Unit("mm", true)]
        public static CustomLength Millimetre { get; } = new CustomLength(1e-3);

        /// <summary>
        /// Gets the positive infinity quantity.
        /// </summary>
        public static CustomLength PositiveInfinity { get; } = new CustomLength(double.PositiveInfinity);

        /// <summary>
        /// Gets the negative infinity quantity.
        /// </summary>
        public static CustomLength NegativeInfinity { get; } = new CustomLength(double.NegativeInfinity);

        /// <summary>
        /// Gets the NaN quantity.
        /// </summary>
        public static CustomLength NaN { get; } = new CustomLength(double.NaN);

        /// <summary>
        /// Gets the value of the CustomLength in the base unit.
        /// </summary>
        public double Value => this.value;

        /// <summary>
        /// Converts a string representation of a quantity in a specific culture-specific format with a specific unit provider.
        /// </summary>
        /// <param name="input">
        /// A string that contains the quantity to convert. 
        /// </param>
        /// <param name="provider">
        /// An object that supplies culture-specific formatting information about <paramref name="input" />. If not specified, the culture of the default <see cref="UnitProvider" /> is used. 
        /// </param>
        /// <param name="unitProvider">
        /// The unit provider. If not specified, the default <see cref="UnitProvider" /> is used.
        /// </param>
        /// <returns>
        /// A <see cref="CustomLength"/> that represents the quantity in <paramref name="input" />. 
        /// </returns>
        public static CustomLength Parse(string input, IFormatProvider provider, IUnitProvider unitProvider)
        {
            if (unitProvider == null)
            {
                unitProvider = provider as IUnitProvider ?? UnitProvider.Default;
            }

            CustomLength value;
            if (!unitProvider.TryParse(input, provider, out value))
            {
                throw new FormatException("Invalid format.");
            }

            return value;
        }

        /// <summary>
        /// Converts a string representation of a quantity in a specific culture-specific format.
        /// </summary>
        /// <param name="input">
        /// A string that contains the quantity to convert. 
        /// </param>
        /// <param name="provider">
        /// An object that supplies culture-specific formatting information about <paramref name="input" />. If not specified, the culture of the default <see cref="UnitProvider" /> is used. 
        /// </param>
        /// <returns>
        /// A <see cref="CustomLength"/> that represents the quantity in <paramref name="input" />. 
        /// </returns>
        public static CustomLength Parse(string input, IFormatProvider provider = null)
        {
            var unitProvider = provider as IUnitProvider ?? UnitProvider.Default;

            CustomLength value;
            if (!unitProvider.TryParse(input, provider, out value))
            {
                throw new FormatException("Invalid format.");
            }

            return value;
        }

        /// <summary>
        /// Converts a string representation of a quantity with a specific unit provider.
        /// </summary>
        /// <param name="input">
        /// A string that contains the quantity to convert. 
        /// </param>
        /// <param name="unitProvider">
        /// The unit provider. If not specified, the default <see cref="UnitProvider" /> is used.
        /// </param>
        /// <returns>
        /// A <see cref="CustomLength"/> that represents the quantity in <paramref name="input" />. 
        /// </returns>
        public static CustomLength Parse(string input, IUnitProvider unitProvider)
        {
            if (unitProvider == null)
            {
                unitProvider = UnitProvider.Default;
            }

            CustomLength value;
            if (!unitProvider.TryParse(input, unitProvider.Culture, out value))
            {
                throw new FormatException("Invalid format.");
            }

            return value;
        }

        /// <summary>
        /// Tries to parse the specified string.
        /// </summary>
        /// <param name="input">The input string.</param>
        /// <param name="provider">The format provider.</param>
        /// <param name="unitProvider">The unit provider.</param>
        /// <param name="result">The result.</param>
        /// <returns><c>true</c> if the string was parsed, <c>false</c> otherwise.</returns>
        public static bool TryParse(string input, IFormatProvider provider, IUnitProvider unitProvider, out CustomLength result)
        {
            if (unitProvider == null)
            {
                unitProvider = provider as IUnitProvider ?? UnitProvider.Default;
            }

            return unitProvider.TryParse(input, provider, out result);
        }

        /// <summary>
        /// Parses the specified JSON string.
        /// </summary>
        /// <param name="input">The JSON input.</param>
        /// <returns>
        /// The <see cref="CustomLength"/> .
        /// </returns>
        public static CustomLength ParseJson(string input)
        {
            return Parse(input, CultureInfo.InvariantCulture);
        }

        /// <summary>
        /// Returns a value that indicates whether the specified quantity is not a number.
        /// </summary>
        /// <param name="x">The quantity.</param>
        /// <returns>
        ///   <c>true</c> if the specified quantity is not a number; otherwise, <c>false</c>.
        /// </returns>
        public static bool IsNaN(CustomLength x)
        {
            return double.IsNaN(x.Value);
        }

        /// <summary>
        /// Returns a value that indicates whether the specified quantity evaluates to positive infinity.
        /// </summary>
        /// <param name="x">The quantity.</param>
        /// <returns>
        ///   <c>true</c> if the specified quantity evaluates to positive infinity; otherwise, <c>false</c>.
        /// </returns>
        public static bool IsPositiveInfinity(CustomLength x)
        {
            return double.IsPositiveInfinity(x.Value);
        }

        /// <summary>
        /// Returns a value that indicates whether the specified quantity evaluates to negative infinity.
        /// </summary>
        /// <param name="x">The quantity.</param>
        /// <returns>
        ///   <c>true</c> if the specified quantity evaluates to negative infinity; otherwise, <c>false</c>.
        /// </returns>
        public static bool IsNegativeInfinity(CustomLength x)
        {
            return double.IsNegativeInfinity(x.Value);
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
        public static CustomLength operator +(CustomLength x, CustomLength y)
        {
            return new CustomLength(x.value + y.value);
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
        public static CustomLength operator /(CustomLength x, double y)
        {
            return new CustomLength(x.value / y);
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
        public static double operator /(CustomLength x, CustomLength y)
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
        public static bool operator ==(CustomLength x, CustomLength y)
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
        public static bool operator >(CustomLength x, CustomLength y)
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
        public static bool operator >=(CustomLength x, CustomLength y)
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
        public static bool operator !=(CustomLength x, CustomLength y)
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
        public static bool operator <(CustomLength x, CustomLength y)
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
        public static bool operator <=(CustomLength x, CustomLength y)
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
        public static CustomLength operator *(double x, CustomLength y)
        {
            return new CustomLength(x * y.value);
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
        public static CustomLength operator *(CustomLength x, double y)
        {
            return new CustomLength(x.value * y);
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
        public static CustomLength operator -(CustomLength x, CustomLength y)
        {
            return new CustomLength(x.value - y.value);
        }

        /// <summary>
        /// Implements the unary plus operator.
        /// </summary>
        /// <param name="x">
        /// The x. 
        /// </param>
        /// <returns>
        /// The result of the operator. 
        /// </returns>
        public static CustomLength operator +(CustomLength x)
        {
            return new CustomLength(x.value);
        }

        /// <summary>
        /// Implements the unary minus operator.
        /// </summary>
        /// <param name="x">
        /// The x. 
        /// </param>
        /// <returns>
        /// The result of the operator. 
        /// </returns>
        public static CustomLength operator -(CustomLength x)
        {
            return new CustomLength(-x.value);
        }

        /// <summary>
        /// Compares this instance to the specified <see cref="CustomLength"/> and returns an indication of their relative values.
        /// </summary>
        /// <param name="other">
        /// The other <see cref="CustomLength"/> . 
        /// </param>
        /// <returns>
        /// A signed number indicating the relative values of this instance and the other value. 
        /// </returns>
        public int CompareTo(CustomLength other)
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
            return this.CompareTo((CustomLength)obj);
        }

        /// <summary>
        /// Converts the quantity to the specified unit.
        /// </summary>
        /// <param name="unit">The unit.</param>
        /// <returns>The amount of the specified unit.</returns>
        double IQuantity.ConvertTo(IQuantity unit)
        {
            return this.ConvertTo((CustomLength)unit);
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
        public double ConvertTo(CustomLength unit)
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
            if (obj is CustomLength)
            {
                return this.Equals((CustomLength)obj);
            }

            return false;
        }

        /// <summary>
        /// Determines if the specified <see cref="CustomLength"/> is equal to this instance.
        /// </summary>
        /// <param name="other">
        /// The other <see cref="CustomLength"/> . 
        /// </param>
        /// <returns>
        /// True if the values are equal. 
        /// </returns>
        public bool Equals(CustomLength other)
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
        /// Adds the specified quantity.
        /// </summary>
        /// <param name="x">The quantity to add.</param>
        /// <returns>The sum.</returns>
        public IQuantity Add(IQuantity x)
        {
            if (!(x is CustomLength))
            {
                throw new InvalidOperationException("Can only add quantities of the same types.");
            }

            return new CustomLength(this.value + x.Value);
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
        /// <param name="formatProvider">
        /// The format provider. 
        /// </param>
        /// <returns>
        /// A <see cref="System.String"/> that represents this instance. 
        /// </returns>
        public string ToString(IFormatProvider formatProvider)
        {
            var unitProvider = formatProvider as IUnitProvider ?? UnitProvider.Default;

            return this.ToString(null, formatProvider, unitProvider);
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
            var unitProvider = formatProvider as IUnitProvider ?? UnitProvider.Default;

            return this.ToString(format, formatProvider, unitProvider);
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
        /// <param name="unitProvider">
        /// The unit provider. 
        /// </param>
        /// <returns>
        /// A <see cref="System.String"/> that represents this instance. 
        /// </returns>
        public string ToString(string format, IFormatProvider formatProvider, IUnitProvider unitProvider)
        {
            if (unitProvider == null)
            {
                unitProvider = formatProvider as IUnitProvider ?? UnitProvider.Default;
            }

            return unitProvider.Format(format, formatProvider, this);
        }

        /// <summary>
        ///     Performs an implicit conversion from <see cref="Length" /> to <see cref="CustomLength" />.
        /// </summary>
        /// <param name="l"> The length. </param>
        /// <returns> The custom length. </returns>
        public static implicit operator CustomLength(Length l)
        {
            return new CustomLength(l.Value);
        }

        /// <summary>
        ///     Performs an implicit conversion from <see cref="CustomLength" /> to <see cref="Length" />.
        /// </summary>
        /// <param name="l"> The custom length. </param>
        /// <returns> The length. </returns>
        public static implicit operator Length(CustomLength l)
        {
            return new Length(l.Value);
        }

        /// <summary>
        /// Gets the XML schema.
        /// </summary>
        /// <returns>The schema.</returns>
        XmlSchema IXmlSerializable.GetSchema()
        {
            return null;
        }

        /// <summary>
        /// Writes the XML.
        /// </summary>
        /// <param name="writer">The writer.</param>
        void IXmlSerializable.WriteXml(XmlWriter writer)
        {
            // write the raw value in the base unit
            writer.WriteString(this.Value.ToString("R", CultureInfo.InvariantCulture));
        }

        /// <summary>
        /// Reads the XML.
        /// </summary>
        /// <param name="reader">The reader.</param>
        void IXmlSerializable.ReadXml(XmlReader reader)
        {
            var content = reader.ReadElementContentAsString();
            double v;
            if (double.TryParse(content, NumberStyles.Float, CultureInfo.InvariantCulture, out v))
            {
                this.value = v;
                return;
            }

            // If content could not be parsed to a float, try to parse with unit. 
            // This requires the UnitProvider.Default to be set.
            this.value = Parse(content, CultureInfo.InvariantCulture).value;
        }

    }
}