namespace PackageManager.Tests.Models.PackageTests
{
    using System;

    using NUnit.Framework;
    using Moq;

    using PackageManager.Models.Contracts;
    using PackageManager.Models;
    using PackageManager.Enums;

    [TestFixture]
    public class CompareTo_Tests
    {
        //Test for valid and invalid value other
        [Test]
        public void CompareTo_PassedOtherValueIsNull_ShouldThrowArgumentNullException()
        {
            //Arrange
            string name = "someName";
            var versionMock = new Mock<IVersion>();
            var package = new Package(name, versionMock.Object);

            IPackage nullOther = null;

            //Act/Assert
            Assert.Throws<ArgumentNullException>(() => package.CompareTo(nullOther));
        }

        [Test]
        public void CompareTo_PassedOtherValueIsValid_ShouldNotThrowArgumentNullException()
        {
            //Arrange
            string name = "someName";
            var versionMock = new Mock<IVersion>();
            versionMock.SetupGet(v => v.Major).Returns(2);
            versionMock.SetupGet(v => v.Minor).Returns(1);
            versionMock.SetupGet(v => v.Patch).Returns(3);
            versionMock.SetupGet(v => v.VersionType).Returns(VersionType.alpha);

            var package = new Package(name, versionMock.Object);

            var otherPackageMock = new Mock<IPackage>();
            otherPackageMock.SetupGet(p => p.Name).Returns(name);
            otherPackageMock.SetupGet(v => v.Version.Major).Returns(3);
            otherPackageMock.SetupGet(v => v.Version.Minor).Returns(4);
            otherPackageMock.SetupGet(v => v.Version.Patch).Returns(5);
            otherPackageMock.SetupGet(v => v.Version.VersionType).Returns(VersionType.final);

            //Act/Assert
            Assert.DoesNotThrow(() => package.CompareTo(otherPackageMock.Object));
        }

        //Test if the passed package is not with the same name
        [Test]
        public void CompareTo_PassedOtherPackageNameAndCurrentPackageNameAreSame_ShouldThrowArgumentException()
        {
            //Arrange
            string name = "someName";
            var versionMock = new Mock<IVersion>();
            var package = new Package(name, versionMock.Object);

            var otherPackageMock = new Mock<IPackage>();
            otherPackageMock.SetupGet(p => p.Name).Returns("someOtherName");

            //Act/Assert
            Assert.Throws<ArgumentException>(() => package.CompareTo(otherPackageMock.Object));
        }

        //Test for package passed to be higher version
        [Test]
        public void CompareTo_PassedOtherPackageIsHigherVersion_ShouldReturnMinusOne()
        {
            //Arrange
            string name = "someName";
            var versionMock = new Mock<IVersion>();
            versionMock.SetupGet(v => v.Major).Returns(2);
            versionMock.SetupGet(v => v.Minor).Returns(1);
            versionMock.SetupGet(v => v.Patch).Returns(3);
            versionMock.SetupGet(v => v.VersionType).Returns(VersionType.alpha);

            var package = new Package(name, versionMock.Object);

            var otherPackageMock = new Mock<IPackage>();
            otherPackageMock.SetupGet(p => p.Name).Returns(name);
            otherPackageMock.SetupGet(v => v.Version.Major).Returns(3);
            otherPackageMock.SetupGet(v => v.Version.Minor).Returns(4);
            otherPackageMock.SetupGet(v => v.Version.Patch).Returns(5);
            otherPackageMock.SetupGet(v => v.Version.VersionType).Returns(VersionType.final);

            //Act
            var actual = package.CompareTo(otherPackageMock.Object);

            //Assert
            Assert.AreEqual(-1, actual);
        }

        //Test for package passed to be lower version
        [Test]
        public void CompareTo_PassedOtherPackageIsLowerVersion_ShouldReturnOne()
        {
            //Arrange
            string name = "someName";
            var versionMock = new Mock<IVersion>();
            versionMock.SetupGet(v => v.Major).Returns(3);
            versionMock.SetupGet(v => v.Minor).Returns(4);
            versionMock.SetupGet(v => v.Patch).Returns(5);
            versionMock.SetupGet(v => v.VersionType).Returns(VersionType.final);

            var package = new Package(name, versionMock.Object);

            var otherPackageMock = new Mock<IPackage>();
            otherPackageMock.SetupGet(p => p.Name).Returns(name);
            otherPackageMock.SetupGet(v => v.Version.Major).Returns(1);
            otherPackageMock.SetupGet(v => v.Version.Minor).Returns(2);
            otherPackageMock.SetupGet(v => v.Version.Patch).Returns(3);
            otherPackageMock.SetupGet(v => v.Version.VersionType).Returns(VersionType.alpha);

            //Act
            var actual = package.CompareTo(otherPackageMock.Object);

            //Assert
            Assert.AreEqual(1, actual);
        }

        //Test for package passed to be the same version
        [Test]
        public void CompareTo_PassedOtherPackageAndCurrentPackageHaveSameVersion_ShouldReturnZero()
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
            otherPackageMock.SetupGet(p => p.Name).Returns(name);
            otherPackageMock.SetupGet(v => v.Version.Major).Returns(1);
            otherPackageMock.SetupGet(v => v.Version.Minor).Returns(2);
            otherPackageMock.SetupGet(v => v.Version.Patch).Returns(3);
            otherPackageMock.SetupGet(v => v.Version.VersionType).Returns(VersionType.alpha);

            //Act
            var actual = package.CompareTo(otherPackageMock.Object);

            //Assert
            Assert.AreEqual(0, actual);
        }
    }
}
