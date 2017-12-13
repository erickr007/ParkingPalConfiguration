using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ParkingPalAPI.Services;
using ParkingPalAPI.Models;

namespace ParkingPalAPI.Controllers
{
    [Produces("application/json")]
    [Route("api/Data")]
    public class DataController : Controller
    {
        private DataAccessService DataService;

        #region Constructor

        public DataController(DataAccessService service)
        {
            this.DataService = service;
        }

        #endregion


        #region Get Actions



        #endregion

    }
}