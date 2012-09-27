namespace Units
{
    /// <summary>
    /// Provides operators related to volume.
    /// </summary>
    /// <remarks></remarks>
    public partial struct Volume
    {
        /// <summary>
        /// Implements the operator /.
        /// </summary>
        /// <param name="l1">The l1.</param>
        /// <param name="l2">The l2.</param>
        /// <returns>The result of the operator.</returns>
        /// <remarks></remarks>
        public static Length operator /(Volume l1, Area l2)
        {
            return new Length(l1.Value / l2.Value);
        }
    }
}