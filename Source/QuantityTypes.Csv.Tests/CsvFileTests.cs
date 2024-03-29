﻿// --------------------------------------------------------------------------------------------------------------------
// <copyright file="CsvFileTests.cs" company="QuantityTypes">
//   Copyright (c) 2014 QuantityTypes contributors
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace QuantityTypes.Csv.Tests
{
    using System.Collections.Generic;
    using System.Globalization;
    using System.IO;
    using System.Linq;
    using System.Reflection;
    using System.Text;

    using NUnit.Framework;

    using QuantityTypes.Csv;
    using QuantityTypes.Tests;

    [TestFixture]
    public class CsvFileTests
    {
        // Content of an invariant culture CSV file
        internal const string Test1Content = "Text,Number,Length [km],NullableLength [km]\r\nOne,-3,1,0.1\r\nTwo,17,42.195,";

        // Content of a culture-specific CSV file
        internal const string Test1ContentCultureSpecific = "Text;Number;Length [km];NullableLength [km]\r\nOne;-3;1;0,1\r\nTwo;17;42,195;";

        // Content of an invariant culture CSV file
        internal const string Test2Content = "Length [km]\r\n0\r\n0.1";

        // Content of a culture-specific CSV file
        internal const string Test2ContentCultureSpecific = "Length [km]\r\n0\r\n0,1";

        internal static List<CsvFileTests.TestObject> TestList = new List<TestObject>
                            {
                                new CsvFileTests.TestObject { Text = "One", Number = -3, Length = 1 * Length.Kilometre, NullableLength=100*Length.Metre },
                                new CsvFileTests.TestObject { Text = "Two", Number = 17, Length = 42.195 * Length.Kilometre }
                            };
        [Test]
        public void LoadFromString_Test1()
        {
            var input = Test1Content;
            var inputStream = new MemoryStream(Encoding.UTF8.GetBytes(input));
            var file = CsvFile.Load(inputStream, CultureInfo.InvariantCulture);
            ValidateTest1(file);
            Assert.AreEqual(typeof(double), file.Columns[2].Type);

            var outputStream = new MemoryStream();
            file.Save(outputStream, CultureInfo.InvariantCulture);
            QAssert.AreEqual(input, Encoding.UTF8.GetString(outputStream.ToArray()));
        }

        [Test]
        public void LoadFromString_Test2()
        {
            var c = CultureInfos.Norwegian;
            var input = Test1ContentCultureSpecific;
            var inputStream = new MemoryStream(Encoding.UTF8.GetBytes(input));
            var file = CsvFile.Load(inputStream, c);
            ValidateTest1(file);
            Assert.AreEqual(typeof(double), file.Columns[2].Type);

            var outputStream = new MemoryStream();
            file.Save(outputStream, c);
            QAssert.AreEqual(input, Encoding.UTF8.GetString(outputStream.ToArray()));
        }

        [Test]
        public void LoadFromList_Test1()
        {
            var up = new UnitProvider(typeof(UnitProvider).GetTypeInfo().Assembly, CultureInfo.InvariantCulture);
            up.TrySetDisplayUnit<Length>("km");
            var file = CsvFile.Load(TestList, up);
            ValidateTest1(file);
            Assert.AreEqual(typeof(Length), file.Columns[2].Type);

            var outputStream = new MemoryStream();
            file.Save(outputStream, null, up);
            QAssert.AreEqual(Test1Content, Encoding.UTF8.GetString(outputStream.ToArray()));
        }

        //[Test]
        //public void PropertyDescriptor()
        //{
        //    var properties = TypeDescriptor.GetProperties(typeof(CsvFile.CsvRow));
        //    Assert.AreEqual(0, properties.Count);
        //}

        private static void ValidateTest1(CsvFile file)
        {
            Assert.AreEqual(4, file.Columns.Count);
            Assert.AreEqual(typeof(string), file.Columns[0].Type);
            Assert.AreEqual(typeof(int), file.Columns[1].Type);
            Assert.AreEqual("km", file.Columns[2].Unit);
            Assert.AreEqual(2, file.Rows.Count);
        }

        private static void ValidateTest1Properties(CsvFile file)
        {
            var type = file.Rows[0].GetType();
            var properties = type.GetTypeInfo().DeclaredProperties.ToArray(); 
            Assert.AreEqual(4, properties.Count());
            Assert.AreEqual("Text", properties[0].Name);
            Assert.AreEqual(typeof(int), properties[1].PropertyType);
            Assert.AreEqual(17, properties[1].GetValue(file.Rows[1]));
        }

        internal class TestObject
        {
            [CsvColumn(2)]
            public Length Length { get; set; }

            [CsvColumn(3)]
            public Length? NullableLength { get; set; }

            [CsvColumn(1)]
            public int Number { get; set; }

            [CsvColumn(0)]
            public string Text { get; set; }
        }
    }
}