using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ParkingPalAPI.Services;
using ParkingPalAPI.Models;
using System.Net.Http;

namespace ParkingPalAPI.Controllers
{
    [Produces("application/json")]
    [Route("api/locations")]
    public class LocationsController : Controller
    {
        private DataAccessService _dataAccessService;

        #region Constructor

        public DataController(DataAccessService service)
        {
            this._dataAccessService = service;
        }

        #endregion


        #region Get Actions

        /// <summary>
        /// Returns all existing Locations
        /// </summary>
        [Route("")]
        public List<ParkingLocation> Get()
        {
            return _dataAccessService.GetAllLocations();
        }

        /// <summary>
        /// Returns a Location with the specified id
        /// </summary>
        [Route("{id: string}")]
        public ParkingLocation Get(string id)
        {
            return _dataAccessService.GetParkingLocation(id);
        }

        #endregion


        #region Post Actions

        /// <summary>
        /// Inserts a new ParkingLocation record
        /// </summary>
        [Route("add")]
        [HttpPost]
        public ActionResult AddLocation([FromBody]ParkingLocation location)
        {
            try
            {
                _dataAccessService.InsertParkingLocation(location);
            }
            catch(Exception ex)
            {
                return new StatusCodeResult(500);
            }

            return new StatusCodeResult(200);
        }

        #endregion

    }
}