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
        /// Gets the imperial thou unit.
        /// </summary>
        [Unit("th")]
        public static Length Thou { get; } = Length.Foot / 12000;

        /// <summary>
        /// Gets the imperial inch unit.
        /// </summary>
        [Unit("in")]
        public static Length Inch { get; } = Length.Foot / 12;

        /// <summary>
        /// Gets the imperial foot unit.
        /// </summary>
        [Unit("ft")]
        public static Length Foot { get; } = Length.Foot;

        /// <summary>
        /// Gets the imperial yard unit.
        /// </summary>
        [Unit("yd")]
        public static Length Yard { get; } = 3 * Length.Foot;

        /// <summary>
        /// Gets the imperial chain unit.
        /// </summary>
        [Unit("ch")]
        public static Length Chain { get; } = 22 * Yard;

        /// <summary>
        /// Gets the imperial furlong unit.
        /// </summary>
        [Unit("fur")]
        public static Length Furlong { get; } = 10 * Chain;

        /// <summary>
        /// Gets the imperial mile unit.
        /// </summary>
        [Unit("ml")]
        public static Length Mile { get; } = 8 * Furlong;

        /// <summary>
        /// Gets the imperial league unit.
        /// </summary>
        [Unit("lea")]
        public static Length League { get; } = 3 * Mile;

        /// <summary>
        /// Gets the imperial fathom unit.
        /// </summary>
        [Unit("ftm")]
        public static Length Fathom { get; } = 2.02667 * Yard;

        /// <summary>
        /// Gets the imperial cable unit.
        /// </summary>
        public static Length Cable { get; } = 100 * Fathom;

        /// <summary>
        /// Gets the imperial nautical mile unit.
        /// </summary>
        public static Length NauticalMile { get; } = 10 * Cable;

        /// <summary>
        /// Gets the imperial link unit.
        /// </summary>
        public static Length Link { get; } = 7.92 * Inch;

        /// <summary>
        /// Gets the imperial rod unit.
        /// </summary>
        public static Length Rod { get; } = 25 * Link;
        
        /// <summary>
        /// Gets the imperial fluid ounce unit.
        /// </summary>
        [Unit("floz")]
        public static Volume FluidOunce { get; } = new Volume(28.4130625e-6);

        /// <summary>
        /// Gets the imperial gill unit.
        /// </summary>
        [Unit("gi")]
        public static Volume Gill { get; } = 5 * FluidOunce;

        /// <summary>
        /// Gets the imperial pint unit.
        /// </summary>
        [Unit("pt")]
        public static Volume Pint { get; } = 20 * FluidOunce;

        /// <summary>
        /// Gets the imperial quart unit.
        /// </summary>
        [Unit("qt")]
        public static Volume Quart { get; } = 40 * FluidOunce;

        /// <summary>
        /// Gets the imperial gallon unit.
        /// </summary>
        [Unit("gal")]
        public static Volume Gallon { get; } = 160 * FluidOunce;
    }
}
