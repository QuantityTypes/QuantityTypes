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
    public partial struct ElectricConductance
    {
        /// <summary>
        ///     Implements the operator /.
        /// </summary>
        /// <param name="c"> The conductance. </param>
        /// <param name="l"> The length. </param>
        /// <returns> The result of the operator. </returns>
        public static ElectricConductivity operator /(ElectricConductance c, Length l)
        {
            return new ElectricConductivity(c.Value / l.Value);
        }

    }
}