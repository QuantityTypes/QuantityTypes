// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Utilities.cs" company="QuantityTypes">
//   Copyright (c) 2014 QuantityTypes contributors
// </copyright>
// <summary>
//   Provides utility methods for quantity processing.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace QuantityTypes.Dynamic
{
    using System;
    using System.Globalization;

    /// <summary>
    /// Provides utility methods for quantity processing.
    /// </summary>
    public static class Utilities
    {
        /// <summary>
        /// Converts the string representation of a quantity to its <see cref="double" /> value and <see cref="string" /> unit equivalent.
        /// A return value indicates whether the conversion succeeded or failed.
        /// </summary>
        /// <param name="s">A string containing a number to convert.</param>
        /// <param name="provider">An <see cref="IFormatProvider" /> that supplies culture-specific formatting information about <paramref name="s" />.</param>
        /// <param name="resultValue">When this method returns, contains a double-precision floating-point number equivalent of the numeric value contained in s. This parameter is passed uninitialized.</param>
        /// <param name="resultUnit">When this method returns, contains a string equivalent of the unit contained in s. This parameter is passed uninitialized.</param>
        /// <returns><c>true</c> if <paramref name="s" /> was converted successfully; otherwise <c>false</c>.</returns>
        public static bool TrySplit(string s, IFormatProvider provider, out double resultValue, out string resultUnit)
        {
            // remove whitespace
            s = s.Replace(" ", string.Empty);

            // find the index where the unit starts
            var unitIndex = 0;
            Func<char, bool> isDecimalSeparator = c => false;
            Func<char, bool> isGroupSeparator = c => false;

            var numberFormatInfo = provider.GetFormat(typeof(NumberFormatInfo)) as NumberFormatInfo ?? CultureInfo.CurrentCulture.NumberFormat;

            var ngs = numberFormatInfo.NumberGroupSeparator;
            if (ngs != null)
            {
                isGroupSeparator = c => ngs.Contains(c.ToString());
            }

            var nds = numberFormatInfo.NumberDecimalSeparator;
            if (nds != null)
            {
                isDecimalSeparator = c => nds.Contains(c.ToString());
            }

            while (unitIndex < s.Length)
            {
                var c = s[unitIndex];

                // exponential
                if (c == 'e' || c == 'E')
                {
                    // check if it is followed by a digit or '-'/'+', otherwise it might be a unit
                    if (unitIndex + 1 < s.Length && (char.IsDigit(s[unitIndex + 1]) || s[unitIndex + 1] == '-' || s[unitIndex + 1] == '+'))
                    {
                        unitIndex += 2;
                        continue;
                    }
                }

                if (char.IsDigit(c) || char.IsWhiteSpace(c) || c == '+' || c == '-' || isDecimalSeparator(c) || isGroupSeparator(c))
                {
                    // digit, decimal or numeric group separator, continue
                    unitIndex++;
                    continue;
                }

                // unit starts here
                break;
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