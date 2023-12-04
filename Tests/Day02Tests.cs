using Day02;
using FluentAssertions;

namespace Tests
{
    public class Day02Tests
    {
        [Fact]
        public void ParsingWorks()
        {
            var sut = new Day02.Day02(SampleInput.Split('\n'));
            sut.Games[0].Reveals.Count.Should().Be(3);
            sut.Games[0].Reveals[0].Blue.Should().Be(3);
            sut.Games[0].Reveals[0].Red.Should().Be(4);
            sut.Games[0].GameNumber.Should().Be(1);

            sut.Games[2].Reveals[0].Green.Should().Be(8);
            sut.Games[2].Reveals[0].Blue.Should().Be(6);
            sut.Games[2].Reveals[0].Red.Should().Be(20);
        }

        [Fact]
        public void Example1Works()
        {
            var sut = new Day02.Day02(SampleInput.Split('\n'))
            {
                RedCubes = 12,
                GreenCubes = 13,
                BlueCubes = 14
            };

            sut.GetAnswerForPart1().Should().Be("8");
        }

        [Fact]
        public void Example2Works()
        {
            var sut = new Day02.Day02(SampleInput.Split('\n'))
            {
                RedCubes = 12,
                GreenCubes = 13,
                BlueCubes = 14
            };

            sut.GetAnswerForPart2().Should().Be("2286");
        }

        public static readonly string SampleInput = """
            Game 1: 3 blue, 4 red; 1 red, 2 green, 6 blue; 2 green
            Game 2: 1 blue, 2 green; 3 green, 4 blue, 1 red; 1 green, 1 blue
            Game 3: 8 green, 6 blue, 20 red; 5 blue, 4 red, 13 green; 5 green, 1 red
            Game 4: 1 green, 3 red, 6 blue; 3 green, 6 red; 3 green, 15 blue, 14 red
            Game 5: 6 red, 1 blue, 3 green; 2 blue, 1 red, 2 green
            """.ReplaceLineEndings("\n");
    }
}
