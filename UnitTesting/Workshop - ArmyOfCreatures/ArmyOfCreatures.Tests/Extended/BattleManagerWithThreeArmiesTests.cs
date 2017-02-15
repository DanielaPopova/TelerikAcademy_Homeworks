namespace ArmyOfCreatures.Tests.Extended
{    
    using System.Collections.Generic;
    using System.Reflection;

    using ArmyOfCreatures.Logic;
    using ArmyOfCreatures.Extended;
    using ArmyOfCreatures.Logic.Battles;

    using NUnit.Framework;
    using Moq;

    public class BattleManagerWithThreeArmiesTests
    {
        /*Constructor should call base() constructor and instantiate the object with all properties set up.
        (Use C# integrated PrivateObject class, to expose private fields, so that you can assert, that the object was instantiated properly).*/
        [Test]
        public void Constructor_ShouldInstantiateAllObjectProperties()
        {
            //Arrange
            var factoryMock = new Mock<ICreaturesFactory>();
            var loggerMock = new Mock<ILogger>();

            var managerWithThreeArmies = new BattleManagerWithThreeArmies(factoryMock.Object, loggerMock.Object);

            //Using MSTest built-in PrivateObject - cannot access base class fields
            var privateManagerWithThreeArmies = new Microsoft.VisualStudio.TestTools.UnitTesting.PrivateObject(managerWithThreeArmies);
            var privateThirdArmy = privateManagerWithThreeArmies.GetField("thirdArmyCreatures");

            //Using Reflection
            var privateFirstArmy = managerWithThreeArmies.GetType().BaseType.GetField("firstArmyCreatures", BindingFlags.NonPublic | BindingFlags.Instance).GetValue(managerWithThreeArmies);
            var privateSecondArmy = managerWithThreeArmies.GetType().BaseType.GetField("secondArmyCreatures", BindingFlags.NonPublic | BindingFlags.Instance).GetValue(managerWithThreeArmies);
            var privateFactory = managerWithThreeArmies.GetType().BaseType.GetField("creaturesFactory", BindingFlags.NonPublic | BindingFlags.Instance).GetValue(managerWithThreeArmies);
            var privateLogger = managerWithThreeArmies.GetType().BaseType.GetField("logger", BindingFlags.NonPublic | BindingFlags.Instance).GetValue(managerWithThreeArmies);

            //Assert
            Assert.IsInstanceOf<List<ICreaturesInBattle>>(privateFirstArmy);
            Assert.IsInstanceOf<List<ICreaturesInBattle>>(privateSecondArmy);
            Assert.IsInstanceOf<List<ICreaturesInBattle>>(privateThirdArmy);
            Assert.AreSame(factoryMock.Object, privateFactory);
            Assert.AreSame(loggerMock.Object, privateLogger);
        }
    }
}
