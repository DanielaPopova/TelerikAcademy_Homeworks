namespace PackageManager.Tests.Repositories.PackageRepository_Tests
{
    using System;
    using System.Collections.Generic;

    using NUnit.Framework;
    using Moq;

    using Info.Contracts;
    using PackageManager.Repositories;
    using PackageManager.Models.Contracts;
    using Enums;
    using PackageManager.Models;

    [TestFixture]
    public class Add_Tests
    {
        //Test for valid and invalid value package
        [Test]
        public void Add_PassedPackageIsNull_ShouldThrowArgumentNullException()
        {
            //Arrange
            var loggerMock = new Mock<ILogger>();
            var repo = new PackageRepository(loggerMock.Object);

            IPackage nullPackage = null;

            //Act/Assert
            Assert.Throws<ArgumentNullException>(() => repo.Add(nullPackage));
        }

        //Test for adding the package when the package does not exist
        [Test]
        public void Add_PassedPackageDoesNotExist_ShouldBeAddedToCurrentRepoPackagesListAndReturn()
        {
            //Arrange
            var loggerMock = new Mock<ILogger>();
            loggerMock.Setup(l => l.Log(It.IsAny<string>()));
            var packageMock = new Mock<IPackage>();
            packageMock.SetupGet(p => p.Name).Returns("someOtherName");
            var packages = new List<IPackage>(){ packageMock.Object};

            var repo = new ExtendedPackageRepository(loggerMock.Object, packages);

            var packageToAddMock = new Mock<IPackage>();
            packageToAddMock.SetupGet(p => p.Name).Returns("someName");

            //Act
            repo.Add(packageToAddMock.Object);

            //Assert
            CollectionAssert.Contains(repo.Packages, packageToAddMock.Object);
        }

        //Test for package already exist with the same version
        [Test]
        public void Add_PackageWithSameVersionAlreadyExists_ShouldLog3TimesAndReturn()
        {
            //Arrange
            var loggerMock = new Mock<ILogger>();
            loggerMock.Setup(l => l.Log(It.IsAny<string>()));

            var packageMock = new Mock<IPackage>();
            packageMock.SetupGet(p => p.Name).Returns("someName");

            var packages = new List<IPackage>() { packageMock.Object };

            var repo = new ExtendedPackageRepository(loggerMock.Object, packages);

            var packageToAddMock = new Mock<IPackage>();
            packageToAddMock.SetupGet(p => p.Name).Returns("someName");
            packageToAddMock.Setup(p => p.CompareTo(It.IsAny<IPackage>())).Returns(0);

            //Act
            repo.Add(packageToAddMock.Object);

            //Assert
            loggerMock.Verify(l => l.Log(It.IsAny<string>()), Times.Exactly(3));
        }

        //Test for calling the Update method when the package exist but with lower version
        //DO NOT MOCK the System under test
        [Test]
        public void Add_PackageWithLowerVersionIsFound_ShouldCallUpdate()
        {
            //Arrange
            var loggerMock = new Mock<ILogger>();
            loggerMock.Setup(l => l.Log(It.IsAny<string>()));

            var packageMock = new Mock<IPackage>();
            packageMock.SetupGet(p => p.Name).Returns("someName");

            var packages = new List<IPackage>() { packageMock.Object };

            var repo = new ExtendedPackageRepository(loggerMock.Object, packages);

            var packageToAddMock = new Mock<IPackage>();
            packageToAddMock.SetupGet(p => p.Name).Returns("someName");
           
            packageToAddMock.Setup(p => p.CompareTo(It.IsAny<IPackage>())).Returns(1);

            //Act
            repo.Add(packageToAddMock.Object);

            //Assert
            Assert.AreEqual(true, repo.Update(packageToAddMock.Object));
        }

        //Test for package with higher version already exist
        [Test]
        public void Add_PackageWithHigherVersionIsFound_ShouldLog2TimesAndReturn()
        {
            //Arrange
            var loggerMock = new Mock<ILogger>();
            loggerMock.Setup(l => l.Log(It.IsAny<string>()));

            var packageMock = new Mock<IPackage>();
            packageMock.SetupGet(p => p.Name).Returns("someName");
            //packageMock.SetupGet(p => p.Version).Returns(new PackageVersion(2, 1, 3, VersionType.alpha));
           
            var packages = new List<IPackage>() { packageMock.Object };

            var repo = new ExtendedPackageRepository(loggerMock.Object, packages);

            var packageToAddMock = new Mock<IPackage>();
            packageToAddMock.SetupGet(p => p.Name).Returns("someName");
           //packageToAddMock.SetupGet(p => p.Version).Returns(new PackageVersion(1, 2, 2, VersionType.alpha));
            packageToAddMock.Setup(p => p.CompareTo(It.IsAny<IPackage>())).Returns(-1);

            //Act
            repo.Add(packageToAddMock.Object);

            //Assert
            loggerMock.Verify(l => l.Log(It.IsAny<string>()), Times.Exactly(2));
        }
    }
}
