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
        [TestCase(-1)]        
        public void Size_PassedValueIsInvalid_ShouldThrowArgumentException(int invalidSize)
        {  
            Assert.Throws<ArgumentException>(() => new SquareMatrix(invalidSize));
        }

        [TestCase(-1, 0)]
        [TestCase(-1, -1)]
        [TestCase(0, -1)]
        [TestCase(4, 3)]
        [TestCase(4, 4)]
        [TestCase(3, 4)]
        [TestCase(-1, 4)]
        public void Indexator_GettingCellWithInvalidRowCol_ShouldThrowIndexOutOfRangeException(int row, int col)
        {
            var matrix = new SquareMatrix(4);
            int someValue;

            Assert.Throws<IndexOutOfRangeException>(() => someValue = matrix[row, col]);
        }

        [TestCase(-1, 0)]
        [TestCase(-1, -1)]
        [TestCase(0, -1)]
        [TestCase(4, 3)]
        [TestCase(4, 4)]
        [TestCase(3, 4)]
        [TestCase(-1, 4)]
        public void Indexator_SettingCellWithInvalidRowCol_ShouldThrowIndexOutOfRangeException(int row, int col)
        {
            var matrix = new SquareMatrix(4);
            int someValue = 12;

            Assert.Throws<IndexOutOfRangeException>(() => matrix[row, col] = someValue);
        }
    }
}
