// --------------------------------------------------------------------------------------------------------------------
// <copyright file="NewtonSoftJsonTests.cs" company="QuantityTypes">
//   Copyright (c) 2014 QuantityTypes contributors
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace QuantityTypes.Tests
{
    using System.Text.Json;

    using NUnit.Framework;

    [TestFixture]
    public class SystemTextJsonTests
    {
        [Test]
        public void Serialize_WithBasicConverter()
        {
            var options = new JsonSerializerOptions();
            options.Converters.Add(new QuantityJsonConverter<Length>(UnitProvider.Default));

            var obj = new TestObject { Distance = 1.23 * Length.Metre, Time = null };
            var json = JsonSerializer.Serialize(obj, options);

            Assert.AreEqual("{\"Distance\":\"1.23 m\",\"Time\":null,\"Quantities\":[]}", json);
        }

        [Test]
        public void Deserialize_WithBasicConverter()
        {
            var options = new JsonSerializerOptions();
            options.Converters.Add(new QuantityJsonConverter<Length>(UnitProvider.Default));

            var json = "{\"Distance\":\"1.23 m\",\"Time\":null,\"Quantities\":[]}";
            var obj = JsonSerializer.Deserialize<TestObject>(json, options);

            Assert.AreEqual(1.23 * Length.Metre, obj.Distance);
            Assert.AreEqual(null, obj.Time);
        }

        [Test]
        public void Serialize_WithFactoryConverter()
        {
            var options = new JsonSerializerOptions();
            options.Converters.Add(new QuantityJsonConverterFactory(UnitProvider.Default));

            var obj = new TestObject { Distance = 1.23 * Length.Metre, Time = null };
            var json = JsonSerializer.Serialize(obj, options);

            Assert.AreEqual("{\"Distance\":\"1.23 m\",\"Time\":null,\"Quantities\":[]}", json);
        }

        [Test]
        public void Deserialize_WithFactoryConverter()
        {
            var options = new JsonSerializerOptions();
            options.Converters.Add(new QuantityJsonConverterFactory(UnitProvider.Default));

            var json = "{\"Distance\":\"1.23 m\",\"Time\":null,\"Quantities\":[]}";
            var obj = JsonSerializer.Deserialize<TestObject>(json, options);

            Assert.AreEqual(1.23 * Length.Metre, obj.Distance);
            Assert.AreEqual(null, obj.Time);
        }

        [Test]
        public void Serialize_WithoutConverter()
        {
            var obj = new TestObject { Distance = 1.23 * Length.Metre, Time = null };
            var json = JsonSerializer.Serialize(obj);

            Assert.AreEqual("{\"Distance\":{\"Value\":1.23},\"Time\":null,\"Quantities\":[]}", json);
        }

        [Test]
        public void Deserialize_WithoutConverter_DoesNotWork()
        {
            var json = "{\"Distance\":{\"Value\":1.23},\"Time\":null}";
            var obj = JsonSerializer.Deserialize<TestObject>(json);

            Assert.AreNotEqual(1.23 * Length.Metre, obj.Distance);
            Assert.AreEqual(null, obj.Time);
        }
    }
}
