// --------------------------------------------------------------------------------------------------------------------
// <copyright file="TestObject.cs" company="QuantityTypes">
//   Copyright (c) 2014 QuantityTypes contributors
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace QuantityTypes.Tests
{
    using System.Runtime.Serialization;

    [DataContract]
    public class TestObject
    {
        public TestObject()
        {
            this.Quantities = new System.Collections.Generic.List<IQuantity>();
        }
        [DataMember]
        public Length Distance { get; set; }

        [DataMember]
        public Time? Time { get; set; }

        [DataMember]
        public System.Collections.Generic.List<IQuantity> Quantities { get; set; }
    }
}