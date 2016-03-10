// --------------------------------------------------------------------------------------------------------------------
// <copyright file="TemperatureRateOfChange.cs" company="QuantityTypes">
//   Copyright (c) 2014 QuantityTypes contributors
// </copyright>
// <summary>
//   Implements operators related to temperature rate of change.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace QuantityTypes
{
    /// <summary>
    ///     Implements operators related to temperature rate of change.
    /// </summary>
    public partial struct TemperatureRateOfChange
    {
        /// <summary>
        ///     Implements the operator *.
        /// </summary>
        /// <param name="x"> The temperature rate of change. </param>
        /// <param name="dt"> The time duration. </param>
        /// <returns> The result of the operator. </returns>
        public static TemperatureDifference operator *(TemperatureRateOfChange x, Time dt)
        {
            return new TemperatureDifference(x.value * dt.Value);
        }
    }
}