namespace Units
{
    class Program
    {
        static void Main(string[] args)
        {
            var v = 100 * Length.Metre / (9 * Time.Second);
            var l = Length.Metre;
            var mm = l.ConvertTo(Length.Millimetre);
            var l1 = Length.Parse("10.1 m");
            var s1 = l1.ToString();
            var s2 = l1.ToString("0.000");

            var l2 = Length.Parse("10.1");
            var l3 = Length.Parse("1e1");
            var l4 = Length.Parse("1e1m");
            var b1 = l1 == l2;
            var b2 = l1.Equals(l2);
            var b3 = l1 < l2;
            var b4 = l1 <= l2;
            var sl1 = ShortLength.Millimetre;
            Length sl2 = sl1;
            Velocity v2 = (Length)sl1 / Time.Second;

            UnitProvider.Default.SetDisplayUnit(Length.Millimetre, "millim");
            var s3 = l1.ToString();
            UnitProvider.Default.RegisterUnit(0.3048 * Length.Metre, "fot");
            var l5 = Length.Parse("2fot");

            var t1 = 10 * Temperature.Celsius;
            var t2 = Temperature.Parse("300K");
            var t3 = 0 * Temperature.Fahrenheit;
            var t4 = Temperature.Parse("300C");
            var b5 = (0 * Temperature.Celsius).Equals(273.15 * Temperature.Kelvin);
            UnitProvider.Default.SetDisplayUnit(Temperature.Fahrenheit, "f");

            var mf = Force.Newton * Length.Metre;
            Energy e = Force.Newton * Length.Metre;

            var p1 = Power.Parse("2 hp");

            var ul = UnitProvider.Default.GetUnits(typeof(Length));
            var ux = UnitProvider.Default.GetUnit("m");
        }
    }
}
