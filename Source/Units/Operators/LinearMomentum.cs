namespace Units
{
    /// <summary>
    /// Provides operators related to linear momentum.
    /// </summary>
    /// <remarks></remarks>
    public partial struct LinearMomentum
    {
        /// <summary>
        /// Implements the operator /.
        /// </summary>
        /// <param name="x">The x.</param>
        /// <param name="y">The y.</param>
        /// <returns>The result of the operator.</returns>
        /// <remarks></remarks>
        public static Mass operator /(LinearMomentum x, Velocity y)
        {
            return new Mass(x.Value / y.Value);
        }

        /// <summary>
        /// Implements the operator /.
        /// </summary>
        /// <param name="x">The x.</param>
        /// <param name="y">The y.</param>
        /// <returns>The result of the operator.</returns>
        /// <remarks></remarks>
        public static Velocity operator /(LinearMomentum x, Mass y)
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
        public static Energy operator *(LinearMomentum x, Velocity y)
        {
            return new Energy(x.Value * y.Value);
        }
    }
}