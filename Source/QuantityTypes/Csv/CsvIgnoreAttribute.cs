// --------------------------------------------------------------------------------------------------------------------
// <copyright file="CsvIgnoreAttribute.cs" company="QuantityTypes">
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
// <summary>
//   Specifies that a property should be ignored in comma separated file output.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace QuantityTypes.Csv
{
    using System;
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
            return propertyInfo.GetCustomAttributes(typeof(CsvIgnoreAttribute), false).Length > 0;
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