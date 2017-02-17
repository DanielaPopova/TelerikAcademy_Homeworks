namespace PackageManager.Tests.Repositories.PackageRepository_Tests
{
    using System;
    using System.Collections.Generic;

    using NUnit.Framework;
    using Moq;

    using PackageManager.Info.Contracts;
    using PackageManager.Models.Contracts;
    using PackageManager.Repositories;

    [TestFixture]
    public class GetAll_Tests
    {
        //Test for repository with no passed collection to return as parameter empty collection
        [Test]
        public void GetAll_NoPackagesCollectionIsPassed_ShouldReturnEmptyCollection()
        {
            //Arrange
            var loggerMock = new Mock<ILogger>();
            //not necessary to setup Log(), test still works
            loggerMock.Setup(l => l.Log(It.IsAny<string>()));
            
            var repo = new ExtendedPackageRepository(loggerMock.Object);

            //Act
            repo.GetAll();

            //Assert
            Assert.AreEqual(0, repo.Packages.Count);
        }

        //Test for repository with passed collection as parameter to return collection with equal number of elements
        [Test]
        public void GetAll_PassedPackagesCollectionWithElements_ShouldReturnCollection()
        {
            //Arrange
            var loggerMock = new Mock<ILogger>();
            loggerMock.Setup(l => l.Log(It.IsAny<string>()));
            var packageMock = new Mock<IPackage>();

            var packages = new List<IPackage>() { packageMock.Object};
            
            var repo = new ExtendedPackageRepository(loggerMock.Object, packages);

            //Act
            repo.GetAll();

            //Assert
            Assert.AreEqual(1, repo.Packages.Count);
            CollectionAssert.Contains(repo.Packages, packageMock.Object);            
        }

        [Test]
        public void GetAll_PassedPackagesCollectionWithElements_ShouldLogOnce()
        {
            //Arrange
            var loggerMock = new Mock<ILogger>();            
            var packageMock = new Mock<IPackage>();

            var packages = new List<IPackage>() { packageMock.Object };

            var repo = new ExtendedPackageRepository(loggerMock.Object, packages);

            //Act
            repo.GetAll();

            //Assert            
            loggerMock.Verify(l => l.Log("All packages"), Times.Once);
        }
    }
}
