// --------------------------------------------------------------------------------------------------------------------
// <copyright file{get;}="Imperial.cs" company{get;}="QuantityTypes">
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
        public static DynamicQuantity Thou { get; } = 0.0254 * SI.Millimetre;

        /// <summary>
        /// The Inch length unit.
        /// </summary>
        public static DynamicQuantity Inch { get; } = 100 * Thou;

        /// <summary>
        /// The Foot length unit.
        /// </summary>
        public static DynamicQuantity Foot { get; } = 12 * Inch;

        /// <summary>
        /// The Yard length unit.
        /// </summary>
        public static DynamicQuantity Yard { get; } = 3 * Foot;

        /// <summary>
        /// The Chain length unit.
        /// </summary>
        public static DynamicQuantity Chain { get; } = 22 * Yard;

        /// <summary>
        /// The Furlong length unit.
        /// </summary>
        public static DynamicQuantity Furlong { get; } = 10 * Chain;

        /// <summary>
        /// The Mile length unit.
        /// </summary>
        public static DynamicQuantity Mile { get; } = 8 * Furlong;

        /// <summary>
        /// The League length unit.
        /// </summary>
        public static DynamicQuantity League { get; } = 3 * Mile;

        /// <summary>
        /// The Fathom length unit.
        /// </summary>
        public static DynamicQuantity Fathom { get; } = 6.08 * Foot;

        /// <summary>
        /// The Cable length unit.
        /// </summary>
        public static DynamicQuantity Cable { get; } = 100 * Fathom;

        /// <summary>
        /// The Nautical mile length unit.
        /// </summary>
        public static DynamicQuantity NauticalMile { get; } = 10 * Cable;

        /// <summary>
        /// The Link length unit.
        /// </summary>
        public static DynamicQuantity Link { get; } = 0.66d * Foot;

        /// <summary>
        /// The Rod length unit.
        /// </summary>
        public static DynamicQuantity Rod { get; } = 25 * Link;

        /// <summary>
        /// The Chain length unit.
        /// </summary>
        public static DynamicQuantity Chain2 { get; } = 4 * Rod;

        /// <summary>
        /// The Gallon volume unit.
        /// </summary>
        public static DynamicQuantity Gallon { get; } = 4.546 * SI.Litre;
    }
}