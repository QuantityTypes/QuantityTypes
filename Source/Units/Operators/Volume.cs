// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Volume.cs" company="Units.NET">
//   Copyright (c) 2012 Oystein Bjorke
// </copyright>
// <summary>
//   Provides operators related to volume.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Units
{
    /// <summary>
    /// Provides operators related to volume.
    /// </summary>
    public partial struct Volume
    {
        /// <summary>
        /// Implements the operator /.
        /// </summary>
        /// <param name="l1"> The l1. </param>
        /// <param name="l2"> The l2. </param>
        /// <returns> The result of the operator. </returns>
        public static Length operator /(Volume l1, Area l2)
        {
            return new Length(l1.Value / l2.Value);
        }
    }
}