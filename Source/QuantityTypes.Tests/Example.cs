// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Example.cs" company="QuantityTypes">
//   Copyright (c) 2014 QuantityTypes contributors
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace QuantityTypes.Tests
{
    using System;

    using QuantityTypes;

    public class Example
    {
        public void Example1()
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

            UnitProvider.Default.TrySetDisplayUnit<Length>("mm");
            var s3 = l1.ToString();
            UnitProvider.Default.RegisterUnit(0.3048 * Length.Metre, "fot");
            var l5 = Length.Parse("2fot");

            var t1 = 10 * Temperature.DegreeCelsius;
            var t2 = Temperature.Parse("300K");
            var t3 = 0 * Temperature.DegreeFahrenheit;
            var t4 = Temperature.Parse("300C");
            var b5 = (0 * Temperature.DegreeCelsius).Equals(273.15 * Temperature.Kelvin);
            UnitProvider.Default.TrySetDisplayUnit<Temperature>("F");

            var mf = Force.Newton * Length.Metre;
            Energy e = Force.Newton * Length.Metre;

            var p1 = Power.Parse("2 hp");

            var ul = UnitProvider.Default.GetUnits(typeof(Length));
            var ux = UnitProvider.Default.GetUnit("m");
        }

        public void ReadMeExample()
        {
            Length s = 100 * Length.Metre;
            Time t = 9.58 * Time.Second;
            Velocity v = s / t;
            Console.WriteLine(v);
            Console.WriteLine(v.ToString("0.00 [km/h]"));
            Console.WriteLine("Speed: {0:0.00 [km/h]}", v);
            Mass m = Mass.Parse("92 kg");
            double massInPounds = m.ConvertTo(Mass.Pound);
            Temperature temp = 100 * Temperature.DegreeCelsius;
            double tempInFahrenheit = temp.ConvertTo(Temperature.DegreeFahrenheit);
        }
    }
}