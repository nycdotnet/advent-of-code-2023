using Common;

namespace Day01
{
    public class Day01 : IAdventOfCodeDay
    {
        private readonly string[] input;
        private static readonly char[] numericDigits = "0123456789".ToCharArray();
        private static readonly string[] textDigits = [
            "zero",
            "one",
            "two",
            "three",
            "four",
            "five",
            "six",
            "seven",
            "eight",
            "nine"
        ];

        public Day01(string[] input)
        {
            this.input = input;
        }

        public string GetAnswerForPart1()
        {
            var total = 0;
            var d = new char[2];
            for (var i = 0; i < input.Length; i++)
            {
                var leftMostIndex = input[i].IndexOfAny(numericDigits);
                var rightMostIndex = input[i].LastIndexOfAny(numericDigits);
                d[0] = input[i][leftMostIndex];
                d[1] = input[i][rightMostIndex];
                var num = int.Parse(d);
                total += num;
            }
            return total.ToString();
        }

        public string GetAnswerForPart2()
        {
            var total = 0;
            var d = new char[2];
            var matchIndexes = new int[11];

            for (var i = 0; i < input.Length; i++)
            {
                var leftMostDigitIndex = input[i].IndexOfAny(numericDigits);
                if (leftMostDigitIndex == 0)
                {
                    d[0] = input[i][leftMostDigitIndex];
                }
                else
                {
                    var leftIndex = textDigits
                        .Select((td, idx) => (digit: idx, index: input[i].IndexOf(td)))
                        .Where(x => x.index > -1)
                        .DefaultIfEmpty((digit: -1, index: int.MaxValue))
                        .MinBy(x => x.index);

                    if (leftMostDigitIndex > -1 && leftMostDigitIndex < leftIndex.index)
                    {   
                        d[0] = input[i][leftMostDigitIndex];
                    }
                    else
                    {
                        d[0] = (char)('0' + leftIndex.digit);
                    }    
                }

                var rightMostDigitIndex = input[i].LastIndexOfAny(numericDigits);
                if (rightMostDigitIndex == input[i].Length - 1)
                {
                    d[1] = input[i][rightMostDigitIndex];
                }
                else
                {
                    var rightIndex = textDigits
                        .Select((td, idx) => (digit: idx, index: input[i].LastIndexOf(td)))
                        .Where(x => x.index > -1)
                        .DefaultIfEmpty((digit: -1, index: int.MinValue))
                        .MaxBy(x => x.index);

                    if (rightMostDigitIndex > -1 && rightMostDigitIndex > rightIndex.index)
                    {
                        d[1] = input[i][rightMostDigitIndex];
                    }
                    else
                    {
                        d[1] = (char)('0' + rightIndex.digit);
                    }
                }

                var num = int.Parse(d);
                total += num;
            }
            return total.ToString();
        }
    }
}
