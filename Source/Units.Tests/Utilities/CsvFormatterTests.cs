namespace Units.Tests.Utilities
{
    using NUnit.Framework;

    [TestFixture]
    public class CsvFormatterTests
    {
        [Test]
        public void Format()
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
                var expected = CsvParserTests.TestString1.Replace("\r", string.Empty).Replace("\n", "\r\n");
                Assert.AreEqual(expected, output);
            }
        }
    }
}