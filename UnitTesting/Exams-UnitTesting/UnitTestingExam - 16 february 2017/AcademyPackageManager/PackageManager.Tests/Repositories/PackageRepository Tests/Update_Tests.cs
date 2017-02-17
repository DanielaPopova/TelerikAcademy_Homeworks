﻿namespace PackageManager.Tests.Repositories.PackageRepository_Tests
{
    using System;
    using System.Collections.Generic;

    using NUnit.Framework;
    using Moq;

    using PackageManager.Info.Contracts;
    using PackageManager.Enums;
    using PackageManager.Repositories;
    using PackageManager.Models.Contracts;
    using PackageManager.Models;

    [TestFixture]
    public class Update_Tests
    {
        //Test for valid and invalid value package
        [Test]
        public void Update_PassedPackageIsNull_ShouldThrowArgumentNullException()
        {
            //Arrange
            var loggerMock = new Mock<ILogger>();
            var repo = new PackageRepository(loggerMock.Object);

            IPackage nullPackage = null;

            //Act/Assert
            Assert.Throws<ArgumentNullException>(() => repo.Update(nullPackage));
        }

        //Test for package not found
        [Test]
        public void Update_PassedPackageIsValidButNotFound_ShouldThrowArgumentNullException()
        {
            //Arrange
            var loggerMock = new Mock<ILogger>();

            var packageInPackages = new Mock<IPackage>();
            packageInPackages.SetupGet(p => p.Name).Returns("someOtherName");
            var packagesMock = new List<IPackage>() { packageInPackages.Object };

            var repo = new PackageRepository(loggerMock.Object);

            var packageToUpdateMock = new Mock<IPackage>();
            packageToUpdateMock.SetupGet(p => p.Name).Returns("someName");

            //Act/Assert
            Assert.Throws<ArgumentNullException>(() => repo.Update(packageToUpdateMock.Object));
        }

        //Test for successfully updated package when there is package found with lower version
        [Test]
        [Ignore("cannot assign packageFound.Version to package.Version, probably because of Returns, then how to check the change?")]
        public void Update_PackageWithLowerVersionIsFound_ShouldBeSuccessfullyUpdated()
        {
            //Arrange
            var loggerMock = new Mock<ILogger>();

            var packageInPackages = new Mock<IPackage>();
            packageInPackages.SetupGet(p => p.Name).Returns("someName");
            packageInPackages.Setup(p => p.Version).Returns(new PackageVersion(2, 3, 2, Enums.VersionType.beta));

            var packages = new List<IPackage>() { packageInPackages.Object };

            var repo = new PackageRepository(loggerMock.Object, packages);

            var packageToUpdateMock = new Mock<IPackage>();
            packageToUpdateMock.SetupGet(p => p.Name).Returns("someName");
            packageToUpdateMock.SetupGet(p => p.Version).Returns(new PackageVersion(1, 2, 3, VersionType.alpha));
            packageToUpdateMock.Setup(p => p.CompareTo(It.IsAny<IPackage>())).Returns(1);

            //Act
            repo.Update(packageToUpdateMock.Object);

            //Assert
            Assert.AreSame(packageToUpdateMock.Object.Version, packageInPackages.Object.Version);
            //Assert.AreEqual(1, packageInPackages.Object.Version.Major);
            //Assert.AreEqual(packageToUpdateMock.Object.Version.Major, packageInPackages.Object.Version.Major);
        }

        [Test]
        public void Update_PackageWithLowerVersionIsFound_ShouldReturnTrue()
        {
            //Arrange
            var loggerMock = new Mock<ILogger>();

            var packageInPackages = new Mock<IPackage>();
            packageInPackages.SetupGet(p => p.Name).Returns("someName");
            packageInPackages.SetupGet(p => p.Version).Returns(new PackageVersion(2, 3, 2, Enums.VersionType.beta));

            var packages = new List<IPackage>() { packageInPackages.Object };

            var repo = new PackageRepository(loggerMock.Object, packages);

            var packageToUpdateMock = new Mock<IPackage>();
            packageToUpdateMock.SetupGet(p => p.Name).Returns("someName");
            packageToUpdateMock.SetupGet(p => p.Version).Returns(new PackageVersion(1, 2, 3, Enums.VersionType.alpha));
            packageToUpdateMock.Setup(p => p.CompareTo(It.IsAny<IPackage>())).Returns(1);

            //Act/Assert
            Assert.AreEqual(true, repo.Update(packageToUpdateMock.Object));
        }

        //Test for found package with higher version
        [Test]
        public void Update_PackageWithHigherVersionIsFound_ShouldThrowArgumentException()
        {
            //Arrange
            var loggerMock = new Mock<ILogger>();

            var packageInPackages = new Mock<IPackage>();
            packageInPackages.SetupGet(p => p.Name).Returns("someName");
            
            var packages = new List<IPackage>() { packageInPackages.Object };

            var repo = new PackageRepository(loggerMock.Object, packages);

            var packageToUpdateMock = new Mock<IPackage>();
            packageToUpdateMock.SetupGet(p => p.Name).Returns("someName");           
            packageToUpdateMock.Setup(p => p.CompareTo(It.IsAny<IPackage>())).Returns(-1);

            //Act/Assert
            Assert.Throws<ArgumentException>(() => repo.Update(packageToUpdateMock.Object));
        }

        //Test for found package with the same version
        [Test]
        public void Update_PackageWithSameVersionIsFound_ShouldReturnFalse()
        {
            //Arrange
            var loggerMock = new Mock<ILogger>();
            loggerMock.Setup(l => l.Log(It.IsAny<string>()));

            var packageInPackages = new Mock<IPackage>();
            packageInPackages.SetupGet(p => p.Name).Returns("someName");

            var packages = new List<IPackage>() { packageInPackages.Object };

            var repo = new PackageRepository(loggerMock.Object, packages);

            var packageToUpdateMock = new Mock<IPackage>();
            packageToUpdateMock.SetupGet(p => p.Name).Returns("someName");
            packageToUpdateMock.Setup(p => p.CompareTo(It.IsAny<IPackage>())).Returns(0);

            //Act/Assert
            Assert.AreEqual(false, repo.Update(packageToUpdateMock.Object));
        }

        [Test]
        public void Update_PackageWithSameVersionIsFound_ShouldLogOnce()
        {
            //Arrange
            var loggerMock = new Mock<ILogger>();
            loggerMock.Setup(l => l.Log(It.IsAny<string>()));

            var packageInPackages = new Mock<IPackage>();
            packageInPackages.SetupGet(p => p.Name).Returns("someName");

            var packages = new List<IPackage>() { packageInPackages.Object };

            var repo = new PackageRepository(loggerMock.Object, packages);

            var packageToUpdateMock = new Mock<IPackage>();
            packageToUpdateMock.SetupGet(p => p.Name).Returns("someName");
            packageToUpdateMock.Setup(p => p.CompareTo(It.IsAny<IPackage>())).Returns(0);

            //Act
            repo.Update(packageToUpdateMock.Object);

            //Assert
            loggerMock.Verify(l => l.Log(It.IsAny<string>()), Times.Once);
        }
    }
}
