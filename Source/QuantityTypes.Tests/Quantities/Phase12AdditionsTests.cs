namespace QuantityTypes.Tests
{
    using NUnit.Framework;

    public class Phase12AdditionsTests : Tests
    {
        [Test]
        public void AmbiguousUnits()
        {
            AssertAreEqual(Power.HorsePower, Power.MetricHorsePower);
            Assert.AreEqual(745.69987158227, Power.MechanicalHorsePower.ConvertTo(Power.Watt), 1e-9);

            AssertAreEqual(Volume.ImperialGallon, Volume.Parse("1 gal(imp)"));
            AssertAreEqual(Mass.ShortTon, 2000 * Mass.Pound);
            AssertAreEqual(Mass.LongTon, Mass.Ton);
            AssertAreEqual(Energy.CalorieThermochemical, Energy.Parse("1 cal(th)"));
        }

        [Test]
        public void StandardsConformantAliases()
        {
            AssertAreEqual(Acceleration.MetrePerSecondSquared, Acceleration.Parse("1 m/s²"));
            AssertAreEqual(Moment.NewtonMetre, Moment.Parse("1 N·m"));
            AssertAreEqual(Torque.NewtonMetre, Torque.Parse("1 N·m"));
            AssertAreEqual(TemperatureRateOfChange.DegreeCelsiusPerSecond, TemperatureRateOfChange.Parse("1 °C/s"));
            AssertAreEqual(FuelConsumption.LitrePer100Kilometre, FuelConsumption.Parse("1 L/100km"));
            AssertAreEqual(FuelEconomy.KilometrePerLitre, FuelEconomy.Parse("1 km/L"));
        }

        [Test]
        public void SiprefixedAndInformationUnits()
        {
            AssertAreEqual(1000 * Pressure.Megapascal, Pressure.Gigapascal);
            AssertAreEqual(1000 * Frequency.Gigahertz, Frequency.Terahertz);

            AssertAreEqual(8 * InformationQuantity.Bit, InformationQuantity.Byte);
            AssertAreEqual(1024 * InformationQuantity.Kibibyte, InformationQuantity.Mebibyte);
            AssertAreEqual(InformationQuantity.Mebibyte, InformationQuantity.Parse("1 MiB"));
            AssertAreEqual(FuelEconomy.MilesPerImperialGallon, FuelEconomy.Parse("1 mpg(imp)"));
        }
    }
}
