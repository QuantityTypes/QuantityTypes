// --------------------------------------------------------------------------------------------------------------------
// <copyright file="UnitAttribute.cs" company="QuantityTypes">
//   Copyright (c) 2014 QuantityTypes contributors
// </copyright>
// <summary>
//   Specifies the unit name (e.g. "m/s^2").
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace QuantityTypes
{
    using System;

    /// <summary>
    ///     Specifies the unit name (e.g. "m/s^2").
    /// </summary>
    /// <remarks>
    ///     The unit name is used when formatting and parsing strings.
    /// </remarks>
    [AttributeUsage(AttributeTargets.Property, AllowMultiple = true)]
    public class UnitAttribute : Attribute
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="UnitAttribute"/> class.
        /// </summary>
        /// <param name="symbol">
        /// The unit symbol. 
        /// </param>
        /// <param name="isDefaultDisplayUnit">
        /// if set to <c>true</c>, the unit is the default display unit. 
        /// </param>
        public UnitAttribute(string symbol, bool isDefaultDisplayUnit = false)
        {
            this.Symbol = symbol;
            this.IsDefaultDisplayUnit = isDefaultDisplayUnit;
        }

        /// <summary>
        ///     Gets a value indicating whether this unit is the default display unit.
        /// </summary>
        /// <value> <c>true</c> if this instance is default display unit; otherwise, <c>false</c> . </value>
        public bool IsDefaultDisplayUnit { get; }

        /// <summary>
        ///     Gets the symbol of the unit.
        /// </summary>
        /// <value> The name. </value>
        public string Symbol { get; }
    }
}