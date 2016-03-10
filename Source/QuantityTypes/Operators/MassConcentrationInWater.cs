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
   ///     Implements operators related to MassConcentrationInWater.
    /// </summary>
    public partial struct MassConcentrationInWater
    {
        /// <summary>
        ///     Implements the operator *.
        /// </summary>
        /// <param name="x"> The concentration. </param>
        /// <param name="y"> The volume. </param>
        /// <returns> The result of the operator. </returns>
        public static Mass operator *(MassConcentrationInWater x, Volume y)
        {
            return new Mass(x.Value * y.Value);
        }

        /// <summary>
        ///     Performs an implicit conversion from <see cref="MassConcentrationInWater" /> to <see cref="MassConcentration" />.
        /// </summary>
        /// <param name="c"> The mass concentration in water. </param>
        /// <returns> MassConcentration. </returns>
        public static implicit operator MassConcentration(MassConcentrationInWater c)
        {
           return new MassConcentration(c.Value);
        }

        /// <summary>
        ///     Performs an implicit conversion from <see cref="MassConcentrationInWater" /> to <see cref="Fraction" />.
        /// </summary>
        /// <param name="c"> The mass concentration in water. </param>
        /// <returns> Fraction. </returns>
        public static implicit operator Fraction(MassConcentrationInWater c)
        {
           // Base unit of MassConcentrationInWater is kg/m^3. 1mg/L == 1 ppm.
           return Fraction.PartPerMillion * c.ConvertTo(MassConcentrationInWater.MilligramPerLitre);
        }

    }
}