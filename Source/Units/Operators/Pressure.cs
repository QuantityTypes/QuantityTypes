// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Pressure.cs" company="Units.NET">
//   Copyright (c) 2012 Oystein Bjorke
// </copyright>
// <summary>
//   Provides operators related to pressure.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Units
{
    /// <summary>
    /// Provides operators related to pressure.
    /// </summary>
    public partial struct Pressure
    {
        /// <summary>
        /// Implements the operator *.
        /// </summary>
        /// <param name="x"> The x. </param>
        /// <param name="y"> The y. </param>
        /// <returns> The result of the operator. </returns>
        public static Force operator *(Pressure x, Area y)
        {
            return new Force(x.Value * y.Value);
        }

    }
}