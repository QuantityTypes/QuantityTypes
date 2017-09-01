namespace CodeGenerator
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Reflection;
    using System.Text;

    static class Program
    {
        static int Main(string[] args)
        {
            Console.WriteLine("CodeGenerator " + typeof(Program).GetTypeInfo().Assembly.GetName().Version);

            var sourceFile = args.Length > 0 ? args[0] : "units.csv";
            var outputFolder = (args.Length > 1 ? args[1] : null) ?? ".";
            if (!File.Exists(sourceFile))
            {
                Console.WriteLine("{0} not found.", Path.GetFullPath(sourceFile));
                return 1;
            }

            Console.WriteLine();
            Console.WriteLine("Source: {0}", Path.GetFullPath(sourceFile));
            Console.WriteLine("Output folder: {0}", Path.GetFullPath(outputFolder));
            Console.WriteLine();

            if (!Directory.Exists(outputFolder))
            {
                Directory.CreateDirectory(outputFolder);
            }

            var allLines = File.ReadAllLines(sourceFile);
            var typeNames = GetTypeNames(allLines).Distinct().ToArray();
            foreach (var typeName in typeNames)
            {
                var fileName = Path.Combine(outputFolder, typeName + ".Generated.cs");
                if (GenerateQuantityType(fileName, typeName, allLines))
                {
                    Console.WriteLine(typeName);
                }
            }

            return 0;
        }

        private static IEnumerable<string> GetTypeNames(IEnumerable<string> lines)
        {
            foreach (var line in lines)
            {
                if (string.IsNullOrWhiteSpace(line) || line.Trim().StartsWith("//"))
                {
                    continue;
                }

                var values = line.Split(',');
                yield return values[0];
            }
        }

        private static bool GenerateQuantityType(string fileName, string typeName, IEnumerable<string> lines)
        {
            var input = ReadFromEmbeddedResource("CodeGenerator.Template.cs");

            var staticProperties = new StringBuilder();

            bool isFirstUnit = true;
            foreach (var line in lines)
            {
                if (string.IsNullOrWhiteSpace(line) || line.Trim().StartsWith("//")) continue;
                var values = line.Split(',');
                if (values.Length < 4 || values[0] != typeName) continue;
                var name = values[1];
                var value = values[3];

                var symbolList = values[2].Split('|');
                var displayUnit = isFirstUnit ? ", true" : "";
                var symbolsDisplay = string.Join(",", symbolList);

                if (!isFirstUnit) staticProperties.AppendLine();
                staticProperties.AppendLine(@"        /// <summary>");
                staticProperties.AppendLine(@"        /// Gets the ""{0}"" unit.", symbolsDisplay);
                staticProperties.AppendLine(@"        /// </summary>");
                foreach (var symbol in symbolList)
                {
                    staticProperties.AppendLine(@"        [Unit(""{0}""{1})]", symbol, displayUnit);
                }
                staticProperties.AppendLine(@"        public static {0} {1} {{ get; }} = new {0}({2});", typeName, name, value);
                isFirstUnit = false;
            }

            var output = input;
            output = output.Replace("Length", typeName);
            output = output.Replace("length", GetDescriptiveName(typeName));

            output = output.Replace("        //// [STATIC PROPERTIES]", staticProperties.ToString().TrimEnd());

            var isModified = output != input;
            if (isModified)
            {
                File.WriteAllText(fileName, output);
            }

            return isModified;
        }

        private static string ReadFromEmbeddedResource(string name)
        {
            string input;
            var stream = typeof(Program).GetTypeInfo().Assembly.GetManifestResourceStream(name);
            if (stream == null)
            {
                return null;
            }

            using (var r = new StreamReader(stream))
            {
                input = r.ReadToEnd();
            }

            return input;
        }

        private static string GetDescriptiveName(string typeName)
        {
            string classname = typeName.Substring(0, 1);
            for (int i = 1; i < typeName.Length; i++)
            {
                if (Char.IsUpper(typeName[i])) classname += " ";
                classname += typeName[i];
            }

            classname = classname.ToLower();
            return classname;
        }

        public static void AppendLine(this StringBuilder b, string format, params object[] args)
        {
            b.AppendFormat(format, args);
            b.AppendLine();
        }
    }
}
