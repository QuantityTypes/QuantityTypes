namespace QuantityTypes.Tests
{
    using System.IO;
    using System.Text;
    using Newtonsoft.Json;
    using NUnit.Framework;

    public class QuantityJsonConverterTests
    {
        [Test]
        public void WriteJson()
        {
            this.WriteJson(null, "null");
            this.WriteJson(19 * Length.Metre, "\"19 m\"");
            this.WriteJson(-1000 * Time.Millisecond, "\"-1 s\"");
        }

        private void WriteJson(object value, string expected)
        {
            var converter = new QuantityJsonConverter(UnitProvider.Default);
            var stream = new MemoryStream();
            var writer = new StreamWriter(stream);

            using (var jsonWriter = new JsonTextWriter(writer))
            {
                var serializer = new JsonSerializer();
                converter.WriteJson(jsonWriter, value, serializer);
            }

            var json = Encoding.UTF8.GetString(stream.ToArray());
            Assert.AreEqual(expected, json);
        }

    }
}