// --------------------------------------------------------------------------------------------------------------------
// <copyright file="UnitAttribute.cs" company="Units.NET">
//   The MIT License (MIT)
//   
//   Copyright (c) 2012 Oystein Bjorke
//   
//   Permission is hereby granted, free of charge, to any person obtaining a
//   copy of this software and associated documentation files (the
//   "Software"), to deal in the Software without restriction, including
//   without limitation the rights to use, copy, modify, merge, publish,
//   distribute, sublicense, and/or sell copies of the Software, and to
//   permit persons to whom the Software is furnished to do so, subject to
//   the following conditions:
//   
//   The above copyright notice and this permission notice shall be included
//   in all copies or substantial portions of the Software.
//   
//   THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS
//   OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF
//   MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT.
//   IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY
//   CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER IN AN ACTION OF CONTRACT,
//   TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN CONNECTION WITH THE
//   SOFTWARE OR THE USE OR OTHER DEALINGS IN THE SOFTWARE.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------
namespace Units
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
        public bool IsDefaultDisplayUnit { get; private set; }

        /// <summary>
        ///     Gets the symbol of the unit.
        /// </summary>
        /// <value> The name. </value>
        public string Symbol { get; private set; }

        /// <summary>
        ///     When implemented in a derived class, gets a unique identifier for this <see cref="T:System.Attribute" />.
        /// </summary>
        /// <returns> An <see cref="T:System.Object" /> that is a unique identifier for the attribute. </returns>
        public override object TypeId
        {
            get
            {
                return new Guid(this.Symbol);
            }
        }
    }
}