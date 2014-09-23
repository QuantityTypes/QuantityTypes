// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Imperial.cs" company="QuantityTypes">
//   Copyright (c) 2014 QuantityTypes contributors
// </copyright>
// <summary>
//   Provides (British) Imperial units
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace QuantityTypes.Dynamic
{
    /// <summary>
    /// Provides (British) Imperial units
    /// </summary>
    public static class Imperial
    {
        //// http://en.wikipedia.org/wiki/Imperial_units

        /// <summary>
        /// The Thou length unit.
        /// </summary>
        public static readonly DynamicQuantity Thou = 0.0254 * SI.Millimetre;

        /// <summary>
        /// The Inch length unit.
        /// </summary>
        public static readonly DynamicQuantity Inch = 100 * Thou;

        /// <summary>
        /// The Foot length unit.
        /// </summary>
        public static readonly DynamicQuantity Foot = 12 * Inch;

        /// <summary>
        /// The Yard length unit.
        /// </summary>
        public static readonly DynamicQuantity Yard = 3 * Foot;

        /// <summary>
        /// The Chain length unit.
        /// </summary>
        public static readonly DynamicQuantity Chain = 22 * Yard;

        /// <summary>
        /// The Furlong length unit.
        /// </summary>
        public static readonly DynamicQuantity Furlong = 10 * Chain;

        /// <summary>
        /// The Mile length unit.
        /// </summary>
        public static readonly DynamicQuantity Mile = 8 * Furlong;

        /// <summary>
        /// The League length unit.
        /// </summary>
        public static readonly DynamicQuantity League = 3 * Mile;

        /// <summary>
        /// The Fathom length unit.
        /// </summary>
        public static readonly DynamicQuantity Fathom = 6.08 * Foot;

        /// <summary>
        /// The Cable length unit.
        /// </summary>
        public static readonly DynamicQuantity Cable = 100 * Fathom;

        /// <summary>
        /// The Nautical mile length unit.
        /// </summary>
        public static readonly DynamicQuantity NauticalMile = 10 * Cable;

        /// <summary>
        /// The Link length unit.
        /// </summary>
        public static readonly DynamicQuantity Link = 0.66d * Foot;

        /// <summary>
        /// The Rod length unit.
        /// </summary>
        public static readonly DynamicQuantity Rod = 25 * Link;

        /// <summary>
        /// The Chain length unit.
        /// </summary>
        public static readonly DynamicQuantity Chain2 = 4 * Rod;

        /// <summary>
        /// The Gallon volume unit.
        /// </summary>
        public static readonly DynamicQuantity Gallon = 4.546 * SI.Litre;
    }
}