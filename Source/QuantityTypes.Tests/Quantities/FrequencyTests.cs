namespace QuantityTypes.Tests
{
    using NUnit.Framework;

    public class FrequencyTests : Tests
    {
        [Test]
        public void TerahertzUnit()
        {
            AssertAreEqual(1000 * Frequency.Gigahertz, Frequency.Terahertz);
        }
    }
}
