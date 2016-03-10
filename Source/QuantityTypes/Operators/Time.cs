// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Time.cs" company="QuantityTypes">
//   Copyright (c) 2014 QuantityTypes contributors
// </copyright>
// <summary>
//   Implements operators related to time.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace QuantityTypes
{
    using System;

    /// <summary>
    ///     Implements operators related to time.
    /// </summary>
    public partial struct Time
    {
        /// <summary>
        ///     Implements the operator /.
        /// </summary>
        /// <param name="x"> The x. </param>
        /// <param name="y"> The y. </param>
        /// <returns> The result of the operator. </returns>
        public static Frequency operator /(double x, Time y)
        {
            return new Frequency(x / y.value);
        }

        /// <summary>
        /// Implements the * operator for the product of <see cref="Time" /> and <see cref="Time" />.
        /// </summary>
        /// <param name="x">The x.</param>
        /// <param name="y">The y.</param>
        /// <returns>The result of the operator.</returns>
        public static TimeSquared operator *(Time x, Time y)
        {
            return new TimeSquared(x.value * y.value);
        }

        /// <summary>
        ///     Implements the operator ^.
        /// </summary>
        /// <param name="x"> The x. </param>
        /// <param name="exp"> The exponent. </param>
        /// <returns> The result of the operator. </returns>
        public static TimeSquared operator ^(Time x, int exp)
        {
            if (exp == 2)
            {
                return new TimeSquared(x.Value * x.Value);
            }

            throw new NotSupportedException();
        }

        /// <summary>
        ///     Inverses this time.
        /// </summary>
        /// <returns> The frequency. </returns>
        public Frequency Inverse()
        {
            return new Frequency(1 / this.value);
        }

		/// <summary>
		/// Implements the * operator for the product of <see cref="Time" /> and <see cref="Time" />.
		/// </summary>
		/// <param name="x">The x.</param>
		/// <param name="y">The y.</param>
		/// <returns>The result of the operator.</returns>
		public static ElectricCharge operator *(Time x, ElectricCurrent y)
		{
			return new ElectricCharge(x.value * y.Value);
		}

    }
}