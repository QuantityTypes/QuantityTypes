// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Utilities.cs" company="QuantityTypes">
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
//   Provides utility methods for quantity processing.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace QuantityTypes
{
    using System;
    using System.Globalization;

    /// <summary>
    /// Provides utility methods for quantity processing.
    /// </summary>
    public static class Utilities
    {
        /// <summary>
        /// Converts the string representation of a quantity to its <see cref="double"/> value and <see cref="string"/> unit equivalent. 
        /// A return value indicates whether the conversion succeeded or failed.
        /// </summary>
        /// <param name="s">A string containing a number to convert.</param>
        /// <param name="provider">An <see cref="IFormatProvider"/> that supplies culture-specific formatting information about <paramref name="s"/>.</param>
        /// <param name="resultValue">When this method returns, contains a double-precision floating-point number equivalent of the numeric value contained in s. This parameter is passed uninitialized.</param>
        /// <param name="resultUnit">When this method returns, contains a string equivalent of the unit contained in s. This parameter is passed uninitialized.</param>
        /// <returns><c>true</c> if <paramref name="s"/> was converted successfully; otherwise <c>false</c>.</returns>
        public static bool TrySplit(string s, IFormatProvider provider, out double resultValue, out string resultUnit)
        {
            // remove whitespace
            s = s.Replace(" ", string.Empty);

            // find the index where the unit starts
            int unitIndex = 0;
            while (unitIndex < s.Length)
            {
                var c = s[unitIndex];

                // exponential
                if (c == 'e' || c == 'E')
                {
                    // check if it is followed by a digit or '-'/'+', otherwise it might be a unit
                    if (unitIndex + 1 < s.Length && (char.IsDigit(s[unitIndex + 1]) || s[unitIndex + 1] == '-' || s[unitIndex + 1] == '+'))
                    {
                        unitIndex++;
                        continue;
                    }
                }

                if (char.IsLetter(c) || c == '%' || c == '°')
                {
                    // unit starts here
                    break;
                }

                // digit or numeric group separator, continue
                unitIndex++;
            }

            var valueString = unitIndex > 0 ? s.Substring(0, unitIndex) : string.Empty;
            resultUnit = unitIndex < s.Length ? s.Substring(unitIndex) : string.Empty;

            resultValue = 0;
            if (string.IsNullOrEmpty(valueString))
            {
                if (!string.IsNullOrEmpty(resultUnit))
                {
                    resultValue = 1;
                }
            }
            else
            {
                if (!double.TryParse(valueString, NumberStyles.Any, provider, out resultValue))
                {
                    return false;
                }
            }

            return true;
        }
    }
}