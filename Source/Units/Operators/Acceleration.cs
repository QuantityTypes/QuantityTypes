// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Acceleration.cs" company="Units.NET">
//   Copyright (c) 2012 Oystein Bjorke
// </copyright>
// <summary>
//   Provides operators related to acceleration.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Units
{
    /// <summary>
    /// Provides operators related to acceleration.
    /// </summary>
    public partial struct Acceleration
    {
        /// <summary>
        /// Implements the operator *.
        /// </summary>
        /// <param name="x"> The x. </param>
        /// <param name="y"> The y. </param>
        /// <returns> The result of the operator. </returns>
        public static Velocity operator *(Acceleration x, Time y)
        {
            return new Velocity(x.Value / y.Value);
        }

    }
}