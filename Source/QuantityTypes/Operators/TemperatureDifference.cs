// --------------------------------------------------------------------------------------------------------------------
// <copyright file="TemperatureDifference.cs" company="QuantityTypes">
//   Copyright (c) 2014 QuantityTypes contributors
// </copyright>
// <summary>
//   Provides operators related to temperature difference.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace QuantityTypes
{
    /// <summary>
    ///     Provides operators related to temperature difference.
    /// </summary>
    public partial struct TemperatureDifference
    {
        /// <summary>
        ///     Implements the operator /.
        /// </summary>
        /// <param name="dT"> The temperature difference. </param>
        /// <param name="dt"> The time duration. </param>
        /// <returns> The result of the operator. </returns>
        public static TemperatureChange operator /(TemperatureDifference dT, Time dt)
        {
            return new TemperatureChange(dT.value / dt.Value);
        }
    }
}