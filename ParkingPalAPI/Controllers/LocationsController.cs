using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ParkingPalAPI.Services;
using ParkingPalAPI.Models;
using System.Net.Http;
using Microsoft.AspNetCore.Cors;
using Newtonsoft.Json;

namespace ParkingPalAPI.Controllers
{
    [EnableCors("AllowAll")]
    [Produces("application/json")]
    [Route("Locations")]
    public class LocationsController : Controller
    {
        private DataAccessService _dataAccessService;

        #region Constructor

        public LocationsController(DataAccessService service)
        {
            this._dataAccessService = service;
        }

        #endregion


        #region Get Actions

        /// <summary>
        /// Returns all existing Locations
        /// </summary>
        [HttpGet("")]
        public List<ParkingLocation> GetAllLocations()
        {
            return _dataAccessService.GetAllLocations();
        }

        /// <summary>
        /// Returns a Location with the specified id
        /// </summary>
        [HttpGet("{id}")]
        public ParkingLocation GetLocationByID(string id)
        {
            return _dataAccessService.GetParkingLocation(id);
        }

        [HttpPost("envelope")]
        public List<ParkingLocation> GetLocationsByEnvelope([FromBody]Envelope envelope)
        {
            List<ParkingLocation> locations = new List<ParkingLocation>();
            //Envelope envelope = new Envelope();
            //envelope.Xmin = -118.180230;
            //envelope.Xmax = -116.128088;
            //envelope.Ymin = 31.709528;
            //envelope.Ymax = 33.739684;
            locations = _dataAccessService.GetLocationsWithinEnvelope(envelope);

            return locations;
        }

        #endregion


        #region Post Actions

        /// <summary>
        /// Inserts a new ParkingLocation record
        /// </summary>
        [EnableCors("AllowAll")]
        [HttpPost]
        [Route("Add")]
        public void AddLocation([FromBody]string locationJson)
        {
            ParkingLocation location = JsonConvert.DeserializeObject<ParkingLocation>(locationJson);
            try
            {
                location.GlobalID = Guid.NewGuid().ToString();

                _dataAccessService.InsertParkingLocation(location);
            }
            catch(Exception ex)
            {
                //return new StatusCodeResult(500);
            }

            //return new StatusCodeResult(200);
        }

        #endregion

    }
}