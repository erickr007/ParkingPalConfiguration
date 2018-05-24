using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ParkingPal.Data.Interfaces
{
    public interface IParkingLocationDataAccess
    {
        List<ParkingLocations> GetAllLocations();
        ParkingLocations GetParkingLocationById(string id);
        List<ParkingLocations> GetLocationsWithinEnvelope(Envelope envelope);
        void InsertParkingLocation(ParkingLocations location);
        void DeleteParkingLocation(string globalid);
    }
}
