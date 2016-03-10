// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ElectricResistance.cs" company="QuantityTypes">
//   Copyright (c) 2014 QuantityTypes contributors
// </copyright>
// <summary>
//   Implements operators related to electric resistance.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace QuantityTypes
{
    /// <summary>
    ///     Implements operators related to electric resistance.
    /// </summary>
    public partial struct ElectricResistance
    {
        /// <summary>
        ///     Implements the operator *.
        /// </summary>
        /// <param name="x"> The x. </param>
        /// <param name="y"> The y. </param>
        /// <returns> The result of the operator. </returns>
        public static ElectricVoltage operator *(ElectricResistance x, ElectricCurrent y)
        {
            return new ElectricVoltage(x.Value * y.Value);
        }
    }
}