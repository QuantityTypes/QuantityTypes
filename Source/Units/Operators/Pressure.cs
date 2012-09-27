namespace Units
{
    /// <summary>
    /// Provides operators related to pressure.
    /// </summary>
    /// <remarks></remarks>
    public partial struct Pressure
    {
        /// <summary>
        /// Implements the operator *.
        /// </summary>
        /// <param name="x">The x.</param>
        /// <param name="y">The y.</param>
        /// <returns>The result of the operator.</returns>
        /// <remarks></remarks>
        public static Force operator *(Pressure x, Area y)
        {
            return new Force(x.Value * y.Value);
        }

    }
}