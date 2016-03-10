// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Pressure.cs" company="QuantityTypes">
//   Copyright (c) 2014 QuantityTypes contributors
// </copyright>
// <summary>
//   Implements operators related to pressure.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace QuantityTypes
{
    /// <summary>
    ///     Implements operators related to pressure.
    /// </summary>
    public partial struct Pressure
    {
        /// <summary>
        ///     Implements the operator *.
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