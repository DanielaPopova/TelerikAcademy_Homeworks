namespace Cosmetics.Tests.Common.ValidatorTests
{
    using NUnit.Framework;
    using System;
    using Cosmetics.Common;

    [TestFixture]
    public class CheckIfNull_Tests
    {
        [Test]
        public void CheckIfNull_ObjIsNull_ShouldThrowNullReferenceException()
        {
            //Arrange
            string nullObj = null;

            //Act/Assert
            Assert.Throws<NullReferenceException>(() => Validator.CheckIfNull(nullObj));
        }

        [Test]
        public void CheckIfNull_ObjIsNotNull_ShouldNotThrowNullReferenceException()
        {
            //Arrange
            string validObj = "someObj";

            //Act/Assert
            Assert.DoesNotThrow(() => Validator.CheckIfNull(validObj));
        }
    }
}
