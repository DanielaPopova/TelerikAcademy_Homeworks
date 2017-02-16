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
    }
}
