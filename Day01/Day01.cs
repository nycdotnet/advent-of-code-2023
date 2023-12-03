using Common;
using System.Buffers;

namespace Day01
{
    public class Day01(string[] input) : IAdventOfCodeDay
    {
        private static readonly SearchValues<char> numericDigits = SearchValues.Create("0123456789");
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

        public string GetAnswerForPart1()
        {
            var total = 0;
            var d = new char[2];
            for (var i = 0; i < input.Length; i++)
            {
                var leftMostIndex = input[i].AsSpan().IndexOfAny(numericDigits);
                var rightMostIndex = input[i].AsSpan().LastIndexOfAny(numericDigits);
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

            for (var i = 0; i < input.Length; i++)
            {
                var leftMostDigitIndex = input[i].AsSpan().IndexOfAny(numericDigits);
                if (leftMostDigitIndex == 0)
                {
                    d[0] = input[i][leftMostDigitIndex];
                }
                else
                {
                    var (stringDigit, stringDigitIndex) = textDigits
                        .Select((td, idx) => (digit: idx, index: input[i].IndexOf(td)))
                        .Where(x => x.index > -1)
                        .DefaultIfEmpty((digit: -1, index: int.MaxValue))
                        .MinBy(x => x.index);

                    if (leftMostDigitIndex > -1 && leftMostDigitIndex < stringDigitIndex)
                    {   
                        d[0] = input[i][leftMostDigitIndex];
                    }
                    else
                    {
                        d[0] = (char)('0' + stringDigit);
                    }    
                }

                var rightMostDigitIndex = input[i].AsSpan().LastIndexOfAny(numericDigits);
                if (rightMostDigitIndex == input[i].Length - 1)
                {
                    d[1] = input[i][rightMostDigitIndex];
                }
                else
                {
                    var (stringDigit, stringDigitIndex) = textDigits
                        .Select((td, idx) => (digit: idx, index: input[i].LastIndexOf(td)))
                        .Where(x => x.index > -1)
                        .DefaultIfEmpty((digit: -1, index: int.MinValue))
                        .MaxBy(x => x.index);

                    if (rightMostDigitIndex > -1 && rightMostDigitIndex > stringDigitIndex)
                    {
                        d[1] = input[i][rightMostDigitIndex];
                    }
                    else
                    {
                        d[1] = (char)('0' + stringDigit);
                    }
                }

                var num = int.Parse(d);
                total += num;
            }
            return total.ToString();
        }
    }
}
