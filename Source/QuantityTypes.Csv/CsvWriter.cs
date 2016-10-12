// --------------------------------------------------------------------------------------------------------------------
// <copyright file="CsvWriter.cs" company="QuantityTypes">
//   Copyright (c) 2014 QuantityTypes contributors
// </copyright>
// <summary>
//   Provides TextWriter extension methods for writing csv content.
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