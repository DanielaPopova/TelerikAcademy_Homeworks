namespace ArmyOfCreatures.Tests.Logic.Battles
{
    using System;

    using NUnit.Framework;
    using Moq;
    using ArmyOfCreatures.Logic;
    using ArmyOfCreatures.Logic.Battles;
    using ArmyOfCreatures.Logic.Creatures;

    [TestFixture]
    public class BattleManagerTests
    {
        //Add creatures should throw ArgumentNullException, when Identifier is null
        [Test]
        public void AddCreatures_IdentifierIsNull_ShouldThrowArgumentNullException()
        {
            //Arrange
            CreatureIdentifier creatureID = null;
            var factoryMock = new Mock<ICreaturesFactory>();
            var loggerMock = new Mock<ILogger>();

            var battleManager = new BattleManager(factoryMock.Object, loggerMock.Object);

            //Act/Assert
            Assert.Throws<ArgumentNullException>(() => battleManager.AddCreatures(creatureID, 3));
        }

        //Add creatures should call CreteCreature from factory
        [Test]
        public void AddCreatures_ShouldCallCreateCreatureFromFactory()
        {
            //Arrange
            var creatureID = CreatureIdentifier.CreatureIdentifierFromString("Angel(1)");
            var creature = new Angel();
            var factoryMock = new Mock<ICreaturesFactory>();
            var loggerMock = new Mock<ILogger>();
            var battleManager = new BattleManager(factoryMock.Object, loggerMock.Object);

            factoryMock.Setup(f => f.CreateCreature(It.IsAny<string>())).Returns(creature);

            //Act
            battleManager.AddCreatures(creatureID, 2);

            //Assert
            factoryMock.Verify(f => f.CreateCreature(It.IsAny<string>()), Times.Once);
        }

        //Add creatures should call WriteLine from Logger
        [Test]
        public void AddCreatures_ShoulCallWriteLineFromLogger()
        {
            //Arrange
            var creatureID = CreatureIdentifier.CreatureIdentifierFromString("Angel(1)");
            var creature = new Angel();
            var factoryMock = new Mock<ICreaturesFactory>();
            var loggerMock = new Mock<ILogger>();
            var battleManager = new BattleManager(factoryMock.Object, loggerMock.Object);

            factoryMock.Setup(f => f.CreateCreature(It.IsAny<string>())).Returns(creature);
            loggerMock.Setup(l => l.WriteLine(It.IsAny<string>()));

            //Act
            battleManager.AddCreatures(creatureID, 2);

            //Assert
            loggerMock.Verify(l => l.WriteLine(It.IsAny<string>()), Times.Once);
        }

        //Adding creature to Army 3 (not existing) should throw ArgumentException
        [Test]
        public void AddCreatures_AddingToArmy3_ShouldThrowArgumentException()
        {
            //Arrange
            int armyNumber = 3;
            var creatureID = CreatureIdentifier.CreatureIdentifierFromString("Angel(" + armyNumber + ")");
            var creature = new Angel();
            var factoryMock = new Mock<ICreaturesFactory>();
            var loggerMock = new Mock<ILogger>();
            var battleManager = new BattleManager(factoryMock.Object, loggerMock.Object);

            factoryMock.Setup(f => f.CreateCreature("Angel")).Returns(creature);

            //Act/Assert
            Assert.Throws<ArgumentException>(() => battleManager.AddCreatures(creatureID, 2));

            var er = Assert.Throws<ArgumentException>(() => battleManager.AddCreatures(creatureID, 2));
            StringAssert.Contains("Invalid ArmyNumber", er.Message);

            Assert.That(() => battleManager.AddCreatures(creatureID, 2), Throws.ArgumentException.With.Message.Contains("Invalid ArmyNumber"));
        }
    }
}
