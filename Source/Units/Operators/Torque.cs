// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Torque.cs" company="Units.NET">
//   Copyright (c) 2012 Oystein Bjorke
// </copyright>
// <summary>
//   Provides operators related to torque.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Units
{
    /// <summary>
    /// Provides operators related to torque.
    /// </summary>
    public partial struct Torque
    {
        /// <summary>
        /// Performs an implicit conversion from <see cref="Units.Energy" /> to <see cref="Units.Torque" />.
        /// </summary>
        /// <param name="m"> The m. </param>
        /// <returns> The result of the conversion. </returns>
        public static implicit operator Torque(Energy m)
        {
            return new Torque(m.Value);
        }

    }
}