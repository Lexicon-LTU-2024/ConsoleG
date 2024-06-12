using Consoleg.ConsoleGame.Extensions;
using Microsoft.Extensions.Configuration;
using Moq;

namespace ConsoleGame.Tests
{
    public class MapTests
    {
        [Fact]
        public void Constructor_SetCorrectWidth_WithExtenion2()
        {
            //Arrange
            const int expectedWidth = 10;

            var iconfigMock = new Mock<IConfiguration>();
            var getMapSizeMock = new Mock<IGetMapSizeFor>();

            getMapSizeMock.Setup(x => x.GetMapSizeFor(iconfigMock.Object, It.IsAny<string>())).Returns(expectedWidth);
            ConfigExtensions2.Implementation = getMapSizeMock.Object;

            //Act
            var map = new Map(iconfigMock.Object);

            //Assert
            Assert.Equal(expectedWidth, map.Width);

        }
    }
}