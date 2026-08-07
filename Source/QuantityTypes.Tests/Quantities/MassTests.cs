namespace QuantityTypes.Tests
{
    using NUnit.Framework;

    public class MassTests : Tests
    {
        [Test]
        public void TonVariants()
        {
            AssertAreEqual(Mass.ShortTon, 2000 * Mass.Pound);
            AssertAreEqual(Mass.LongTon, Mass.Ton);
        }
    }
}
