// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Temperature.cs" company="QuantityTypes">
//   Copyright (c) 2014 QuantityTypes contributors
// </copyright>
// <summary>
//   Implements operators related to temperature.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace QuantityTypes
{
    /// <summary>
    ///     Implements operators related to temperature.
    /// </summary>
    public partial struct Temperature
    {
        /// <summary>
        ///     Implements the operator +.
        /// </summary>
        /// <param name="x"> The x. </param>
        /// <param name="y"> The y. </param>
        /// <returns> The result of the operator. </returns>
        public static Temperature operator +(Temperature x, TemperatureDifference y)
        {
            return new Temperature(x.value + y.Value);
        }

        /// <summary>
        ///     Implements the operator -.
        /// </summary>
        /// <param name="x"> The x. </param>
        /// <param name="y"> The y. </param>
        /// <returns> The result of the operator. </returns>
        public static Temperature operator -(Temperature x, TemperatureDifference y)
        {
            return new Temperature(x.value - y.Value);
        }
        
        /// <summary>
        ///     Implements the operator -.
        /// </summary>
        /// <param name="x"> The x. </param>
        /// <param name="y"> The y. </param>
        /// <returns> The result of the operator. </returns>
        public static TemperatureDifference operator -(Temperature x, Temperature y)
        {
            return new TemperatureDifference(x.value - y.value);
        }
    }
}