namespace ArmyOfCreatures.Tests.Logic.Specialties
{
    using System;

    using NUnit.Framework;
    using Moq;
    using ArmyOfCreatures.Logic.Specialties;
    using ArmyOfCreatures.Logic.Battles;
    using ArmyOfCreatures.Logic.Creatures;

    [TestFixture]
    public class DoubleDefenseWhenDefendingTests
    {
        [Test]
        public void ApplyWhenDefending_DefenderWithSpecialtyIsNull_ShouldThrowArgumentNullExceotion()
        {
            //Arrange
            var defense = new DoubleDefenseWhenDefending(3);
            ICreaturesInBattle nullDefender = null;
            var attackerMock = new Mock<ICreaturesInBattle>();

            //Act/Assert
            Assert.Throws<ArgumentNullException>(() => defense.ApplyWhenDefending(nullDefender, attackerMock.Object));
        }

        [Test]
        public void ApplyWhenDefending_AttackerIsNull_ShouldThrowArgumentNullExceotion()
        {
            //Arrange
            var defense = new DoubleDefenseWhenDefending(3);
            ICreaturesInBattle nullAttacker = null;
            var defenderMock = new Mock<ICreaturesInBattle>();

            //Act/Assert
            Assert.Throws<ArgumentNullException>(() => defense.ApplyWhenDefending(defenderMock.Object, nullAttacker));
        }

        //[Test]
        //public void ApplyWhenDefending_EffectIsExpired_ShouldNotChangeCurrentDefenceOfDefenderWithSpecialty()
        //{
        //    //Arrange
        //    int rounds = 1;
        //    var defense = new DoubleDefenseWhenDefending(rounds);

        //    var defenderWithSpecialtyMock = new Mock<ICreaturesInBattle>();
        //    var attackerMock = new Mock<ICreaturesInBattle>();

        //    defenderWithSpecialtyMock.SetupGet(d => d.CurrentDefense).Returns(100);

        //    //Act/Assert
        //    defense.ApplyWhenDefending(defenderWithSpecialtyMock.Object, attackerMock.Object);
            
        //}

        [Test]
        public void ApplyWhenDefending_EffectIsNotExpired_ShouldDoubleCurrentDefenceOfDefenderWithSpecialty()
        {
            //Arrange
            int rounds = 1;
            var defense = new DoubleDefenseWhenDefending(rounds);

            var creature = new Angel();
            var defenderWithSpecialty = new CreaturesInBattle(creature, 5);
            defenderWithSpecialty.CurrentDefense = 30;
            var attackerMock = new Mock<ICreaturesInBattle>();          

            //Act
            defense.ApplyWhenDefending(defenderWithSpecialty, attackerMock.Object);

            //Assert
            Assert.AreEqual(60, defenderWithSpecialty.CurrentDefense);
        }
    }
}
