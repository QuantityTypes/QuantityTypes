// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Mass.cs" company="Units.NET">
//   Copyright (c) 2012 Oystein Bjorke
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace Units
{
    /// <summary>
    ///   Provides operators related to mass.
    /// </summary>
    public partial struct Mass
    {
        #region Public Methods and Operators

        /// <summary>
        ///   Implements the operator /.
        /// </summary>
        /// <param name="m"> The mass. </param>
        /// <param name="v"> The volume. </param>
        /// <returns> The result of the operator. </returns>
        public static Density operator /(Mass m, Volume v)
        {
            return new Density(m.Value / v.Value);
        }

        #endregion
    }
}