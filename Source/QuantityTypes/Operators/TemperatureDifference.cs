// --------------------------------------------------------------------------------------------------------------------
// <copyright file="TemperatureDifference.cs" company="QuantityTypes">
//   Copyright (c) 2014 QuantityTypes contributors
// </copyright>
// <summary>
//   Implements operators related to temperature difference.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace QuantityTypes
{
    /// <summary>
    ///     Implements operators related to temperature difference.
    /// </summary>
    public partial struct TemperatureDifference
    {
        /// <summary>
        ///     Implements the operator /.
        /// </summary>
        /// <param name="dT"> The temperature difference. </param>
        /// <param name="dt"> The time duration. </param>
        /// <returns> The result of the operator. </returns>
        public static TemperatureRateOfChange operator /(TemperatureDifference dT, Time dt)
        {
            return new TemperatureRateOfChange(dT.value / dt.Value);
        }
    }
}