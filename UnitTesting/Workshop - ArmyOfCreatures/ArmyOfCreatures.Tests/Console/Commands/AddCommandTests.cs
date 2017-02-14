﻿namespace ArmyOfCreatures.Tests.Console.Commands
{
    using System;

    using NUnit.Framework;
    using Moq;   
    using ArmyOfCreatures.Console.Commands;
    using ArmyOfCreatures.Logic.Battles;

    [TestFixture]
    public class AddCommandTests
    {
        [Test]
        public void ProcessCommand_BattleManagerIsNull_ShouldThrowArgumentNullException()
        {
            //Arrange
            IBattleManager nullBattleManager = null;
            string[] arguments = new string[] { };

            var addCommand = new AddCommand();

            //Act/Assert
            Assert.Throws<ArgumentNullException>(() => addCommand.ProcessCommand(nullBattleManager, arguments));
        }

        [Test]
        public void ProcessCommand_ParamsArgumentsIsNull_ShouldThrowArgumentNullException()
        {
            //Arrange
            var battleManager = new Mock<IBattleManager>();
            string[] nullArguments = null;

            var addCommand = new AddCommand();

            //Act/Assert
            Assert.Throws<ArgumentNullException>(() => addCommand.ProcessCommand(battleManager.Object, nullArguments));
        }

        [Test]
        public void ProcessCommand_ParamsArgumentsLengthIsInvalid_ShouldThrowArgumentException()
        {
            //Arrange
            var battleManager = new Mock<IBattleManager>();
            string[] argumentsWithInvalidLength = new string[1];

            var addCommand = new AddCommand();

            //Act/Assert
            Assert.Throws<ArgumentException>(() => addCommand.ProcessCommand(battleManager.Object, argumentsWithInvalidLength));
        }

        [Test]
        public void ProcessCommand_PassedValuesAreValid_ShouldCallAddCreaturesMethod()
        {
            //Arrange
            var battleManagerMock = new Mock<IBattleManager>();
            string[] validArguments = new string[] { "5", "someCreature(1)" };
            //var creatureID = CreatureIdentifier.CreatureIdentifierFromString("someCreature(1)");

            var command = new AddCommand();
            command.ProcessCommand(battleManagerMock.Object, validArguments);

            //Assert
            battleManagerMock.Verify(b => b.AddCreatures(It.IsAny<CreatureIdentifier>(), 5), Times.Once);
            //battleManagerMock.Verify(b => b.AddCreatures(It.Is<CreatureIdentifier>(c => c.CreatureType == "someCreature" && c.ArmyNumber == 1), It.Is<int>(c => c == 5)), Times.Once);
        }
    }
}
