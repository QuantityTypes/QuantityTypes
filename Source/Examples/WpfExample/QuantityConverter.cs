namespace WpfExample
{
    using System;
    using System.Globalization;
    using System.Windows.Data;

    using QuantityTypes;

    /// <summary>
    /// Converts <see cref="IQuantity"/> instances to <see cref="String"/> instances.
    /// </summary>
    [ValueConversion(typeof(IQuantity), typeof(string))]
    public class QuantityConverter : IValueConverter
    {
        /// <summary>
        /// Converts a value.
        /// </summary>
        /// <param name="value">The value produced by the binding source.</param>
        /// <param name="targetType">The type of the binding target property.</param>
        /// <param name="parameter">The converter parameter to use.</param>
        /// <param name="culture">The culture to use in the converter.</param>
        /// <returns>A converted value. If the method returns null, the valid null value is used.</returns>
        /// <exception cref="System.NotSupportedException">Conversion to  + targetType +  is not supported.</exception>
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (targetType == typeof(string))
            {
                if (parameter == null)
                {
                    return string.Format(culture, "{0}", value);
                }

                var formatString = parameter.ToString();
                if (!formatString.Contains("{0"))
                {
                    formatString = "{0:" + formatString + "}";
                }

                return string.Format(culture, formatString, value);
            }

            throw new NotSupportedException("Conversion to " + targetType + " is not supported.");
        }

        /// <summary>
        /// Converts a value.
        /// </summary>
        /// <param name="value">The value that is produced by the binding target.</param>
        /// <param name="targetType">The type to convert to.</param>
        /// <param name="parameter">The converter parameter to use.</param>
        /// <param name="culture">The culture to use in the converter.</param>
        /// <returns>A converted value. If the method returns null, the valid null value is used.</returns>
        /// <exception cref="System.InvalidOperationException">Cannot set  + targetType +  to null.</exception>
        /// <exception cref="System.FormatException">Could not parse  + value +  to  + targetType + .</exception>
        /// <exception cref="System.NotSupportedException">Conversion to  + targetType +  is not supported.</exception>
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var underlyingType = Nullable.GetUnderlyingType(targetType);
            var realType = underlyingType ?? targetType;
            if (typeof(IQuantity).IsAssignableFrom(realType))
            {
                if (value == null)
                {
                    if (underlyingType != null)
                    {
                        return null;
                    }

                    throw new InvalidOperationException("Cannot set " + targetType + " to null.");
                }

                var s = value.ToString();
                IQuantity q;
                if (UnitProvider.Default.TryParse(realType, s, culture, out q))
                {
                    return q;
                }

                throw new FormatException("Could not parse " + value + " to " + targetType + ".");
            }

            throw new NotSupportedException("Conversion to " + targetType + " is not supported.");
        }
    }
}