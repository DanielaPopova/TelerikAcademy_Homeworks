namespace Cosmetics.Tests.Common.ValidatorTests
{
    using System;

    using NUnit.Framework;
    using Cosmetics.Common;

    [TestFixture]
    public class CheckIfNull_Tests
    {
        [Test]
        public void CheckIfNull_ObjIsNull_ShouldThrowNullReferenceException()
        {
            //Arrange
            object nullObj = null;

            //Act/Assert
            Assert.Throws<NullReferenceException>(() => Validator.CheckIfNull(nullObj));
        }

        [Test]
        public void CheckIfNull_ObjIsNotNull_ShouldNotThrowNullReferenceException()
        {
            //Arrange
            object validObj = new object();

            //Act/Assert
            Assert.DoesNotThrow(() => Validator.CheckIfNull(validObj));
        }
    }
}
