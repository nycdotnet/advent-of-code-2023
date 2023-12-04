using Common;
using System.Buffers;
using System.Diagnostics;
using System.Text.RegularExpressions;

namespace Day02
{
    public class Day02 : IAdventOfCodeDay
    {
        public List<Game> Games { get; } = [];
        public int RedCubes { get; set; }
        public int GreenCubes { get; set; }
        public int BlueCubes { get; set; }

        public Day02(string[] input)
        {
            foreach (var gameText in input.Where(x => !string.IsNullOrEmpty(x)))
            {
                if (Game.TryParse(gameText, out var game))
                {
                    Games.Add(game);
                    continue;
                }
                throw new ParsingException("Unable to parse a valid game from " + gameText);
            }
        }

        public string GetAnswerForPart1()
        {
            var result = 0;

            for (var gi = 0; gi < Games.Count; gi++)
            {
                if (Games[gi].Reveals.All(r => r.Red <= RedCubes && r.Green <= GreenCubes && r.Blue <= BlueCubes))
                {
                    result += Games[gi].GameNumber;
                }
            }

            return result.ToString();
        }

        public string GetAnswerForPart2()
        {
            var result = 0;

            for (var gi = 0; gi < Games.Count; gi++)
            {
                var game = Games[gi];
                var minRed = game.Reveals.Max(r => r.Red);
                var minGreen = game.Reveals.Max(r => r.Green);
                var minBlue = game.Reveals.Max(r => r.Blue);
                var power = minRed * minGreen * minBlue;
                result += power;
            }

            return result.ToString();
        }
    }

    public partial record Game
    {
        [GeneratedRegex(@"Game (\d*)")]
        private static partial Regex GameRegex();
        public int GameNumber { get; set; }
        public List<Reveal> Reveals { get; } = [];
        public static bool TryParse(string gameText, out Game game)
        {
            var indexOfColon = gameText.IndexOf(':');
            var gameMatch = GameRegex().Match(gameText, 0, indexOfColon);

            game = new Game
            {
                GameNumber = int.Parse(gameMatch.Groups[1].ValueSpan)
            };

            var revealSegments = gameText.AsSpan(indexOfColon + 1);
            var revealCount = revealSegments.Count(';') + 1;

            var ranges = ArrayPool<Range>.Shared.Rent(revealCount);

            revealSegments.Split(ranges, ';');
            for (var i = 0; i < revealCount; i++)
            {
                // NOTE: Slice should have an overload that takes a Range or works with Index
                var revealSegment = revealSegments.Slice(
                    ranges[i].Start.Value,
                    ranges[i].End.Value - ranges[i].Start.Value);

                game.Reveals.Add(new Reveal(revealSegment));
            }
            ArrayPool<Range>.Shared.Return(ranges);

            return true;
        }
    }

    public record Reveal
    {
        public Reveal(ReadOnlySpan<char> input)
        {
            var cubeCount = input.Count(',') + 1;
            var ranges = ArrayPool<Range>.Shared.Rent(cubeCount);
            input.Split(ranges, ',');

            for (var i = 0; i < cubeCount; i++)
            {
                var cubeSegment = input.Slice(
                    ranges[i].Start.Value,
                    ranges[i].End.Value - ranges[i].Start.Value);

                var space = cubeSegment.Slice(1).IndexOf(' ') + 1;
                switch (cubeSegment[space + 1])
                {
                    case 'r':
                        Red += int.Parse(cubeSegment.Slice(1, space - 1));
                        break;
                    case 'g':
                        Green += int.Parse(cubeSegment.Slice(1, space - 1));
                        break;
                    case 'b':
                        Blue += int.Parse(cubeSegment.Slice(1, space - 1));
                        break;
                    default:
                        throw new UnreachableException();
                }
            }

            ArrayPool<Range>.Shared.Return(ranges);
        }

        public int Blue { get; set; }
        public int Red { get; set; }
        public int Green { get; set; }
    }
}
