using System;
using Xunit;

namespace LoggingKata.Test
{
    public class TacoParserTests
    {
        [Fact]
        public void ShouldReturnNonNullObject()
        {
            //Arrange
            var tacoParser = new TacoParser();

            //Act
            var actual = tacoParser.Parse("34.073638, -84.677017, Taco Bell Acwort...");

            //Assert
            Assert.NotNull(actual);

        }

        [Theory]
        [InlineData("34.073638, -84.677017, Taco Bell Acwort...", -84.677017)]
        [InlineData("33.951387,-84.061032,Taco Bell Lawrenceville...",-84.061032)]
        [InlineData("33.594359,-86.122022,Taco Bell Lincoln...",-86.122022)]
        //Add additional inline data. Refer to your CSV file.
        public void ShouldParseLongitude(string line, double expected)
        {
            // TODO: Complete the test with Arrange, Act, Assert steps below.
            //       Note: "line" string represents input data we will Parse 
            //       to extract the Longitude.  
            //       Each "line" from your .csv file
            //       represents a TacoBell location ';];[;';
            //Arrange
            var tacoParser = new TacoParser();

            //Act
            var actual = tacoParser.Parse(line);

            //Assert
            Assert.Equal(expected, actual.Location.Longitude);
        }


        //TODO: Create a test called ShouldParseLatitude
        [Theory]
        [InlineData("30.192338,-85.83407,Taco Bell Panama City Beach...", -85.83407)]
        [InlineData("30.445296,-87.240548,Taco Bell Pensacola... ", -87.240548)]

        public void ShouldParseLatitude(string line, double expected)
        {
            var tacoParser = new TacoParser();
            
            var actual = tacoParser.Parse(line);
            
            Assert.Equal(expected, actual.Location.Latitude);
        }

    }
}
