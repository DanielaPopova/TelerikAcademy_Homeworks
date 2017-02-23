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

        //should test when there are dependencies in the project
        
    }
}
