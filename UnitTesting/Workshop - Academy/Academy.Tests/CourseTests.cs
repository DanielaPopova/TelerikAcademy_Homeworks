namespace Academy.Tests
{
    using System;
    using System.Collections.Generic;

    using NUnit.Framework;
    using Academy.Models;
    using Academy.Models.Contracts;
    using Moq;

    [TestFixture]
    public class CourseTests
    {
        [Test]
        public void Constructor_PassedName_ShouldBeCorrectlyAssigned()
        {
            // Arrange
            string validName = "testName";

            //Act
            var course = new Course(validName, 5, new DateTime(), new DateTime());

            //Assert
            Assert.AreEqual(validName, course.Name);
        }

        [Test]
        public void Constructor_PassedLecturesPerWeek_ShouldBeCorrectlyAssigned()
        {
            // Arrange
            int validLecturesPerWeek = 5;

            //Act
            var course = new Course("testName", validLecturesPerWeek, new DateTime(), new DateTime());

            //Assert
            Assert.AreEqual(validLecturesPerWeek, course.LecturesPerWeek);

        }

        [Test]
        public void Constructor_PassedStartingDate_ShouldBeCorrectlyAssigned()
        {
            // Arrange
            var validStartingDate = new DateTime(2016, 5, 20);

            //Act
            var course = new Course("testName", 5, validStartingDate, new DateTime());

            //Assert
            Assert.AreEqual(validStartingDate, course.StartingDate);

        }

        public void Constructor_PassedEndingDate_ShouldBeCorrectlyAssigned()
        {
            // Arrange
            var validEndingDate = new DateTime(2016, 5, 20);

            //Act
            var course = new Course("testName", 5, new DateTime(), validEndingDate);

            //Assert
            Assert.AreEqual(validEndingDate, course.EndingDate);

        }

        [Test]
        public void Constructor_ShouldCreateInstanceOfOnlineStudents()
        { 
            // Arrange
            var course = new Course("Test", 5, new DateTime(), new DateTime());

            //Act/Assert
            Assert.IsInstanceOf<IList<IStudent>>(course.OnlineStudents);
        }

        [Test]
        public void Constructor_ShouldCreateInstanceOfOnsiteStudents()
        {
            // Arrange
            var course = new Course("Test", 5, new DateTime(), new DateTime());

            //Act/Assert
            Assert.IsInstanceOf<IList<IStudent>>(course.OnsiteStudents);
        }

        [Test]
        public void Constructor_ShouldCreateInstanceOfLectures()
        {
            // Arrange
            var course = new Course("Test", 5, new DateTime(), new DateTime());

            //Act/Assert
            Assert.IsInstanceOf<IList<ILecture>>(course.Lectures);
            //Assert.AreEqual(0, course.Lectures.Count);
            //Assert.IsNotNull(course.Lectures);
        }

        [Test]
        public void Name_PassedNameIsNull_ShouldThrowArgumentException()
        {
            // Arrange
            var course = new Course("testName", 5, new DateTime(), new DateTime());
            string nullName = null;
           
            //Act/Assert
            Assert.Throws<ArgumentException>(() => course.Name = nullName);
        }
       
        [Test]
        public void Name_PassedNameIsNotInRange_ShouldThrowArgumentException_LowerRange()
        {
            // Arrange
            var course = new Course("testName", 5, new DateTime(), new DateTime());
            string nameNotInRange = "a";

            //Act/Assert
            Assert.Throws<ArgumentException>(() => course.Name = nameNotInRange);
        }

        [Test]
        public void Name_PassedNameIsNotInRange_ShouldThrowArgumentException_UpperRange()
        {
            // Arrange
            var course = new Course("testName", 5, new DateTime(), new DateTime());
            string nameNotInRange = new string('a', 46);

            //Act/Assert
            Assert.Throws<ArgumentException>(() => course.Name = nameNotInRange);
        }

        [Test]
        public void Name_PassedNameIsValid_ShouldNotThrowAnArgumentException()
        {
            // Arrange
            var course = new Course("testName", 5, new DateTime(), new DateTime());
            var passedName = "NameInRange";

            //Act/Assert
            Assert.DoesNotThrow(() => course.Name = passedName);
        }

        [Test]
        public void Name_PassedName_ShouldBeCorrectlyAssigned()
        {
            // Arrange            
            var course = new Course("testName", 7, new DateTime(), new DateTime());
            string newName = "newTestName";

            //Act
            course.Name = newName;

            //Act/Assert
            Assert.AreEqual(newName, course.Name);
        }

        [Test]
        public void LecturesPerWeek_PassedLecturesPerWeekIsNotInRange_ShouldThrowArgumentException_LowerRange()
        {
            // Arrange
            var course = new Course("testName", 7, new DateTime(), new DateTime());
            int lecturesPerWeekNotInRange = 0;

            //Act/Assert
            Assert.Throws<ArgumentException>(() => course.LecturesPerWeek = lecturesPerWeekNotInRange);
        }

        [Test]
        public void LecturesPerWeek_PassedLecturesPerWeekIsNotInRange_ShouldThrowArgumentException_UpperRange()
        {
            // Arrange
            var course = new Course("testName", 7, new DateTime(), new DateTime());
            int lecturesPerWeekNotInRange = 8;

            //Act/Assert
            Assert.Throws<ArgumentException>(() => course.LecturesPerWeek = lecturesPerWeekNotInRange);
        }

        [Test]
        public void LecturesPerWeek_PassedLecturesPerWeekIsValid_ShouldNotThrowAnArgumentException()
        {
            // Arrange
            var course = new Course("testName", 7, new DateTime(), new DateTime());
            int validLecturesPerWeek = 6;

            //Act/Assert
            Assert.DoesNotThrow(() => course.LecturesPerWeek = validLecturesPerWeek);
        }

        [Test]
        public void LecturesPerWeek_PassedLecturesPerWeekIsValid_ShouldBeCorrectlyAssigned()
        {
            // Arrange
            var course = new Course("testName", 7, new DateTime(), new DateTime());
            int validLecturesPerWeek = 6;

            //Act
            course.LecturesPerWeek = validLecturesPerWeek;

            //Act/Assert
            Assert.AreEqual(validLecturesPerWeek, course.LecturesPerWeek);
        }

        [Test]
        public void StartingDate_PassedStartingDateIsNull_ShouldThrowArgumentNullException()
        {
            //Arrange
            var course = new Course("testName", 7, new DateTime(), new DateTime());
            DateTime? nullDate = null;
            
            //Act/Assert
            Assert.Throws<ArgumentNullException>(() => course.StartingDate = nullDate);
        }

        [Test]
        public void StartingDate_PassedStartingDateIsValid_ShouldNotThrowException()
        {
            //Arrange
            var course = new Course("testName", 7, new DateTime(), new DateTime());
            DateTime? validDate = new DateTime(2016, 2, 15);

            //Act/Assert
            Assert.DoesNotThrow(() => course.StartingDate = validDate);
        }

        [Test]
        public void StartingDate_PassedStartingDateIsValid_ShouldBeCorrectlyAssigned()
        {
            //Arrange
            var course = new Course("testName", 7, new DateTime(), new DateTime());
            DateTime validDate = new DateTime(2016, 2, 15);

            //Act
            course.StartingDate = validDate;

            //Assert
            Assert.AreEqual(validDate, course.StartingDate);
        }

        [Test]
        public void EndingDate_PassedEndingDateIsNull_ShouldThrowArgumentNullException()
        {
            //Arrange
            var course = new Course("testName", 7, new DateTime(), new DateTime());
            DateTime? nullDate = null;

            //Act/Assert
            Assert.Throws<ArgumentNullException>(() => course.EndingDate = nullDate);
        }

        [Test]
        public void EndingDate_PassedEndingDateIsValid_ShouldNotThrowException()
        {
            //Arrange
            var course = new Course("testName", 7, new DateTime(), new DateTime());
            DateTime? validDate = new DateTime(2016, 2, 15);

            //Act/Assert
            Assert.DoesNotThrow(() => course.EndingDate = validDate);
        }

        [Test]
        public void EndingDate_PassedEndingDateIsValid_ShouldBeCorrectlyAssigned()
        {
            //Arrange
            var course = new Course("testName", 7, new DateTime(), new DateTime());
            DateTime validDate = new DateTime(2016, 2, 15);

            //Act
            course.EndingDate = validDate;

            //Assert
            Assert.AreEqual(validDate, course.EndingDate);            
        }

        [Test]
        public void ToString_ListOfLectures_ShouldReturnPassedData()
        {
            //Arrange
            var course = new Course("testName", 7, new DateTime(), new DateTime());

            var lectureMock = new Mock<ILecture>();
            lectureMock.Setup(x => x.ToString());
            
            course.Lectures.Add(lectureMock.Object);

            //Act
            course.ToString();

            //Assert
            lectureMock.Verify(x => x.ToString(), Times.Once);
        }

        [Test]
        public void ToString_ListOfLecturesIsEmpty_ShouldReturnPassedDataAndCorrectMessage()
        {
            //Arrange
            var course = new Course("testName", 5, new DateTime(), new DateTime());
            string message = "There are no lectures";
            
            //Act/Assert
            StringAssert.Contains(message, course.ToString());
        }        
    }
}
