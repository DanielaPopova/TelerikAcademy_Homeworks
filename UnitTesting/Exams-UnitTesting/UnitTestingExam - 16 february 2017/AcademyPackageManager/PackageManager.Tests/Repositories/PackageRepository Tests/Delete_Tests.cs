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
    public class Delete_Tests
    {
        //Test for valid and invalid value package
        [Test]
        public void Delete_PassedPackageIsNull_ShouldThrowArgumentNullException()
        {
            //Arrange
            //Arrange
            var loggerMock = new Mock<ILogger>();
            var repo = new PackageRepository(loggerMock.Object);

            IPackage nullPackage = null;

            //Act/Assert
            Assert.Throws<ArgumentNullException>(() => repo.Delete(nullPackage));
        }

        //Test for package not found
        [Test]
        public void Delete_PackageIsValidButNotFound_ShouldThrowArgumentNullException()
        {
            //Arrange
            var loggerMock = new Mock<ILogger>();
            loggerMock.Setup(l => l.Log(It.IsAny<string>()));

            var packageMock = new Mock<IPackage>();
            packageMock.SetupGet(p => p.Name).Returns("someName");            
            packageMock.Setup(p => p.Equals(It.IsAny<IPackage>())).Returns(false);

            var packages = new List<IPackage>() { packageMock.Object };

            var repo = new ExtendedPackageRepository(loggerMock.Object, packages);

            var packageToDeleteMock = new Mock<IPackage>();           

            //Act/Assert
            Assert.Throws<ArgumentNullException>(() => repo.Delete(packageToDeleteMock.Object));
        }

        //Test for package found but is a dependency of other projects and cannot be removed
        [Test]
        public void Delete_PassedPackageIsFoundButIsADependency_ShouldLog3Times()
        {
            //Arrange
            var loggerMock = new Mock<ILogger>();
            loggerMock.Setup(l => l.Log(It.IsAny<string>()));

            var packageMock = new Mock<IPackage>();
            packageMock.SetupGet(p => p.Name).Returns("someName");           
            packageMock.Setup(p => p.Equals(It.IsAny<IPackage>())).Returns(true);            
            packageMock.SetupGet(p => p.Dependencies).Returns(new List<IPackage>() { packageMock.Object });

            var packages = new List<IPackage>() { packageMock.Object };

            var repo = new ExtendedPackageRepository(loggerMock.Object, packages);

            var packageToDeleteMock = new Mock<IPackage>();
            packageToDeleteMock.SetupGet(p => p.Name).Returns("someName");            

            //Act
            repo.Delete(packageToDeleteMock.Object);

            //Assert
            loggerMock.Verify(l => l.Log(It.IsAny<string>()), Times.Exactly(3));
        }

        //Test for returning the package deleted
        [Test]
        public void Delete_PassedPackageIsFoundWithNoDependencies_ShouldReturnDeletedPackage()
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
            packageMock.SetupSequence(p => p.Equals(It.IsAny<IPackage>())).Returns(true).Returns(false);

            packageMock.SetupGet(p => p.Dependencies).Returns(new List<IPackage>() { packageMock.Object });

            var packages = new List<IPackage>() { packageMock.Object };

            var repo = new ExtendedPackageRepository(loggerMock.Object, packages);

            var packageToDeleteMock = new Mock<IPackage>();
            packageToDeleteMock.SetupGet(p => p.Name).Returns("someName");
            packageToDeleteMock.SetupGet(p => p.Version.Major).Returns(1);
            packageToDeleteMock.SetupGet(p => p.Version.Minor).Returns(1);
            packageToDeleteMock.SetupGet(p => p.Version.Patch).Returns(1);
            packageToDeleteMock.SetupGet(p => p.Version.VersionType).Returns(VersionType.alpha);           

            //Act/Asser
            Assert.AreSame(packageToDeleteMock.Object, repo.Delete(packageToDeleteMock.Object));
        }

        [Test]
        public void Delete_PassedPackageIsFoundWithNoDependencies_ShouldDeletePackageFromPackages()
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
            packageMock.SetupSequence(p => p.Equals(It.IsAny<IPackage>())).Returns(true).Returns(false);

            packageMock.SetupGet(p => p.Dependencies).Returns(new List<IPackage>() { packageMock.Object });

            var packages = new List<IPackage>() { packageMock.Object };

            var repo = new ExtendedPackageRepository(loggerMock.Object, packages);

            var packageToDeleteMock = new Mock<IPackage>();
            packageToDeleteMock.SetupGet(p => p.Name).Returns("someName");
            packageToDeleteMock.SetupGet(p => p.Version.Major).Returns(1);
            packageToDeleteMock.SetupGet(p => p.Version.Minor).Returns(1);
            packageToDeleteMock.SetupGet(p => p.Version.Patch).Returns(1);
            packageToDeleteMock.SetupGet(p => p.Version.VersionType).Returns(VersionType.alpha);

            //Act/Asser
            CollectionAssert.DoesNotContain(repo.Packages, packageToDeleteMock.Object);
        }
    }
}
