namespace QuantityTypes.Tests
{
    using System.Collections.Generic;
    using System.Globalization;
    using System.IO;
    using System.Linq;
    using System.Text;

    using NUnit.Framework;

    using QuantityTypes.Csv;

    [TestFixture]
    public class CsvTests
    {
        [Test]
        public void Load_Test1_ToList()
        {
            var input = CsvFileTests.Test1Content;
            var inputStream = new MemoryStream(Encoding.UTF8.GetBytes(input));
            var items = Csv.Load<CsvFileTests.TestObject>(inputStream, CultureInfo.InvariantCulture).ToList();
            Assert.AreEqual(2, items.Count);
            Assert.AreEqual("Two", items[1].Text);
            Assert.AreEqual(-3, items[0].Number);
            Assert.AreEqual(42.195 * Length.Kilometre, items[1].Length);
        }

        [Test]
        public void SaveFromList_Test1()
        {
            var old = UnitProvider.Default.GetDisplayUnit(typeof(Length));
            UnitProvider.Default.TrySetDisplayUnit<Length>("km");
            var items = CsvFileTests.TestList;

            var outputStream = new MemoryStream();
            Csv.Save(items, outputStream);
            Assert.AreEqual(CsvFileTests.Test1Content, Encoding.UTF8.GetString(outputStream.ToArray()));

            var outputStream2 = new MemoryStream();
            Csv.Save(items, outputStream2, new CultureInfo("no"));
            Assert.AreEqual(CsvFileTests.Test1ContentCultureSpecific, Encoding.UTF8.GetString(outputStream2.ToArray()));

            UnitProvider.Default.TrySetDisplayUnit<Length>(old);
        }

        [Test]
        public void LoadQuantities_Test2_ToList()
        {
            var input = CsvFileTests.Test2Content;
            var inputStream = new MemoryStream(Encoding.UTF8.GetBytes(input));
            var items = Csv.LoadQuantities<Length>(inputStream, CultureInfo.InvariantCulture).ToList();
            Assert.AreEqual(2, items.Count);
            Assert.AreEqual(0, items[0].Value);
            Assert.AreEqual(100, items[1].Value);
        }

        [Test]
        public void SaveQuantities_FromList_Test2()
        {
            var old = UnitProvider.Default.GetDisplayUnit(typeof(Length));
            UnitProvider.Default.TrySetDisplayUnit<Length>("km");
            var items = new List<Length> { 0 * Length.Metre, 100 * Length.Metre };

            var outputStream = new MemoryStream();
            Csv.SaveQuantities(items, outputStream);
            Assert.AreEqual(CsvFileTests.Test2Content, Encoding.UTF8.GetString(outputStream.ToArray()));

            var outputStream2 = new MemoryStream();
            Csv.SaveQuantities(items, outputStream2, new CultureInfo("no"));
            Assert.AreEqual(CsvFileTests.Test2ContentCultureSpecific, Encoding.UTF8.GetString(outputStream2.ToArray()));

            UnitProvider.Default.TrySetDisplayUnit<Length>(old);
        }
    }
}