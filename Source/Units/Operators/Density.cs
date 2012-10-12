// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Density.cs" company="Units.NET">
//   Copyright (c) 2012 Oystein Bjorke
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

    namespace Units
{
    /// <summary>
    ///   Provides operators related to volume.
    /// </summary>
    public partial struct Density
    {
        #region Public Methods and Operators

        /// <summary>
        ///   Implements the operator *.
        /// </summary>
        /// <param name="x"> The x. </param>
        /// <param name="y"> The y. </param>
        /// <returns> The result of the operator. </returns>
        public static Mass operator *(Density x, Volume y)
        {
            return new Mass(x.Value * y.Value);
        }

        #endregion
    }
}