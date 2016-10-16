// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Torque.cs" company="QuantityTypes">
//   Copyright (c) 2014 QuantityTypes contributors
// </copyright>
// <summary>
//   Implements operators related to torque.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace QuantityTypes
{
    /// <summary>
    /// Implements operators related to torque.
    /// </summary>
    public partial struct Moment
    {
        /// <summary>
        ///     Performs an implicit conversion from <see cref="Torque" /> to <see cref="Moment" />.
        /// </summary>
        /// <param name="m"> The moment to convert. </param>
        /// <returns> The result of the conversion. </returns>
        public static implicit operator Moment(Torque m)
        {
            return new Moment(m.Value);
        }


        /// <summary>
        /// Implements moment divided by length.
        /// </summary>
        /// <param name="x">The moment.</param>
        /// <param name="y">The length.</param>
        /// <returns>The resulting force.</returns>
        public static Force operator /(Moment x, Length y)
        {
            return new Force(x.Value / y.Value);
        }

        /// <summary>
        /// Implements moment divided by force.
        /// </summary>
        /// <param name="x">The moment.</param>
        /// <param name="y">The force.</param>
        /// <returns>The resulting length.</returns>
        public static Length operator /(Moment x, Force y)
        {
            return new Length(x.Value / y.Value);
        }
    }
}