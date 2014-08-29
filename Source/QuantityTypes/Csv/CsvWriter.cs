// --------------------------------------------------------------------------------------------------------------------
// <copyright file="CsvWriter.cs" company="QuantityTypes">
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
//   Provides functionality to format and write csv content.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace QuantityTypes.Csv
{
    using System.Globalization;
    using System.IO;
    using System.Text;

    /// <summary>
    /// Provides TextWriter extension methods for writing csv content.
    /// </summary>
    public static class CsvWriter
    {
        /// <summary>
        /// Writes a CSV line to the specified stream writer using the current culture.
        /// </summary>
        /// <param name="w">
        /// The text writer.
        /// </param>
        /// <param name="objects">
        /// The objects to write.
        /// </param>
        public static void WriteCsvLine(this TextWriter w, params object[] objects)
        {
            WriteCsvLine(w, CultureInfo.CurrentCulture, objects);
        }

        /// <summary>
        /// Writes a CSV line to the specified stream writer using invariant culture.
        /// </summary>
        /// <param name="w">
        /// The text writer.
        /// </param>
        /// <param name="objects">
        /// The objects to write.
        /// </param>
        public static void WriteInvariantCsvLine(this TextWriter w, params object[] objects)
        {
            WriteCsvLine(w, CultureInfo.InvariantCulture, objects);
        }

        /// <summary>
        /// Writes a CSV line to the specified stream writer using the specified culture.
        /// </summary>
        /// <param name="w">
        /// The text writer.
        /// </param>
        /// <param name="culture">
        /// The culture.
        /// </param>
        /// <param name="objects">
        /// The objects to write.
        /// </param>
        public static void WriteCsvLine(this TextWriter w, CultureInfo culture, params object[] objects)
        {
            WriteCsvLine(w, culture, '"', objects);
        }

        /// <summary>
        /// Writes a CSV line to the specified stream writer using the specified culture and quote character.
        /// </summary>
        /// <param name="w">
        /// The text writer.
        /// </param>
        /// <param name="culture">
        /// The culture.
        /// </param>
        /// <param name="quote">
        /// The quote.
        /// </param>
        /// <param name="objects">
        /// The objects to write.
        /// </param>
        public static void WriteCsvLine(this TextWriter w, CultureInfo culture, char quote, params object[] objects)
        {
            w.WriteLine(Format(culture, quote, objects));
        }

        /// <summary>
        /// Formats the specified objects to a csv string using the specified culture.
        /// </summary>
        /// <param name="culture">
        /// The culture.
        /// </param>
        /// <param name="objects">
        /// The objects.
        /// </param>
        /// <returns>
        /// The csv string.
        /// </returns>
        public static string Format(CultureInfo culture, params object[] objects)
        {
            return Format(culture, '"', objects);
        }

        /// <summary>
        /// Formats the specified objects to a csv string using the specified culture and quote character.
        /// </summary>
        /// <param name="culture">
        /// The culture.
        /// </param>
        /// <param name="quote">
        /// The quote character.
        /// </param>
        /// <param name="objects">
        /// The objects.
        /// </param>
        /// <returns>
        /// The csv string.
        /// </returns>
        public static string Format(CultureInfo culture, char quote, params object[] objects)
        {
            var separator = culture.TextInfo.ListSeparator;
            bool first = true;
            var quote1 = quote.ToString();
            var quote2 = quote1 + quote1;
            var sb = new StringBuilder();
            foreach (var o in objects)
            {
                var text = string.Format(culture, "{0}", o);
                if (!first)
                {
                    sb.Append(separator);
                }
                else
                {
                    first = false;
                }

                if (text.Contains(quote1) || text.Contains(separator) || text.Contains("\n"))
                {
                    text = text.Replace(quote1, quote2);
                    sb.Append(quote1 + text + quote1);
                }
                else
                {
                    sb.Append(text);
                }
            }

            return sb.ToString();
        }
    }
}