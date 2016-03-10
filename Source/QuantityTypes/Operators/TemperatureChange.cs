// --------------------------------------------------------------------------------------------------------------------
// <copyright file="TemperatureChange.cs" company="QuantityTypes">
//   Copyright (c) 2014 QuantityTypes contributors
// </copyright>
// <summary>
//   Provides operators related to temperature change.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace QuantityTypes
{
    /// <summary>
    ///     Provides operators related to temperature change.
    /// </summary>
    public partial struct TemperatureChange
    {
        /// <summary>
        ///     Implements the operator *.
        /// </summary>
        /// <param name="x"> The temperature change. </param>
        /// <param name="dt"> The time duration. </param>
        /// <returns> The result of the operator. </returns>
        public static TemperatureDifference operator *(TemperatureChange x, Time dt)
        {
            return new TemperatureDifference(x.value * dt.Value);
        }
    }
}