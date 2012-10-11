// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Length.cs" company="Units.NET">
//   Copyright (c) 2012 Oystein Bjorke
// </copyright>
// <summary>
//   Provides operators related to length.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Units
{
    using System;

    /// <summary>
    /// Provides operators related to length.
    /// </summary>
    public partial struct Length
    {
        /// <summary>
        /// Implements the operator /.
        /// </summary>
        /// <param name="x"> The x. </param>
        /// <param name="y"> The y. </param>
        /// <returns> The result of the operator. </returns>
        public static Velocity operator /(Length x, Time y)
        {
            return new Velocity(x.Value / y.Value);
        }

        /// <summary>
        /// Implements the operator ^.
        /// </summary>
        /// <param name="x"> The x. </param>
        /// <param name="exp"> The exponent. </param>
        /// <returns> The result of the operator. </returns>
        public static IQuantity operator ^(Length x, int exp)
        {
            if (exp == 2)
            {
                return new Area(x.Value * x.Value);
            }

            if (exp == 3)
            {
                return new Volume(x.Value * x.Value * x.Value);
            }

            throw new NotSupportedException();
        }

        /// <summary>
        /// Implements the operator *.
        /// </summary>
        /// <param name="x"> The x. </param>
        /// <param name="y"> The y. </param>
        /// <returns> The result of the operator. </returns>
        public static Area operator *(Length x, Length y)
        {
            return new Area(x.Value * y.Value);
        }

        /// <summary>
        /// Implements the operator *.
        /// </summary>
        /// <param name="x"> The x. </param>
        /// <param name="y"> The y. </param>
        /// <returns> The result of the operator. </returns>
        public static Volume operator *(Length x, Area y)
        {
            return new Volume(x.Value * y.Value);
        }

        /// <summary>
        /// Cubes this length.
        /// </summary>
        /// <returns> The volume. </returns>
        public Volume Cubed()
        {
            return new Volume(this.Value * this.Value * this.Value);
        }

        /// <summary>
        /// Squares this length.
        /// </summary>
        /// <returns> The area. </returns>
        public Area Squared()
        {
            return new Area(this.Value * this.Value);
        }

    }
}