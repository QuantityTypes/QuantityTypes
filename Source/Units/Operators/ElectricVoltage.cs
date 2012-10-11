// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ElectricVoltage.cs" company="Units.NET">
//   Copyright (c) 2012 Oystein Bjorke
// </copyright>
// <summary>
//   Provides operators related to electric voltage.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Units
{
    /// <summary>
    /// Provides operators related to electric voltage.
    /// </summary>
    public partial struct ElectricVoltage
    {
        /// <summary>
        /// Implements the operator /.
        /// </summary>
        /// <param name="x"> The x. </param>
        /// <param name="y"> The y. </param>
        /// <returns> The result of the operator. </returns>
        public static ElectricResistance operator /(ElectricVoltage x, ElectricCurrent y)
        {
            return new ElectricResistance(x.Value / y.Value);
        }

        /// <summary>
        /// Implements the operator /.
        /// </summary>
        /// <param name="x"> The x. </param>
        /// <param name="y"> The y. </param>
        /// <returns> The result of the operator. </returns>
        public static ElectricCurrent operator /(ElectricVoltage x, ElectricResistance y)
        {
            return new ElectricCurrent(x.Value / y.Value);
        }

    }
}