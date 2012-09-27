namespace Units
{
    using System;

    /// <summary>
    /// Specifies the unit name.
    /// </summary>
    /// <remarks></remarks>
    [AttributeUsage(AttributeTargets.Field, AllowMultiple = true)]
    public class UnitAttribute : Attribute
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="UnitAttribute"/> class.
        /// </summary>
        /// <param name="name">The name.</param>
        /// <param name="isDefaultDisplayUnit">if set to <c>true</c> [is default display unit].</param>
        /// <remarks></remarks>
        public UnitAttribute(string name, bool isDefaultDisplayUnit = false)
        {
            this.Name = name;
            this.IsDefaultDisplayUnit = isDefaultDisplayUnit; 
        }

        /// <summary>
        /// Gets or sets the name of the unit.
        /// </summary>
        /// <value>The name.</value>
        /// <remarks></remarks>
        public string Name { get; private set; }

        /// <summary>
        /// Gets or sets a value indicating whether this unit is the default display unit.
        /// </summary>
        /// <value><c>true</c> if this instance is default display unit; otherwise, <c>false</c>.</value>
        /// <remarks></remarks>
        public bool IsDefaultDisplayUnit { get; private set; }

        /// <summary>
        /// When implemented in a derived class, gets a unique identifier for this <see cref="T:System.Attribute"/>.
        /// </summary>
        /// <returns>An <see cref="T:System.Object"/> that is a unique identifier for the attribute.</returns>
        /// <remarks></remarks>
        public override object TypeId
        {
            get
            {
                return new Guid(this.Name);
            }
        }
    }
}