namespace PackageManager.Tests.Models.ProjectTests
{
    using System;

    using NUnit.Framework;    
   
    using PackageManager.Models;

    [TestFixture]
    public class Properties_Tests
    {
        //Test if Name is set correctly
        [Test]
        public void Name_PassedNameIsNull_ShouldThrowArgumentNullException()
        {
            //Arrange
            string nullName = null;
            string validLocation = "someLocation";

            //Act
            Assert.Throws<ArgumentNullException>(() => new Project(nullName, validLocation));
        }

        [Test]
        public void Name_PassedNameIsValid_ShouldNotThrowArgumentNullException()
        {
            //Arrange
            string validName = "someName";
            string validLocation = "someLocation";

            //Act
            Assert.DoesNotThrow(() => new Project(validName, validLocation));
        }

        //Test if Location is set correctly
        [Test]
        public void Location_PassedLocationIsNull_ShouldThrowArgumentNullException()
        {
            //Arrange
            string validName = "someName";
            string nullLocation = null;

            //Act
            Assert.Throws<ArgumentNullException>(() => new Project(validName, nullLocation));
        }

        [Test]
        public void Location_PassedLocationIsValid_ShouldNotThrowArgumentNullException()
        {
            //Arrange
            string validName = "someName";
            string validLocation = "someLocation";

            //Act
            Assert.DoesNotThrow(() => new Project(validName, validLocation));
        }
    }
}
