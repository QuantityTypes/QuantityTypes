// --------------------------------------------------------------------------------------------------------------------
// <copyright file="QuantityTypeConverter.cs" company="QuantityTypes">
//   Copyright (c) 2014 QuantityTypes contributors
// </copyright>
// <summary>
//   Implements a generic type converter from string to quantity types.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Units
{
    using System;
    using System.ComponentModel;
    using System.Globalization;

    /// <summary>
    /// Implements a generic type converter from string to quantity types.
    /// </summary>
    /// <typeparam name="T">
    /// </typeparam>
    public class QuantityTypeConverter<T> : TypeConverter
        where T : IQuantity<T>
    {
        /// <summary>
        /// Returns whether this converter can convert an object of the given type to the type of this converter, using the specified context.
        /// </summary>
        /// <param name="context">
        /// An <see cref="T:System.ComponentModel.ITypeDescriptorContext"/> that provides a format context. 
        /// </param>
        /// <param name="sourceType">
        /// A <see cref="T:System.Type"/> that represents the type you want to convert from. 
        /// </param>
        /// <returns>
        /// true if this converter can perform the conversion; otherwise, false. 
        /// </returns>
        public override bool CanConvertFrom(ITypeDescriptorContext context, Type sourceType)
        {
            if (sourceType == typeof(string))
            {
                return true;
            }

            if (sourceType == typeof(double))
            {
                return true;
            }

            return base.CanConvertFrom(context, sourceType);
        }

        /// <summary>
        /// Converts the given object to the type of this converter, using the specified context and culture information.
        /// </summary>
        /// <param name="context">
        /// An <see cref="T:System.ComponentModel.ITypeDescriptorContext"/> that provides a format context. 
        /// </param>
        /// <param name="culture">
        /// The <see cref="T:System.Globalization.CultureInfo"/> to use as the current culture. 
        /// </param>
        /// <param name="value">
        /// The <see cref="T:System.Object"/> to convert. 
        /// </param>
        /// <returns>
        /// An <see cref="T:System.Object"/> that represents the converted value. 
        /// </returns>
        /// <exception cref="T:System.NotSupportedException">
        /// The conversion cannot be performed.
        /// </exception>
        public override object ConvertFrom(ITypeDescriptorContext context, CultureInfo culture, object value)
        {
            var s = value as string;
            if (Nullable.GetUnderlyingType(typeof(T))!=null)
            {
                if (value == null || string.IsNullOrWhiteSpace(s))
                {
                    return null;
                }
            }

            if (s != null)
            {
                return (T)Activator.CreateInstance(typeof(T), s, null);
            }

            if (value is double)
            {
                var d = (double)value;
                return (T)Activator.CreateInstance(typeof(T), d.ToString(culture));
            }

            return default(T);
        }

        /// <summary>
        /// Returns whether this converter can convert the object to the specified type, using the specified context.
        /// </summary>
        /// <param name="context">An <see cref="T:System.ComponentModel.ITypeDescriptorContext" /> that provides a format context.</param>
        /// <param name="destinationType">A <see cref="T:System.Type" /> that represents the type you want to convert to.</param>
        /// <returns>true if this converter can perform the conversion; otherwise, false.</returns>
        public override bool CanConvertTo(ITypeDescriptorContext context, Type destinationType)
        {
            if (destinationType == typeof(string))
            {
                return true;
            }

            if (destinationType == typeof(double))
            {
                return true;
            }

            return base.CanConvertTo(context, destinationType);
        }

        /// <summary>
        /// Converts the given value object to the specified type, using the specified context and culture information.
        /// </summary>
        /// <param name="context">An <see cref="T:System.ComponentModel.ITypeDescriptorContext" /> that provides a format context.</param>
        /// <param name="culture">A <see cref="T:System.Globalization.CultureInfo" />. If null is passed, the current culture is assumed.</param>
        /// <param name="value">The <see cref="T:System.Object" /> to convert.</param>
        /// <param name="destinationType">The <see cref="T:System.Type" /> to convert the <paramref name="value" /> parameter to.</param>
        /// <returns>An <see cref="T:System.Object" /> that represents the converted value.</returns>
        public override object ConvertTo(ITypeDescriptorContext context, CultureInfo culture, object value, Type destinationType)
        {
            var q = value as IQuantity<T>;
            if (q != null)
            {
                if (destinationType == typeof(string))
                {
                    return q.ToString(null, culture);
                }

                if (destinationType == typeof(double))
                {
                    return q.Value;
                }
            }

            return base.ConvertTo(context, culture, value, destinationType);
        }
    }
}