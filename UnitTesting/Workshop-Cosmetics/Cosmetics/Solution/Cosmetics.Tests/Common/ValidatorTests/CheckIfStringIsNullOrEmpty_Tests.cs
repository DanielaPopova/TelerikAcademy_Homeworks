namespace Cosmetics.Tests.Common.ValidatorTests
{
    using NUnit.Framework;
    using System;
    using Cosmetics.Common;

    [TestFixture]
    public class CheckIfStringIsNullOrEmpty_Tests
    {
        [TestCase("")]
        [TestCase(null)]
        public void CheckIfStringIsNullOrEmpty_TextIsNullOrEmpty_ShouldThrowNullreferneceException(string nullOrEmptyText)
        {
            Assert.Throws<NullReferenceException>(() => Validator.CheckIfStringIsNullOrEmpty(nullOrEmptyText));
        }
       
        [TestCase]
        public void CheckIfStringIsNullOrEmpty_TextIsNotNullOrEmpty_ShouldNotThrowNullreferneceException()
        {
            //Arrange
            string notNullOrEmptryText = "someText";

            //Act/Assert
            Assert.DoesNotThrow(() => Validator.CheckIfStringIsNullOrEmpty(notNullOrEmptryText));
        }

    }
}
