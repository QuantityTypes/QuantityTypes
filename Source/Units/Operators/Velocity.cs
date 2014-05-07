// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Velocity.cs" company="Units.NET">
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
//   Provides operators related to velocity.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace Units
{
    using System;

    /// <summary>
    ///     Provides operators related to velocity.
    /// </summary>
    public partial struct Velocity
    {
        /// <summary>
        ///     Implements the operator /.
        /// </summary>
        /// <param name="x"> The velocity. </param>
        /// <param name="y"> The time. </param>
        /// <returns> The result of the operator. </returns>
        public static Acceleration operator /(Velocity x, Time y)
        {
            return new Acceleration(x.Value / y.Value);
        }

        /// <summary>
        ///     Implements the operator /.
        /// </summary>
        /// <param name="x"> The velocity. </param>
        /// <param name="y"> The acceleration. </param>
        /// <returns> The result of the operator. </returns>
        public static Time operator /(Velocity x, Acceleration y)
        {
            return new Time(x.Value / y.Value);
        }

        /// <summary>
        ///     Implements the operator *.
        /// </summary>
        /// <param name="x"> The velocity. </param>
        /// <param name="y"> The time. </param>
        /// <returns> The result of the operator. </returns>
        public static Length operator *(Velocity x, Time y)
        {
            return new Length(x.Value * y.Value);
        }

        /// <summary>
        ///     Implements the operator ^.
        /// </summary>
        /// <param name="x"> The x. </param>
        /// <param name="exp"> The exponent. </param>
        /// <returns> The result of the operator. </returns>
        public static VelocitySquared operator ^(Velocity x, int exp)
        {
            if (exp == 2)
            {
                return new VelocitySquared(x.Value * x.Value);
            }

            throw new NotSupportedException();
        }

        /// <summary>
        /// Implements the operator * for the product of <see cref="Velocity" /> and <see cref="Velocity" />.
        /// </summary>
        /// <param name="x">The first velocity.</param>
        /// <param name="y">The second velocity.</param>
        /// <returns>The result of the operator.</returns>
        public static VelocitySquared operator *(Velocity x, Velocity y)
        {
            return new VelocitySquared(x.Value * y.Value);
        }
    }
}