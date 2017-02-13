namespace Academy.Tests
{
    using System;

    using Models;
    using Models.Contracts;
    using Models.Enums;
    using Moq;
    using NUnit.Framework;

    [TestFixture]
    public class SeasonTests
    {
        [Test]
        public void ListUsers_ShouldReturnListOfStudents()
        {
            //Arrange
            var season = new Season(2016, 2017, Initiative.SoftwareAcademy);

            var studentMock = new Mock<IStudent>();
            studentMock.Setup(st => st.ToString());
            
            season.Students.Add(studentMock.Object);

            //Act
            season.ListUsers();

            //Assert
            studentMock.Verify(st => st.ToString(), Times.Once);
        }

        [Test]
        public void ListUsers_ShouldReturnListOfTrainers()
        {
            //Arrange
            var season = new Season(2016, 2017, Initiative.SoftwareAcademy);

            var trainerMock = new Mock<ITrainer>();
            trainerMock.Setup(tr => tr.ToString());

            season.Trainers.Add(trainerMock.Object);

            //Act
            season.ListUsers();

            //Assert
            trainerMock.Verify(tr => tr.ToString(), Times.Once);
        }

        [Test]
        public void ListUsers_WhenNoUsers_ShouldReturnMessage()
        {
            //Arrange
            var season = new Season(2016, 2017, Initiative.SoftwareAcademy);
            string expectedMessage = "no users";

            //Act
            var actual = season.ListUsers();

            //Assert
            StringAssert.Contains(expectedMessage, actual);
        }

        [Test]
        public void ListCourses_ShouldReturnListOfCourses()
        {
            //Arrange
            var season = new Season(2016, 2017, Initiative.SoftwareAcademy);

            var courseMock = new Mock<ICourse>();
            courseMock.Setup(c => c.ToString());

            season.Courses.Add(courseMock.Object);

            //Act
            season.ListCourses();

            //Assert
            courseMock.Verify(c => c.ToString(), Times.Once);
        }

        [Test]
        public void ListCourses_WhenNoCourses_ShouldReturnMessage()
        {
            var season = new Season(2016, 2017, Initiative.SoftwareAcademy);
            string expectedMessage = "no courses";

            //Act
            string actual = season.ListCourses();

            //Assert
            StringAssert.Contains(expectedMessage, actual);
        }
    }
}
