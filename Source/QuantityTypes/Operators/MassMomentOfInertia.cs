// --------------------------------------------------------------------------------------------------------------------
// <copyright file="MassMomentOfInertia.cs" company="QuantityTypes">
//   Copyright (c) 2014 QuantityTypes contributors
// </copyright>
// <summary>
//   Implements operators related to mass moment of inertia.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace QuantityTypes
{
    /// <summary>
    /// Implements operators related to mass moment of inertia.
    /// </summary>
    public partial struct MassMomentOfInertia
    {
        /// <summary>
        /// Implements the operator /.
        /// </summary>
        /// <param name="i">The moment of inertia.</param>
        /// <param name="a">The area.</param>
        /// <returns>
        /// The mass.
        /// </returns>
        public static Mass operator /(MassMomentOfInertia i, Area a)
        {
            return new Mass(i.Value / a.Value);
        }

        /// <summary>
        /// Implements the operator /.
        /// </summary>
        /// <param name="i">The moment of inertia.</param>
        /// <param name="m">The mass.</param>
        /// <returns>
        /// The area.
        /// </returns>
        public static Area operator /(MassMomentOfInertia i, Mass m)
        {
            return new Area(i.Value / m.Value);
        }
    }
}