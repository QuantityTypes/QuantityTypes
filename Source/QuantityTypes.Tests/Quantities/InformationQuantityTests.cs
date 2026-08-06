namespace QuantityTypes.Tests
{
    using NUnit.Framework;

    public class InformationQuantityTests : Tests
    {
        [Test]
        public void UnitsAndParsing()
        {
            AssertAreEqual(8 * InformationQuantity.Bit, InformationQuantity.Byte);
            AssertAreEqual(1024 * InformationQuantity.Kibibyte, InformationQuantity.Mebibyte);
            AssertAreEqual(InformationQuantity.Mebibyte, InformationQuantity.Parse("1 MiB"));
        }
    }
}
