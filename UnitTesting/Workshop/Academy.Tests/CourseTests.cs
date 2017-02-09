namespace Academy.Tests
{
    using System;
    using System.Collections.Generic;

    using NUnit.Framework;
    using Academy.Models;
    using Models.Contracts;

    [TestFixture]
    public class CourseTests
    {
        [Test]
        public void Constructor_ShouldCreateInstanceOfOnlineStudents()
        { 
            var course = new Course("Test", 5, new DateTime(), new DateTime());

            Assert.IsInstanceOf<IList<IStudent>>(course.OnlineStudents);
        }

        [Test]
        public void Constructor_ShouldCreateInstanceOfOnsiteStudents()
        {
            var course = new Course("Test", 5, new DateTime(), new DateTime());

            Assert.IsInstanceOf<IList<IStudent>>(course.OnsiteStudents);
        }

        [Test]
        public void Constructor_ShouldCreateInstanceOfLectures()
        {
            var course = new Course("Test", 5, new DateTime(), new DateTime());

            Assert.IsInstanceOf<IList<ILecture>>(course.Lectures);
        }

        [Test]
        public void Constructor_PassedNameIsNull_ShouldThrowArgumentException()
        {
            string nullName = null;

            Assert.Throws<ArgumentException>(() => new Course(nullName, 5, new DateTime(), new DateTime()));
        }
       
        [Test]
        public void Constructor_PassedNameIsNotInRange_ShouldThrowArgumentException_LowerRange()
        {
            string nameNotInRange = "a";

            Assert.Throws<ArgumentException>(() => new Course(nameNotInRange, 5, new DateTime(), new DateTime()));
        }

        [Test]
        public void Constructor_PassedNameIsNotInRange_ShouldThrowArgumentException_UpperRange()
        {
            string nameNotInRange = new string('a', 46);

            Assert.Throws<ArgumentException>(() => new Course(nameNotInRange, 5, new DateTime(), new DateTime()));
        }

        [Test]
        public void Constructor_PassedNameIsValid_ShouldNotThrowAnArgumentException()
        {
            var passedName = "NameInRange";
           
            Assert.DoesNotThrow(() => new Course(passedName, 5, new DateTime(), new DateTime()));
        }

        [Test]
        public void Constructor_PassedNameIsCorrectlyAssigned()
        {
            var expectedName = "NameInRange";
            var course = new Course(expectedName, 7, new DateTime(), new DateTime());

            Assert.AreEqual(expectedName, course.Name);
        }
    }
}
