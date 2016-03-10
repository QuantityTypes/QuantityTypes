// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Angle.cs" company="QuantityTypes">
//   Copyright (c) 2014 QuantityTypes contributors
// </copyright>
// <summary>
//   Implements operators related to angle.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace QuantityTypes
{
    using System;

    /// <summary>
    ///     Implements operators related to angle.
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
        /// Returns the angle whose tangent is the quotient of the two specified numbers.
        /// </summary>
        /// <param name="y">The y coordinate of a point.</param>
        /// <param name="x">The x coordinate of a point.</param>
        /// <returns>An angle, θ, measured in radians, such that -π ≤ θ ≤ π, and tan(θ) = y / x, where (x, y) is a point in the Cartesian plane.</returns>
        public static Angle Atan2(double y, double x)
        {
            return new Angle(Math.Atan2(y, x));
        }

        /// <summary>
        /// Returns the angle whose tangent is the quotient of the two specified numbers.
        /// </summary>
        /// <param name="y">The y coordinate of a point.</param>
        /// <param name="x">The x coordinate of a point.</param>
        /// <returns>An angle, θ, measured in radians, such that -π ≤ θ ≤ π, and tan(θ) = y / x, where (x, y) is a point in the Cartesian plane.</returns>
        public static Angle Atan2(Length y, Length x)
        {
            return new Angle(Math.Atan2(y.Value, x.Value));
        }

        /// <summary>
        ///     Calculates the cosine of the specified angle.
        /// </summary>
        /// <returns> The value. </returns>
        public double Cos()
        {
            return Math.Cos(this.value);
        }

        /// <summary>
        ///     Calculates the sine of the specified angle.
        /// </summary>
        /// <returns> The value. </returns>
        public double Sin()
        {
            return Math.Sin(this.value);
        }

        /// <summary>
        ///     Returns the tangent of the specified angle.
        /// </summary>
        /// <returns>The tangent of the angle.</returns>
        public double Tan()
        {
            return Math.Tan(this.value);
        }

        /// <summary>
        /// Converts the angle to degrees.
        /// </summary>
        /// <returns>The angle in degrees</returns>
        public double ToDegrees()
        {
            return this.ConvertTo(Degree);
        }

        /// <summary>
        /// Converts the angle to radians.
        /// </summary>
        /// <returns>The angle in radians.</returns>
        public double ToRadians()
        {
            return this.ConvertTo(Radian);
        }
    }
}