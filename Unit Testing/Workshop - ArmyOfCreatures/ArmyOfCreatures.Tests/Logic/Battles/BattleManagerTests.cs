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

        //Attacking with null identifier should throw ArgumentNullException
        [Test]
        public void Attack_AttackerIdentifierIsNull_ShouldThrowArgumentNullException()
        {
            //Arrange
            var factoryMock = new Mock<ICreaturesFactory>();
            var loggerMock = new Mock<ILogger>();
            var battleManager = new BattleManager(factoryMock.Object, loggerMock.Object);

            CreatureIdentifier attackerID = null;
            var defenderID = CreatureIdentifier.CreatureIdentifierFromString("Angel(1)");

            //Act/Assert
            Assert.Throws<ArgumentNullException>(() => battleManager.Attack(attackerID, defenderID));
        }

        [Test]
        public void Attack_DefenderIdentifierIsNull_ShouldThrowArgumentNullException()
        {
            //Arrange
            var factoryMock = new Mock<ICreaturesFactory>();
            var loggerMock = new Mock<ILogger>();
            var battleManager = new BattleManager(factoryMock.Object, loggerMock.Object);

            var attackerCreature = new Angel();
            var attackerID = CreatureIdentifier.CreatureIdentifierFromString("Angel(1)");
            CreatureIdentifier defenderID = null;

            //Attacker should be added first => then check null for defender
            factoryMock.Setup(f => f.CreateCreature(It.IsAny<string>())).Returns(attackerCreature);
            battleManager.AddCreatures(attackerID, 2);

            //Act/Assert
            var er = Assert.Throws<ArgumentNullException>(() => battleManager.Attack(attackerID, defenderID));
            StringAssert.Contains("identifier", er.Message);
        }

        //Attacking with null unit should throw ArgumentException
        [Test]
        public void Attack_AttackerUnitIsNull_ShouldThrowArgumentException()
        {
            //Arrange
            var factoryMock = new Mock<ICreaturesFactory>();
            var loggerMock = new Mock<ILogger>();
            var battleManager = new BattleManager(factoryMock.Object, loggerMock.Object);

            //Assure that always Angel will be returned
            var creature = new Angel();
            factoryMock.Setup(f => f.CreateCreature(It.IsAny<string>())).Returns(creature);
            
            var fakeAttackerID = CreatureIdentifier.CreatureIdentifierFromString("NotAngel(1)");
            var defenderID = CreatureIdentifier.CreatureIdentifierFromString("Angel(2)");

            //Adding both attacker/defender to collections first/secondArmyCreatures
            //fakeAttacker won't be found since CreateCreatures always returns Angel...not NotAngel
            battleManager.AddCreatures(fakeAttackerID, 5);
            battleManager.AddCreatures(defenderID, 10);

            //Act/Assert
            Assert.That(() => battleManager.Attack(fakeAttackerID, defenderID), Throws.ArgumentException.With.Message.Contains("Attacker not found"));
        }

        [Test]
        public void Attack_DefenderUnitIsNull_ShouldThrowArgumentException()
        {
            //Arrange
            var factoryMock = new Mock<ICreaturesFactory>();
            var loggerMock = new Mock<ILogger>();
            var battleManager = new BattleManager(factoryMock.Object, loggerMock.Object);
            
            var creature = new Angel();
            factoryMock.Setup(f => f.CreateCreature(It.IsAny<string>())).Returns(creature);

            var attackerID = CreatureIdentifier.CreatureIdentifierFromString("Angel(1)");
            var fakeDefenderID = CreatureIdentifier.CreatureIdentifierFromString("NotAngel(2)");
           
            battleManager.AddCreatures(attackerID, 5);
            battleManager.AddCreatures(fakeDefenderID, 10);

            //Act/Assert
            Assert.That(() => battleManager.Attack(attackerID, fakeDefenderID), Throws.ArgumentException.With.Message.Contains("Defender not found"));
        }

        //Attacking successful should call WriteLine from Logger exactly 6 times
        [Test]
        public void Attack_IfSuccessful_ShouldCallWriteLineFromLogger6Times()
        {
            //Arrange
            var factoryMock = new Mock<ICreaturesFactory>();
            var loggerMock = new Mock<ILogger>();
            var battleManager = new BattleManager(factoryMock.Object, loggerMock.Object);

            //loggerMock.Setup(l => l.WriteLine(It.IsAny<string>()));

            var creature = new Angel();
            factoryMock.Setup(f => f.CreateCreature(It.IsAny<string>())).Returns(creature);

            var attackerID = CreatureIdentifier.CreatureIdentifierFromString("Angel(1)");
            var defenderID = CreatureIdentifier.CreatureIdentifierFromString("Angel(2)");

            battleManager.AddCreatures(attackerID, 5);
            battleManager.AddCreatures(defenderID, 10);

            battleManager.Attack(attackerID, defenderID);

            //Act/Assert
            loggerMock.Verify(l => l.WriteLine(It.IsAny<string>()), Times.Exactly(6));
        }

        //Attacking with two Behemoths should return right result (two Behemoths attack 1 Behemoth and the expected result is 56)
        //- could be tried with all the other creatures
    }
}
