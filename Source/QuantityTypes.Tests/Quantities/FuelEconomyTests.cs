namespace QuantityTypes.Tests
{
    using NUnit.Framework;

    public class FuelEconomyTests : Tests
    {
        [Test]
        public void Parse_AdditionalUnits()
        {
            AssertAreEqual(FuelEconomy.KilometrePerLitre, FuelEconomy.Parse("1 km/L"));
            AssertAreEqual(FuelEconomy.MilesPerImperialGallon, FuelEconomy.Parse("1 mpg(imp)"));
        }
    }
}
