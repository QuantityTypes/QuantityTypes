namespace Units
{
    /// <summary>
    /// Provides operators related to temperature.
    /// </summary>
    /// <remarks></remarks>
    public partial struct Temperature
    {
        /// <summary>
        /// Implements the operator -.
        /// </summary>
        /// <param name="x">The x.</param>
        /// <param name="y">The y.</param>
        /// <returns>The result of the operator.</returns>
        /// <remarks></remarks>
        public static TemperatureDifference operator -(Temperature x, Temperature y)
        {
            return new TemperatureDifference(x.value - y.value);
        }

        /// <summary>
        /// Implements the operator +.
        /// </summary>
        /// <param name="x">The x.</param>
        /// <param name="y">The y.</param>
        /// <returns>The result of the operator.</returns>
        /// <remarks></remarks>
        public static Temperature operator +(Temperature x, TemperatureDifference y)
        {
            return new Temperature(x.value + y.Value);
        }
    }
}