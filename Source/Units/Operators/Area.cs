namespace Units
{
    using System;

    /// <summary>
    /// Provides operators related to area.
    /// </summary>
    /// <remarks></remarks>
    public partial struct Area
    {
        /// <summary>
        /// Implements the operator /.
        /// </summary>
        /// <param name="a1">The area.</param>
        /// <param name="a2">The area.</param>
        /// <returns>The result of the operator.</returns>
        /// <remarks></remarks>
        public static Length operator /(Area a1, Length a2)
        {
            return new Length(a1.value / a2.Value);
        }

        /// <summary>
        /// Implements the operator *.
        /// </summary>
        /// <param name="a1">The area.</param>
        /// <param name="a2">The area.</param>
        /// <returns>The result of the operator.</returns>
        /// <remarks></remarks>
        public static Volume operator *(Area a1, Length a2)
        {
            return new Volume(a1.value * a2.Value);
        }

        /// <summary>
        /// Calculates the square root of the specified area.
        /// </summary>
        /// <param name="l">The area.</param>
        /// <returns>The length.</returns>
        /// <remarks></remarks>
        public static Length Sqrt(Area l)
        {
            return new Length(Math.Sqrt(l.value));
        }
    }
}