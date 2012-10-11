﻿// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Temperature.cs" company="Units.NET">
//   Copyright (c) 2012 Oystein Bjorke
// </copyright>
// <summary>
//   Provides operators related to temperature.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Units
{
    /// <summary>
    /// Provides operators related to temperature.
    /// </summary>
    public partial struct Temperature
    {
        /// <summary>
        /// Implements the operator +.
        /// </summary>
        /// <param name="x"> The x. </param>
        /// <param name="y"> The y. </param>
        /// <returns> The result of the operator. </returns>
        public static Temperature operator +(Temperature x, TemperatureDifference y)
        {
            return new Temperature(x.value + y.Value);
        }

        /// <summary>
        /// Implements the operator -.
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