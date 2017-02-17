namespace PackageManager.Tests.Models.PackageTests
{
    using System;

    using NUnit.Framework;
    using Moq;

    using PackageManager.Models.Contracts;
    using PackageManager.Models;
    using PackageManager.Enums;

    [TestFixture]
    public class Properties_Tests
    {
        //Test if Name is set correctly
        [Test]
        public void Name_PassedNameIsNull_ShouldThrowArgumentNullException()
        {
            //Arrange
            string nullName = null;
            var versionMock = new Mock<IVersion>();

            //Act/Assert
            Assert.Throws<ArgumentNullException>(() => new Package(nullName, versionMock.Object));
        }

        [Test]
        public void Name_PassedNameIsValid_ShouldNotThrowArgumentNullException()
        {
            //Arrange
            string validName = "someName";
            var versionMock = new Mock<IVersion>();

            //Act/Assert
            Assert.DoesNotThrow(() => new Package(validName, versionMock.Object));
        }

        //Test if Version is set correctly
        [Test]
        public void Version_PassedVersionIsNull_ShouldThrowArgumenNullException()
        {
            //Arrange
            string validName = "someName";
            IVersion nullVersion = null;

            //Act/Assert
            Assert.Throws<ArgumentNullException>(() => new Package(validName, nullVersion));
        }

        [Test]
        public void Version_PassedVersionIsValid_ShouldNotThrowArgumenNullException()
        {
            //Arrange
            string validName = "someName";
            var validVersion = new Mock<IVersion>();

            //Act/Assert
            Assert.DoesNotThrow(() => new Package(validName, validVersion.Object));
        }

        //Test if Url is set correctly
        [Test]
        public void Url_PassedVersionIsValid_ShouldCorrectlySetUrl()
        {
            //Arrange
            string validName = "someName";
            var versionMock = new Mock<IVersion>();
            versionMock.SetupGet(v => v.Major).Returns(1);
            versionMock.SetupGet(v => v.Minor).Returns(2);
            versionMock.SetupGet(v => v.Patch).Returns(3);
            versionMock.SetupGet(v => v.VersionType).Returns(VersionType.alpha);

            string expectedUrl = "1.2.3-alpha";

            //Act
            var package = new Package(validName, versionMock.Object);

            //Assert
            Assert.AreEqual(expectedUrl, package.Url);
        }
    }
}
