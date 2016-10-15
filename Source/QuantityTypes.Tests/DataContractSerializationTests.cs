using System;

namespace QuantityTypes.Tests
{
    using System.IO;
    using System.Runtime.Serialization;
    using System.Text;
    using NUnit.Framework;

    [TestFixture]
    public class DataContractSerializationTests
    {
        const string ExpectedXml = "<DataContractSerializationTests.Test xmlns=\"http://schemas.datacontract.org/2004/07/QuantityTypes.Tests\" xmlns:i=\"http://www.w3.org/2001/XMLSchema-instance\"><Distance>100.2 m</Distance></DataContractSerializationTests.Test>";

        [Test]
        public void Roundtrip()
        {
            var t = new Test();
            var xml = Serialize(t);
            File.WriteAllText("D:\\temp.txt", xml);
            Assert.AreEqual(ExpectedXml, xml);

            // Deserialize
            var t2 = Deserialize<Test>(xml);
            Assert.AreEqual(t2.Distance, t.Distance);
        }

        private static string Serialize<T>(T t)
        {
            var s = new DataContractSerializer(typeof(T));
            var ms = new MemoryStream();
            s.WriteObject(ms, t);
            return Encoding.UTF8.GetString(ms.ToArray());
        }

        private static T Deserialize<T>(string xml)
        {
            var s = new DataContractSerializer(typeof(T));
            var ms = new MemoryStream(Encoding.UTF8.GetBytes(xml));
            return (T)s.ReadObject(ms);
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