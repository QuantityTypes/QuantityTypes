// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Imperial.cs" company="QuantityTypes">
//   Copyright (c) 2014 QuantityTypes contributors
// </copyright>
// <summary>
//   Provides imperial (UK) units.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace QuantityTypes
{
    /// <summary>
    /// Provides imperial (UK) units.
    /// </summary>
    /// <remarks>See <a href="https://en.wikipedia.org/wiki/Imperial_units"> Imperial units</a>.</remarks>
    public class Imperial
    {
        /// <summary>
        /// Gets the imperical fluid ounce unit.
        /// </summary>
        [Unit("floz")]
        public static Volume FluidOunce { get; } = new Volume(28.4130625e-6);

        /// <summary>
        /// Gets the imperical gill unit.
        /// </summary>
        [Unit("gi")]
        public static Volume Gill { get; } = 5 * FluidOunce;

        /// <summary>
        /// Gets the imperical pint unit.
        /// </summary>
        [Unit("pt")]
        public static Volume Pint { get; } = 20 * FluidOunce;

        /// <summary>
        /// Gets the imperical quart unit.
        /// </summary>
        [Unit("qt")]
        public static Volume Quart { get; } = 40 * FluidOunce;

        /// <summary>
        /// Gets the imperical gallon unit.
        /// </summary>
        [Unit("gal")]
        public static Volume Gallon { get; } = 160 * FluidOunce;
    }
}
