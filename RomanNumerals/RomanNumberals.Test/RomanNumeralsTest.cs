using Xunit;
using Shouldly;
using RomanNumerals.App;

namespace RomanNumberals.Test
{
    public class RomanNumeralsTest
    {
        [Theory]
        [InlineData(2000, "MM")]
        [InlineData(300, "CCC")]
        [InlineData(150, "CL")]
        [InlineData(140, "CXL")]
        [InlineData(1900, "MCM")]
        [InlineData(1444, "MCDXLIV")]
        [InlineData(1642, "MDCXLII")]
        [InlineData(3, "III")]
        public void ReturnNumeralWhenGivenANumber(int arabic, string roman)
        {
            //Arange
            var arabicToRoman = new ArabicToRoman();

            //Act
            var calculatedNumeral = arabicToRoman.CalcNumerals(arabic);

            //Assert
            calculatedNumeral.ShouldBe(roman);
        }

        [Theory]
        [InlineData("MM", 2000)]
        [InlineData("CCC", 300)]
        [InlineData("CL", 150)]
        [InlineData("CXL", 140)]
        [InlineData("CM", 900)]
        [InlineData("MCDXLIV", 1444)]
        [InlineData("MDCXLII", 1642)]
        [InlineData("III", 3)]
        public void ReturnNumberWhenGivenANumeral(string roman, int arabic)
        {
            //Arange
            var romanToArabic = new RomanToArabic();

            //Act
            var calculatedNumber = romanToArabic.CalcNumerals(roman);

            //Assert
            calculatedNumber.ShouldBe(arabic);
        }
    }
}
