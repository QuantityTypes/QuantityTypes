using NUnit.Framework;

namespace QuantityTypes.Tests
{
    [TestFixture]
    public class SecondMomentOfAreaTests : Tests
    {
        [Test]
        public void Units()
        {
            AssertAreEqual(Length.Metre * Length.Metre * Length.Metre * Length.Metre, SecondMomentOfArea.MetreToTheFourth);
            AssertAreEqual(Length.Centimetre * Length.Centimetre * Length.Centimetre * Length.Centimetre, SecondMomentOfArea.CentimetreToTheFourth);
        }
    }
}