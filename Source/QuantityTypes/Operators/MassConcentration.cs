// --------------------------------------------------------------------------------------------------------------------
// <copyright file="MassConcentration.cs" company="QuantityTypes">
//   Copyright (c) 2015 QuantityTypes contributors
// </copyright>
// <summary>
//   Provides operators related to volume.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace QuantityTypes
{
    /// <summary>
    ///     Provides operators related to volume.
    /// </summary>
    public partial struct MassConcentration
    {
        /// <summary>
        ///     Implements the operator *.
        /// </summary>
        /// <param name="x"> The concentration. </param>
        /// <param name="y"> The volume. </param>
        /// <returns> The result of the operator. </returns>
        public static Mass operator *(MassConcentration x, Volume y)
        {
            return new Mass(x.Value * y.Value);
        }
    }
}