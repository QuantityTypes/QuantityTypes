// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Illuminance.cs" company="QuantityTypes">
//   Copyright (c) 2014 QuantityTypes contributors
// </copyright>
// <summary>
//   Implements operators related to illuminance.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace QuantityTypes
{
    /// <summary>
    ///     Implements operators related to illuminance.
    /// </summary>
    public partial struct Illuminance
    {
        /// <summary>
        ///     Implements the operator *.
        ///     I=E*A
        /// </summary>
        /// <param name="l1"> The illuminance. </param>
        /// <param name="l2"> The area. </param>
        /// <returns> The luminous flux through an area. </returns>
        public static LuminousFlux operator *(Illuminance l1, Area l2)
        {
            return new LuminousFlux(l1.value * l2.Value);
        }

        /// <summary>
        ///     Implements the operator *.
        ///     I=E*r²
        /// </summary>
        /// <param name="l1"> The illuminance. </param>
        /// <param name="l2"> The distance. </param>
        /// <returns> Luminous intensity generating the illuminance in that distance </returns>
        public static LuminousIntensity operator *(Illuminance l1, Length l2)
        {
            return new LuminousIntensity(l1.value * l2.Squared().Value);
        }
    }
}