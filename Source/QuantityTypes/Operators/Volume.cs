// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Volume.cs" company="QuantityTypes">
//   Copyright (c) 2014 QuantityTypes contributors
// </copyright>
// <summary>
//   Implements operators related to volume.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace QuantityTypes
{
    /// <summary>
    ///     Implements operators related to volume.
    /// </summary>
    public partial struct Volume
    {
        /// <summary>
        ///     Implements the operator /.
        /// </summary>
        /// <param name="l1"> The l1. </param>
        /// <param name="l2"> The l2. </param>
        /// <returns> The result of the operator. </returns>
        public static Length operator /(Volume l1, Area l2)
        {
            return new Length(l1.Value / l2.Value);
        }

        /// <summary>
        ///     Implements the operator *.
        /// </summary>
        /// <param name="x"> The volume. </param>
        /// <param name="y"> The density. </param>
        /// <returns> The result of the operator. </returns>
        public static Mass operator *(Volume x, Density y)
        {
            return new Mass(x.Value * y.Value);
        }
    
        /// <summary>
        /// Implements the operator *.
        /// </summary>
        /// <param name="x">The volume.</param>
        /// <param name="y">The length.</param>
        /// <returns>
        /// The result of the operator.
        /// </returns>
        public static SecondMomentOfArea operator *(Volume x, Length y)
        {
            return new SecondMomentOfArea(x.value * y.Value);
        }
    }
}