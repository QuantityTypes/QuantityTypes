namespace Units.Tests
{
    using System;
    using System.ComponentModel;
    using System.Diagnostics.CodeAnalysis;
    using System.Globalization;
    using System.IO;
    using System.Runtime.Serialization;
    using System.Text;
    using System.Threading;
    using System.Xml.Serialization;

    using NUnit.Framework;

    using Units;

    [TestFixture]
    [SuppressMessage("StyleCop.CSharp.DocumentationRules", "SA1600:ElementsMustBeDocumented", Justification = "Reviewed. Suppression is OK here.")]
    // ReSharper disable InconsistentNaming
    public class LengthTests
    {
        [Test]
        public void Constructors()
        {
            Assert.AreEqual(2, new Length(2).Value);
            Assert.AreEqual(2, new Length("2m").Value);
        }

        [Test]
        public void Operators()
        {
            Assert.AreEqual(2 * Length.Metre, Length.Metre + Length.Metre);
            Assert.AreEqual(1 * Length.Metre, (2 * Length.Metre) - Length.Metre);
            Assert.AreEqual(1 * Length.Metre, (2 * Length.Metre) / 2);
            Assert.AreEqual(100 * Area.SquareMetre, (10 * Length.Metre) * (10 * Length.Metre));

            Length s = 100 * Length.Metre;
            Time t = 9.58 * Time.Second;
            Velocity v = s / t;
            Console.WriteLine(v.ToString("0.00"));
            Console.WriteLine(v.ToString("0.00 km/h"));

            Assert.AreEqual(10.44, v.ConvertTo(Velocity.MetrePerSecond), 0.01);
            Assert.AreEqual(37.58, v.ConvertTo(Velocity.KilometrePerHour), 0.01);
        }

        [Test]
        public void ConvertTo()
        {
            var l = 100 * Length.Metre;
            Assert.AreEqual(0.1, l.ConvertTo(Length.Kilometre));
        }

        [Test, Ignore]
        public void Converter()
        {
            var converter = TypeDescriptor.GetConverter(typeof(Length));
            Assert.IsTrue(converter.CanConvertFrom(typeof(string)));
            Assert.AreEqual(100 * Length.Metre, converter.ConvertFrom("100m"));
            Assert.AreEqual(0 * Length.Metre, converter.ConvertFrom(null));
        }

        [Test, Ignore]
        public void NullableLengthConverter()
        {
            var converter = TypeDescriptor.GetConverter(typeof(Length?));
            Assert.AreEqual(100 * Length.Metre, converter.ConvertFrom("100m"));
            Assert.AreEqual(null, converter.ConvertFrom(null));
            const string nullString = null;
            Assert.AreEqual(null, converter.ConvertFrom(nullString));
            Assert.AreEqual(null, converter.ConvertFrom(string.Empty));
        }

        [Test]
        public void SetFromString()
        {
            var l = default(Length);
            l.SetFromString("100 m", UnitProvider.Default);
            Assert.AreEqual(100 * Length.Metre, l);
        }

        [Test]
        [ExpectedException(typeof(FormatException))]
        public void Parse_InvalidUnit()
        {
            Length.Parse("100 Metre");
        }

        [Test]
        public void Parse_ValidStrings()
        {
            Assert.AreEqual(100 * Length.Metre, Length.Parse("100 m"));
            Assert.AreEqual(100 * Length.Metre, Length.Parse("0.1 km", CultureInfo.InvariantCulture));
            Assert.AreEqual(100 * Length.Metre, Length.Parse("1e2"));
            Assert.AreEqual(100 * Length.Metre, Length.Parse("1e2m"));
            Assert.AreEqual(1e-10 * Length.Metre, Length.Parse("1Å"));
            Assert.AreEqual(1 * Length.Metre, Length.Parse("m"));
            Assert.AreEqual(-60 * Length.Metre, Length.Parse(" -60 m"));
            Assert.AreEqual(100 * Length.Metre, Length.Parse("100 m "));
        }

        [Test]
        public void Parse_StringsWithWhitespace()
        {
            Assert.AreEqual(1100 * Length.Metre, Length.Parse("1 100 m"));
            Assert.AreEqual(-100 * Length.Metre, Length.Parse("- 100 m"));
        }

        [Test]
        public void Parse_UnitSymbolOnly()
        {
            Assert.AreEqual(1 * Length.Metre, Length.Parse("m"));
            Assert.AreEqual(1 * Length.Metre, Length.Parse(" m"));
            Assert.AreEqual(1 * Length.Metre, Length.Parse("m "));
        }

        [Test]
        public void ToString_ValidFormatStrings()
        {
            var l = 100 * Length.Metre;
            Assert.AreEqual("100 m", l.ToString());
            Assert.AreEqual("100.00 m", l.ToString("0.00", CultureInfo.InvariantCulture));
            Assert.AreEqual("0100 m", l.ToString("0000", CultureInfo.InvariantCulture));
            Assert.AreEqual("0.1 km", l.ToString("0.0 km", CultureInfo.InvariantCulture));
            Assert.AreEqual("0.1 km", l.ToString("0.0km", CultureInfo.InvariantCulture));
            Assert.AreEqual("100000 mm", l.ToString("0.# mm", CultureInfo.InvariantCulture));
            Assert.AreEqual("100000 mm", l.ToString("0. mm", CultureInfo.InvariantCulture));
        }

        [Test]
        public void ToString_NoUnit()
        {
            var l = 100 * Length.Metre;
            Assert.AreEqual("100", l.ToString("[]"));
            Assert.AreEqual("100.00", l.ToString("0.00 []", CultureInfo.InvariantCulture));
            Assert.AreEqual("100.00", l.ToString("0.00[]", CultureInfo.InvariantCulture));
        }

        readonly CultureInfo customCulture = new CultureInfo("nb-NO")
        {
            NumberFormat =
            {
                NumberGroupSeparator = ".",
                NumberGroupSizes = new[] { 3, 3, 3 },
                NumberDecimalDigits = 1
            }
        };

        [Test]
        public void ToString_CustomCulture()
        {
            var value = "10.000.000.000,0 m";
            Assert.AreEqual(value, (1e10 * Length.Metre).ToString("N", customCulture));
        }

        [Test]
        public void Parse_CustomCulture()
        {
            var value = "10.000.000.000,0 m";
            Assert.AreEqual(1e10 * Length.Metre, Length.Parse(value, customCulture));
        }

        [Test]
        public void ToString_ThousandSeparator_ValidFormatStrings()
        {
            var l = 1000 * Length.Kilometre;
            Assert.AreEqual("1 000 000 m", l.ToString("# ### ###"));
            Assert.AreEqual("1 000 km", l.ToString("# ### km"));
            var l2 = 1 * Length.Metre;
            // Assert.AreEqual("1", 1.ToString("# ### ###"));
            Assert.AreEqual("1 m", l2.ToString("# ### ###"));
        }

        [Test]
        [ExpectedException(typeof(FormatException))]
        public void ToString_InvalidFormatString()
        {
            var l = 100 * Length.Metre;
            Console.WriteLine(l.ToString("0 Metre"));
        }
        [Test]
        public void Compare()
        {
            var l1 = 100 * Length.Metre;
            var l2 = 200 * Length.Metre;
            var l3 = 100 * Length.Metre;
            Assert.IsTrue(l2 > l1);
            Assert.IsTrue(l1 < l2);
            Assert.IsTrue(l2 != l1);
            Assert.IsTrue(l3 == l1);
            Assert.AreEqual(1, l2.CompareTo(l1));
            Assert.AreEqual(-1, l1.CompareTo(l2));
            Assert.AreEqual(0, l1.CompareTo(l3));
        }

        [Test]
        public void XmlValue_RoundTrip_ValuesShouldBeEqual()
        {
            var l1 = 4.0 / 7 * Length.Metre;
            var l2 = new Length { XmlValue = l1.XmlValue };
            Assert.AreEqual(l1, l2);
        }

        [Test]
        public void Serialize_XmlSerializer()
        {
            Thread.CurrentThread.CurrentCulture = CultureInfo.InvariantCulture;
            var s = new XmlSerializer(typeof(Test));
            var t = new Test { Distance = 100.2 * Length.Metre };
            var ms = new MemoryStream();
            s.Serialize(ms, t);
            var xml = Encoding.UTF8.GetString(ms.ToArray());
            Assert.IsTrue(xml.Contains(@"<Distance>100.2 m</Distance>"));

            // Deserialize
            var ms2 = new MemoryStream(Encoding.UTF8.GetBytes(xml));
            var t2 = (Test)s.Deserialize(ms2);
            Assert.AreEqual(t2.Distance, t.Distance);
        }

        [Test]
        public void Serialize_DataContractSerializer()
        {
            // Thread.CurrentThread.CurrentCulture = CultureInfo.InvariantCulture;
            var s = new DataContractSerializer(typeof(Test));
            var t = new Test { Distance = 100.2 * Length.Metre };
            var ms = new MemoryStream();
            s.WriteObject(ms, t);
            var xml = Encoding.UTF8.GetString(ms.ToArray());
            Assert.IsTrue(xml.Contains(@"<a:XmlValue>100.2 m</a:XmlValue>"));

            // Deserialize
            var ms2 = new MemoryStream(Encoding.UTF8.GetBytes(xml));
            var t2 = (Test)s.ReadObject(ms2);
            Assert.AreEqual(t2.Distance, t.Distance);
        }

        [Test]
        public void StoppingDistance()
        {
            var speed = 100.0 * Velocity.KilometrePerHour;
            var reactionTime = 1.0 * Time.Second;
            var deceleration = 6.0 * Acceleration.MetrePerSecondSquared;

            var distance = (speed * reactionTime) + (speed * (speed / (2.0 * deceleration)));
            Assert.AreEqual(92, distance.Value, 1);
        }

        public class Test
        {
            public Length Distance { get; set; }
        }
    }
}