namespace IntergalacticTravel.Tests
{
    using System;

    using NUnit.Framework;
    using Moq;

    using IntergalacticTravel.Contracts;

    [TestFixture]
    public class UnitTests
    {
        //Pay should throw NullReferenceException if the object passed is null
        [Test]
        public void Pay_PassedObjectIsNull_ShouldThrowNullReferenceException()
        {
            //Arrange
            IResources nullCost = null;
            var unit = new Unit(4, "someName");

            //Act/Assert
            Assert.Throws<NullReferenceException>(() => unit.Pay(nullCost));
        }

        //Pay should decrease the owner's amount of Resources by the amount of the cost.
        [Test]
        public void Pay_ShouldDecreaseOwnersAmountByTheAmountOfCost()
        {
            //Arrange
            var resoursesMock = new Mock<IResources>();
            resoursesMock.SetupGet(r => r.BronzeCoins).Returns(20);
            resoursesMock.SetupGet(r => r.SilverCoins).Returns(20);
            resoursesMock.SetupGet(r => r.GoldCoins).Returns(20);

            var costMock = new Mock<IResources>();
            costMock.SetupGet(r => r.BronzeCoins).Returns(5);
            costMock.SetupGet(r => r.SilverCoins).Returns(10);
            costMock.SetupGet(r => r.GoldCoins).Returns(15);

            var expectedBronzeCoinsLeft = 15;
            var expectedSilverCoinsLeft = 10;
            var expectedGoldCoinsLeft = 5;

            var unit = new Unit(4, "someName");
            unit.Resources.Add(resoursesMock.Object);

            //Act
            unit.Pay(costMock.Object);

            //Assert
            Assert.AreEqual(expectedBronzeCoinsLeft, unit.Resources.BronzeCoins);
            Assert.AreEqual(expectedSilverCoinsLeft, unit.Resources.SilverCoins);
            Assert.AreEqual(expectedGoldCoinsLeft, unit.Resources.GoldCoins);
        }

        //Pay should return Resource object with the amount of resources in the cost object.
        [Test]
        public void Pay_ShouldReturnResourceObjectWithCostObjectResourcesAmount()
        {
            //Arrange
            var resoursesMock = new Mock<IResources>();
            resoursesMock.SetupGet(r => r.BronzeCoins).Returns(20);
            resoursesMock.SetupGet(r => r.SilverCoins).Returns(20);
            resoursesMock.SetupGet(r => r.GoldCoins).Returns(20);

            var costMock = new Mock<IResources>();
            costMock.SetupGet(r => r.BronzeCoins).Returns(5);
            costMock.SetupGet(r => r.SilverCoins).Returns(10);
            costMock.SetupGet(r => r.GoldCoins).Returns(15);

            var unit = new Unit(4, "someName");
            unit.Resources.Add(resoursesMock.Object);

            //Act
            var actualResources = unit.Pay(costMock.Object);

            //Assert
            Assert.AreEqual(costMock.Object.BronzeCoins, actualResources.BronzeCoins);
            Assert.AreEqual(costMock.Object.SilverCoins, actualResources.SilverCoins);
            Assert.AreEqual(costMock.Object.GoldCoins, actualResources.GoldCoins);
        }
    }
}
