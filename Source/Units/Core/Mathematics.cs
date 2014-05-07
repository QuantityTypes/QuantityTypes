// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Mathematics.cs" company="Units.NET">
//   The MIT License (MIT)
//   
//   Copyright (c) 2012 Oystein Bjorke
//   
//   Permission is hereby granted, free of charge, to any person obtaining a
//   copy of this software and associated documentation files (the
//   "Software"), to deal in the Software without restriction, including
//   without limitation the rights to use, copy, modify, merge, publish,
//   distribute, sublicense, and/or sell copies of the Software, and to
//   permit persons to whom the Software is furnished to do so, subject to
//   the following conditions:
//   
//   The above copyright notice and this permission notice shall be included
//   in all copies or substantial portions of the Software.
//   
//   THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS
//   OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF
//   MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT.
//   IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY
//   CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER IN AN ACTION OF CONTRACT,
//   TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN CONNECTION WITH THE
//   SOFTWARE OR THE USE OR OTHER DEALINGS IN THE SOFTWARE.
// </copyright>
// <summary>
//   Provides constants and static methods for trigonometric, logarithmic, and other common mathematical functions.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Units
{
    using System;

    /// <summary>
    /// Provides constants and static methods for trigonometric, logarithmic, and other common mathematical functions.
    /// </summary>
    public static class Mathematics
    {
        /// <summary>
        /// Calculates the sine of the specified angle.
        /// </summary>
        /// <param name="a">
        /// The angle.
        /// </param>
        /// <returns>
        /// The value.
        /// </returns>
        public static double Sin(Angle a)
        {
            return Math.Sin(a.ConvertTo(Angle.Radian));
        }

        /// <summary>
        /// Calculates the cosine of the specified angle.
        /// </summary>
        /// <param name="a">
        /// The angle.
        /// </param>
        /// <returns>
        /// The value.
        /// </returns>
        public static double Cos(Angle a)
        {
            return Math.Cos(a.ConvertTo(Angle.Radian));
        }

        /// <summary>
        /// Calculates the tangent of the specified angle.
        /// </summary>
        /// <param name="a">
        /// The angle.
        /// </param>
        /// <returns>
        /// The value.
        /// </returns>
        public static double Tan(Angle a)
        {
            return Math.Tan(a.ConvertTo(Angle.Radian));
        }

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
        /// Returns the angle whose tangent is the quotient of two specified numbers.
        /// </summary>
        /// <param name="y">
        /// The y coordinate of a point.
        /// </param>
        /// <param name="x">
        /// The x coordinate of a point.
        /// </param>
        /// <returns>
        /// An angle, θ, measured in radians, such that -π≤θ≤π, and tan(θ) = y / x, where (x, y) is a point in the Cartesian plane.
        /// </returns>
        public static Angle Atan2(double y, double x)
        {
            return new Angle(Math.Atan2(y, x));
        }

        /// <summary>
        /// Returns the square root of a specified area.
        /// </summary>
        /// <param name="a">
        /// The area.
        /// </param>
        /// <returns>
        /// The positive square root of the area.
        /// </returns>
        public static Length Sqrt(Area a)
        {
            return Math.Sqrt(a.ConvertTo(Area.SquareMetre)) * Length.Metre;
        }

        /// <summary>
        /// Returns the square root of a specified time squared.
        /// </summary>
        /// <param name="a">
        /// The squared time.
        /// </param>
        /// <returns>
        /// The positive square root of the time squared.
        /// </returns>
        public static Time Sqrt(TimeSquared a)
        {
            return Math.Sqrt(a.ConvertTo(TimeSquared.SecondSquared)) * Time.Second;
        }

        /// <summary>
        /// Returns the square root of a specified time squared.
        /// </summary>
        /// <param name="a">
        /// The squared velocity.
        /// </param>
        /// <returns>
        /// The positive square root of the area.
        /// </returns>
        public static Velocity Sqrt(VelocitySquared a)
        {
            return Math.Sqrt(a.ConvertTo(VelocitySquared.MetreSquaredPerSecondSquared)) * Velocity.MetrePerSecond;
        }

        /// <summary>
        /// Returns the absolute value of a quantity.
        /// </summary>
        /// <typeparam name="T">
        /// The quantity type
        /// </typeparam>
        /// <param name="a">
        /// The quantity.
        /// </param>
        /// <returns>
        /// The absolute value of the quantity.
        /// </returns>
        public static T Abs<T>(T a) where T : IQuantity
        {
            return a.Value < 0 ? (T)a.MultiplyBy(-1) : a;
        }

        /// <summary>
        /// Returns a value indicating the sign of a quantity.
        /// </summary>
        /// <typeparam name="T">
        /// The quantity type
        /// </typeparam>
        /// <param name="a">
        /// A signed quantity.
        /// </param>
        /// <returns>
        /// A number that indicates the sign of value.
        /// </returns>
        public static int Sign<T>(T a) where T : IQuantity
        {
            return Math.Sign(a.Value);
        }
    }
}