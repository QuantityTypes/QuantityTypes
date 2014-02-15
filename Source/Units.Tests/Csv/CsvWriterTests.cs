﻿namespace Units.Tests
{
    using System.Globalization;

    using NUnit.Framework;

    using Units.Csv;

    [TestFixture]
    public class CsvWriterTests
    {
        [Test]
        public void WriteCsvLine()
        {
            using (var w = new MemoryStreamWriter())
            {
                var culture = new CultureInfo("nb-NO");
                w.WriteCsvLine(culture, "a b c", 3.14);
                w.WriteCsvLine(culture, "def\r\nghi", "3,14\r\n2.5");
                w.WriteCsvLine(culture, "a \"b\" c", "a ;b c");
                w.WriteCsvLine(culture, "\"abc\"", ";");
                w.WriteCsvLine(culture, string.Empty, string.Empty);
                w.WriteCsvLine(culture, (object)null, null);
                w.WriteCsvLine(culture, (object)null);
                w.WriteCsvLine(culture, true, false);
                var output = w.ToString();
                var expected = CsvParserTests.TestString1;
                Assert.AreEqual(expected, output);
            }
        }
    }
}