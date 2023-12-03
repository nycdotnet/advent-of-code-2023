namespace Tests
{
    public class Day01Tests
    {
        [Fact]
        public void Part1()
        {
            var sut = new Day01.Day01(ExampleInput.Split('\n'));
            Assert.Equal("142", sut.GetAnswerForPart1());
        }

        [Fact]
        public void Part2()
        {
            var sut = new Day01.Day01(ExampleInput2.Split('\n'));
            Assert.Equal("281", sut.GetAnswerForPart2());
        }

        private static readonly string ExampleInput = """
            1abc2
            pqr3stu8vwx
            a1b2c3d4e5f
            treb7uchet
            """.ReplaceLineEndings("\n");
        private static readonly string ExampleInput2 = """
            two1nine
            eightwothree
            abcone2threexyz
            xtwone3four
            4nineeightseven2
            zoneight234
            7pqrstsixteen
            """.ReplaceLineEndings("\n");
    }
}