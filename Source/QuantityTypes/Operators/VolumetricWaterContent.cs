// --------------------------------------------------------------------------------------------------------------------
// <copyright file="MassConcentration.cs" company="QuantityTypes">
//   Copyright (c) 2015 QuantityTypes contributors
// </copyright>
// <summary>
//   Implements operators related to volume.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace QuantityTypes
{
    /// <summary>
   ///     Implements operators related to VolumetricWaterContent.
    /// </summary>
    public partial struct VolumetricWaterContent
    {
        /// <summary>
       ///     Performs an implicit conversion from <see cref="VolumetricWaterContent" /> to <see cref="Fraction" />.
        /// </summary>
        /// <param name="c"> The volumetric water content. </param>
        /// <returns> Fraction. </returns>
        public static implicit operator Fraction(VolumetricWaterContent c)
        {
           return new Fraction(c.value);
        }

    }
}