namespace Units
{
    /// <summary>
    /// Provides operators related to acceleration.
    /// </summary>
    /// <remarks></remarks>
    public partial struct Acceleration
    {
        /// <summary>
        /// Implements the operator *.
        /// </summary>
        /// <param name="x">The x.</param>
        /// <param name="y">The y.</param>
        /// <returns>The result of the operator.</returns>
        /// <remarks></remarks>
        public static Velocity operator *(Acceleration x, Time y)
        {
            return new Velocity(x.Value / y.Value);
        }
    }
}