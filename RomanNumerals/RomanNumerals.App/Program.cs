using RomanNumerals.App;
using System;

namespace RomanNumerals
{
    public class Program
    {
        

        static void Main(string[] args)
        {
            var arabicToRoman = new ArabicToRoman();
            Console.WriteLine("Enter a number");
            var number = Console.ReadLine();
            var result = arabicToRoman.CalcNumerals(Convert.ToInt32(number));
            Console.WriteLine(result);
        }
    }
}