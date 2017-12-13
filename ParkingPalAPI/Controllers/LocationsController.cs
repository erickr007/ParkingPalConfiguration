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
        private DataAccessService DataService;

        #region Constructor

        public DataController(DataAccessService service)
        {
            this.DataService = service;
        }

        #endregion


        #region Get Actions

        /// <summary>
        /// Returns all existing Locations
        /// </summary>
        [Route("")]
        public List<ParkingLocation> Get()
        {
            return new List<ParkingLocation>();
        }

        /// <summary>
        /// Returns a Location with the specified id
        /// </summary>
        [Route("{id: string}")]
        public ParkingLocation Get(string id)
        {
            return new ParkingLocation();
        }

        #endregion


        #region Post Actions

        [Route("add")]
        [HttpPost]
        public ActionResult AddLocation(ParkingLocation location)
        {
            return new StatusCodeResult(200);
        }

        #endregion

    }
}