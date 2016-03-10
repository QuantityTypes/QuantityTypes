// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ElectricVoltage.cs" company="QuantityTypes">
//   Copyright (c) 2014 QuantityTypes contributors
// </copyright>
// <summary>
//   Implements operators related to capacitance.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace QuantityTypes
{
    /// <summary>
    ///     Implements operators related to capacitance.
    /// </summary>
    public partial struct Capacitance
    {
        /// <summary>
        ///     Implements the operator *.
        /// </summary>
        /// <param name="x"> The x. </param>
        /// <param name="y"> The y. </param>
        /// <returns> The result of the operator. </returns>
        public static ElectricCharge operator *(Capacitance x, ElectricVoltage y)
        {
            return new ElectricCharge(x.Value * y.Value);
        }



    }
}