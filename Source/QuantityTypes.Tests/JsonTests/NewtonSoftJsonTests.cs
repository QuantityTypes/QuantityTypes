// --------------------------------------------------------------------------------------------------------------------
// <copyright file="NewtonSoftJsonTests.cs" company="QuantityTypes">
//   Copyright (c) 2014 QuantityTypes contributors
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace QuantityTypes.Tests
{
    using NUnit.Framework;

    using Newtonsoft.Json;

    [TestFixture]
    public class NewtonSoftJsonTests
    {
        [Test]
        public void Serialize_WithConverter()
        {
            var converter = new QuantityJsonConverter(UnitProvider.Default);
            var obj = new TestObject { Distance = 1.23 * Length.Metre, Time = null };
            var json = JsonConvert.SerializeObject(obj, converter);
            Assert.AreEqual("{\"Distance\":\"1.23 m\",\"Time\":null,\"Quantities\":[]}", json);
        }

        [Test]
        public void Deserialize_WithConverter()
        {
            var converter = new QuantityJsonConverter(UnitProvider.Default);
            var json = "{\"Distance\":\"1.23 m\",\"Time\":null,\"Quantities\":[]}";
            var obj = JsonConvert.DeserializeObject<TestObject>(json, converter);
            Assert.AreEqual(1.23 * Length.Metre, obj.Distance);
            Assert.AreEqual(null, obj.Time);
        }

        [Test]
        public void Serialize_WithoutConverter()
        {
            var obj = new TestObject { Distance = 1.23 * Length.Metre, Time = null };
            var json = JsonConvert.SerializeObject(obj);
            Assert.AreEqual("{\"Distance\":{\"Value\":1.23},\"Time\":null,\"Quantities\":[]}", json);
        }

        // [Test, Ignore("Deserializing without converter is not supported")]
        public void Deserialize_WithoutConverter()
        {
            var json = "{\"Distance\":{\"Value\":1.23},\"Time\":null}";
            var obj = JsonConvert.DeserializeObject<TestObject>(json);
            Assert.AreEqual(1.23 * Length.Metre, obj.Distance);
            Assert.AreEqual(null, obj.Time);
        }
    }
}