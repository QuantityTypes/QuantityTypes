// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IDynamicUnitProvider.cs" company="QuantityTypes">
//   Copyright (c) 2014 QuantityTypes contributors
// </copyright>
// <summary>
//   Defines functionality to get units for dynamic quantities.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace QuantityTypes.Dynamic
{
    using System;

    /// <summary>
    /// Defines functionality to get units for dynamic quantities.
    /// </summary>
    public interface IDynamicUnitProvider : IFormatProvider
    {
        /// <summary>
        /// Tries to get the unit for the specified symbol.
        /// </summary>
        /// <param name="s">The symbol.</param>
        /// <param name="q">The unit.</param>
        /// <returns><c>true</c> if the unit was found, <c>false</c> otherwise.</returns>
        bool TryGetUnit(string s, out DynamicQuantity q);

        /// <summary>
        /// Tries to get the display unit for the specified dimension.
        /// </summary>
        /// <param name="d">The dimension.</param>
        /// <param name="symbol">The symbol.</param>
        /// <param name="q">The unit.</param>
        /// <returns><c>true</c> if the unit was found, <c>false</c> otherwise.</returns>
        bool TryGetDisplayUnit(Dimensions d, out string symbol, out DynamicQuantity q);
    }
}