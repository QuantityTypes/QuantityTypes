// --------------------------------------------------------------------------------------------------------------------
// <copyright file="CultureInfos.cs" company="QuantityTypes">
//   Copyright (c) 2014 QuantityTypes contributors
// </copyright>
// <summary>
//   Provides information about cultures.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace QuantityTypes.Tests
{
    using System.Globalization;

    /// <summary>
    /// Provides information about cultures.
    /// </summary>
    public static class CultureInfos
    {
        /// <summary>
        /// The default norwegian culture. Decimal separator must be specified in case it has been modified on the current system.
        /// </summary>
        private static readonly CultureInfo NorwegianCultureInfo = new CultureInfo("nb-NO") { NumberFormat = { NumberDecimalSeparator = "," } };

        /// <summary>
        /// Gets the default Norwegian culture.
        /// </summary>
        /// <value>The Norwegian culture.</value>
        public static CultureInfo Norwegian
        {
            get
            {
                return NorwegianCultureInfo;
            }
        }
    }
}