using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PerformanceTest
{
    using System.Diagnostics;
    using System.Globalization;
    using System.IO;
    using System.Runtime.InteropServices;

    using Units;

    class Program
    {
        static void Main(string[] args)
        {
            int N = 2000000;
            Console.WriteLine("N = {0}", N);
            Console.WriteLine(UnitProvider.Default);

            var results = new List<IList<long>>();
            results.Add(TestDouble(N).ToList());
            results.Add(TestUnits(N).ToList());

            using (var s = new StreamWriter("results.txt"))
            {
                foreach (var r in results)
                {
                    foreach (var i in r) s.Write(i + "\t");
                    s.WriteLine();
                }
            }

            Process.Start("results.txt");
            Console.ReadKey();
        }

        static IEnumerable<long> TestDouble(int N)
        {
            Console.WriteLine("double : {0} bytes", Marshal.SizeOf(typeof(double)));

            var a1 = new double[N];
            var a2 = new double[N];

            using (var timer = new Timer("Assign"))
            {
                for (int i = 0; i < N; i++) a1[i] = i;
                yield return timer.Stop();
            }

            yield return 0;

            using (var timer = new Timer("Add"))
            {
                for (int i = 0; i < N; i++) a1[i] = a1[i] + a1[0];
                yield return timer.Stop();
            }

            yield return 0;

            var s = "10";
            using (var timer = new Timer("Parse"))
            {
                for (int i = 0; i < N; i++) a1[i] = double.Parse(s, CultureInfo.InvariantCulture);
                yield return timer.Stop();
            }
            yield return 0;

            using (var timer = new Timer("Multiply (double)"))
            {
                for (int i = 0; i < N; i++) a2[i] = a1[i] * a1[i];
                yield return timer.Stop();
            }
            yield return 0;

            using (var timer = new Timer("Sum"))
            {
                double sum = 0;
                for (int i = 0; i < N; i++) sum += a2[i];
                yield return timer.Stop();
            }
            yield return 0;

            Console.WriteLine();
        }

        static Timer Timer(string message)
        {
            return new Timer(message);
        }

        static IEnumerable<long> TestUnits(int N)
        {
            Console.WriteLine("Length = {0} bytes", Marshal.SizeOf(typeof(Length)));

            var a1 = new Length[N];
            var a2 = new Area[N];

            using (var timer = new Timer("Assign"))
            {
                for (int i = 0; i < N; i++) a1[i] = Length.Metre;
            }

            using (var timer = new Timer("Assign (multiplication)"))
            {
                for (int i = 0; i < N; i++) a1[i] = i * Length.Metre;
                yield return timer.Stop();
            }

            using (var timer = new Timer("Assign (ctor)"))
            {
                for (int i = 0; i < N; i++) a1[i] = new Length(i);
                yield return timer.Stop();
            }

            using (var timer = new Timer("Add (operator)"))
            {
                for (int i = 0; i < N; i++) a1[i] = a1[i] + a1[0];
                yield return timer.Stop();
            }

#if PublicFields
            using (var timer=new Timer("Add (field)"))
            {
                for (int i = 0; i < N; i++) a1[i] = new Length(a1[i].value + a1[0].value);
            }
#endif

            using (var timer = new Timer("Add (property)"))
            {
                for (int i = 0; i < N; i++) a1[i] = new Length(a1[i].Value + a1[0].Value);
                yield return timer.Stop();
            }

            var s = "10";
            using (var timer = new Timer("Parse"))
            {
                for (int i = 0; i < N; i++) a1[i] = Length.Parse(s);
                yield return timer.Stop();
            }

            s = "10 m";
            using (var timer = new Timer("Parse with unit"))
            {
                for (int i = 0; i < N; i++) a1[i] = Length.Parse(s);
                yield return timer.Stop();
            }

            using (var timer = new Timer("Multiply"))
            {
                for (int i = 0; i < N; i++) a2[i] = a1[i] * a1[i];
                yield return timer.Stop();
            }

#if PublicFields
            using (var timer=new Timer("Multiply (field)"))
            {
                for (int i = 0; i < N; i++) a2[i] = new Area(a1[i].value * a1[i].value);
                yield return timer.Stop();
            }
#endif

            using (var timer = new Timer("Multiply (property, ctor)"))
            {
                for (int i = 0; i < N; i++) a2[i] = new Area(a1[i].Value * a1[i].Value);
                yield return timer.Stop();
            }

            using (var timer = new Timer("Multiply (property, multiplication)"))
            {
                for (int i = 0; i < N; i++) a2[i] = (a1[i].Value * a1[i].Value) * Area.SquareMetre;
            }

            using (var timer = new Timer("Square"))
            {
                for (int i = 0; i < N; i++) a2[i] = a1[i].Squared();
            }

            using (var timer = new Timer("^"))
            {
                for (int i = 0; i < N; i++) a2[i] = (Area)(a1[i] ^ 2);
            }

            double sum1;
            using (var timer = new Timer("Sum (operator)"))
            {
                var sum = new Area();
                for (int i = 0; i < N; i++) sum += a2[i];
                sum1 = sum.ConvertTo(Area.SquareMetre);
                yield return timer.Stop();
            }

#if PublicFields
            double sum2 = 0;
            using (var timer=new Timer("Sum (field)"))
            {
                for (int i = 0; i < N; i++) sum2 += a2[i].value;
            }
#endif

            double sum3 = 0;
            using (var timer = new Timer("Sum (property)"))
            {
                for (int i = 0; i < N; i++) sum3 += a2[i].Value;
                yield return timer.Stop();
            }

            Console.WriteLine();
        }

    }

    class LengthClass
    {
        public double Value { get; set; }
    }
}
