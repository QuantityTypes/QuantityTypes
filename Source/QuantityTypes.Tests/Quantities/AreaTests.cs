using NUnit.Framework;

namespace QuantityTypes.Tests
{
    [TestFixture]
    public class AreaTests : Tests
    {
        [Test]
        public void Units()
        {
            AssertAreEqual(Length.Centimetre * Length.Centimetre, Area.SquareCentimetre);
            AssertAreEqual(Length.Millimetre * Length.Millimetre, Area.SquareMillimetre);
        }
    }
}