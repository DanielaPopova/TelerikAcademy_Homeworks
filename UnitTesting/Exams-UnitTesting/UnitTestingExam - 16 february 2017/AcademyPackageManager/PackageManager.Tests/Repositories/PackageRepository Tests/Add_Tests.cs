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
            packageMock.SetupGet(p => p.Version.Major).Returns(1);
            packageMock.SetupGet(p => p.Version.Minor).Returns(1);
            packageMock.SetupGet(p => p.Version.Patch).Returns(1);
            packageMock.SetupGet(p => p.Version.VersionType).Returns(VersionType.alpha);

            var packages = new List<IPackage>() { packageMock.Object };

            var repo = new ExtendedPackageRepository(loggerMock.Object, packages);

            var packageToAddMock = new Mock<IPackage>();
            packageToAddMock.SetupGet(p => p.Name).Returns("someName");            
            packageToAddMock.SetupGet(p => p.Version.Major).Returns(1);
            packageToAddMock.SetupGet(p => p.Version.Minor).Returns(1);
            packageToAddMock.SetupGet(p => p.Version.Patch).Returns(1);
            packageToAddMock.SetupGet(p => p.Version.VersionType).Returns(VersionType.alpha);

            //Act
            repo.Add(packageToAddMock.Object);

            //Assert
            loggerMock.Verify(l => l.Log(It.IsAny<string>()), Times.Exactly(3));
        }
    }
}
