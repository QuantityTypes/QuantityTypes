namespace QuantityTypes.Tests
{
    using System.Globalization;
    using System.IO;
    using System.Text;
    using System.Xml.Serialization;
    using NUnit.Framework;

    [TestFixture]
    public class XmlSerializationTests
    {
        const string ExpectedXml = "<?xml version=\"1.0\"?>\r\n<Test xmlns:xsd=\"http://www.w3.org/2001/XMLSchema\" xmlns:xsi=\"http://www.w3.org/2001/XMLSchema-instance\">\r\n  <Distance>100.2 m</Distance>\r\n</Test>";

        [Test]
        public void Serialize_XmlSerializer()
        {
            var t = new Test();
            var xml = Serialize(t);
            Assert.AreEqual(ExpectedXml, xml);

            // Deserialize
            var t2 = Deserialize<Test>(xml);
            Assert.AreEqual(t2.Distance, t.Distance);
        }

        [Test]
        public void Serialize_XmlSerializer_CultureWithCommaAsNumericSeparator()
        {
            using (CurrentCulture.TemporaryChangeTo(CultureInfos.Norwegian))
            {
                var t = new Test();
                var xml = Serialize(t);
                Assert.AreEqual(ExpectedXml, xml);

                // Deserialize
                var t2 = Deserialize<Test>(xml);
                Assert.AreEqual(t2.Distance, t.Distance);
            }
        }

        [Test]
        public void Deserialize_XmlSerializer()
        {
            var l = Deserialize<Length>("<Length>100.2 m</Length>");
            Assert.AreEqual(100.2 * Length.Metre, l);
        }

        [Test]
        public void Temperature_Roundtrip()
        {
            var t1 = 37.5 * Temperature.DegreeCelsius;
            var xml = Serialize(t1);
            Assert.IsTrue(xml.Contains(@"<Temperature>37.5 °C</Temperature>"));

            // Deserialize
            var t2 = Deserialize<Temperature>(xml);
            Assert.AreEqual(t1, t2);
        }

        private static string Serialize<T>(T t)
        {
            var s = new XmlSerializer(typeof(T));
            var ms = new MemoryStream();
            s.Serialize(ms, t);
            return Encoding.UTF8.GetString(ms.ToArray());
        }

        private static T Deserialize<T>(string xml)
        {
            var s = new XmlSerializer(typeof(T));
            var ms = new MemoryStream(Encoding.UTF8.GetBytes(xml));
            return (T)s.Deserialize(ms);
        }


        public class Test
        {
            public Test()
            {
                this.Distance = 100.2 * Length.Metre;
            }

            public Length Distance { get; set; }
        }
    }
}