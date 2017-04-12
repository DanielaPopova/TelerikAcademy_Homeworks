namespace WalkInMatrix.Tests.Models
{
    using System;    

    using WalkInMatrix.Models;

    using NUnit.Framework;

    [TestFixture]
    public class SquareMatrixTests
    {
        [Test]
        public void Constructor_PassedSize_ShouldBeCorrectlyAssigned()
        {
            int validSize = 5;

            var squareMatrix = new SquareMatrix(validSize);

            Assert.AreEqual(validSize, squareMatrix.Size);
        }

        [TestCase(0)]
        [TestCase(-2)]
        public void Size_PassedValueIsSmallerThanZero_ShouldThrowArgumentException(int invalidSize)
        {  
            Assert.Throws<ArgumentException>(() => new SquareMatrix(invalidSize));
        }

        [TestCase(-1, 2)]
        [TestCase(4, 2)]
        [TestCase(-1, 4)]        
        public void Indexator_GettingRowAndColOutsideMatrixBorder_ShouldThrowIndexOutOfRangeException(int row, int col)
        {
            int validSize = 4;
            var matrix = new SquareMatrix(validSize);
            int invalid;

            Assert.Throws<IndexOutOfRangeException>(() => invalid = matrix[row, col]);
        }

        [TestCase(-1, 2)]
        [TestCase(4, 2)]
        [TestCase(-1, 4)]
        public void Indexator_SettingMatrixCellWithInvalidRowAndColToValue_ShouldThrowIndexOutOfRangeException(int row, int col)
        {
            int validSize = 4;
            var matrix = new SquareMatrix(validSize);
           
            Assert.Throws<IndexOutOfRangeException>(() => matrix[row, col] = 2);
        }

        [TestCase(0, 0)]
        [TestCase(1, 2)]
        [TestCase(3, 3)]
        public void Indexator_GettingMatrixCellWithValidRowAndCol_ShouldReturnCorrectValue(int row, int col)
        {
            int validSize = 4;
            var matrix = new SquareMatrix(validSize);            

            Assert.AreEqual(0, matrix[row, col]);
        }

        [TestCase(0, 0)]
        [TestCase(1, 2)]
        [TestCase(3, 3)]
        public void Indexator_SettingMatrixCellWithValidRowAndColToValue_ShouldReturnCorrectValue(int row, int col)
        {
            int validSize = 4;
            var matrix = new SquareMatrix(validSize);
            int validValue = 2;

            // Act
            matrix[row, col] = 2;

            Assert.AreEqual(validValue, matrix[row, col]);
        }

        [Test]
        public void ToString_ShouldPrintMatrixCorrectly()
        {
            var matrix = new SquareMatrix(2);
            string expectedOutput = "    0    0\r\n    0    0\r\n";

            var actual = matrix.ToString();

            Assert.AreEqual(expectedOutput, actual);
        }
    }
}
