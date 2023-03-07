using Console_Unit_Testing;
using Microsoft.VisualStudio.TestPlatform.TestHost;

namespace TestProject1
{
    public class UnitTest1
    {
        [Theory]
        [InlineData(2, 3, 6)]
        [InlineData(4, 5, 20)]
        [InlineData(0, 5, 0)]
        public double CalculateArea_ReturnsCorrectResult(double width, double height, double expectedResult)
        {
            // Arrange
            var program = new Class1();

            // Act
            double result = Class1.CalculateArea(width, height);

            // Assert
            Assert.Equal(expectedResult, result);
            return result;
        }
    }
}
