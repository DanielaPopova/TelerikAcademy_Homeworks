namespace Academy.Tests
{
    using System;

    using NUnit.Framework;
    using Moq;
    using Core.Contracts;
    using Commands.Adding;
    using Mocks;

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
    }
}
