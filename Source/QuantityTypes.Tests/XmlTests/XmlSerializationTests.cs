namespace QuantityTypes.Tests
{
    using System.IO;
    using System.Text;
    using System.Xml.Serialization;
    using NUnit.Framework;

    [TestFixture]
    public class XmlSerializationTests
    {
        const string ExpectedXml = "<?xml version=\"1.0\"?>\r\n<Test xmlns:xsd=\"http://www.w3.org/2001/XMLSchema\" xmlns:xsi=\"http://www.w3.org/2001/XMLSchema-instance\">\r\n  <Distance>100.2</Distance>\r\n</Test>";

        [Test]
        public void Serialize()
        {
            var t = new Test();
            var xml = Serialize(t);
            Assert.AreEqual(ExpectedXml, xml);
        }

        [Test]
        public void Deserialize()
        {
            var t2 = Deserialize<Test>(ExpectedXml);
            Assert.AreEqual(100.2 * Length.Metre, t2.Distance);
        }

        [Test]
        public void Serialize_CultureWithCommaAsNumericSeparator()
        {
            using (CurrentCulture.TemporaryChangeTo(CultureInfos.Norwegian))
            {
                var t = new Test();
                var xml = Serialize(t);
                Assert.AreEqual(ExpectedXml, xml);

                var t2 = Deserialize<Test>(xml);
                Assert.AreEqual(t2.Distance, t.Distance);
            }
        }

        [Test]
        public void Serialize_WithoutUnitProvider()
        {
            using (DefaultUnitProvider.TemporaryChangeTo(null))
            {
                var t = new Test();
                var xml = Serialize(t);
                Assert.AreEqual(ExpectedXml, xml);

                var t2 = Deserialize<Test>(xml);
                Assert.AreEqual(t2.Distance, t.Distance);
            }
        }

        [Test]
        public void Length_Roundtrip()
        {
            var x1 = 5d / 7 * Length.Metre;
            var x2 = Deserialize<Length>(Serialize(x1));
            Assert.AreEqual(x1, x2);
        }

        [Test]
        public void Length_Deserialize_WithUnit()
        {
            var l = Deserialize<Length>("<Length>100.2 m</Length>");
            Assert.AreEqual(100.2 * Length.Metre, l);
        }

        [Test]
        public void Temperature_Serialize()
        {
            var xml = Serialize(37.5 * Temperature.DegreeCelsius);
            Assert.AreEqual("<?xml version=\"1.0\"?>\r\n<Temperature>310.65</Temperature>", xml);
        }

        [Test]
        public void Temperature_Deserialize()
        {
            var t1 = Deserialize<Temperature>(@"<Temperature>310.65</Temperature>");
            Assert.AreEqual(37.5 * Temperature.DegreeCelsius, t1);
        }

        [Test]
        public void Temperature_Deserialize_WithUnit()
        {
            var t2 = Deserialize<Temperature>(@"<Temperature>37.5 °C</Temperature>");
            Assert.AreEqual(37.5 * Temperature.DegreeCelsius, t2);
        }

        [Test]
        public void Temperature_Roundtrip()
        {
            var t1 = 37.5 * Temperature.DegreeCelsius;
            var t2 = Deserialize<Temperature>(Serialize(t1));
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