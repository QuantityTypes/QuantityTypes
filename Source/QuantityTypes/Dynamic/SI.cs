// --------------------------------------------------------------------------------------------------------------------
// <copyright file="SI.cs" company="QuantityTypes">
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
        public static DynamicQuantity Kilogram
        {
            get
            {
                return kilogram;
            }
        }

        /// <summary>
        /// Gets the meter unit.
        /// </summary>
        /// <value>The meter unit.</value>
        [Unit("m", true)]
        public static DynamicQuantity Metre
        {
            get
            {
                return metre;
            }
        }

        /// <summary>
        /// Gets the meter per second.
        /// </summary>
        /// <value>The meter per second.</value>
        [Unit("m/s", true)]
        public static DynamicQuantity MetrePerSecond
        {
            get
            {
                return metrePerSecond;
            }
        }

        /// <summary>
        /// Gets the kilometer per hour.
        /// </summary>
        /// <value>The kilometer per hour.</value>
        [Unit("km/h")]
        public static DynamicQuantity KilometrePerHour
        {
            get
            {
                return kilometrePerHour;
            }
        }

        /// <summary>
        /// The kilogram unit
        /// </summary>
        public static readonly DynamicQuantity kilogram = new DynamicQuantity(1, new Dimensions(1, 0, 0));

        /// <summary>
        /// The meter unit
        /// </summary>
        public static readonly DynamicQuantity metre = new DynamicQuantity(1, new Dimensions(0, 1, 0));

        /// <summary>
        /// The kilometer unit
        /// </summary>
        public static readonly DynamicQuantity Kilometre = 1000 * Metre;

        /// <summary>
        /// The centimeter unit
        /// </summary>
        public static readonly DynamicQuantity Centimetre = 0.01 * Metre;

        /// <summary>
        /// The millimeter unit
        /// </summary>
        public static readonly DynamicQuantity Millimetre = 0.001 * Metre;

        /// <summary>
        /// The second unit
        /// </summary>
        public static readonly DynamicQuantity Second = new DynamicQuantity(1, new Dimensions(0, 0, 1));

        /// <summary>
        /// The minute unit
        /// </summary>
        public static readonly DynamicQuantity Minute = 60 * Second;

        /// <summary>
        /// The hour unit
        /// </summary>
        public static readonly DynamicQuantity Hour = 60 * Minute;

        /// <summary>
        /// The m/s unit
        /// </summary>
        public static readonly DynamicQuantity metrePerSecond = Metre / Second;

        /// <summary>
        /// The km/h unit
        /// </summary>
        public static readonly DynamicQuantity kilometrePerHour = Kilometre / Hour;

        /// <summary>
        /// The m/s^2 unit
        /// </summary>
        public static readonly DynamicQuantity MetrePerSecondSquared = Metre / (Second * Second);


        /// <summary>
        /// The m^2 unit
        /// </summary>
        public static readonly DynamicQuantity SquareMetre = new DynamicQuantity(1, new Dimensions(0, 2, 0));

        /// <summary>
        /// The m^3 unit
        /// </summary>
        public static readonly DynamicQuantity CubicMetre = new DynamicQuantity(1, new Dimensions(0, 3, 0));

        /// <summary>
        /// The dm^3 unit
        /// </summary>
        public static readonly DynamicQuantity CubicDecimetre = new DynamicQuantity(0.001, new Dimensions(0, 3, 0));

        /// <summary>
        /// The liter unit
        /// </summary>
        public static readonly DynamicQuantity Litre = CubicDecimetre;
    }
}