// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Energy.cs" company="QuantityTypes">
//   Copyright (c) 2014 QuantityTypes contributors
// </copyright>
// <summary>
//   Provides operators related to energy.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace QuantityTypes
{
    /// <summary>
    ///     Provides operators related to energy.
    /// </summary>
    public partial struct Energy
    {
        /// <summary>
        ///     Implements the operator /.
        /// </summary>
        /// <param name="x"> The x. </param>
        /// <param name="y"> The y. </param>
        /// <returns> The result of the operator. </returns>
        public static HeatCapacity operator /(Energy x, TemperatureDifference y)
        {
            return new HeatCapacity(x.value / y.Value);
        }

        /// <summary>
        ///     Performs an implicit conversion from <see cref="Torque" /> to <see cref="Energy" />.
        /// </summary>
        /// <param name="m"> The m. </param>
        /// <returns> The result of the conversion. </returns>
        public static implicit operator Energy(Torque m)
        {
            return new Energy(m.Value);
        }

        /// <summary>
        ///     Implements the operator /.
        /// </summary>
        /// <param name="e"> The energy. </param>
        /// <param name="dt"> The time duration. </param>
        /// <returns> The result of the operator. </returns>
        public static Power operator /(Energy e, Time dt)
        {
            return new Power(e.Value / dt.Value);
        }
    }
}