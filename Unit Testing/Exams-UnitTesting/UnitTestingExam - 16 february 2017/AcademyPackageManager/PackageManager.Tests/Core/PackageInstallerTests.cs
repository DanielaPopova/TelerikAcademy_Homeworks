namespace PackageManager.Tests.Core
{
    using System;
    using System.Collections.Generic;

    using NUnit.Framework;
    using Moq;

    using PackageManager.Core.Contracts;
    using PackageManager.Models.Contracts;
    using PackageManager.Core;
    using Mocks;
    using Enums;

    [TestFixture]
    public class PackageInstallerTests
    {
        //Test for restoring packages when the object is constructed
        //should test when there are dependencies in the project
        [Test]
        public void Constructor_WhenObjectIsConstructed_ShouldRestorePackages()
        {
            //Arrange            
            var downloaderMock = new Mock<IDownloader>();
            var projectMock = new Mock<IProject>();
            var packageMock = new Mock<IPackage>();

            packageMock.Setup(p => p.Dependencies.Add(packageMock.Object));
            projectMock.Setup(p => p.PackageRepository.GetAll()).Returns(new List<IPackage> { packageMock.Object });

            //Act
            var installer = new PackageInstallerMock(downloaderMock.Object, projectMock.Object);

            //Assert
            projectMock.Verify(p => p.PackageRepository.GetAll(), Times.Once);
        }

        //PerformOperation - Test for Install command and empty dependencies list - should call two times Download and one time Remove
        [Test]
        public void PerformOperation_InstallCommandWithEmptyDependencies_ShouldCall2TimesDownload1TimeRemove()
        {
            //Arrange
            var downloaderMock = new Mock<IDownloader>();
            var projectMock = new Mock<IProject>();
            var packageMock = new Mock<IPackage>();
            packageMock.SetupGet(p => p.Dependencies).Returns(new List<IPackage>());
            projectMock.Setup(p => p.PackageRepository.GetAll()).Returns(new List<IPackage>());

            var installer = new PackageInstallerMock(downloaderMock.Object, projectMock.Object);
            installer.Operation = InstallerOperation.Install;

            //Act
            installer.PerformOperation(packageMock.Object);

            //Assert
            downloaderMock.Verify(d => d.Remove(It.IsAny<string>()), Times.Once);
            downloaderMock.Verify(d => d.Download(It.IsAny<string>()), Times.Exactly(2));
        }

        //PerformOperation - Test for Install command and at least one dependency in the dependencies list
        //- every dependency on the chain will multiply the calss to the Download and Remove mehtod by 2
        [Test]
        public void PerformOperation_InstallCommandWithOneDependency_ShouldCall4TimesDownload2TimeRemove()
        {
            //Arrange
            var downloaderMock = new Mock<IDownloader>();
            var projectMock = new Mock<IProject>();
            var packageMock = new Mock<IPackage>();
            var packageDependencyMock = new Mock<IPackage>();

            packageDependencyMock.SetupGet(p => p.Dependencies).Returns(new List<IPackage>());
            packageMock.SetupGet(p => p.Dependencies).Returns(new List<IPackage>() { packageDependencyMock.Object});
            projectMock.Setup(p => p.PackageRepository.GetAll()).Returns(new List<IPackage>());

            var installer = new PackageInstallerMock(downloaderMock.Object, projectMock.Object);

            //Act
            installer.PerformOperation(packageMock.Object);

            //Assert
            downloaderMock.Verify(d => d.Remove(It.IsAny<string>()), Times.Exactly(2));
            downloaderMock.Verify(d => d.Download(It.IsAny<string>()), Times.Exactly(4));
        }
    }
}
