namespace Academy.Tests
{
    using System;

    using NUnit.Framework;
    using Moq;
    using Core.Contracts;
    using Commands.Adding;
    using Mocks;
    using System.Collections.Generic;
    using Models.Contracts;

    [TestFixture]
    public class AddStudentToCourseCommandTests
    {
        [Test]
        public void Constructor_PassedFactoryIsNull_ShouldThrowArgumentNullException()
        {
            //Arrange
            IAcademyFactory factory = null;
            var engine = new Mock<IEngine>();

            //Assert
            Assert.Throws<ArgumentNullException>(() => new AddStudentToCourseCommand(factory, engine.Object));
        }

        [Test]
        public void Constructor_PassedEngineIsNull_ShouldThrowArgumentNullException()
        {
            //Arrange
            IEngine engine = null;
            var factory = new Mock<IAcademyFactory>();

            //Assert
            Assert.Throws<ArgumentNullException>(() => new AddStudentToCourseCommand(factory.Object, engine));
        }

        [Test]
        public void Constructor_PassedAcademyFactoryIsValid_ShouldBeCorrectlyAssigned()
        {
            //Arrange
            var factory = new Mock<IAcademyFactory>();
            var engine = new Mock<IEngine>();

            //Act
            var command = new AddStudentToCourseCommandMock(factory.Object, engine.Object);

            //Assert
            Assert.AreSame(factory.Object, command.AcademyFactory);
        }

        [Test]
        public void Constructor_PassedEngineIsValid_ShouldBeCorrectlyAssigned()
        {
            //Arrange
            var factory = new Mock<IAcademyFactory>();
            var engine = new Mock<IEngine>();

            //Act
            var command = new AddStudentToCourseCommandMock(factory.Object, engine.Object);

            //Assert
            Assert.AreSame(engine.Object, command.Engine);
        }

        [Test]
        public void Execute_PassedCourseFormIsInvalid_ShouldThrowArgumentException()
        {
            //Arrange
            var factoryMock = new Mock<IAcademyFactory>();
            var engineMock = new Mock<IEngine>();
            var command = new AddStudentToCourseCommand(factoryMock.Object, engineMock.Object);

            var studentMock = new Mock<IStudent>();
            studentMock.SetupGet(st => st.Username).Returns("someUsername");

            var courseMock = new Mock<ICourse>();

            var seasonMock = new Mock<ISeason>();
            seasonMock.SetupGet(s => s.Courses).Returns(new List<ICourse>() { courseMock.Object });

            engineMock.SetupGet(e => e.Students).Returns(new List<IStudent>() { studentMock.Object });
            engineMock.SetupGet(e => e.Seasons).Returns(new List<ISeason>() { seasonMock.Object });

            string invalidForm = "invalid";
            var parameters = new List<string>() { "someUserName", "0", "0", invalidForm };

            //Act/Assert
            Assert.Throws<ArgumentException>(() => command.Execute(parameters));
        }

        [Test]
        public void Execute_FoundStudent_ShoulBeAddedToOnsiteStudents()
        {
            //Arrange
            var factoryMock = new Mock<IAcademyFactory>();
            var engineMock = new Mock<IEngine>();
            var command = new AddStudentToCourseCommand(factoryMock.Object, engineMock.Object);

            var studentMock = new Mock<IStudent>();
            studentMock.SetupGet(st => st.Username).Returns("someUsername");

            var courseMock = new Mock<ICourse>();
            courseMock.SetupGet(c => c.OnsiteStudents).Returns(new List<IStudent>());

            var seasonMock = new Mock<ISeason>();
            seasonMock.SetupGet(s => s.Courses).Returns(new List<ICourse>() { courseMock.Object });

            engineMock.SetupGet(e => e.Students).Returns(new List<IStudent>() { studentMock.Object });
            engineMock.SetupGet(e => e.Seasons).Returns(new List<ISeason>() { seasonMock.Object });

            string validForm = "onsite";
            var parameters = new List<string>() { "someUserName", "0", "0", validForm };

            //Act
            command.Execute(parameters);

            //Assert
            Assert.AreEqual(1, courseMock.Object.OnsiteStudents.Count);
        }

        [Test]
        public void Execute_FoundStudent_ShoulBeAddedToOnlineStudents()
        {
            //Arrange
            var factoryMock = new Mock<IAcademyFactory>();
            var engineMock = new Mock<IEngine>();
            var command = new AddStudentToCourseCommand(factoryMock.Object, engineMock.Object);

            var studentMock = new Mock<IStudent>();
            studentMock.SetupGet(st => st.Username).Returns("someUsername");

            var courseMock = new Mock<ICourse>();
            courseMock.SetupGet(c => c.OnlineStudents).Returns(new List<IStudent>());

            var seasonMock = new Mock<ISeason>();
            seasonMock.SetupGet(s => s.Courses).Returns(new List<ICourse>() { courseMock.Object });

            engineMock.SetupGet(e => e.Students).Returns(new List<IStudent>() { studentMock.Object });
            engineMock.SetupGet(e => e.Seasons).Returns(new List<ISeason>() { seasonMock.Object });

            string validForm = "online";
            var parameters = new List<string>() { "someUserName", "0", "0", validForm };

            //Act
            command.Execute(parameters);

            //Assert
            //Assert.AreSame(studentMock.Object.Username, engineMock.Object.Seasons[0].Courses[0].OnlineStudents[0].Username);
            Assert.AreEqual(1, courseMock.Object.OnlineStudents.Count);
        }

        [TestCase("online")]
        [TestCase("onsite")]
        public void Execute_WhenStudentIsAddedCorrectly_ReturnsMessageWithStudentUsernameAndSeasonID(string validForm)
        {
            //Arrange
            var factoryMock = new Mock<IAcademyFactory>();
            var engineMock = new Mock<IEngine>();
            var command = new AddStudentToCourseCommand(factoryMock.Object, engineMock.Object);

            var studentMock = new Mock<IStudent>();
            studentMock.SetupGet(st => st.Username).Returns("someUsername");

            var courseMock = new Mock<ICourse>();
            courseMock.SetupGet(c => c.OnlineStudents).Returns(new List<IStudent>());
            courseMock.SetupGet(c => c.OnsiteStudents).Returns(new List<IStudent>());

            var seasonMock = new Mock<ISeason>();
            seasonMock.SetupGet(s => s.Courses).Returns(new List<ICourse>() { courseMock.Object });

            engineMock.SetupGet(e => e.Students).Returns(new List<IStudent>() { studentMock.Object });
            engineMock.SetupGet(e => e.Seasons).Returns(new List<ISeason>() { seasonMock.Object });

            string username = "someUsername";
            string seasonId = "0";
            var parameters = new List<string>() { username, seasonId, "0", validForm };

            //Act
            var actualMessage = command.Execute(parameters);

            //Assert
            StringAssert.Contains(username, actualMessage);
            StringAssert.Contains(seasonId, actualMessage);
        }
    }
}
