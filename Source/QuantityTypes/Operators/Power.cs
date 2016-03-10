// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ElectricVoltage.cs" company="QuantityTypes">
//   Copyright (c) 2014 QuantityTypes contributors
// </copyright>
// <summary>
//   Provides operators related to power.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace QuantityTypes
{
    /// <summary>
    ///     Provides operators related to power.
    /// </summary>
    public partial struct Power
    {
        /// <summary>
        ///     Implements the operator /.
        /// </summary>
        /// <param name="x"> The x. </param>
        /// <param name="y"> The y. </param>
        /// <returns> The result of the operator. </returns>
        public static ElectricVoltage operator /(Power x, ElectricCurrent y)
        {
            return new ElectricVoltage(x.Value / y.Value);
        }

        /// <summary>
        ///     Implements the operator /.
        /// </summary>
        /// <param name="x"> The x. </param>
        /// <param name="y"> The y. </param>
        /// <returns> The result of the operator. </returns>
        public static ElectricCurrent operator /(Power x, ElectricVoltage y)
        {
            return new ElectricCurrent(x.Value / y.Value);
        }

        /// <summary>
        ///     Implements the operator /.
        /// </summary>
        /// <param name="p"> The power. </param>
        /// <param name="dt"> The time duration. </param>
        /// <returns> The result of the operator. </returns>
        public static Energy operator *(Power p, Time dt)
        {
            return new Energy(p.Value * dt.Value);
        }
    }
}