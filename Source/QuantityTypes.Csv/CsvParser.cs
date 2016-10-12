// --------------------------------------------------------------------------------------------------------------------
// <copyright file="CsvParser.cs" company="QuantityTypes">
//   Copyright (c) 2014 QuantityTypes contributors
// </copyright>
// <summary>
//   Provides static csv parser methods.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace QuantityTypes.Csv
{
    using System.Collections.Generic;
    using System.Globalization;

    /// <summary>
    /// Provides static csv parser methods.
    /// </summary>
    public static class CsvParser
    {
        /// <summary>
        /// Parses the specified text.
        /// </summary>
        /// <param name="text">
        /// The text.
        /// </param>
        /// <param name="culture">
        /// The culture.
        /// </param>
        /// <returns>
        /// A sequence of records.
        /// </returns>
        public static IEnumerable<IList<string>> Parse(string text, CultureInfo culture = null)
        {
            if (culture == null)
            {
                culture = CultureInfo.CurrentCulture;
            }

            var separator = culture.TextInfo.ListSeparator[0];
            return Parse(text, separator);
        }

        /// <summary>
        /// Parses the specified text.
        /// </summary>
        /// <param name="text">
        /// The text.
        /// </param>
        /// <param name="separator">
        /// The separator character.
        /// </param>
        /// <param name="quote">
        /// The quote character.
        /// </param>
        /// <returns>
        /// A sequence of records.
        /// </returns>
        public static IEnumerable<IList<string>> Parse(string text, char separator, char quote = '"')
        {
            const char NewLine = '\n';
            const char CarriageReturn = '\r';
            var quote1 = char.ToString(quote);
            var quote2 = quote1 + quote1;

            int i = 0;
            int n = text.Length;
            var fields = new List<string>(10);
            int startIndex = 0;
            int endIndex = 0;
            bool isInsideQuote = false;

            while (i < n)
            {
                if (isInsideQuote)
                {
                    if (text[i] == quote)
                    {
                        if (text[i + 1] != quote)
                        {
                            isInsideQuote = false;
                            endIndex = i;
                        }
                        else
                        {
                            i++;
                        }
                    }

                    i++;
                    continue;
                }

                if (text[i] == NewLine)
                {
                    if (endIndex > startIndex)
                    {
                        fields.Add(text.Substring(startIndex, endIndex - startIndex).Replace(quote2, quote1));
                    }
                    else
                    {
                        fields.Add(string.Empty);
                    }

                    int m = fields.Count;
                    yield return fields;
                    fields = new List<string>(m);
                    startIndex = i + 1;
                    i++;
                    continue;
                }

                if (text[i] == separator)
                {
                    if (endIndex > startIndex)
                    {
                        fields.Add(text.Substring(startIndex, endIndex - startIndex).Replace(quote2, quote1));
                    }
                    else
                    {
                        fields.Add(string.Empty);
                    }

                    startIndex = i + 1;
                    i++;
                    continue;
                }

                if (i == startIndex && text[i] == quote)
                {
                    isInsideQuote = true;
                    startIndex = i + 1;
                    i++;
                    continue;
                }

                if (text[i] != CarriageReturn)
                {
                    endIndex = i + 1;
                }

                i++;
            }
        }
    }
}