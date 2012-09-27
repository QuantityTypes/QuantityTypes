namespace Units
{
    /// <summary>
    /// Provides operators related to electric voltage.
    /// </summary>
    /// <remarks></remarks>
    public partial struct ElectricVoltage
    {
        /// <summary>
        /// Implements the operator /.
        /// </summary>
        /// <param name="x">The x.</param>
        /// <param name="y">The y.</param>
        /// <returns>The result of the operator.</returns>
        /// <remarks></remarks>
        public static ElectricResistance operator /(ElectricVoltage x, ElectricCurrent y)
        {
            return new ElectricResistance(x.Value / y.Value);
        }
        /// <summary>
        /// Implements the operator /.
        /// </summary>
        /// <param name="x">The x.</param>
        /// <param name="y">The y.</param>
        /// <returns>The result of the operator.</returns>
        /// <remarks></remarks>
        public static ElectricCurrent operator /(ElectricVoltage x, ElectricResistance y)
        {
            return new ElectricCurrent(x.Value / y.Value);
        }
    }
}