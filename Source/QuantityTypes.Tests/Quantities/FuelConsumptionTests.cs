namespace QuantityTypes.Tests
{
    using NUnit.Framework;

    public class FuelConsumptionTests : Tests
    {
        [Test]
        public void Parse_LitrePer100KilometreUppercaseAlias()
        {
            AssertAreEqual(FuelConsumption.LitrePer100Kilometre, FuelConsumption.Parse("1 L/100km"));
        }
    }
}
