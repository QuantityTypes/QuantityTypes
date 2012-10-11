// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ElectricResistance.cs" company="Units.NET">
//   Copyright (c) 2012 Oystein Bjorke
// </copyright>
// <summary>
//   Provides operators related to electric resistance.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Units
{
    /// <summary>
    /// Provides operators related to electric resistance.
    /// </summary>
    public partial struct ElectricResistance
    {
        /// <summary>
        /// Implements the operator *.
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