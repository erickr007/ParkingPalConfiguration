using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ParkingPalAPI.Services
{
    public class DataAccessService
    {

        #region Private Properties

        private string _connectionString;

        #endregion


        #region Public Properties

        public string ConnectionString
        {
            get { return _connectionString; }
            set { _connectionString = value; }
        }

        #endregion


        #region Constructor

        public DataAccessService()
        {
            _connectionString = "";
        }

        #endregion


        

    }
}
