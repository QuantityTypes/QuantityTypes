using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace CodeGenerator
{
    static class Program
    {
        static int Main(string[] args)
        {
            var sourceFile = args[0] ?? "units.csv";
            if (!File.Exists(sourceFile))
            {
                Console.WriteLine("{0} not found.", Path.GetFullPath(sourceFile));
                return 1;
            }

            var allLines = File.ReadAllLines(sourceFile);
            var dir = Path.GetDirectoryName(sourceFile) ?? ".";
            var typeNames = GetTypeNames(allLines).Distinct().ToArray();
            foreach (var typeName in typeNames)
            {
                var fileName = Path.Combine(dir, typeName + ".cs");
                if (GenerateQuantityType(fileName, typeName, allLines))
                {
                    Console.WriteLine(typeName);
                }
            }

            // TODO: update .csproj file

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
            var input = File.ReadAllText("Template.cs");
            var backingFields = new StringBuilder();
            var staticProperties = new StringBuilder();

            bool isFirstUnit = true;
            foreach (var line in lines)
            {
                if (string.IsNullOrWhiteSpace(line) || line.Trim().StartsWith("//")) continue;
                var values = line.Split(',');
                if (values.Length < 4 || values[0] != typeName) continue;
                var name = values[1];
                var value = values[3];

                if (!isFirstUnit) backingFields.AppendLine();
                backingFields.AppendLine(@"        /// <summary>");
                backingFields.AppendLine(@"        /// The backing field for the <see cref=""{0}"" /> property.", name);
                backingFields.AppendLine(@"        /// </summary>");
                backingFields.AppendLine(@"        private static readonly {0} {1}Field = new {0}({2});", typeName, name, value);

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
                staticProperties.AppendLine(@"        public static {0} {1}", typeName, name);
                staticProperties.AppendLine(@"        {");
                staticProperties.AppendLine(@"            get {{ return {0}Field; }}", name);
                staticProperties.AppendLine(@"        }");
                isFirstUnit = false;
            }

            var output = input;
            output = output.Replace("Length", typeName);
            output = output.Replace("length", GetDescriptiveName(typeName));

            output = output.Replace("        //// [BACKING FIELDS]", backingFields.ToString().TrimEnd());

            output = output.Replace("        //// [STATIC PROPERTIES]", staticProperties.ToString().TrimEnd());

            var isModified = output != input;
            if (isModified)
            {
                File.WriteAllText(fileName, output);
            }

            return isModified;
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

        const string BackingFieldTemplate = @"        /// <summary>
        /// The backing field for the <see cref=""Metre"" /> property.
        /// </summary>
        private static readonly Length MetreField = new Length(1);";

        const string StaticPropertyTemplate = @"        /// <summary>
        /// Gets the ""m"" unit.
        /// </summary>
        [Unit(""m"", true)]
        public static Length Metre
        {
            get { return MetreField; }
        }";
    }
}
