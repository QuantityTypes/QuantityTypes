// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Area.cs" company="QuantityTypes">
//   Copyright (c) 2014 QuantityTypes contributors
// </copyright>
// <summary>
//   Provides operators related to area.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace QuantityTypes
{
    using System;

    /// <summary>
    ///     Provides operators related to area.
    /// </summary>
    public partial struct Area
    {
        /// <summary>
        /// Calculates the square root of the specified area.
        /// </summary>
        /// <param name="a">
        /// The area. 
        /// </param>
        /// <returns>
        /// The length. 
        /// </returns>
        public static Length Sqrt(Area a)
        {
            return new Length(System.Math.Sqrt(a.value));
        }

        /// <summary>
        ///     Implements the operator /.
        /// </summary>
        /// <param name="a1"> The area. </param>
        /// <param name="a2"> The area. </param>
        /// <returns> The result of the operator. </returns>
        public static Length operator /(Area a1, Length a2)
        {
            return new Length(a1.value / a2.Value);
        }

        /// <summary>
        ///     Implements the operator *.
        /// </summary>
        /// <param name="a1"> The area. </param>
        /// <param name="a2"> The area. </param>
        /// <returns> The result of the operator. </returns>
        public static Volume operator *(Area a1, Length a2)
        {
            return new Volume(a1.value * a2.Value);
        }

        /// <summary>
        ///     Implements the operator *.
        /// </summary>
        /// <param name="a1"> The area. </param>
        /// <param name="a2"> The area. </param>
        /// <returns> The result of the operator. </returns>
        public static SecondMomentOfArea operator *(Area a1, Area a2)
        {
            return new SecondMomentOfArea(a1.value * a2.Value);
        }

        /// <summary>
        ///     Implements the operator *.
        /// </summary>
        /// <param name="a"> The area. </param>
        /// <param name="f"> The heat flux density. </param>
        /// <returns> The result of the operator. </returns>
        public static Power operator *(Area a, HeatFluxDensity f)
        {
            return new Power(a.value * f.Value);
        }
    }
}