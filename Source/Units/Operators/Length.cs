// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Length.cs" company="Units.NET">
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
//   Provides operators related to length.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace Units
{
    using System;

    /// <summary>
    ///     Provides operators related to length.
    /// </summary>
    public partial struct Length
    {
        /// <summary>
        ///     Implements the operator /.
        /// </summary>
        /// <param name="x"> The x. </param>
        /// <param name="y"> The y. </param>
        /// <returns> The result of the operator. </returns>
        public static Velocity operator /(Length x, Time y)
        {
            return new Velocity(x.Value / y.Value);
        }

        /// <summary>
        ///     Implements the operator ^.
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
        ///     Implements the operator *.
        /// </summary>
        /// <param name="x"> The x. </param>
        /// <param name="y"> The y. </param>
        /// <returns> The result of the operator. </returns>
        public static Area operator *(Length x, Length y)
        {
            return new Area(x.Value * y.Value);
        }

        /// <summary>
        ///     Implements the operator *.
        /// </summary>
        /// <param name="x"> The x. </param>
        /// <param name="y"> The y. </param>
        /// <returns> The result of the operator. </returns>
        public static Volume operator *(Length x, Area y)
        {
            return new Volume(x.Value * y.Value);
        }

        /// <summary>
        /// Implements the / operator for the product of <see cref="Acceleration" /> and <see cref="TimeSquared" />.
        /// </summary>
        /// <param name="x">The x.</param>
        /// <param name="y">The y.</param>
        /// <returns>The result of the operator.</returns>
        public static Acceleration operator /(Length x, TimeSquared y)
        {
            return new Acceleration(x.Value / y.Value);
        }

        /// <summary>
        ///     Cubes this length.
        /// </summary>
        /// <returns> The volume. </returns>
        public Volume Cubed()
        {
            return new Volume(this.Value * this.Value * this.Value);
        }

        /// <summary>
        ///     Squares this length.
        /// </summary>
        /// <returns> The area. </returns>
        public Area Squared()
        {
            return new Area(this.Value * this.Value);
        }
    }
}