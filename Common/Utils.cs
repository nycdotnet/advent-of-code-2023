using System.Reflection;

namespace Common
{
    public static class Utils
    {
        public static IEnumerable<int> GetInputAsIntegers(string fileName) => GetLines(fileName)
            .Where(x => !string.IsNullOrWhiteSpace(x))
            .Select(int.Parse);

        /// <summary>
        /// Gets the lines from the specified file relative to the project folder, removing empty lines
        /// </summary>
        public static string[] GetLines(string fileName) =>
            File.ReadAllText(Path.Combine(ProjectFolder(), fileName))
            .Split("\r\n", StringSplitOptions.RemoveEmptyEntries);

        public static string ProjectFolder() => Path.GetFullPath(Path.Combine(AppContext.BaseDirectory, "..\\..\\..\\"));

        public static short[] ParseCharsToShorts(this string str)
        {
            var ss = str.AsSpan();
            var result = new short[str.Length];
            for (var i = 0; i < ss.Length; i++)
            {
                result[i] = short.Parse(ss.Slice(i, 1));
            }
            return result;
        }

        public static string GetResourceStringFromAssembly<TDefinedInAssembly>(string resourceName)
        {
            var assembly = Assembly.GetAssembly(typeof(TDefinedInAssembly));

            using var stream = assembly!.GetManifestResourceStream(resourceName) ?? throw new KeyNotFoundException($"Unable to find resource {resourceName} in assembly \"{assembly.FullName}\".");
            using var reader = new StreamReader(stream);
            return reader.ReadToEnd();
        }
    }
}