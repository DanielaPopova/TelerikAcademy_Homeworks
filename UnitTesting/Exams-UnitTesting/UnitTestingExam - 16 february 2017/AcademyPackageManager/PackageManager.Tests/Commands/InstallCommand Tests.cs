namespace PackageManager.Tests.Commands
{
    using System;

    using NUnit.Framework;
    using Moq;

    using PackageManager.Models.Contracts;
    using PackageManager.Core.Contracts;
    using PackageManager.Commands;
    using Enums;

    [TestFixture]
    public class InstallCommand_Tests
    {
        //Test the constructor if it sets the appropriate passed values
        [Test]
        public void Constructor_ObjectIsConstructed_ShouldSetCorrectlyInstaller()
        {
            //Arrange
            var installerMock = new Mock<IInstaller<IPackage>>();
            var packageMock = new Mock<IPackage>();

            //Act
            var installCommand = new ExtendedInstallCommand(installerMock.Object, packageMock.Object);

            //Using PrivateObject
            //var privateCommand = new Microsoft.VisualStudio.TestTools.UnitTesting.PrivateObject(installCommand);
            //var privateCommandInstallerField = privateCommand.GetField("installer");
            //var privateCommandPackageField = privateCommand.GetField("package");

            //Assert
            Assert.AreSame(installerMock.Object, installCommand.Installer);
        }

        [Test]
        public void Constructor_ObjectIsConstructed_ShouldSetCorrectlyPackage()
        {
            //Arrange
            var installerMock = new Mock<IInstaller<IPackage>>();
            var packageMock = new Mock<IPackage>();

            //Act
            var installCommand = new ExtendedInstallCommand(installerMock.Object, packageMock.Object);

            //Assert
            Assert.AreSame(packageMock.Object, installCommand.Package);
        }

        //Test for right value set for the installer
        [Test]
        public void Constructor_PassedInstallerIsNull_ShouldThrowArgumentNullException()
        {
            //Arrange
            IInstaller<IPackage> nullInstaller = null;
            var packageMock = new Mock<IPackage>();

            //Act/Assert
            Assert.Throws<ArgumentNullException>(() => new InstallCommand(nullInstaller, packageMock.Object));
        }

        //Test for right value set for the package
        [Test]
        public void Constructor_PassedPackageIsNull_ShouldThrowArgumentNullException()
        {
            //Arrange
            var installerMock = new Mock<IInstaller<IPackage>>();
            IPackage nullPackage = null;

            //Act/Assert
            Assert.Throws<ArgumentNullException>(() => new InstallCommand(installerMock.Object, nullPackage));
        }

        //Test for right value set for the Operation of the installer
        [Test]
        public void Constructor_PassedValuesAreValid_ShouldCorrectlySetOperationToInstall()
        {
            //Arrange
            var installerMock = new Mock<IInstaller<IPackage>>();
            installerMock.SetupGet(ins => ins.Operation).Returns(InstallerOperation.Install);
            var packageMock = new Mock<IPackage>();

            //Act
            var installCommand = new ExtendedInstallCommand(installerMock.Object, packageMock.Object);

            //Assert
            Assert.AreEqual(installerMock.Object.Operation, installCommand.Installer.Operation);
        }

        //Test for calling the perform operation from the installer
        [Test]
        public void Execute_ShouldPerformOperationFromInstaller()
        {
            //Arrange
            var installerMock = new Mock<IInstaller<IPackage>>();            
            var packageMock = new Mock<IPackage>();

            var installCommand = new ExtendedInstallCommand(installerMock.Object, packageMock.Object);

            //Act
            installCommand.Execute();

            //Assert
            installerMock.Verify(ins => ins.PerformOperation(It.IsAny<IPackage>()), Times.Once);
        }
    }
}
