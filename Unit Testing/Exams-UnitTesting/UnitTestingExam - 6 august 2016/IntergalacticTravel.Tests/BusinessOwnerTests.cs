namespace IntergalacticTravel.Tests
{
    using System;

    using NUnit.Framework;
    using Moq;
    using Contracts;
    using System.Collections;
    using System.Collections.Generic;

    [TestFixture]
    public class BusinessOwnerTests
    {
        //CollectProfits should increase the owner Resources by the total amount of Resources generated from the Teleport Stations that are in his possession.
        [Test]
        public void CollectProfits_ResourcesFromOwnersTeleportStations_ShouldIncreaseOwnersResources()
        {
            //Arrange
            var businessOwner = new BusinessOwner(2, "someName", new List<ITeleportStation>());

            var resourcesMock = new Mock<IResources>();
            resourcesMock.SetupGet(r => r.BronzeCoins).Returns(10);
            resourcesMock.SetupGet(r => r.SilverCoins).Returns(20);
            resourcesMock.SetupGet(r => r.GoldCoins).Returns(30);

            var teleportStationMock = new Mock<ITeleportStation>();
            teleportStationMock.Setup(t => t.PayProfits(businessOwner)).Returns(resourcesMock.Object);

            businessOwner.TeleportStations.Add(teleportStationMock.Object);
            businessOwner.TeleportStations.Add(teleportStationMock.Object);

            var expectedBronzeCoins = resourcesMock.Object.BronzeCoins * 2; //10 * 2
            var expectedSilverCoins = resourcesMock.Object.SilverCoins * 2; //20 * 2
            var expectedGoldCoins = resourcesMock.Object.GoldCoins * 2; //30 * 2

            //Act
            businessOwner.CollectProfits();

            //Assert
            Assert.AreEqual(expectedBronzeCoins, businessOwner.Resources.BronzeCoins);
            Assert.AreEqual(expectedSilverCoins, businessOwner.Resources.SilverCoins);
            Assert.AreEqual(expectedGoldCoins, businessOwner.Resources.GoldCoins);
        }
    }
}
