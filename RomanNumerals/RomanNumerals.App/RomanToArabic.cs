using System.Collections.Generic;

namespace RomanNumerals.App
{
    public class RomanToArabic
    {
        public List<(char roman, int arabic)> values = new List<(char roman, int arabic)>
        {
            ('?', 0),
            ('?', 0),
            ('M', 1000),
            ('D', 500),
            ('C', 100),
            ('L', 50),
            ('X', 10),
            ('V', 5),
            ('I', 1)
        };

        public int CalcNumerals(string numerals)
        {
            var numeralsStack = ConvertNumeralsToStack(numerals);
            var answer = 0;

            while (numeralsStack.Count != 1)
            {
                var numeral = numeralsStack.Pop().ToString();
                var numeralPair = numeral + numeralsStack.Peek().ToString();

                for (var j = 2; j < values.Count; j++)
                {
                    if (numeralPair == values[j].roman.ToString() + values[j - 1].roman.ToString())
                    {
                        answer += values[j - 1].arabic - values[j].arabic;
                        numeralsStack.Pop();
                    }
                    else if (numeralPair == values[j].roman.ToString() + values[j - 2].roman.ToString())
                    {
                        answer += values[j - 2].arabic - values[j].arabic;
                        numeralsStack.Pop();
                    }
                    else if (numeral == values[j].roman.ToString())
                        answer += values[j].arabic;
                }
            }
            return answer;
        }

        public Stack<char> ConvertNumeralsToStack(string numerals)
        {
            var numeralsStack = new Stack<char>();
            var reverseStack = new Stack<char>();

            numerals += "-";
            foreach (var i in numerals)
                numeralsStack.Push(i);

            while (numeralsStack.Count != 0)
                reverseStack.Push(numeralsStack.Pop());

            return reverseStack;
        }
    }
}
