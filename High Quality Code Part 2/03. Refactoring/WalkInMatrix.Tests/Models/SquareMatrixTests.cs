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
    }
}
