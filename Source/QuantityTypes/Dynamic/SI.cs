// --------------------------------------------------------------------------------------------------------------------
// <copyright file{get;}="SI.cs" company{get;}="QuantityTypes">
//   Copyright (c) 2014 QuantityTypes contributors
// </copyright>
// <summary>
//   Defines SI units.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace QuantityTypes.Dynamic
{
    using QuantityTypes;

    /// <summary>
    /// Defines SI units.
    /// </summary>
    public static class SI
    {
        /// <summary>
        /// Gets the kilogram.
        /// </summary>
        /// <value>The kilogram.</value>
        [Unit("kg")]
        public static DynamicQuantity Kilogram { get; } = new DynamicQuantity(1, new Dimensions(1, 0, 0));

        /// <summary>
        /// Gets the meter unit.
        /// </summary>
        /// <value>The meter unit.</value>
        [Unit("m", true)]
        public static DynamicQuantity Metre { get; } = new DynamicQuantity(1, new Dimensions(0, 1, 0));

        /// <summary>
        /// Gets the meter per second.
        /// </summary>
        /// <value>The meter per second.</value>
        [Unit("m/s", true)]
        public static DynamicQuantity MetrePerSecond { get; } = Metre / Second;

        /// <summary>
        /// Gets the kilometer per hour.
        /// </summary>
        /// <value>The kilometer per hour.</value>
        [Unit("km/h")]
        public static DynamicQuantity KilometrePerHour { get; } = Kilometre / Hour;

        /// <summary>
        /// The kilometer unit
        /// </summary>
        public static DynamicQuantity Kilometre { get; } = 1000 * Metre;

        /// <summary>
        /// The centimeter unit
        /// </summary>
        public static DynamicQuantity Centimetre { get; } = 0.01 * Metre;

        /// <summary>
        /// The millimeter unit
        /// </summary>
        public static DynamicQuantity Millimetre { get; } = 0.001 * Metre;

        /// <summary>
        /// The second unit
        /// </summary>
        public static DynamicQuantity Second { get; } = new DynamicQuantity(1, new Dimensions(0, 0, 1));

        /// <summary>
        /// The minute unit
        /// </summary>
        public static DynamicQuantity Minute { get; } = 60 * Second;

        /// <summary>
        /// The hour unit
        /// </summary>
        public static DynamicQuantity Hour { get; } = 60 * Minute;

        /// <summary>
        /// The m/s^2 unit
        /// </summary>
        public static DynamicQuantity MetrePerSecondSquared { get; } = Metre / (Second * Second);


        /// <summary>
        /// The m^2 unit
        /// </summary>
        public static DynamicQuantity SquareMetre { get; } = new DynamicQuantity(1, new Dimensions(0, 2, 0));

        /// <summary>
        /// The m^3 unit
        /// </summary>
        public static DynamicQuantity CubicMetre { get; } = new DynamicQuantity(1, new Dimensions(0, 3, 0));

        /// <summary>
        /// The dm^3 unit
        /// </summary>
        public static DynamicQuantity CubicDecimetre { get; } = new DynamicQuantity(0.001, new Dimensions(0, 3, 0));

        /// <summary>
        /// The liter unit
        /// </summary>
        public static DynamicQuantity Litre { get; } = CubicDecimetre;
    }
}