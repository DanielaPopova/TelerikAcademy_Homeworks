namespace ArmyOfCreatures.Tests.Logic.Battles
{
    using System;

    using NUnit.Framework;
    using ArmyOfCreatures.Logic.Battles;
    using ArmyOfCreatures.Logic.Creatures;

    [TestFixture]
    public class CreaturesInBattleTests
    {
        public object ICreatureInBattle { get; private set; }

        //Deal Damage with null defender should throw ArgumentNullException
        [Test]
        public void DealDamage_DefenderIsNull_ShouldThrowArgumentNullException()
        {
            //Arrange
            ICreaturesInBattle defender = null;
            var creature = new Angel();

            var sut = new CreaturesInBattle(creature, 2);

            //Assert
            Assert.Throws<ArgumentNullException>(() => sut.DealDamage(defender));
        }

        //Deal Damage should return expected result        
    }
}
