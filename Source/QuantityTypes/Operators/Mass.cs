// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Mass.cs" company="QuantityTypes">
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
//   Provides operators related to mass.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace QuantityTypes
{
    /// <summary>
    /// Provides operators related to mass.
    /// </summary>
    public partial struct Mass
    {
        /// <summary>
        ///     Implements the operator /.
        /// </summary>
        /// <param name="m"> The mass. </param>
        /// <param name="v"> The volume. </param>
        /// <returns> The result of the operator. </returns>
        public static Density operator /(Mass m, Volume v)
        {
            return new Density(m.Value / v.Value);
        }

        /// <summary>
        ///     Implements the operator /.
        /// </summary>
        /// <param name="m"> The mass. </param>
        /// <param name="d"> The density. </param>
        /// <returns> The result of the operator. </returns>
        public static Volume operator /(Mass m, Density d)
        {
            return new Volume(m.Value / d.Value);
        }

        /// <summary>
        /// Implements the operator *.
        /// </summary>
        /// <param name="m">The mass.</param>
        /// <param name="a">The area.</param>
        /// <returns>The mass moment of inertia.</returns>
        public static MassMomentOfInertia operator *(Mass m, Area a)
        {
            return new MassMomentOfInertia(m.Value * a.Value);
        }

        /// <summary>
        /// Implements the operator *.
        /// </summary>
        /// <param name="m">The mass.</param>
        /// <param name="a">The acceleration.</param>
        /// <returns>The force.</returns>
        public static Force operator *(Mass m, Acceleration a)
        {
            return new Force(m.Value * a.Value);
        }

        /// <summary>
        /// Implements the operator * for the product of <see cref="Mass" /> and <see cref="VelocitySquared" />.
        /// </summary>
        /// <param name="m">The mass.</param>
        /// <param name="v2">The velocity squared.</param>
        /// <returns>The energy.</returns>
        public static Energy operator *(Mass m, VelocitySquared v2)
        {
            return new Energy(m.Value * v2.Value);
        }
    }
}