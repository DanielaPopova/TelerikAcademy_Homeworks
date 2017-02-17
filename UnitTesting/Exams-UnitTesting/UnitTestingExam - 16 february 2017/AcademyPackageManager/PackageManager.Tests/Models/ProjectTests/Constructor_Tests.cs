namespace PackageManager.Tests.Models.ProjectTests
{
    using NUnit.Framework;
    using Moq;

    using PackageManager.Models.Contracts;
    using PackageManager.Models;
    using PackageManager.Info;
    using PackageManager.Repositories.Contracts;
    using PackageManager.Repositories;

    [TestFixture]
    public class Constructor_Tests
    {
        //Test the constructor if it sets the appropriate passed values
        //Test if PackageRepository is set correctly for optional parameter packages
        //Test if PackageRepository is set correctly for passed parameter packages
        [Test]
        public void Constructor_ObjectIsConstructed_ShouldCorrectlySetName()
        {
            //Arrange
            string validName = "someName";
            string validLocation = "someLocation";
            var packagesMock = new Mock<IRepository<IPackage>>();

            //Act
            var project = new Project(validName, validLocation, packagesMock.Object);

            //Assert
            Assert.AreEqual(validName, project.Name);
        }

        [Test]
        public void Constructor_ObjectIsConstructed_ShouldCorrectlySetLocation()
        {
            //Arrange
            string validName = "someName";
            string validLocation = "someLocation";
            var packagesMock = new Mock<IRepository<IPackage>>();

            //Act
            var project = new Project(validName, validLocation, packagesMock.Object);

            //Assert
            Assert.AreEqual(validLocation, project.Location);
        }

        [Test]
        public void Constructor_ObjectIsConstructed_ShouldCorrectlySetPackages()
        {
            //Arrange
            string validName = "someName";
            string validLocation = "someLocation";
            var packagesMock = new Mock<IRepository<IPackage>>();

            //Act
            var project = new Project(validName, validLocation, packagesMock.Object);

            //Assert
            Assert.AreSame(packagesMock.Object, project.PackageRepository);
        }

        //TODO
        [Test]
        public void Constructor_ObjectIsConstructedWitNullPackages_ShouldCorrectlySetOptionalPackages()
        {
            //Arrange
            string validName = "someName";
            string validLocation = "someLocation";
            var optionalPackages = new PackageRepository(new ConsoleLogger());

            //Act
            var project = new Project(validName, validLocation);

            //Assert
            Assert.IsInstanceOf(typeof(PackageRepository), project.PackageRepository);
        }
    }
}
