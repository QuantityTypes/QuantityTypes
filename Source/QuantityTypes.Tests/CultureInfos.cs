﻿// --------------------------------------------------------------------------------------------------------------------
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
        /// Gets the default Norwegian culture.
        /// </summary>
        /// <value>The Norwegian culture.</value>
        /// <remarks>This culture has ',' as decimal separator.</remarks>
        public static CultureInfo Norwegian { get; } = new CultureInfo("nb-NO") { NumberFormat = { NumberDecimalSeparator = "," } };
    }
}