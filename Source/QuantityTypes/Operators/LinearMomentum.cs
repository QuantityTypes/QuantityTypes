// --------------------------------------------------------------------------------------------------------------------
// <copyright file="LinearMomentum.cs" company="QuantityTypes">
//   Copyright (c) 2014 QuantityTypes contributors
// </copyright>
// <summary>
//   Implements operators related to linear momentum.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace QuantityTypes
{
    /// <summary>
    ///     Implements operators related to linear momentum.
    /// </summary>
    public partial struct LinearMomentum
    {
        /// <summary>
        ///     Implements the operator /.
        /// </summary>
        /// <param name="x"> The x. </param>
        /// <param name="y"> The y. </param>
        /// <returns> The result of the operator. </returns>
        public static Mass operator /(LinearMomentum x, Velocity y)
        {
            return new Mass(x.Value / y.Value);
        }

        /// <summary>
        ///     Implements the operator /.
        /// </summary>
        /// <param name="x"> The x. </param>
        /// <param name="y"> The y. </param>
        /// <returns> The result of the operator. </returns>
        public static Velocity operator /(LinearMomentum x, Mass y)
        {
            return new Velocity(x.Value / y.Value);
        }

        /// <summary>
        ///     Implements the operator *.
        /// </summary>
        /// <param name="x"> The x. </param>
        /// <param name="y"> The y. </param>
        /// <returns> The result of the operator. </returns>
        public static Energy operator *(LinearMomentum x, Velocity y)
        {
            return new Energy(x.Value * y.Value);
        }
    }
}