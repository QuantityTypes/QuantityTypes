// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ElectricVoltage.cs" company="QuantityTypes">
//   Copyright (c) 2014 QuantityTypes contributors
// </copyright>
// <summary>
//   Implements operators related to electric voltage.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace QuantityTypes
{
    /// <summary>
    ///     Implements operators related to electric voltage.
    /// </summary>
    public partial struct ElectricVoltage
    {
        /// <summary>
        ///     Implements the operator /.
        /// </summary>
        /// <param name="x"> The x. </param>
        /// <param name="y"> The y. </param>
        /// <returns> The result of the operator. </returns>
        public static ElectricResistance operator /(ElectricVoltage x, ElectricCurrent y)
        {
            return new ElectricResistance(x.Value / y.Value);
        }

        /// <summary>
        ///     Implements the operator /.
        /// </summary>
        /// <param name="x"> The x. </param>
        /// <param name="y"> The y. </param>
        /// <returns> The result of the operator. </returns>
        public static ElectricCurrent operator /(ElectricVoltage x, ElectricResistance y)
        {
            return new ElectricCurrent(x.Value / y.Value);
        }

        /// <summary>
        ///     Implements the operator *.
        /// </summary>
        /// <param name="x"> The x. </param>
        /// <param name="y"> The y. </param>
        /// <returns> The result of the operator. </returns>
        public static Power operator *(ElectricVoltage x, ElectricCurrent y)
        {
            return new Power(x.Value * y.Value);
        }
    }
}