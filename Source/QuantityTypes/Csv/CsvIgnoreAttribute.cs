// --------------------------------------------------------------------------------------------------------------------
// <copyright file="CsvIgnoreAttribute.cs" company="QuantityTypes">
//   Copyright (c) 2014 QuantityTypes contributors
// </copyright>
// <summary>
//   Specifies that a property should be ignored in comma separated file output.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace QuantityTypes.Csv
{
    using System;
    using System.Linq;
    using System.Reflection;

    /// <summary>
    /// Specifies that a property should be ignored in comma separated file output.
    /// </summary>
    [AttributeUsage(AttributeTargets.Property)]
    public class CsvIgnoreAttribute : Attribute
    {
        /// <summary>
        /// Determines whether the specified property should be ignored.
        /// </summary>
        /// <param name="propertyInfo">
        /// The property descriptor.
        /// </param>
        /// <returns>
        /// A <see cref="bool"/>.
        /// </returns>
        public static bool IsIgnored(PropertyInfo propertyInfo)
        {
            return propertyInfo.GetCustomAttributes(typeof(CsvIgnoreAttribute), false).Count() > 0;
        }

        /// <summary>
        /// Determines whether the specified property should not be ignored.
        /// </summary>
        /// <param name="propertyInfo">The property info.</param>
        /// <returns>A <see cref="bool" />.</returns>
        public static bool IsNotIgnored(PropertyInfo propertyInfo)
        {
            return !IsIgnored(propertyInfo);
        }
    }
}