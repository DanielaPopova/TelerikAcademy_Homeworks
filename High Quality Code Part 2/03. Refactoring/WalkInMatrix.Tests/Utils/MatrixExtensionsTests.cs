namespace WalkInMatrixTests.Utils
{ 
    using Moq;
    using NUnit.Framework;
    
    using WalkInMatrix.Models;
    using WalkInMatrix.Contracts;
    using WalkInMatrix.Utils;

    [TestFixture]
    public class MatrixExtensionsTests
    {
        /// <summary>
        /// According to:
        /// int[] directionRow = { 1, 1, 1, 0, -1, -1, -1, 0 }
        /// int[] directionCol = { 1, 0, -1, -1, -1, 0, 1, 1 }
        /// when delta is directionRow[0]/directionCol[0] = (1, 1)
        /// changed delta should be one position to the right:
        /// directionRow[0 + 1]/directionCol[0 + 1] = (1, 0)
        /// </summary>        
        [TestCase(1, 1, 1, 0)]
        [TestCase(1, 0, 1, -1)]            
        [TestCase(0, 1, 1, 1)]
        public void ChangeDirection_PassedDeltaIsValid_ShouldChangeDeltaCorectly(int deltaX, int deltaY, int expectedDeltaX, int expectedDeltaY)
        {
            var delta = new Coordinates(deltaX, deltaY);            

            //Arrange
           MatrixExtensions.ChangeDirection(delta);

            Assert.AreEqual(expectedDeltaX, delta.X);
            Assert.AreEqual(expectedDeltaY, delta.Y);
            Assert.AreEqual(expectedDeltaX, delta.X);
            Assert.AreEqual(expectedDeltaY, delta.Y);
            Assert.AreEqual(expectedDeltaX, delta.X);
            Assert.AreEqual(expectedDeltaY, delta.Y);
        }

        [Test]
        public void IsNearCellEmpty_IfNextPositionInMatrixIsEmptyCell_ShouldReturnTrue()
        {
            var matrix = new int[,]
            {
                {1, 0, 0, 0, 0 },
                {12, 2, 0, 0, 0 },
                {11, 0, 3, 0, 0 },
                {10, 0, 0, 4, 0 },
                {9, 8, 7, 6, 5 }
            };

            var currentPosition = new Coordinates(1, 0); // first empty cell would be [2,1] diagonal clockwise
            var actual = matrix.IsNearCellEmpty(currentPosition);

            Assert.AreEqual(true, actual);
        }

        [Test]
        public void IsNearCellEmpty_IfNextPositionInMatrixIsNotEmptyCell_ShouldReturnFalse()
        {
            var matrix = new int[,]
            {
                {1, 13, 14, 15, 16 },
                {12, 2, 21, 22, 17 },
                {11, 0, 3, 20, 18 },
                {10, 0, 0, 4, 19 },
                {9, 8, 7, 6, 5 }
            };
            
            var currentPosition = new Coordinates(0, 0); 
            var actual = matrix.IsNearCellEmpty(currentPosition);

            Assert.AreEqual(false, actual);
        }

        [Test]
        public void FindEmptyCell_WhenThereIsEmptyCellInMatrix_ShouldReturnCoordinatesOfFirstFoundZero()
        {
            var matrix = new int[,]
            {
                {1, 13, 14, 15, 16 },
                {12, 2, 21, 22, 17 },
                {11, 0, 3, 20, 18 },
                {10, 0, 0, 4, 19 },
                {9, 8, 7, 6, 5 }
            };

            int expectedCoordinatesRow = 2;
            int expectedCoordinatesCol = 1;

            var actualCoordinates = matrix.FindEmptyCell(); // matrix[2, 1] - first found zero          

            Assert.AreEqual(expectedCoordinatesRow, actualCoordinates.X);
            Assert.AreEqual(expectedCoordinatesCol, actualCoordinates.Y);
        }

        [Test]
        public void FindEmptyCell_WhenThereIsNoEmptyCellInMatrix_ShouldReturnNull()
        {
            var matrix = new int[,]
            {
                {1, 13, 14, 15, 16 },
                {12, 2, 21, 22, 17 },
                {11, 23, 3, 20, 18 },
                {10, 25, 24, 4, 19 },
                {9, 8, 7, 6, 5 }
            };

            var actualCoordinates = matrix.FindEmptyCell(); // matrix[2, 1] - first found zero          

            Assert.AreEqual(null, actualCoordinates);
        }

        [TestCase(-1, 0)]
        [TestCase(0, -1)]
        [TestCase(-1, -1)]
        public void IsOutsideMatrixBorders_IfNewPositionIsOutOfRange_ShouldReturnTrue(int deltaX, int deltaY)
        {
           var matrix = new int[,]
           {
                {1, 13, 14, 15, 16 },
                {12, 2, 21, 22, 17 },
                {11, 23, 3, 20, 18 },
                {10, 25, 24, 4, 19 },
                {9, 8, 7, 6, 5 }
           };

            var cellMock = new Mock<ICoordinates>();
            cellMock.Setup(cell => cell.X).Returns(0);
            cellMock.Setup(cell => cell.Y).Returns(0);

            var expectedPosition = matrix.IsOutsideMatrixBorders(cellMock.Object, new Coordinates(deltaX, deltaY));

            Assert.AreEqual(true, expectedPosition);
        }

        [TestCase(1, 1)]
        [TestCase(0, 1)]
        [TestCase(1, 0)]
        public void IsOutsideMatrixBorders_IfNewPositionIsInRange_ShouldReturnFalse(int deltaX, int deltaY)
        {
            var matrix = new int[,]
            {
                {1, 13, 14, 15, 16 },
                {12, 2, 21, 22, 17 },
                {11, 23, 3, 20, 18 },
                {10, 25, 24, 4, 19 },
                {9, 8, 7, 6, 5 }
            };

            var cellMock = new Mock<ICoordinates>(); // cell in position matrix[0, 0]
            cellMock.Setup(cell => cell.X).Returns(0);
            cellMock.Setup(cell => cell.Y).Returns(0);

            var expectedPosition = matrix.IsOutsideMatrixBorders(cellMock.Object, new Coordinates(deltaX, deltaY));

            Assert.AreEqual(false, expectedPosition);
        }
    }
}
