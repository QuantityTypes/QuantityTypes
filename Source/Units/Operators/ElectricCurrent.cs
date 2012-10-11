// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ElectricCurrent.cs" company="Units.NET">
//   Copyright (c) 2012 Oystein Bjorke
// </copyright>
// <summary>
//   Provides operators related to electric current.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Units
{
    /// <summary>
    /// Provides operators related to electric current.
    /// </summary>
    public partial struct ElectricCurrent
    {
        /// <summary>
        /// Implements the operator *.
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