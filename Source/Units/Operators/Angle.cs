// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Angle.cs" company="Units.NET">
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
//   Provides operators related to angle.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace Units
{
    using System;

    /// <summary>
    ///     Provides operators related to angle.
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
        ///     Calculates the tangent of the specified angle.
        /// </summary>
        /// <returns> The value. </returns>
        public double Tan()
        {
            return Math.Tan(this.value);
        }
    }
}