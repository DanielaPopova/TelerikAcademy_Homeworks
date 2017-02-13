namespace Cosmetics.Tests.Common.ValidatorTests
{
    using System;
    using Cosmetics.Common;
    using NUnit.Framework;

    [TestFixture]
    public class CheckIfStringLengthIsValid_Tests
    {
        [TestCase("a")]
        [TestCase("aaaaaaaaaaa")]
        public void CheckIfStringLengthIsValid_TextLengthIsOutOfRange_ShouldThrowIndexOutOfRangeException(string invalidText)
        {
            //Arrange
            int minRange = 5;
            int maxRange = 10;

            //ActAssert
            Assert.Throws<IndexOutOfRangeException>(() => Validator.CheckIfStringLengthIsValid(invalidText, maxRange, minRange));
        }

        [Test]
        public void CheckIfStringLengthIsValid_TextLengthIsInRange_ShouldNotThrowIndexOutOfRangeException()
        {
            //Arrange
            int minRange = 5;
            int maxRange = 10;
            string validText = "someText";

            //Assert
            Assert.DoesNotThrow(() => Validator.CheckIfStringLengthIsValid(validText, maxRange, minRange));
        }
    }
}
