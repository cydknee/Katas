using Xunit;
using Shouldly;

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
            var romanNumerals = new RomanNumerals.Program();

            //Act
            var calculatedNumeral = romanNumerals.CalcNumerals(arabic);

            //Assert
            calculatedNumeral.ShouldBe(roman);
        }
    }
}
