//using Microsoft.VisualStudio.TestTools.UnitTesting;
using NUnit.Framework;
using ParkingPal.Data;
using ParkingPal.Data.DataAccess;
using ParkingPal.Data.Interfaces;

namespace ParkingPal.Data.Tests
{
    [TestFixture]
    public class ParkingLocationsDataAccessTests
    {
        IParkingLocationDataAccess _dataAccessManager;

        public ParkingLocationsDataAccessTests()
        {
            _dataAccessManager = new ParkingPalContextManager(new ParkingPalContext());
        }

        [Test]
        public void GetLocation_WithValidID_ReturnsLocation()
        {


            //Arrange
            ParkingLocations result = null;

            //Act
            result = _dataAccessManager.GetParkingLocationById("736b13df-e666-4ef8-bd22-dc2500634020");

            //Assert
            Assert.IsNotNull(result);
        }
    }
}
