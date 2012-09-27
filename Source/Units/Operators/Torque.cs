namespace Units
{
    /// <summary>
    /// Provides operators related to torque.
    /// </summary>
    /// <remarks></remarks>
    public partial struct Torque
    {
        /// <summary>
        /// Performs an implicit conversion from <see cref="Units.Energy"/> to <see cref="Units.Torque"/>.
        /// </summary>
        /// <param name="m">The m.</param>
        /// <returns>The result of the conversion.</returns>
        /// <remarks></remarks>
        public static implicit operator Torque(Energy m)
        {
            return new Torque(m.Value);
        }
    }
}