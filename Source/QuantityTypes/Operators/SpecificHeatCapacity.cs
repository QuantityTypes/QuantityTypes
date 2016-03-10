// --------------------------------------------------------------------------------------------------------------------
// <copyright file="SpecificHeatCapacity.cs" company="QuantityTypes">
//   Copyright (c) 2014 QuantityTypes contributors
// </copyright>
// <summary>
//   Implements operators related to specific heat capacity.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace QuantityTypes
{
    /// <summary>
    /// Implements operators related to specific heat capacity.
    /// </summary>
    public partial struct SpecificHeatCapacity
    {
        /// <summary>
        ///     Implements the operator *.
        /// </summary>
        /// <param name="c"> The specific heat capacity. </param>
        /// <param name="m"> The mass. </param>
        /// <returns> The result of the operator. </returns>
        public static HeatCapacity operator *(SpecificHeatCapacity c, Mass m)
        {
            return new HeatCapacity(c.value * m.Value);
        }
    }
}