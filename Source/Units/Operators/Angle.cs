namespace Units
{
    using System;

    /// <summary>
    /// Provides operators related to angle.
    /// </summary>
    /// <remarks></remarks>
    public partial struct Angle
    {
        /// <summary>
        /// Calculates the sine of the specified angle.
        /// </summary>
        /// <returns>The value.</returns>
        /// <remarks></remarks>
        public double Sin()
        {
            return Math.Sin(this.value);
        }
        /// <summary>
        /// Calculates the cosine of the specified angle.
        /// </summary>
        /// <returns>The value.</returns>
        /// <remarks></remarks>
        public double Cos()
        {
            return Math.Cos(this.value);
        }
        /// <summary>
        /// Calculates the tangent of the specified angle.
        /// </summary>
        /// <returns>The value.</returns>
        /// <remarks></remarks>
        public double Tan()
        {
            return Math.Tan(this.value);
        }

        /// <summary>
        /// Calculates the arc cosine of the specified value.
        /// </summary>
        /// <param name="d">The value.</param>
        /// <returns>The angle.</returns>
        /// <remarks></remarks>
        public static Angle Acos(double d)
        {
            return new Angle(Math.Acos(d));
        }

        /// <summary>
        /// Calculates the arc sine of the specified value.
        /// </summary>
        /// <param name="d">The value.</param>
        /// <returns>The angle.</returns>
        /// <remarks></remarks>
        public static Angle Asin(double d)
        {
            return new Angle(Math.Asin(d));
        }

        /// <summary>
        /// Calculates the arc tangent of the specified value.
        /// </summary>
        /// <param name="d">The value.</param>
        /// <returns>The angle.</returns>
        /// <remarks></remarks>
        public static Angle Atan(double d)
        {
            return new Angle(Math.Atan(d));
        }
    }
}