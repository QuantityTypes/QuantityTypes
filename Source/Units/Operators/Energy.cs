// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Energy.cs" company="Units.NET">
//   Copyright (c) 2012 Oystein Bjorke
// </copyright>
// <summary>
//   Provides operators related to energy.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Units
{
    /// <summary>
    /// Provides operators related to energy.
    /// </summary>
    public partial struct Energy
    {
        /// <summary>
        /// Implements the operator /.
        /// </summary>
        /// <param name="x"> The x. </param>
        /// <param name="y"> The y. </param>
        /// <returns> The result of the operator. </returns>
        public static HeatCapacity operator /(Energy x, TemperatureDifference y)
        {
            return new HeatCapacity(x.value / y.Value);
        }

        /// <summary>
        /// Performs an implicit conversion from <see cref="Units.Torque" /> to <see cref="Units.Energy" />.
        /// </summary>
        /// <param name="m"> The m. </param>
        /// <returns> The result of the conversion. </returns>
        public static implicit operator Energy(Torque m)
        {
            return new Energy(m.Value);
        }

    }
}