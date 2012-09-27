namespace Units
{
    using System;

    /// <summary>
    /// Provides operators related to length.
    /// </summary>
    /// <remarks></remarks>
    public partial struct Length
    {
        /// <summary>
        /// Implements the operator /.
        /// </summary>
        /// <param name="x">The x.</param>
        /// <param name="y">The y.</param>
        /// <returns>The result of the operator.</returns>
        /// <remarks></remarks>
        public static Velocity operator /(Length x, Time y)
        {
            return new Velocity(x.Value / y.Value);
        }

        /// <summary>
        /// Implements the operator *.
        /// </summary>
        /// <param name="x">The x.</param>
        /// <param name="y">The y.</param>
        /// <returns>The result of the operator.</returns>
        /// <remarks></remarks>
        public static Area operator *(Length x, Length y)
        {
            return new Area(x.Value * y.Value);
        }

        /// <summary>
        /// Implements the operator *.
        /// </summary>
        /// <param name="x">The x.</param>
        /// <param name="y">The y.</param>
        /// <returns>The result of the operator.</returns>
        /// <remarks></remarks>
        public static Volume operator *(Length x, Area y)
        {
            return new Volume(x.Value * y.Value);
        }

        /// <summary>
        /// Squares this length.
        /// </summary>
        /// <returns>The area.</returns>
        /// <remarks></remarks>
        public Area Squared()
        {
            return new Area(this.Value * this.Value);
        }

        /// <summary>
        /// Cubes this length.
        /// </summary>
        /// <returns>The volume.</returns>
        /// <remarks></remarks>
        public Volume Cubed()
        {
            return new Volume(this.Value * this.Value * this.Value);
        }

        /// <summary>
        /// Implements the operator ^.
        /// </summary>
        /// <param name="x">The x.</param>
        /// <param name="exp">The exponent.</param>
        /// <returns>The result of the operator.</returns>
        /// <remarks></remarks>
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
    }
}