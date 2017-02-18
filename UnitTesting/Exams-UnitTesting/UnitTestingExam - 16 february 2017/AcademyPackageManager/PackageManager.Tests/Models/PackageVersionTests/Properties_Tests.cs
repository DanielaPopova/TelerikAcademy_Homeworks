namespace PackageManager.Tests.Models.PackageVersionTests
{
    using System;

    using NUnit.Framework;

    using PackageManager.Enums;
    using PackageManager.Models;

    [TestFixture]
    public class Properties_Tests
    {

        //Test for valid and invalid value Major
        [Test]
        public void Major_PassedMajorIsInvalid_ShouldThrowArgumentException()
        {
            //Arrange
            int invalidMajor = -5;
            int validMinor = 3;
            int validPatch = 4;
            var validVersionType = VersionType.alpha;

            //Act/Assert
            Assert.Throws<ArgumentException>(() => new PackageVersion(invalidMajor, validMinor, validPatch, validVersionType));
        }

        [Test]
        public void Major_PassedMajorIsValid_ShouldNotThrowArgumentException()
        {
            //Arrange
            int validMajor = 5;
            int validMinor = 3;
            int validPatch = 4;
            var validVersionType = VersionType.alpha;

            //Act/Assert
            Assert.DoesNotThrow(() => new PackageVersion(validMajor, validMinor, validPatch, validVersionType));
        }

        //Test for valid and invalid value Minor
        [Test]
        public void Minor_PassedMinorIsInvalid_ShouldThrowArgumentException()
        {
            //Arrange
            int validMajor = 5;
            int invalidMinor = -3;
            int validPatch = 4;
            var validVersionType = VersionType.alpha;

            //Act/Assert
            Assert.Throws<ArgumentException>(() => new PackageVersion(validMajor, invalidMinor, validPatch, validVersionType));
        }

        [Test]
        public void Minor_PassedMinorIsValid_ShouldNotThrowArgumentException()
        {
            //Arrange
            int validMajor = 5;
            int validMinor = 3;
            int validPatch = 4;
            var validVersionType = VersionType.alpha;

            //Act/Assert
            Assert.DoesNotThrow(() => new PackageVersion(validMajor, validMinor, validPatch, validVersionType));
        }

        //Test for valid and invalid value Patch
        [Test]
        public void Patch_PassedPatchIsInvalid_ShouldThrowArgumentException()
        {
            //Arrange
            int validMajor = 5;
            int validMinor = 3;
            int invalidPatch = -4;
            var validVersionType = VersionType.alpha;

            //Act/Assert
            Assert.Throws<ArgumentException>(() => new PackageVersion(validMajor, validMinor, invalidPatch, validVersionType));
        }

        [Test]
        public void Patch_PassedPatchIsValid_ShouldNotThrowArgumentException()
        {
            //Arrange
            int validMajor = 5;
            int validMinor = 3;
            int validPatch = 4;
            var validVersionType = VersionType.alpha;

            //Act/Assert
            Assert.DoesNotThrow(() => new PackageVersion(validMajor, validMinor, validPatch, validVersionType));
        }
        
        //Test for valid and invalid value VersionType
        [Test]
        public void Constuctor_PassedVersionTypeIsInvalid_ShouldThrowArgumentException()
        {
            //Arrange
            int validMajor = 5;
            int validMinor = 3;
            int validPatch = 4;
            int invalidVersionType = 5;

            //Act/Assert
            Assert.Throws<ArgumentException>(() => new PackageVersion(validMajor, validMinor, validPatch, (VersionType)invalidVersionType));
        }

        [Test]
        public void Constuctor_PassedVersionTypeIsValid_ShouldNotThrowArgumentException()
        {
            //Arrange
            int validMajor = 5;
            int validMinor = 3;
            int validPatch = 4;
            var validVersionType = VersionType.alpha;

            //Act/Assert
            Assert.DoesNotThrow(() => new PackageVersion(validMajor, validMinor, validPatch, validVersionType));
        }
    }
}
