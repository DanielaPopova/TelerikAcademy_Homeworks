namespace Academy.Tests
{
    using System;

    using NUnit.Framework;
    using Commands.Adding;
    using Core.Contracts;
    using Moq;
    using Mocks;

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
    }
}
