// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ElectricCurrent.cs" company="QuantityTypes">
//   Copyright (c) 2014 QuantityTypes contributors
// </copyright>
// <summary>
//   Provides operators related to electric current.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace QuantityTypes
{
    /// <summary>
    ///     Provides operators related to electric current.
    /// </summary>
    public partial struct ElectricCurrent
    {
        /// <summary>
        ///     Implements the operator *.
        /// </summary>
        /// <param name="x"> The x. </param>
        /// <param name="y"> The y. </param>
        /// <returns> The result of the operator. </returns>
        public static ElectricCharge operator *(ElectricCurrent x, Time y)
        {
            return new ElectricCharge(x.Value * y.Value);
        }
    }
}