// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Force.cs" company="QuantityTypes">
//   Copyright (c) 2014 QuantityTypes contributors
// </copyright>
// <summary>
//   Implements operators related to force.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace QuantityTypes
{
    /// <summary>
    ///     Implements operators related to force.
    /// </summary>
    public partial struct Force
    {
        /// <summary>
        ///     Implements the operator /.
        /// </summary>
        /// <param name="x"> The x. </param>
        /// <param name="y"> The y. </param>
        /// <returns> The result of the operator. </returns>
        public static Pressure operator /(Force x, Area y)
        {
            return new Pressure(x.Value / y.Value);
        }

        /// <summary>
        ///     Implements the operator *.
        /// </summary>
        /// <param name="f"> The f. </param>
        /// <param name="l"> The l. </param>
        /// <returns> The result of the operator. </returns>
        public static Torque operator *(Force f, Length l)
        {
            return new Torque(f.Value * l.Value);
        }
    }
}