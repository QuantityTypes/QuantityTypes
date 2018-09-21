// --------------------------------------------------------------------------------------------------------------------
// <copyright file="CsvParserTests.cs" company="QuantityTypes">
//   Copyright (c) 2014 QuantityTypes contributors
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace QuantityTypes.Csv.Tests
{
    using System.Linq;

    using NUnit.Framework;

    using QuantityTypes.Csv;

    [TestFixture]
    public class CsvParserTests
    {
        public static string TestString1 = "a b c;3,14\r\n\"def\r\nghi\";\"3,14\r\n2.5\"\r\n\"a \"\"b\"\" c\";\"a ;b c\"\r\n\"\"\"abc\"\"\";\";\"\r\n;\r\n;\r\n\r\nTrue;False\r\n";

        [Test]
        public void Parse()
        {
            var records = CsvParser.Parse(TestString1, CultureInfos.Norwegian).ToList();
            Assert.AreEqual(8, records.Count);
            Assert.AreEqual("a b c", records[0][0]);
            Assert.AreEqual("3,14", records[0][1]);
            Assert.AreEqual("def\r\nghi", records[1][0]);
            Assert.AreEqual("3,14\r\n2.5", records[1][1]);
            Assert.AreEqual("a \"b\" c", records[2][0]);
            Assert.AreEqual("a ;b c", records[2][1]);
            Assert.AreEqual("\"abc\"", records[3][0]);
            Assert.AreEqual(";", records[3][1]);
            Assert.AreEqual("", records[4][0]);
            Assert.AreEqual("", records[4][1]);
            Assert.AreEqual("", records[5][0]);
            Assert.AreEqual("", records[5][1]);
            Assert.AreEqual("", records[6][0]);
            Assert.AreEqual("True", records[7][0]);
            Assert.AreEqual("False", records[7][1]);
        }
    }
}