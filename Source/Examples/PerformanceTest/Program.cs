// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Program.cs" company="QuantityTypes">
//   Copyright (c) 2014 QuantityTypes contributors
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace PerformanceTest
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Diagnostics;
    using System.Globalization;
    using System.IO;
    using System.Runtime.InteropServices;

    using QuantityTypes;
    using QuantityTypes.Dynamic;

    class Program
    {
        static void Main(string[] args)
        {
            int N = 2000000;
            Console.WriteLine("N = {0}", N);
            //Console.WriteLine("Culture = {0}", UnitProvider.Default.Culture);
            Console.WriteLine();

            var results = new Dictionary<string, IList<long>>();
            results.Add("double", TestDouble(N).ToList());
            results.Add("QuantityTypes", TestQuantityTypes(N).ToList());
            results.Add("QuantityTypes (dynamic)", TestQuantityTypesDynamic(N).ToList());

            var tests = new[]
                            {
                                "Type","Size", "Assign (multiplication)", "Assign (ctor)", "Add (operator)", "Add (property)", "Parse",
                                "Parse with unit", "Multiply", "Multiply (property, ctor)", "Sum (operator)",
                                "Sum (property)"
                            };

            using (var s = new StreamWriter("results.txt"))
            {
                foreach (var i in tests) s.Write(i + "\t");
                s.WriteLine();
                foreach (var r in results)
                {
                    s.Write(r.Key + "\t");
                    foreach (var i in r.Value) s.Write((i >= 0 ? i.ToString(CultureInfo.InvariantCulture) : string.Empty) + "\t");
                    s.WriteLine();
                }
            }

            Process.Start("results.txt");

            Console.ReadKey();
        }

        static IEnumerable<long> TestDouble(int N)
        {
            Console.WriteLine("=== double ===");

            var length = Marshal.SizeOf(typeof(double));
            Console.WriteLine("Length : {0} bytes", length);
            yield return length;

            var a1 = new double[N];
            var a2 = new double[N];

            using (var timer = new Timer("Assign"))
            {
                for (int i = 0; i < N; i++) a1[i] = i;
                yield return timer.Stop();
            }

            yield return -1;

            using (var timer = new Timer("Add"))
            {
                for (int i = 0; i < N; i++) a1[i] = a1[i] + a1[0];
                yield return timer.Stop();
            }

            yield return -1;

            var s = "10";
            using (var timer = new Timer("Parse"))
            {
                for (int i = 0; i < N; i++) a1[i] = double.Parse(s, CultureInfo.InvariantCulture);
                yield return timer.Stop();
            }

            yield return -1;

            using (var timer = new Timer("Multiply (double)"))
            {
                for (int i = 0; i < N; i++) a2[i] = a1[i] * a1[i];
                yield return timer.Stop();
            }

            yield return -1;

            using (var timer = new Timer("Sum"))
            {
                double sum = 0;
                for (int i = 0; i < N; i++) sum += a2[i];
                yield return timer.Stop();
            }

            yield return -1;

            Console.WriteLine();
        }

        static Timer Timer(string message)
        {
            return new Timer(message);
        }

        static IEnumerable<long> TestQuantityTypes(int N)
        {
            Console.WriteLine("=== QuantityTypes ===");

            var length = Marshal.SizeOf(typeof(Length));
            Console.WriteLine("Length = {0} bytes", length);
            yield return length;

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

        static IEnumerable<long> TestQuantityTypesDynamic(int N)
        {
            Console.WriteLine("=== QuantityTypes (dynamic) ===");

            var length = Marshal.SizeOf(typeof(DynamicQuantity));
            Console.WriteLine("Length = {0} bytes", length);
            yield return length;

            var a1 = new DynamicQuantity[N];
            var a2 = new DynamicQuantity[N];

            using (var timer = new Timer("Assign"))
            {
                for (int i = 0; i < N; i++) a1[i] = SI.Metre;
            }

            using (var timer = new Timer("Assign (multiplication)"))
            {
                for (int i = 0; i < N; i++) a1[i] = i * SI.Metre;
                yield return timer.Stop();
            }

            using (var timer = new Timer("Assign (ctor)"))
            {
                for (int i = 0; i < N; i++) a1[i] = new DynamicQuantity(i, new Dimensions(0, 1, 0));
                yield return timer.Stop();
            }

            using (var timer = new Timer("Add (operator)"))
            {
                for (int i = 0; i < N; i++) a1[i] = a1[i] + a1[0];
                yield return timer.Stop();
            }

            using (var timer = new Timer("Add (property)"))
            {
                for (int i = 0; i < N; i++) a1[i] = new DynamicQuantity(a1[i].Value + a1[0].Value, new Dimensions(0, 1, 0));
                yield return timer.Stop();
            }

            var s = "10";
            using (var timer = new Timer("Parse"))
            {
             //   for (int i = 0; i < N; i++) a1[i] = DynamicQuantity.Parse(s);
                yield return timer.Stop();
            }

            s = "10 m";
            using (var timer = new Timer("Parse with unit"))
            {
                for (int i = 0; i < N; i++) a1[i] = DynamicQuantity.Parse(s);
                yield return timer.Stop();
            }

            using (var timer = new Timer("Multiply"))
            {
                for (int i = 0; i < N; i++) a2[i] = a1[i] * a1[i];
                yield return timer.Stop();
            }

            using (var timer = new Timer("Multiply (property, ctor)"))
            {
                for (int i = 0; i < N; i++) a2[i] = new DynamicQuantity(a1[i].Value * a1[i].Value, new Dimensions(0, 2, 0));
                yield return timer.Stop();
            }

            double sum1;
            using (var timer = new Timer("Sum (operator)"))
            {
                var sum = new DynamicQuantity();
                for (int i = 0; i < N; i++) sum += a2[i];
                sum1 = sum.ConvertTo(SI.SquareMetre);
                yield return timer.Stop();
            }

            double sum3 = 0;
            using (var timer = new Timer("Sum (property)"))
            {
                for (int i = 0; i < N; i++) sum3 += a2[i].Value;
                yield return timer.Stop();
            }

            Console.WriteLine();
        }

/*        static IEnumerable<long> TestTypedUnits(int N)
        {
            // http://www.codeproject.com/Articles/611731/Working-with-Units-and-Amounts
            Console.WriteLine("=== TypedUnits ===");

            var a1 = new TypedUnits.Amount[N];
            var a2 = new TypedUnits.Amount[N];

            {
                // http://stackoverflow.com/questions/207592/getting-the-size-of-a-field-in-bytes-with-c-sharp
                var mem0 = GC.GetTotalMemory(true);
                var a = new TypedUnits.Amount[N];
                var mem1 = GC.GetTotalMemory(true);
                for (int i = 0; i < N; i++) a[i] = new TypedUnits.Amount(1, StandardUnits.LengthUnits.Meter);
                var mem2 = GC.GetTotalMemory(true);
                var length = (mem2 - mem0) / (double)N;
                Console.WriteLine("Approx. length = {0:0.###} bytes (incl. reference {1:0.###} bytes)", length, (mem1 - mem0) / (double)N);
                yield return (int)length;
            }

            var meter = new TypedUnits.Amount(1, StandardUnits.LengthUnits.Meter);
            using (var timer = new Timer("Assign (reference)"))
            {
                for (int i = 0; i < N; i++) a1[i] = meter;
            }

            using (var timer = new Timer("Assign (multiplication)"))
            {
                for (int i = 0; i < N; i++) a1[i] = i * a1[i];
                yield return timer.Stop();
            }

            using (var timer = new Timer("Assign (ctor)"))
            {
                for (int i = 0; i < N; i++) a1[i] = new TypedUnits.Amount(1, StandardUnits.LengthUnits.Meter);
                yield return timer.Stop();
            }

            using (var timer = new Timer("Add (operator)"))
            {
                for (int i = 0; i < N; i++) a1[i] = a1[i] + a1[0];
                yield return timer.Stop();
            }

            using (var timer = new Timer("Add (property)"))
            {
                for (int i = 0; i < N; i++) a1[i] = new TypedUnits.Amount(a1[i].Value + a1[0].Value, StandardUnits.LengthUnits.Meter);
                yield return timer.Stop();
            }

            // var s = "10 m";
            using (var timer = new Timer("Parse"))
            {
                // TODO:
                // for (int i = 0; i < N; i++) a1[i] = Length.Parse(s);
                // yield return timer.Stop();
                yield return -1;
            }

            using (var timer = new Timer("Parse with unit"))
            {
                // TODO
                // for (int i = 0; i < N; i++) a1[i] = Length.Parse(s);
                // yield return timer.Stop();
                yield return -1;
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
                for (int i = 0; i < N; i++) a2[i] = new TypedUnits.Amount(a1[i].Value * a1[i].Value, StandardUnits.SurfaceUnits.Meter2);
                yield return timer.Stop();
            }

            using (var timer = new Timer("Multiply (property, multiplication)"))
            {
                var m2 = new TypedUnits.Amount(1, StandardUnits.SurfaceUnits.Meter2);
                for (int i = 0; i < N; i++) a2[i] = (a1[i].Value * a1[i].Value) * m2;
            }

            double sum1;
            using (var timer = new Timer("Sum (operator)"))
            {
                var sum = new TypedUnits.Amount(0, StandardUnits.SurfaceUnits.Meter2);
                for (int i = 0; i < N; i++) sum += a2[i];
                // todo
                sum1 = sum.Value; // ConvertTo(Area.SquareMetre);
                yield return timer.Stop();
            }

            double sum3 = 0;
            using (var timer = new Timer("Sum (property)"))
            {
                for (int i = 0; i < N; i++) sum3 += a2[i].Value;
                yield return timer.Stop();
            }

            Console.WriteLine();
        }*/
    }

    class LengthClass
    {
        public double Value { get; set; }
    }
}