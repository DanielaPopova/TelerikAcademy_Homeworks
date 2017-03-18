namespace PackageManager.Tests.Models.PackageTests
{
    using System;
    using System.Collections.Generic;

    using NUnit.Framework;
    using Moq;

    using PackageManager.Models.Contracts;
    using PackageManager.Models;
    
    [TestFixture]
    public class Constructor_Tests
    {
        //Test the constructor if it sets the appropriate passed values
        //Test if Dependencies is set correctly for optional parameter dependencies
        //Test if Dependencies is set correctly for passed parameter dependencies
        [Test]
        public void Constructor_ObjectIsConstructed_ShouldCorrectlySetName()
        {
            //Arrange
            string validName = "someName";
            var versionMock = new Mock<IVersion>();

            //Act
            var package = new Package(validName, versionMock.Object);

            //Assert
            Assert.AreEqual(validName, package.Name);            
        }

        [Test]
        public void Constructor_ObjectIsConstructed_ShouldCorrectlySetVersion()
        {
            //Arrange
            string validName = "someName";
            var versionMock = new Mock<IVersion>();

            //Act
            var package = new Package(validName, versionMock.Object);

            //Assert
            Assert.AreSame(versionMock.Object, package.Version);
        }

        [Test]
        public void Constructor_ObjectIsConstructed_ShouldCorrectlySetDependencies()
        {
            //Arrange
            string validName = "someName";
            var versionMock = new Mock<IVersion>();
            var validDependencies = new List<IPackage>();

            //Act
            var package = new Package(validName, versionMock.Object, validDependencies);

            //Assert
            Assert.AreSame(validDependencies, package.Dependencies);
        }

        [Test]
        public void Constructor_ObjectIsConstructedWithNullDependencies_ShouldCorrectlySetOptionalDependencies()
        {
            //Arrange
            string validName = "someName";
            var versionMock = new Mock<IVersion>();
            var optionalDependencies = new HashSet<IPackage>();

            //Act
            var package = new Package(validName, versionMock.Object);

            //Assert
            Assert.IsInstanceOf(typeof(HashSet<IPackage>), package.Dependencies);
        }
    }
}
