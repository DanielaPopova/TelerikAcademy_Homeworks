namespace ProjectManager.Tests.Commands
{
    using System.Collections.Generic;

    using Common.Exceptions;
    using Data;
    using Models.Contracts;
    using Moq;
    using NUnit.Framework;
    using ProjectManager.Commands;   

    [TestFixture]
    public class CreateTaskCommandTests
    {
        // Test if Execute() throws when invalid parameters count are passed. (0.5 points)
        [Test]
        public static void Execute_InvalidCountPassed_ShouldThrowUserValidationException()
        {
            // Arrange
            var commandParameters = new List<string> { "0" };
            var databaseMock = new Mock<IDatabase>();
            var factoryMock = new Mock<IModelsFactory>();
            var command = new CreateTaskCommand(databaseMock.Object, factoryMock.Object);

            // Act/Assert
            Assert.Throws<UserValidationException>(() => command.Execute(commandParameters));
        }

        // Test if Execute() throws when empty parameters are passed. 
        [Test]
        public static void Execute_EmptyParametersArePassed_ShouldThrowUserValidationException()
        {
            // Arrange
            var commandParameters = new List<string> { "0", string.Empty, string.Empty, "Pending" };
            var databaseMock = new Mock<IDatabase>();
            var factoryMock = new Mock<IModelsFactory>();
            var command = new CreateTaskCommand(databaseMock.Object, factoryMock.Object);

            // Act/Assert
            Assert.Throws<UserValidationException>(() => command.Execute(commandParameters));
        }
    }
}
