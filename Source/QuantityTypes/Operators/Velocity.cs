// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Velocity.cs" company="QuantityTypes">
//   Copyright (c) 2014 QuantityTypes contributors
// </copyright>
// <summary>
//   Implements operators related to velocity.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace QuantityTypes
{
    using System;

    /// <summary>
    ///     Implements operators related to velocity.
    /// </summary>
    public partial struct Velocity
    {
        /// <summary>
        ///     Implements the operator /.
        /// </summary>
        /// <param name="x"> The velocity. </param>
        /// <param name="y"> The time. </param>
        /// <returns> The result of the operator. </returns>
        public static Acceleration operator /(Velocity x, Time y)
        {
            return new Acceleration(x.Value / y.Value);
        }

        /// <summary>
        ///     Implements the operator /.
        /// </summary>
        /// <param name="x"> The velocity. </param>
        /// <param name="y"> The acceleration. </param>
        /// <returns> The result of the operator. </returns>
        public static Time operator /(Velocity x, Acceleration y)
        {
            return new Time(x.Value / y.Value);
        }

        /// <summary>
        ///     Implements the operator *.
        /// </summary>
        /// <param name="x"> The velocity. </param>
        /// <param name="y"> The time. </param>
        /// <returns> The result of the operator. </returns>
        public static Length operator *(Velocity x, Time y)
        {
            return new Length(x.Value * y.Value);
        }

        /// <summary>
        ///     Implements the operator ^.
        /// </summary>
        /// <param name="x"> The x. </param>
        /// <param name="exp"> The exponent. </param>
        /// <returns> The result of the operator. </returns>
        public static VelocitySquared operator ^(Velocity x, int exp)
        {
            if (exp == 2)
            {
                return new VelocitySquared(x.Value * x.Value);
            }

            throw new NotSupportedException();
        }

        /// <summary>
        /// Implements the operator * for the product of <see cref="Velocity" /> and <see cref="Velocity" />.
        /// </summary>
        /// <param name="x">The first velocity.</param>
        /// <param name="y">The second velocity.</param>
        /// <returns>The result of the operator.</returns>
        public static VelocitySquared operator *(Velocity x, Velocity y)
        {
            return new VelocitySquared(x.Value * y.Value);
        }
    }
}