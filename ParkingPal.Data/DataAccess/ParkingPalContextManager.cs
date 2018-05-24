using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Extensions;
using ParkingPal.Data.Interfaces;

namespace ParkingPal.Data.DataAccess
{
    public class ParkingPalContextManager : IParkingLocationDataAccess
    {
        private ParkingPalContext _context;
        public ParkingPalContextManager(ParkingPalContext context)
        {
            _context = context;
        }


        #region SELECT

        public List<ParkingLocations> GetAllLocations()
        {
            return _context.ParkingLocations.ToList();
        }

        public ParkingLocations GetParkingLocationById(string id)
        {
            var location = from pl in _context.ParkingLocations
                           where pl.GlobalId.ToString().ToLower() == id.ToLower()
                           select pl;


            return location.First();
        }

        public List<ParkingLocations> GetLocationsWithinEnvelope(Envelope envelope)
        {
            string selectCommand = "getLocationsWithinEnvelope";

            SqlParameter xmin = new SqlParameter("@xmin", envelope.Xmin);
            SqlParameter xmax = new SqlParameter("@xmax", envelope.Xmax);
            SqlParameter ymin = new SqlParameter("@ymin", envelope.Ymin);
            SqlParameter ymax = new SqlParameter("@ymax", envelope.Ymax);

            var locations = _context.ParkingLocations.FromSql<ParkingLocations>(selectCommand, xmin, xmax, ymin, ymax);

            return locations.ToList();
        }

        #endregion


        #region INSERT

        public void InsertParkingLocation(ParkingLocations location)
        {
            _context.ParkingLocations.Add(location);

            _context.SaveChanges();
        }

        #endregion


        #region DELETE

        public void DeleteParkingLocation(string globalid)
        {
            ParkingLocations location = new ParkingLocations() { GlobalId = new Guid(globalid)};

            _context.ParkingLocations.Attach(location);
            _context.Remove<ParkingLocations>(location);
            _context.SaveChanges();
        }

            #endregion

        }
}
