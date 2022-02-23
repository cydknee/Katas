using System;
using System.Collections.Generic;

namespace RomanNumerals.App
{
    public class ArabicToRoman
    {
        public List<(string roman, int arabic)> values = new List<(string roman, int arabic)>
        {
            ("M", 1000),
            ("D", 500),
            ("C", 100),
            ("L", 50),
            ("X", 10),
            ("V", 5),
            ("I", 1)
        };

        public string CalcNumerals(int number)
        {
            var numeralString = "";

            for (var i = 0; i < values.Count - 1; i++)
            {
                (numeralString, number) = TensOrFives(number, values[i].arabic, values[i].roman, numeralString);
                if (values[i].arabic.ToString().StartsWith("5"))
                    (numeralString, number) = FourOrNines(values[i + 1].roman + values[i].roman, number, numeralString, values[i].arabic - values[i + 1].arabic);
                else
                    (numeralString, number) = FourOrNines(values[i + 2].roman + values[i].roman, number, numeralString, values[i].arabic - values[i + 2].arabic);
            }

            numeralString = AddLettersToString(values[values.Count - 1].roman, number, numeralString);

            return numeralString;
        }

        public (string, int) TensOrFives(int input, int arabic, string roman, string numeralString)
        {
            var numberOfLetters = Math.Floor(Convert.ToDecimal(input / arabic));
            numeralString = AddLettersToString(roman, numberOfLetters, numeralString);
            input -= Convert.ToInt32(numberOfLetters * arabic);

            return (numeralString, input);
        }

        public (string, int) FourOrNines(string letter, int number, string numeralString, int numberOnTest)
        {
            if (number >= numberOnTest)
            {
                numeralString += letter;
                number -= numberOnTest;
            }
            return (numeralString, number);
        }

        public string AddLettersToString(string letter, decimal numberOfLetters, string numeralString)
        {
            for (var i = 0; i < numberOfLetters; i++)
                numeralString += letter;

            return numeralString;
        }
    }
}
