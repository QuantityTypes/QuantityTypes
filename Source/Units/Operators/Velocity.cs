namespace Units
{
    /// <summary>
    /// Provides operators related to velocity.
    /// </summary>
    /// <remarks></remarks>
    public partial struct Velocity
    {
        /// <summary>
        /// Implements the operator /.
        /// </summary>
        /// <param name="x">The x.</param>
        /// <param name="y">The y.</param>
        /// <returns>The result of the operator.</returns>
        /// <remarks></remarks>
        public static Acceleration operator /(Velocity x, Time y)
        {
            return new Acceleration(x.Value / y.Value);
        }

        /// <summary>
        /// Implements the operator *.
        /// </summary>
        /// <param name="x">The x.</param>
        /// <param name="y">The y.</param>
        /// <returns>The result of the operator.</returns>
        /// <remarks></remarks>
        public static Length operator *(Velocity x, Time y)
        {
            return new Length(x.Value * y.Value);
        }
    }
}