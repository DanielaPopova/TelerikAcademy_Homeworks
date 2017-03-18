namespace IntergalacticTravel.Tests.TeleportStationTests
{
    using System;
    using System.Collections.Generic;

    using NUnit.Framework;
    using Moq;

    using Contracts;

    [TestFixture]
    public class ConstructorTests
    {
        //Constructor should set up all of the provided fields (owner, galacticMap & location),
        //when a new TeleportStation is created with valid parameters passed to the constructor.
        [Test]
        public void Constructor_ValisParametersArePassed_ShouldSetUpAllFields()
        {
            //Arrange
            var ownerMock = new Mock<IBusinessOwner>();
            var pathMock = new Mock<IPath>();
            var galacticMap = new List<IPath>() { pathMock.Object };
            var locationMock = new Mock<ILocation>();

            //Act
            var teleportStation = new ExtendedTeleportStation(ownerMock.Object, galacticMap, locationMock.Object);

            //Assert
            Assert.AreSame(ownerMock.Object, teleportStation.Owner);
            Assert.AreSame(galacticMap, teleportStation.GalacticMap);
            Assert.AreSame(locationMock.Object, teleportStation.Location);
        }
    }
}
