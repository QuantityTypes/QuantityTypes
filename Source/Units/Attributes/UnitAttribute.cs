// --------------------------------------------------------------------------------------------------------------------
// <copyright file="UnitAttribute.cs" company="Units.NET">
//   Copyright (c) 2012 Oystein Bjorke
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace Units
{
    using System;

    /// <summary>
    /// Specifies the unit name (e.g. "m/s^2").
    /// </summary>
    /// <remarks>
    /// The unit name is used when formatting and parsing strings.
    /// </remarks>
    [AttributeUsage(AttributeTargets.Field, AllowMultiple = true)]
    public class UnitAttribute : Attribute
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="UnitAttribute"/> class.
        /// </summary>
        /// <param name="name">
        /// The name.
        /// </param>
        /// <param name="isDefaultDisplayUnit">
        /// if set to <c>true</c> [is default display unit].
        /// </param>
        public UnitAttribute(string name, bool isDefaultDisplayUnit = false)
        {
            this.Name = name;
            this.IsDefaultDisplayUnit = isDefaultDisplayUnit;
        }

        /// <summary>
        /// Gets or sets a value indicating whether this unit is the default display unit.
        /// </summary>
        /// <value> <c>true</c> if this instance is default display unit; otherwise, <c>false</c> . </value>
        public bool IsDefaultDisplayUnit { get; private set; }

        /// <summary>
        /// Gets or sets the name of the unit.
        /// </summary>
        /// <value> The name. </value>
        public string Name { get; private set; }

        /// <summary>
        /// When implemented in a derived class, gets a unique identifier for this <see cref="T:System.Attribute" />.
        /// </summary>
        /// <returns> An <see cref="T:System.Object" /> that is a unique identifier for the attribute. </returns>
        public override object TypeId
        {
            get
            {
                return new Guid(this.Name);
            }
        }

    }
}