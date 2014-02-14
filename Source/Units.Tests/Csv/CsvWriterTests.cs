namespace Units.Tests
{
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
                w.WriteCsvLine("a b c", 3.14);
                w.WriteCsvLine("def\r\nghi", "3,14\r\n2.5");
                w.WriteCsvLine("a \"b\" c", "a ;b c");
                w.WriteCsvLine("\"abc\"", ";");
                w.WriteCsvLine(string.Empty, string.Empty);
                w.WriteCsvLine((object)null, null);
                w.WriteCsvLine((object)null);
                w.WriteCsvLine(true, false);
                var output = w.ToString();
                var expected = CsvParserTests.TestString1;
                Assert.AreEqual(expected, output);
            }
        }
    }
}