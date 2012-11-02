// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Area.cs" company="Units.NET">
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
//   Provides operators related to area.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace Units
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
        /// <param name="l">
        /// The area. 
        /// </param>
        /// <returns>
        /// The length. 
        /// </returns>
        public static Length Sqrt(Area l)
        {
            return new Length(Math.Sqrt(l.value));
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
    }
}