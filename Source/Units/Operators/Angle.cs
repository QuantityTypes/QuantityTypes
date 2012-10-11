// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Angle.cs" company="Units.NET">
//   Copyright (c) 2012 Oystein Bjorke
// </copyright>
// <summary>
//   Provides operators related to angle.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Units
{
    using System;

    /// <summary>
    /// Provides operators related to angle.
    /// </summary>
    public partial struct Angle
    {
        /// <summary>
        /// Calculates the arc cosine of the specified value.
        /// </summary>
        /// <param name="d">
        /// The value.
        /// </param>
        /// <returns>
        /// The angle.
        /// </returns>
        public static Angle Acos(double d)
        {
            return new Angle(Math.Acos(d));
        }

        /// <summary>
        /// Calculates the arc sine of the specified value.
        /// </summary>
        /// <param name="d">
        /// The value.
        /// </param>
        /// <returns>
        /// The angle.
        /// </returns>
        public static Angle Asin(double d)
        {
            return new Angle(Math.Asin(d));
        }

        /// <summary>
        /// Calculates the arc tangent of the specified value.
        /// </summary>
        /// <param name="d">
        /// The value.
        /// </param>
        /// <returns>
        /// The angle.
        /// </returns>
        public static Angle Atan(double d)
        {
            return new Angle(Math.Atan(d));
        }

        /// <summary>
        /// Calculates the cosine of the specified angle.
        /// </summary>
        /// <returns> The value. </returns>
        public double Cos()
        {
            return Math.Cos(this.value);
        }

        /// <summary>
        /// Calculates the sine of the specified angle.
        /// </summary>
        /// <returns> The value. </returns>
        public double Sin()
        {
            return Math.Sin(this.value);
        }

        /// <summary>
        /// Calculates the tangent of the specified angle.
        /// </summary>
        /// <returns> The value. </returns>
        public double Tan()
        {
            return Math.Tan(this.value);
        }

    }
}