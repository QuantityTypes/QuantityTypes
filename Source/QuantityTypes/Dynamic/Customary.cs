// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Customary.cs" company="QuantityTypes">
//   Copyright (c) 2014 QuantityTypes contributors
// </copyright>
// <summary>
//   Provides United States customary units.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace QuantityTypes.Dynamic
{
    /// <summary>
    /// Provides United States customary units.
    /// </summary>
    public static class Customary
    {
        //// http://en.wikipedia.org/wiki/United_States_customary_units

        /// <summary>
        /// The gallon unit.
        /// </summary>
        public static readonly DynamicQuantity Gallon = 3.785412 * SI.Litre;
    }
}