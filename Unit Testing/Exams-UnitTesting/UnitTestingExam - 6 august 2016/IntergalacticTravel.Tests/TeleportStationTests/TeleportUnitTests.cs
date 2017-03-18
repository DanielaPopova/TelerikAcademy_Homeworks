namespace IntergalacticTravel.Tests.TeleportStationTests
{
    using System;
    using System.Collections.Generic;

    using NUnit.Framework;
    using Moq;

    using Contracts;
    using Exceptions;

    [TestFixture]
    public class TeleportUnitTests
    {
        //TeleportUnit should throw ArgumentNullException, with a message that contains the string "unitToTeleport", when IUnit unitToTeleport is null.
        [Test]
        public void TeleportUnit_UnitToTeleportIsNull_ShouldThrowArgumentNullexceptionWithExpectedMessage()
        {
            //Arrange
            var ownerMock = new Mock<IBusinessOwner>();
            var pathMock = new Mock<IPath>();
            var galacticMapMock = new List<IPath>() { pathMock.Object };
            var locationMock = new Mock<ILocation>();

            var station = new TeleportStation(ownerMock.Object, galacticMapMock, locationMock.Object);

            IUnit nullUnit = null;

            //Act/Assert
            var exc = Assert.Throws<ArgumentNullException>(() => station.TeleportUnit(nullUnit, locationMock.Object));
            StringAssert.Contains("unitToTeleport", exc.Message);            
        }

        //TeleportUnit should throw ArgumentNullException, with a message that contains the string "destination", when ILocation destination is null.
        [Test]
        public void TeleportUnit_DestinationIsNull_ShouldThrowArgumentNullexceptionWithExpectedMessage()
        {
            //Arrange
            var ownerMock = new Mock<IBusinessOwner>();
            var pathMock = new Mock<IPath>();
            var galacticMapMock = new List<IPath>() { pathMock.Object };
            ILocation nullLocation = null;

            var station = new TeleportStation(ownerMock.Object, galacticMapMock, nullLocation);

            var unitMock = new Mock<IUnit>();

            //Act/Assert
            var exc = Assert.Throws<ArgumentNullException>(() => station.TeleportUnit(unitMock.Object, nullLocation));
            StringAssert.Contains("destination", exc.Message);
        }

        //TeleportUnit should throw TeleportOutOfRangeException, with a message that contains the string "unitToTeleport.CurrentLocation",
        //when а unit is trying to use the TeleportStation from a distant location (another planet for example).
        [Test]
        public void TeleportUnit_UnitUsesTeleportStationFormOtherLocation_ShouldThrowTeleportOutOfRangeExceptionWithExpectedMessage()
        {
            //Arrange
            var ownerMock = new Mock<IBusinessOwner>();
            var pathMock = new Mock<IPath>();
            var galacticMapMock = new List<IPath>() { pathMock.Object };

            var locationMock = new Mock<ILocation>();
            locationMock.SetupGet(loc => loc.Planet.Name).Returns("otherPlanet");
            locationMock.SetupGet(loc => loc.Planet.Galaxy.Name).Returns("otherGalaxy");

            var station = new ExtendedTeleportStation(ownerMock.Object, galacticMapMock, locationMock.Object);

            var targetLocationMock = new Mock<ILocation>();
            var unitToTeleportMock = new Mock<IUnit>();
            unitToTeleportMock.SetupGet(unit => unit.CurrentLocation.Planet.Name).Returns("somePlanet");
            unitToTeleportMock.SetupGet(unit => unit.CurrentLocation.Planet.Galaxy.Name).Returns("someGalaxy");

            //Act/Assert
            var exc = Assert.Throws<TeleportOutOfRangeException>(() => station.TeleportUnit(unitToTeleportMock.Object, targetLocationMock.Object));
            StringAssert.Contains("unitToTeleport.CurrentLocation", exc.Message);
        }

        //TeleportUnit should throw InvalidTeleportationLocationException, with a message that contains the string "units will overlap"
        //when trying to teleport a unit to a location which another unit has already taken.
        [Test]
        public void TeleportUnit_TeleportUnitToAlreadyTakenLocation_ShouldThrowInvalidTeleportationLocationExceptionWithExpectedMessage()
        {
            //Arrange
            var ownerMock = new Mock<IBusinessOwner>();
            var pathMock = new Mock<IPath>();
            pathMock.SetupGet(path => path.TargetLocation.Planet.Name).Returns("somePlanet");
            pathMock.SetupGet(path => path.TargetLocation.Planet.Galaxy.Name).Returns("someGalaxy");

            var unitInSameLocationMock = new Mock<IUnit>();
            unitInSameLocationMock.SetupGet(unit => unit.CurrentLocation.Planet.Name).Returns("somePlanet");
            unitInSameLocationMock.SetupGet(unit => unit.CurrentLocation.Planet.Galaxy.Name).Returns("someGalaxy");
            unitInSameLocationMock.SetupGet(unit => unit.CurrentLocation.Coordinates.Latitude).Returns(12.0);
            unitInSameLocationMock.SetupGet(unit => unit.CurrentLocation.Coordinates.Longtitude).Returns(15.0);

            pathMock.SetupGet(path => path.TargetLocation.Planet.Units).Returns(new List<IUnit>() { unitInSameLocationMock.Object});

            var galacticMapMock = new List<IPath>() { pathMock.Object };

            var locationMock = new Mock<ILocation>();
            locationMock.SetupGet(loc => loc.Planet.Name).Returns("somePlanet");
            locationMock.SetupGet(loc => loc.Planet.Galaxy.Name).Returns("someGalaxy");

            var station = new ExtendedTeleportStation(ownerMock.Object, galacticMapMock, locationMock.Object);

            var targetlocationMock = new Mock<ILocation>();
            targetlocationMock.SetupGet(loc => loc.Planet.Name).Returns("somePlanet");
            targetlocationMock.SetupGet(loc => loc.Planet.Galaxy.Name).Returns("someGalaxy");
            targetlocationMock.SetupGet(loc => loc.Coordinates.Latitude).Returns(12.0);
            targetlocationMock.SetupGet(loc => loc.Coordinates.Longtitude).Returns(15.0);

            var unitToTeleportMock = new Mock<IUnit>();
            unitToTeleportMock.SetupGet(unit => unit.CurrentLocation.Planet.Name).Returns("somePlanet");
            unitToTeleportMock.SetupGet(unit => unit.CurrentLocation.Planet.Galaxy.Name).Returns("someGalaxy");
            unitToTeleportMock.SetupGet(unit => unit.CurrentLocation.Coordinates.Latitude).Returns(12.0);
            unitToTeleportMock.SetupGet(unit => unit.CurrentLocation.Coordinates.Longtitude).Returns(15.0);

            //Act/Assert
            var exc = Assert.Throws<InvalidTeleportationLocationException>(() => station.TeleportUnit(unitToTeleportMock.Object, targetlocationMock.Object));
            StringAssert.Contains("units will overlap", exc.Message);
        }

        //TeleportUnit should throw LocationNotFoundException, with a message that contains the string "Galaxy",
        //when trying to teleport a unit to a Galaxy, which is not found in the locations list of the teleport station.
        [Test]
        public void TeleportUnit_TeleportUnitToGalaxyNotFoundInTeleportationStationLocationList_ShouldThrowLocationNotFoundExceptionWithExpectedMessage()
        {
            //Arrange
            var ownerMock = new Mock<IBusinessOwner>();

            var pathMock = new Mock<IPath>();
            pathMock.SetupGet(path => path.TargetLocation.Planet.Name).Returns("somePlanet");
            pathMock.SetupGet(path => path.TargetLocation.Planet.Galaxy.Name).Returns("someOtherGalaxy");

            var galacticMapMock = new List<IPath>() { pathMock.Object };

            var locationMock = new Mock<ILocation>();
            locationMock.SetupGet(loc => loc.Planet.Name).Returns("somePlanet");
            locationMock.SetupGet(loc => loc.Planet.Galaxy.Name).Returns("someGalaxy");

            var station = new ExtendedTeleportStation(ownerMock.Object, galacticMapMock, locationMock.Object);

            var unitToTeleportMock = new Mock<IUnit>();
            unitToTeleportMock.SetupGet(unit => unit.CurrentLocation.Planet.Name).Returns("somePlanet");
            unitToTeleportMock.SetupGet(unit => unit.CurrentLocation.Planet.Galaxy.Name).Returns("someGalaxy");
            unitToTeleportMock.SetupGet(unit => unit.CurrentLocation.Coordinates.Latitude).Returns(12.0);
            unitToTeleportMock.SetupGet(unit => unit.CurrentLocation.Coordinates.Longtitude).Returns(15.0);

            var targetlocationMock = new Mock<ILocation>();
            targetlocationMock.SetupGet(loc => loc.Planet.Name).Returns("somePlanet");
            targetlocationMock.SetupGet(loc => loc.Planet.Galaxy.Name).Returns("someGalaxy");
            targetlocationMock.SetupGet(loc => loc.Coordinates.Latitude).Returns(12.0);
            targetlocationMock.SetupGet(loc => loc.Coordinates.Longtitude).Returns(15.0);

            //Act/Assert
            var exc = Assert.Throws<LocationNotFoundException>(() => station.TeleportUnit(unitToTeleportMock.Object, targetlocationMock.Object));
            StringAssert.Contains("Galaxy", exc.Message);
        }

        //TeleportUnit should throw LocationNotFoundException, with a message that contains the string "Planet",
        //when trying to teleport a unit to a Planet, which is not found in the locations list of the teleport station.
        [Test]
        public void TeleportUnit_TeleportUnitToPlanetNotFoundInTeleportationStationLocationList_ShouldThrowLocationNotFoundExceptionWithExpectedMessage()
        {
            //Arrange
            var ownerMock = new Mock<IBusinessOwner>();

            var pathMock = new Mock<IPath>();
            pathMock.SetupGet(path => path.TargetLocation.Planet.Name).Returns("someOtherPlanet");
            pathMock.SetupGet(path => path.TargetLocation.Planet.Galaxy.Name).Returns("someGalaxy");

            var galacticMapMock = new List<IPath>() { pathMock.Object };

            var locationMock = new Mock<ILocation>();
            locationMock.SetupGet(loc => loc.Planet.Name).Returns("somePlanet");
            locationMock.SetupGet(loc => loc.Planet.Galaxy.Name).Returns("someGalaxy");

            var station = new ExtendedTeleportStation(ownerMock.Object, galacticMapMock, locationMock.Object);

            var unitToTeleportMock = new Mock<IUnit>();
            unitToTeleportMock.SetupGet(unit => unit.CurrentLocation.Planet.Name).Returns("somePlanet");
            unitToTeleportMock.SetupGet(unit => unit.CurrentLocation.Planet.Galaxy.Name).Returns("someGalaxy");
            unitToTeleportMock.SetupGet(unit => unit.CurrentLocation.Coordinates.Latitude).Returns(12.0);
            unitToTeleportMock.SetupGet(unit => unit.CurrentLocation.Coordinates.Longtitude).Returns(15.0);

            var targetlocationMock = new Mock<ILocation>();
            targetlocationMock.SetupGet(loc => loc.Planet.Name).Returns("somePlanet");
            targetlocationMock.SetupGet(loc => loc.Planet.Galaxy.Name).Returns("someGalaxy");
            targetlocationMock.SetupGet(loc => loc.Coordinates.Latitude).Returns(12.0);
            targetlocationMock.SetupGet(loc => loc.Coordinates.Longtitude).Returns(15.0);

            //Act/Assert
            var exc = Assert.Throws<LocationNotFoundException>(() => station.TeleportUnit(unitToTeleportMock.Object, targetlocationMock.Object));
            StringAssert.Contains("Planet", exc.Message);
        }

        //TeleportUnit should throw InsufficientResourcesException, with a message that contains the string "FREE LUNCH",
        //when trying to teleport a unit to a given Location, but the service costs more than the unit's current available resources.
        [Test]
        public void TeleportUnit_UnitCannotPay_ShouldThrowInsufficientResourcesExceptionWithExpectedMessage()
        {
            //Arrange
            var ownerMock = new Mock<IBusinessOwner>();

            var pathMock = new Mock<IPath>();
            pathMock.SetupGet(path => path.TargetLocation.Planet.Name).Returns("somePlanet");
            pathMock.SetupGet(path => path.TargetLocation.Planet.Galaxy.Name).Returns("someGalaxy");
            pathMock.Setup(x => x.Cost.BronzeCoins).Returns(30);
            pathMock.Setup(x => x.Cost.SilverCoins).Returns(40);
            pathMock.Setup(x => x.Cost.GoldCoins).Returns(50);

            var unitInPathUnitsMock = new Mock<IUnit>();
            unitInPathUnitsMock.SetupGet(unit => unit.CurrentLocation.Planet.Name).Returns("someOtherPlanet");
            unitInPathUnitsMock.SetupGet(unit => unit.CurrentLocation.Planet.Galaxy.Name).Returns("someotherGalaxy");
            unitInPathUnitsMock.SetupGet(unit => unit.CurrentLocation.Coordinates.Latitude).Returns(14.0);
            unitInPathUnitsMock.SetupGet(unit => unit.CurrentLocation.Coordinates.Longtitude).Returns(16.0);

            pathMock.SetupGet(path => path.TargetLocation.Planet.Units).Returns(new List<IUnit>() { unitInPathUnitsMock.Object });

            var galacticMapMock = new List<IPath>() { pathMock.Object };

            var locationMock = new Mock<ILocation>();
            locationMock.SetupGet(loc => loc.Planet.Name).Returns("somePlanet");
            locationMock.SetupGet(loc => loc.Planet.Galaxy.Name).Returns("someGalaxy");

            var station = new ExtendedTeleportStation(ownerMock.Object, galacticMapMock, locationMock.Object);

            var unitToTeleportMock = new Mock<IUnit>();
            unitToTeleportMock.SetupGet(unit => unit.CurrentLocation.Planet.Name).Returns("somePlanet");
            unitToTeleportMock.SetupGet(unit => unit.CurrentLocation.Planet.Galaxy.Name).Returns("someGalaxy");
            unitToTeleportMock.SetupGet(unit => unit.CurrentLocation.Coordinates.Latitude).Returns(12.0);
            unitToTeleportMock.SetupGet(unit => unit.CurrentLocation.Coordinates.Longtitude).Returns(15.0);
            unitToTeleportMock.Setup(unit => unit.CanPay(It.IsAny<IResources>())).Returns(false);

            //Without setup CanPay() to false
            //var resourcesMock = new Mock<IResources>();
            //resourcesMock.SetupGet(res => res.BronzeCoins).Returns(20);
            //resourcesMock.SetupGet(res => res.SilverCoins).Returns(30);
            //resourcesMock.SetupGet(res => res.GoldCoins).Returns(40);

            //unitToTeleportMock.SetupGet(unit => unit.Resources).Returns(resourcesMock.Object);

            var targetlocationMock = new Mock<ILocation>();
            targetlocationMock.SetupGet(loc => loc.Planet.Name).Returns("somePlanet");
            targetlocationMock.SetupGet(loc => loc.Planet.Galaxy.Name).Returns("someGalaxy");
            targetlocationMock.SetupGet(loc => loc.Coordinates.Latitude).Returns(12.0);
            targetlocationMock.SetupGet(loc => loc.Coordinates.Longtitude).Returns(15.0);

            //Act/Assert
            var exc = Assert.Throws<InsufficientResourcesException>(() => station.TeleportUnit(unitToTeleportMock.Object, targetlocationMock.Object));
            StringAssert.Contains("FREE LUNCH", exc.Message);
        }

        //TeleportUnit should require a payment from the unitToTeleport for the provided services,
        //when all of the validations pass successfully and the unit is ready for teleportation.
        [Test]
        public void TeleportUnit_UnitIsReadyForTeleportation_ShouldRequirePaymentFromUnitToTeleport()
        {
            //Arrange
            var ownerMock = new Mock<IBusinessOwner>();

            var pathMock = new Mock<IPath>();
            pathMock.SetupGet(path => path.TargetLocation.Planet.Name).Returns("somePlanet");
            pathMock.SetupGet(path => path.TargetLocation.Planet.Galaxy.Name).Returns("someGalaxy");
            pathMock.SetupGet(x => x.Cost.BronzeCoins).Returns(10);
            pathMock.SetupGet(x => x.Cost.SilverCoins).Returns(10);
            pathMock.SetupGet(x => x.Cost.GoldCoins).Returns(10);

            var unitInPathUnitsMock = new Mock<IUnit>();
            unitInPathUnitsMock.SetupGet(unit => unit.CurrentLocation.Planet.Name).Returns("someOtherPlanet");
            unitInPathUnitsMock.SetupGet(unit => unit.CurrentLocation.Planet.Galaxy.Name).Returns("someotherGalaxy");
            unitInPathUnitsMock.SetupGet(unit => unit.CurrentLocation.Coordinates.Latitude).Returns(14.0);
            unitInPathUnitsMock.SetupGet(unit => unit.CurrentLocation.Coordinates.Longtitude).Returns(16.0);

            pathMock.SetupGet(path => path.TargetLocation.Planet.Units).Returns(new List<IUnit>() { unitInPathUnitsMock.Object });

            var galacticMapMock = new List<IPath>() { pathMock.Object };

            var locationMock = new Mock<ILocation>();
            locationMock.SetupGet(loc => loc.Planet.Name).Returns("somePlanet");
            locationMock.SetupGet(loc => loc.Planet.Galaxy.Name).Returns("someGalaxy");

            var station = new ExtendedTeleportStation(ownerMock.Object, galacticMapMock, locationMock.Object);

            var unitToTeleportMock = new Mock<IUnit>();
            unitToTeleportMock.SetupGet(unit => unit.CurrentLocation.Planet.Name).Returns("somePlanet");
            unitToTeleportMock.SetupGet(unit => unit.CurrentLocation.Planet.Galaxy.Name).Returns("someGalaxy");
            unitToTeleportMock.SetupGet(unit => unit.CurrentLocation.Coordinates.Latitude).Returns(12.0);
            unitToTeleportMock.SetupGet(unit => unit.CurrentLocation.Coordinates.Longtitude).Returns(15.0);
            unitToTeleportMock.Setup(unit => unit.CanPay(It.IsAny<IResources>())).Returns(true);
            unitToTeleportMock.Setup(unit => unit.Pay(pathMock.Object.Cost)).Returns(pathMock.Object.Cost);            
            unitToTeleportMock.Setup(x => x.CurrentLocation.Planet.Units).Returns(new List<IUnit> { unitToTeleportMock.Object });

            var targetlocationMock = new Mock<ILocation>();
            targetlocationMock.SetupGet(loc => loc.Planet.Name).Returns("somePlanet");
            targetlocationMock.SetupGet(loc => loc.Planet.Galaxy.Name).Returns("someGalaxy");
            targetlocationMock.SetupGet(loc => loc.Coordinates.Latitude).Returns(12.0);
            targetlocationMock.SetupGet(loc => loc.Coordinates.Longtitude).Returns(15.0);

            //Act
            station.TeleportUnit(unitToTeleportMock.Object, targetlocationMock.Object);

            //Assert
            unitToTeleportMock.Verify(unit => unit.Pay(pathMock.Object.Cost), Times.Once);
        }

        //TeleportUnit should obtain a payment from the unitToTeleport for the provided services,
        //when all of the validations pass successfully and the unit is ready for teleportation,
        //and as a result - the amount of Resources of the TeleportStation must be increased by the amount of the payment.
        [Test]
        public void TeleportUnit_UnitIsReadyToTeleport_ShouldIncreaseTeleportStationResourcesByTheAmountOfPayment()
        {
            //Arrange
            var ownerMock = new Mock<IBusinessOwner>();

            var pathMock = new Mock<IPath>();
            pathMock.SetupGet(path => path.TargetLocation.Planet.Name).Returns("somePlanet");
            pathMock.SetupGet(path => path.TargetLocation.Planet.Galaxy.Name).Returns("someGalaxy");
            pathMock.SetupGet(x => x.Cost.BronzeCoins).Returns(10);
            pathMock.SetupGet(x => x.Cost.SilverCoins).Returns(10);
            pathMock.SetupGet(x => x.Cost.GoldCoins).Returns(10);

            var unitInPathUnitsMock = new Mock<IUnit>();
            unitInPathUnitsMock.SetupGet(unit => unit.CurrentLocation.Planet.Name).Returns("someOtherPlanet");
            unitInPathUnitsMock.SetupGet(unit => unit.CurrentLocation.Planet.Galaxy.Name).Returns("someotherGalaxy");
            unitInPathUnitsMock.SetupGet(unit => unit.CurrentLocation.Coordinates.Latitude).Returns(14.0);
            unitInPathUnitsMock.SetupGet(unit => unit.CurrentLocation.Coordinates.Longtitude).Returns(16.0);

            pathMock.SetupGet(path => path.TargetLocation.Planet.Units).Returns(new List<IUnit>() { unitInPathUnitsMock.Object });

            var galacticMapMock = new List<IPath>() { pathMock.Object };

            var locationMock = new Mock<ILocation>();
            locationMock.SetupGet(loc => loc.Planet.Name).Returns("somePlanet");
            locationMock.SetupGet(loc => loc.Planet.Galaxy.Name).Returns("someGalaxy");

            var station = new ExtendedTeleportStation(ownerMock.Object, galacticMapMock, locationMock.Object);

            var unitToTeleportMock = new Mock<IUnit>();
            unitToTeleportMock.SetupGet(unit => unit.CurrentLocation.Planet.Name).Returns("somePlanet");
            unitToTeleportMock.SetupGet(unit => unit.CurrentLocation.Planet.Galaxy.Name).Returns("someGalaxy");
            unitToTeleportMock.SetupGet(unit => unit.CurrentLocation.Coordinates.Latitude).Returns(12.0);
            unitToTeleportMock.SetupGet(unit => unit.CurrentLocation.Coordinates.Longtitude).Returns(15.0);
            unitToTeleportMock.Setup(unit => unit.CanPay(It.IsAny<IResources>())).Returns(true);
            unitToTeleportMock.Setup(unit => unit.Pay(pathMock.Object.Cost)).Returns(pathMock.Object.Cost);
            unitToTeleportMock.Setup(x => x.CurrentLocation.Planet.Units).Returns(new List<IUnit> { unitToTeleportMock.Object });

            var targetlocationMock = new Mock<ILocation>();
            targetlocationMock.SetupGet(loc => loc.Planet.Name).Returns("somePlanet");
            targetlocationMock.SetupGet(loc => loc.Planet.Galaxy.Name).Returns("someGalaxy");
            targetlocationMock.SetupGet(loc => loc.Coordinates.Latitude).Returns(12.0);
            targetlocationMock.SetupGet(loc => loc.Coordinates.Longtitude).Returns(15.0);

            //Act
            station.TeleportUnit(unitToTeleportMock.Object, targetlocationMock.Object);

            //Assert
            Assert.AreEqual(pathMock.Object.Cost.BronzeCoins, station.Resources.BronzeCoins); //10
            Assert.AreEqual(pathMock.Object.Cost.SilverCoins, station.Resources.SilverCoins); //10
            Assert.AreEqual(pathMock.Object.Cost.GoldCoins, station.Resources.GoldCoins); //10
        }

        //TeleportUnit should Set the unitToTeleport's previous location to unitToTeleport's current location,
        //when all of the validations pass successfully and the unit is being teleported.
        [Test]
        public void TeleportUnit_UnitIsReadyToTeleport_ShouldSetUnitsPreviousLocationToCurrentLocation()
        {
            //Arrange
            var ownerMock = new Mock<IBusinessOwner>();

            var pathMock = new Mock<IPath>();
            pathMock.SetupGet(path => path.TargetLocation.Planet.Name).Returns("somePlanet");
            pathMock.SetupGet(path => path.TargetLocation.Planet.Galaxy.Name).Returns("someGalaxy");
            pathMock.SetupGet(x => x.Cost.BronzeCoins).Returns(10);
            pathMock.SetupGet(x => x.Cost.SilverCoins).Returns(10);
            pathMock.SetupGet(x => x.Cost.GoldCoins).Returns(10);

            var unitInPathUnitsMock = new Mock<IUnit>();
            unitInPathUnitsMock.SetupGet(unit => unit.CurrentLocation.Planet.Name).Returns("someOtherPlanet");
            unitInPathUnitsMock.SetupGet(unit => unit.CurrentLocation.Planet.Galaxy.Name).Returns("someotherGalaxy");
            unitInPathUnitsMock.SetupGet(unit => unit.CurrentLocation.Coordinates.Latitude).Returns(14.0);
            unitInPathUnitsMock.SetupGet(unit => unit.CurrentLocation.Coordinates.Longtitude).Returns(16.0);

            pathMock.SetupGet(path => path.TargetLocation.Planet.Units).Returns(new List<IUnit>() { unitInPathUnitsMock.Object });

            var galacticMapMock = new List<IPath>() { pathMock.Object };

            var locationMock = new Mock<ILocation>();
            locationMock.SetupGet(loc => loc.Planet.Name).Returns("somePlanet");
            locationMock.SetupGet(loc => loc.Planet.Galaxy.Name).Returns("someGalaxy");

            var station = new ExtendedTeleportStation(ownerMock.Object, galacticMapMock, locationMock.Object);

            var unitToTeleportMock = new Mock<IUnit>();
            unitToTeleportMock.SetupGet(unit => unit.CurrentLocation.Planet.Name).Returns("somePlanet");
            unitToTeleportMock.SetupGet(unit => unit.CurrentLocation.Planet.Galaxy.Name).Returns("someGalaxy");
            unitToTeleportMock.SetupGet(unit => unit.CurrentLocation.Coordinates.Latitude).Returns(12.0);
            unitToTeleportMock.SetupGet(unit => unit.CurrentLocation.Coordinates.Longtitude).Returns(15.0);
            unitToTeleportMock.Setup(unit => unit.CanPay(It.IsAny<IResources>())).Returns(true);
            unitToTeleportMock.Setup(unit => unit.Pay(pathMock.Object.Cost)).Returns(pathMock.Object.Cost);
            unitToTeleportMock.Setup(x => x.CurrentLocation.Planet.Units).Returns(new List<IUnit> { unitToTeleportMock.Object });

            var targetlocationMock = new Mock<ILocation>();
            targetlocationMock.SetupGet(loc => loc.Planet.Name).Returns("somePlanet");
            targetlocationMock.SetupGet(loc => loc.Planet.Galaxy.Name).Returns("someGalaxy");
            targetlocationMock.SetupGet(loc => loc.Coordinates.Latitude).Returns(12.0);
            targetlocationMock.SetupGet(loc => loc.Coordinates.Longtitude).Returns(15.0);

            //Act
            station.TeleportUnit(unitToTeleportMock.Object, targetlocationMock.Object);

            //Assert
            unitToTeleportMock.VerifySet(x => x.PreviousLocation = x.CurrentLocation, Times.Once());
        }

        //TeleportUnit should Set the unitToTeleport's current location to targetLocation,
        //when all of the validations pass successfully and the unit is being teleported.
        [Test]
        public void TeleportUnit_UnitIsReadyToTeleport_ShouldSetUnitsCurrentLocationTotargetLocation()
        {
            //Arrange
            var ownerMock = new Mock<IBusinessOwner>();

            var pathMock = new Mock<IPath>();
            pathMock.SetupGet(path => path.TargetLocation.Planet.Name).Returns("somePlanet");
            pathMock.SetupGet(path => path.TargetLocation.Planet.Galaxy.Name).Returns("someGalaxy");
            pathMock.SetupGet(x => x.Cost.BronzeCoins).Returns(10);
            pathMock.SetupGet(x => x.Cost.SilverCoins).Returns(10);
            pathMock.SetupGet(x => x.Cost.GoldCoins).Returns(10);

            var unitInPathUnitsMock = new Mock<IUnit>();
            unitInPathUnitsMock.SetupGet(unit => unit.CurrentLocation.Planet.Name).Returns("someOtherPlanet");
            unitInPathUnitsMock.SetupGet(unit => unit.CurrentLocation.Planet.Galaxy.Name).Returns("someotherGalaxy");
            unitInPathUnitsMock.SetupGet(unit => unit.CurrentLocation.Coordinates.Latitude).Returns(14.0);
            unitInPathUnitsMock.SetupGet(unit => unit.CurrentLocation.Coordinates.Longtitude).Returns(16.0);

            pathMock.SetupGet(path => path.TargetLocation.Planet.Units).Returns(new List<IUnit>() { unitInPathUnitsMock.Object });

            var galacticMapMock = new List<IPath>() { pathMock.Object };

            var locationMock = new Mock<ILocation>();
            locationMock.SetupGet(loc => loc.Planet.Name).Returns("somePlanet");
            locationMock.SetupGet(loc => loc.Planet.Galaxy.Name).Returns("someGalaxy");

            var station = new ExtendedTeleportStation(ownerMock.Object, galacticMapMock, locationMock.Object);

            var unitToTeleportMock = new Mock<IUnit>();
            unitToTeleportMock.SetupGet(unit => unit.CurrentLocation.Planet.Name).Returns("somePlanet");
            unitToTeleportMock.SetupGet(unit => unit.CurrentLocation.Planet.Galaxy.Name).Returns("someGalaxy");
            unitToTeleportMock.SetupGet(unit => unit.CurrentLocation.Coordinates.Latitude).Returns(12.0);
            unitToTeleportMock.SetupGet(unit => unit.CurrentLocation.Coordinates.Longtitude).Returns(15.0);
            unitToTeleportMock.Setup(unit => unit.CanPay(It.IsAny<IResources>())).Returns(true);
            unitToTeleportMock.Setup(unit => unit.Pay(pathMock.Object.Cost)).Returns(pathMock.Object.Cost);
            unitToTeleportMock.Setup(x => x.CurrentLocation.Planet.Units).Returns(new List<IUnit> { unitToTeleportMock.Object });

            var targetlocationMock = new Mock<ILocation>();
            targetlocationMock.SetupGet(loc => loc.Planet.Name).Returns("somePlanet");
            targetlocationMock.SetupGet(loc => loc.Planet.Galaxy.Name).Returns("someGalaxy");
            targetlocationMock.SetupGet(loc => loc.Coordinates.Latitude).Returns(12.0);
            targetlocationMock.SetupGet(loc => loc.Coordinates.Longtitude).Returns(15.0);

            //Act
            station.TeleportUnit(unitToTeleportMock.Object, targetlocationMock.Object);

            //Assert
            unitToTeleportMock.VerifySet(x => x.CurrentLocation = targetlocationMock.Object, Times.Once());
        }

        //TeleportUnit should Add the unitToTeleport to the list of Units of the targetLocation (Planet.Units),
        //when all of the validations pass successfully and the unit is on its way to being teleported.
        //TODO
        [Test]
        public void TeleportUnit_UnitIsReadyToTeleport_ShouldAddUnitToTeleportToTargetLocationPlanetUnits()
        {
            //Arrange
            var ownerMock = new Mock<IBusinessOwner>();

            var pathMock = new Mock<IPath>();
            pathMock.SetupGet(path => path.TargetLocation.Planet.Name).Returns("somePlanet");
            pathMock.SetupGet(path => path.TargetLocation.Planet.Galaxy.Name).Returns("someGalaxy");
            pathMock.SetupGet(x => x.Cost.BronzeCoins).Returns(10);
            pathMock.SetupGet(x => x.Cost.SilverCoins).Returns(10);
            pathMock.SetupGet(x => x.Cost.GoldCoins).Returns(10);

            var unitInPathUnitsMock = new Mock<IUnit>();
            unitInPathUnitsMock.SetupGet(unit => unit.CurrentLocation.Planet.Name).Returns("someOtherPlanet");
            unitInPathUnitsMock.SetupGet(unit => unit.CurrentLocation.Planet.Galaxy.Name).Returns("someotherGalaxy");
            unitInPathUnitsMock.SetupGet(unit => unit.CurrentLocation.Coordinates.Latitude).Returns(14.0);
            unitInPathUnitsMock.SetupGet(unit => unit.CurrentLocation.Coordinates.Longtitude).Returns(16.0);

            pathMock.SetupGet(path => path.TargetLocation.Planet.Units).Returns(new List<IUnit>() { unitInPathUnitsMock.Object });

            var galacticMapMock = new List<IPath>() { pathMock.Object };

            var locationMock = new Mock<ILocation>();
            locationMock.SetupGet(loc => loc.Planet.Name).Returns("somePlanet");
            locationMock.SetupGet(loc => loc.Planet.Galaxy.Name).Returns("someGalaxy");

            var station = new ExtendedTeleportStation(ownerMock.Object, galacticMapMock, locationMock.Object);

            var unitToTeleportMock = new Mock<IUnit>();
            unitToTeleportMock.SetupGet(unit => unit.CurrentLocation.Planet.Name).Returns("somePlanet");
            unitToTeleportMock.SetupGet(unit => unit.CurrentLocation.Planet.Galaxy.Name).Returns("someGalaxy");
            unitToTeleportMock.SetupGet(unit => unit.CurrentLocation.Coordinates.Latitude).Returns(12.0);
            unitToTeleportMock.SetupGet(unit => unit.CurrentLocation.Coordinates.Longtitude).Returns(15.0);
            unitToTeleportMock.Setup(unit => unit.CanPay(It.IsAny<IResources>())).Returns(true);
            unitToTeleportMock.Setup(unit => unit.Pay(pathMock.Object.Cost)).Returns(pathMock.Object.Cost);
            unitToTeleportMock.Setup(x => x.CurrentLocation.Planet.Units).Returns(new List<IUnit> { unitToTeleportMock.Object });

            var targetlocationMock = new Mock<ILocation>();
            targetlocationMock.SetupGet(loc => loc.Planet.Name).Returns("somePlanet");
            targetlocationMock.SetupGet(loc => loc.Planet.Galaxy.Name).Returns("someGalaxy");
            targetlocationMock.SetupGet(loc => loc.Coordinates.Latitude).Returns(12.0);
            targetlocationMock.SetupGet(loc => loc.Coordinates.Longtitude).Returns(15.0);

            //Act
            station.TeleportUnit(unitToTeleportMock.Object, targetlocationMock.Object);
        }
    }
}
