namespace Academy.Tests
{
    using System;

    using NUnit.Framework;
    using Mocks;

    [TestFixture]
    public class UserTests
    {
        [Test]
        public void Constructor_PassedUsername_ShouldBeCorrectlyAssigned()
        {
            //Arrange
            string validUsername = "vaidUsername";

            //Act
            var user = new UserMock(validUsername);

            //Act/Assert
            Assert.AreEqual(validUsername, user.Username);
        }

        [Test]
        public void Username_PassedValueIsNull_ShouldThrowArgumentException()
        {
            //Arrange
            string nullName = null;

            //Act/Asser
            Assert.Throws<ArgumentException>(() => new UserMock(nullName)); 
        }

        [TestCase("a")]
        [TestCase("aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa")]
        public void Username_PassedValueIsNotInRange_ShouldThrowArgumentException(string outOfRangeUsername)
        {
            Assert.Throws<ArgumentException>(() => new UserMock(outOfRangeUsername));
        }

        [Test]
        public void Username_PassedValueIsValid_ShouldNotThrowArgumentException()
        {
            //Arrange
            string validName = "validName";

            //Act/Assert
            Assert.DoesNotThrow(() => new UserMock(validName));
        }

        [Test]
        public void Username_PassedValueIsValid_ShouldBeCorrectlyAssigned()
        {
            //Arrange
            string validName = "validName";

            //Act
            var user = new UserMock(validName);

            //Assert
            Assert.AreEqual(validName, user.Username);
        }
    }
}
