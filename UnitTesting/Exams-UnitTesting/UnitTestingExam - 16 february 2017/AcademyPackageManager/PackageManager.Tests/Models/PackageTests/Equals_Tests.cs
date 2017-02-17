namespace PackageManager.Tests.Models.PackageTests
{
    using System;

    using NUnit.Framework;
    using Moq;

    using PackageManager.Models.Contracts;
    using PackageManager.Models;
    using PackageManager.Enums;

    [TestFixture]
    public class Equals_Tests
    {
        //Test for valid and invalid value other
        [Test]
        public void Equals_PassedObjectIsNull_ShouldThrowArgumentNullException()
        {
            //Arrange
            string name = "someName";
            var versionMock = new Mock<IVersion>();
            var package = new Package(name, versionMock.Object);

            object nullObj = null;

            //Act/Assert
            Assert.Throws<ArgumentNullException>(() => package.Equals(nullObj));
        }

        //Test if the passed object is IPackage
        [Test]
        public void Equals_PassedObjectIsNotOfTypeIPackage_ShouldThrowArgumentException()
        {
            //Arrange
            string name = "someName";
            var versionMock = new Mock<IVersion>();
            var package = new Package(name, versionMock.Object);

            var someObj = "string";

            //Act/Assert
            Assert.Throws<ArgumentException>(() => package.Equals(someObj));
        }

        //Test for package passed to be equal to the package
        [Test]
        public void Equals_PassedPackageIsEqualToCurrentPackage_ShouldReturnTrue()
        {
            //Arrange
            string name = "someName";
            var versionMock = new Mock<IVersion>();
            versionMock.SetupGet(v => v.Major).Returns(1);
            versionMock.SetupGet(v => v.Minor).Returns(2);
            versionMock.SetupGet(v => v.Patch).Returns(3);
            versionMock.SetupGet(v => v.VersionType).Returns(VersionType.alpha);

            var package = new Package(name, versionMock.Object);

            var otherPackageMock = new Mock<IPackage>();
            otherPackageMock.SetupGet(v => v.Name).Returns(name);
            otherPackageMock.SetupGet(v => v.Version.Major).Returns(1);
            otherPackageMock.SetupGet(v => v.Version.Minor).Returns(2);
            otherPackageMock.SetupGet(v => v.Version.Patch).Returns(3);
            otherPackageMock.SetupGet(v => v.Version.VersionType).Returns(VersionType.alpha);

            //Act
            bool actual = package.Equals(otherPackageMock.Object);

            //Assert
            Assert.AreEqual(true, actual);
        }

        //Test for package passed to be NOT equal to the package
        [Test]
        public void Equals_PassedPackageIsNotEqualToCurrentPackage_ShouldReturnFalse()
        {
            //Arrange
            string name = "someName";
            var versionMock = new Mock<IVersion>();
            versionMock.SetupGet(v => v.Major).Returns(1);
            versionMock.SetupGet(v => v.Minor).Returns(2);
            versionMock.SetupGet(v => v.Patch).Returns(3);
            versionMock.SetupGet(v => v.VersionType).Returns(VersionType.alpha);

            var package = new Package(name, versionMock.Object);

            var otherPackageMock = new Mock<IPackage>();
            otherPackageMock.SetupGet(v => v.Name).Returns(name);
            otherPackageMock.SetupGet(v => v.Version.Major).Returns(2);
            otherPackageMock.SetupGet(v => v.Version.Minor).Returns(3);
            otherPackageMock.SetupGet(v => v.Version.Patch).Returns(4);
            otherPackageMock.SetupGet(v => v.Version.VersionType).Returns(VersionType.alpha);

            //Act
            bool actual = package.Equals(otherPackageMock.Object);

            //Assert
            Assert.AreEqual(false, actual);
        }
    }
}
