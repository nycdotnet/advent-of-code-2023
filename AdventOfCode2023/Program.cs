using Common;
using System.Diagnostics;

namespace AdventOfCode2023
{
    internal class Program
    {
        static void Main(string[] _)
        {
            var ticks = 0L;
            ticks += GetTicksAndReport(RunDay01);
            ticks += GetTicksAndReport(RunDay02);
            Console.WriteLine($"Total time elapsed: {new TimeSpan(ticks).TotalMilliseconds}ms");
        }

        private static void RunDay01()
        {
            var input = Utils.GetResourceStringFromAssembly<Day01.Day01>("Day01.input.txt");
            var day = new Day01.Day01(input.ReplaceLineEndings("\n").Split('\n', StringSplitOptions.RemoveEmptyEntries));
            Console.WriteLine($"{day.GetType().Name} answer 1: {day.GetAnswerForPart1()}");
            Console.WriteLine($"{day.GetType().Name} answer 2: {day.GetAnswerForPart2()}");
        }

        private static void RunDay02()
        {
            var input = Utils.GetResourceStringFromAssembly<Day02.Day02>("Day02.input.txt");
            var day = new Day02.Day02(input.ReplaceLineEndings("\n").Split('\n', StringSplitOptions.RemoveEmptyEntries))
            {
                RedCubes = 12,
                GreenCubes = 13,
                BlueCubes = 14
            };
            Console.WriteLine($"{day.GetType().Name} answer 1: {day.GetAnswerForPart1()}");
            Console.WriteLine($"{day.GetType().Name} answer 2: {day.GetAnswerForPart2()}");
        }

        /// <summary>
        /// NOTE: Real benchmarks should use Benchmark.NET - this is just for relative info on the console
        /// </summary>
        private static long GetTicksAndReport(Action action)
        {
            var sw = new Stopwatch();
            sw.Start();
            action.Invoke();
            sw.Stop();
            Console.WriteLine($"Completed action in {sw.ElapsedMilliseconds}ms");
            return sw.ElapsedTicks;
        }
    }
}
