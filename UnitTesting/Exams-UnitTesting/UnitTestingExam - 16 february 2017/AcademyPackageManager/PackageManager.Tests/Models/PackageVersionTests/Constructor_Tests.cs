namespace PackageManager.Tests.Models.PackageVersionTests
{   
    using PackageManager.Enums;
    using PackageManager.Models;

    using NUnit.Framework;

    [TestFixture]
    public class Constructor_Tests
    {
        //Test the constructor if it sets the appropriate passed values
        [Test]
        public void Constructor_ObjectIsConstructed_ShouldCorrectlyAssignMajor()
        {
            //Arrange
            int validMajor = 5;
            int validMinor = 3;
            int validPatch = 4;
            var validVersionType = VersionType.alpha;

            //Act
            var packageVersion = new PackageVersion(validMajor, validMinor, validPatch, validVersionType);

            //Assert
            Assert.AreEqual(validMajor, packageVersion.Major);            
        }

        [Test]
        public void Constructor_ObjectIsConstructed_ShouldCorrectlyAssignMinor()
        {
            //Arrange
            int validMajor = 5;
            int validMinor = 3;
            int validPatch = 4;
            var validVersionType = VersionType.alpha;

            //Act
            var packageVersion = new PackageVersion(validMajor, validMinor, validPatch, validVersionType);

            //Assert           
            Assert.AreEqual(validMinor, packageVersion.Minor);
            
        }

        [Test]
        public void Constructor_ObjectIsConstructed_ShouldCorrectlyAssignPatch()
        {
            //Arrange
            int validMajor = 5;
            int validMinor = 3;
            int validPatch = 4;
            var validVersionType = VersionType.alpha;

            //Act
            var packageVersion = new PackageVersion(validMajor, validMinor, validPatch, validVersionType);

            //Assert            
            Assert.AreEqual(validPatch, packageVersion.Patch);            
        }

        [Test]
        public void Constructor_ObjectIsConstructed_ShouldCorrectlyAssignVersionType()
        {
            //Arrange
            int validMajor = 5;
            int validMinor = 3;
            int validPatch = 4;
            var validVersionType = VersionType.alpha;

            //Act
            var packageVersion = new PackageVersion(validMajor, validMinor, validPatch, validVersionType);

            //Assert            
            Assert.AreEqual(validVersionType, packageVersion.VersionType);
        }

    }
}
