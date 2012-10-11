// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Time.cs" company="Units.NET">
//   Copyright (c) 2012 Oystein Bjorke
// </copyright>
// <summary>
//   Provides operators related to time.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Units
{
    /// <summary>
    /// Provides operators related to time.
    /// </summary>
    public partial struct Time
    {
        /// <summary>
        /// Implements the operator /.
        /// </summary>
        /// <param name="x"> The x. </param>
        /// <param name="y"> The y. </param>
        /// <returns> The result of the operator. </returns>
        public static Frequency operator /(double x, Time y)
        {
            return new Frequency(x / y.value);
        }

        /// <summary>
        /// Inverses this time.
        /// </summary>
        /// <returns> The frequency. </returns>
        public Frequency Inverse()
        {
            return new Frequency(1 / this.value);
        }

    }
}