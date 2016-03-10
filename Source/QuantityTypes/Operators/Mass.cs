// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Mass.cs" company="QuantityTypes">
//   Copyright (c) 2014 QuantityTypes contributors
// </copyright>
// <summary>
//   Implements operators related to mass.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace QuantityTypes
{
    /// <summary>
    /// Implements operators related to mass.
    /// </summary>
    public partial struct Mass
    {
        /// <summary>
        ///     Implements the operator /.
        /// </summary>
        /// <param name="m"> The mass. </param>
        /// <param name="v"> The volume. </param>
        /// <returns> The result of the operator. </returns>
        public static Density operator /(Mass m, Volume v)
        {
            return new Density(m.Value / v.Value);
        }

        /// <summary>
        ///     Implements the operator /.
        /// </summary>
        /// <param name="m"> The mass. </param>
        /// <param name="d"> The density. </param>
        /// <returns> The result of the operator. </returns>
        public static Volume operator /(Mass m, Density d)
        {
            return new Volume(m.Value / d.Value);
        }

        /// <summary>
        ///     Implements the operator /.
        /// </summary>
        /// <param name="m"> The mass. </param>
        /// <param name="dt"> The time duration. </param>
        /// <returns> The result of the operator. </returns>
        public static MassFlowRate operator /(Mass m, Time dt)
        {
            return new MassFlowRate(m.Value / dt.Value);
        }

        /// <summary>
        /// Implements the operator *.
        /// </summary>
        /// <param name="m">The mass.</param>
        /// <param name="a">The area.</param>
        /// <returns>The mass moment of inertia.</returns>
        public static MassMomentOfInertia operator *(Mass m, Area a)
        {
            return new MassMomentOfInertia(m.Value * a.Value);
        }

        /// <summary>
        /// Implements the operator *.
        /// </summary>
        /// <param name="m">The mass.</param>
        /// <param name="a">The acceleration.</param>
        /// <returns>The force.</returns>
        public static Force operator *(Mass m, Acceleration a)
        {
            return new Force(m.Value * a.Value);
        }

        /// <summary>
        /// Implements the operator * for the product of <see cref="Mass" /> and <see cref="VelocitySquared" />.
        /// </summary>
        /// <param name="m">The mass.</param>
        /// <param name="v2">The velocity squared.</param>
        /// <returns>The energy.</returns>
        public static Energy operator *(Mass m, VelocitySquared v2)
        {
            return new Energy(m.Value * v2.Value);
        }
    }
}