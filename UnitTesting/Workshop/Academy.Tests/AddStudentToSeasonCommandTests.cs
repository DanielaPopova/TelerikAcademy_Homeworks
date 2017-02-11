namespace Academy.Tests
{
    using System;

    using NUnit.Framework;
    using Commands.Adding;
    using Core.Contracts;
    using Moq;
    using Mocks;   
    using System.Collections.Generic;
    using Models.Contracts;

    [TestFixture]
    public class AddStudentToSeasonCommandTests
    {
        [Test]
        public void Constructor_PassedFactoryIsNull_ShouldThrowArgumentNullException()
        {
            //Arrange
            IAcademyFactory factory = null;
            var engine = new Mock<IEngine>();
           
            //Assert
            Assert.Throws<ArgumentNullException>(() => new AddStudentToSeasonCommand(factory, engine.Object));
        }

        [Test]
        public void Constructor_PassedEngineIsNull_ShouldThrowArgumentNullException()
        {
            //Arrange
            IEngine engine = null;
            var factory = new Mock<IAcademyFactory>();

            //Assert
            Assert.Throws<ArgumentNullException>(() => new AddStudentToSeasonCommand(factory.Object, engine));
        }

        [Test]
        public void Constructor_PassedAcademyFactoryIsValid_ShouldBeCorrectlyAssign()
        {
            //Arrange
            var factory = new Mock<IAcademyFactory>();
            var engine = new Mock<IEngine>();

            //Act
            var command = new AddStudentToSeasonCommandMock(factory.Object, engine.Object);

            //Assert
            Assert.AreSame(factory.Object, command.AcademyFactory);
        }

        [Test]
        public void Constructor_PassedEngineIsValid_ShouldBeCorrectlyAssign()
        {
            //Arrange
            var factory = new Mock<IAcademyFactory>();
            var engine = new Mock<IEngine>();

            //Act
            var command = new AddStudentToSeasonCommandMock(factory.Object, engine.Object);

            //Assert
            Assert.AreSame(engine.Object, command.Engine);
        }

        [Test]
        public void Execute_PassedStudentIsAlreadyInSeason_ShouldThrowArgumentException()
        {
            //Arrange
            var factoryMock = new Mock<IAcademyFactory>();            

            var studentMock = new Mock<IStudent>();
            studentMock.SetupGet(st => st.Username).Returns("validUsername");

            var seasonMock = new Mock<ISeason>();
            seasonMock.SetupGet(s => s.Students).Returns(new List<IStudent>() { studentMock.Object});

            var engineMock = new Mock<IEngine>();
            engineMock.SetupGet(e => e.Students).Returns(new List<IStudent>() { studentMock.Object});
            engineMock.SetupGet(e => e.Seasons).Returns(new List<ISeason>() { seasonMock.Object});
            
            var command = new AddStudentToSeasonCommand(factoryMock.Object, engineMock.Object);

            var parameters = new List<string> { "validUsername", "0" };
            
            //Act/Assert
            Assert.Throws<ArgumentException>(() => command.Execute(parameters));
        }

        [Test]
        public void Execute_PassedStudent_IsAddedInSeason()
        {
            //Arrange
            var factoryMock = new Mock<IAcademyFactory>();

            var studentMock = new Mock<IStudent>();
            studentMock.SetupGet(st => st.Username).Returns("validUsername");

            var seasonMock = new Mock<ISeason>();
            seasonMock.SetupGet(s => s.Students).Returns(new List<IStudent>());

            var engineMock = new Mock<IEngine>();
            engineMock.SetupGet(e => e.Students).Returns(new List<IStudent>() { studentMock.Object});
            engineMock.SetupGet(e => e.Seasons).Returns(new List<ISeason>() { seasonMock.Object });

            var command = new AddStudentToSeasonCommand(factoryMock.Object, engineMock.Object);

            var parameters = new List<string> { "validUsername", "0" };

            //Act
            command.Execute(parameters);

            //Assert
            Assert.AreEqual(1, seasonMock.Object.Students.Count);
        }

        [Test]
        public void Execute_PassedStudentIsAddedInSeason_ReturnsMessage()
        {
            //Arrange
            var factoryMock = new Mock<IAcademyFactory>();

            var studentMock = new Mock<IStudent>();
            studentMock.SetupGet(st => st.Username).Returns("validUsername");

            var seasonMock = new Mock<ISeason>();
            seasonMock.SetupGet(s => s.Students).Returns(new List<IStudent>());

            var engineMock = new Mock<IEngine>();
            engineMock.SetupGet(e => e.Students).Returns(new List<IStudent>() { studentMock.Object });
            engineMock.SetupGet(e => e.Seasons).Returns(new List<ISeason>() { seasonMock.Object });

            var command = new AddStudentToSeasonCommand(factoryMock.Object, engineMock.Object);

            var parameters = new List<string> { "validUsername", "0" };

            //Act
            var actualMessage = command.Execute(parameters);

            //Assert
            StringAssert.Contains("validUsername", actualMessage);
            StringAssert.Contains("Season 0", actualMessage);
        }
    }
}
