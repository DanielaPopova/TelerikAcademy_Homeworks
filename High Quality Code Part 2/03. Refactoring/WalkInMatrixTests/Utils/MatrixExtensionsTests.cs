namespace WalkInMatrixTests.Utils
{    
    using WalkInMatrix.Contracts;   
    using WalkInMatrix.Models;
    using WalkInMatrix.Utils;

    using Moq;
    using NUnit.Framework;

    [TestFixture]
    public class MatrixExtensionsTests
    {
        [TestCase(-1, 2)]
        [TestCase(0, -1)]
        [TestCase(4, 4)]
        public void IsOutsideMatrixBorders_PassedCellCoordinatesAreOutsideMatrixBorders_ShouldReturnTrue(int x, int y)
        {
            var matrixSize = 4;

            var invalidMatrixCell = new Coordinates(x, y);
            var directionMock = new Mock<ICoordinates>();

            var expected = true;
            var actualResult = MatrixExtensions.IsOutsideMatrixBorders(invalidMatrixCell, directionMock.Object, matrixSize);

            Assert.AreEqual(expected, actualResult);
        }

        [TestCase(1, 1)]
        [TestCase(0, 2)]       
        public void IsOutsideMatrixBorders_PassedCellCoordinatesAreInsideMatrixBorders_ShouldReturnFalse(int x, int y)
        {
            var matrixSize = 4;

            var matrixCell = new Coordinates(x, y);
            var directionMock = new Mock<ICoordinates>();

            var expected = false;
            var actualResult = MatrixExtensions.IsOutsideMatrixBorders(matrixCell, directionMock.Object, matrixSize);

            Assert.AreEqual(expected, actualResult);
        }

        [Test]
        public void FindEmptyCell_WhenValidMAtrixIsPassed_ShouldReturnCorectCoordinates()
        {

        }
    }
}
