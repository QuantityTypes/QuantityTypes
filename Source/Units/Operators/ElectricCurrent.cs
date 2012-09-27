namespace Units
{
    /// <summary>
    /// Provides operators related to electric current.
    /// </summary>
    /// <remarks></remarks>
    public partial struct ElectricCurrent
    {
        /// <summary>
        /// Implements the operator *.
        /// </summary>
        /// <param name="x">The x.</param>
        /// <param name="y">The y.</param>
        /// <returns>The result of the operator.</returns>
        /// <remarks></remarks>
        public static ElectricCharge operator *(ElectricCurrent x, Time y)
        {
            return new ElectricCharge(x.Value * y.Value);
        }
    }
}