namespace Units
{
    /// <summary>
    /// Provides operators related to time.
    /// </summary>
    /// <remarks></remarks>
    public partial struct Time
    {
        /// <summary>
        /// Inverses this time.
        /// </summary>
        /// <returns>The frequency.</returns>
        /// <remarks></remarks>
        public Frequency Inverse()
        {
            return new Frequency(1 / this.value);
        }

        /// <summary>
        /// Implements the operator /.
        /// </summary>
        /// <param name="x">The x.</param>
        /// <param name="y">The y.</param>
        /// <returns>The result of the operator.</returns>
        /// <remarks></remarks>
        public static Frequency operator /(double x, Time y)
        {
            return new Frequency(x / y.value);
        }
    }
}