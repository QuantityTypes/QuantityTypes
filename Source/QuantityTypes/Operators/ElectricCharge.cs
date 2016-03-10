// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ElectricVoltage.cs" company="QuantityTypes">
//   Copyright (c) 2014 QuantityTypes contributors
// </copyright>
// <summary>
//   Implements operators related to electric charge.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace QuantityTypes
{
    /// <summary>
    ///     Implements operators related to electric charge.
    /// </summary>
    public partial struct ElectricCharge
    {
        /// <summary>
        ///     Implements the operator /.
        /// </summary>
        /// <param name="x"> The x. </param>
        /// <param name="y"> The y. </param>
        /// <returns> The result of the operator. </returns>
        public static Time operator /(ElectricCharge x, ElectricCurrent y)
        {
            return new Time(x.Value / y.Value);
        }

        /// <summary>
        ///     Implements the operator /.
        /// </summary>
        /// <param name="x"> The x. </param>
        /// <param name="y"> The y. </param>
        /// <returns> The result of the operator. </returns>
        public static ElectricCurrent operator /(ElectricCharge x, Time y)
        {
            return new ElectricCurrent(x.Value / y.Value);
        }

        /// <summary>
        ///     Implements the operator /.
        /// </summary>
        /// <param name="x"> The x. </param>
        /// <param name="y"> The y. </param>
        /// <returns> The result of the operator. </returns>
        public static Capacitance operator /(ElectricCharge x, ElectricVoltage y)
        {
            return new Capacitance(x.Value / y.Value);
        }
    }
}