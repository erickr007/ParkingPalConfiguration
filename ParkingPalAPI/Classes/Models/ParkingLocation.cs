using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace ParkingPalAPI.Models
{
    [Serializable]
    [JsonObject(Title = "ParkingLocation")]
    public class ParkingLocation
    {

        #region Private Properties

        private string _globalID;
        private string _title;
        private string _address;
        private double _latitude;
        private double _longitude;
        private ParkingTypes _parkingType;
        private bool _hasValet;
        private string _description;
        private string _website;

        #endregion


        #region Public Properties

        [JsonProperty(PropertyName = "gi")]
        public string GlobalID
        {
            get { return _globalID; }
            set { _globalID = value; }
        }


        [JsonProperty(PropertyName = "tt")]
        public string Title
        {
            get { return _title; }
            set { _title = value; }
        }


        [JsonProperty(PropertyName = "ad")]
        public string Address
        {
            get { return _address; }
            set { _address = value; }
        }


        [JsonProperty(PropertyName = "lt")]
        public double Latitude
        {
            get { return _latitude; }
            set { _latitude = value; }
        }


        [JsonProperty(PropertyName = "lg")]
        public double Longitude
        {
            get { return _longitude; }
            set { _longitude = value; }
        }


        [JsonProperty(PropertyName = "pt")]
        public ParkingTypes ParkingType
        {
            get { return _parkingType; }
            set { _parkingType = value; }
        }


        [JsonProperty(PropertyName = "hv")]
        public bool HasValet
        {
            get { return _hasValet; }
            set { _hasValet = value; }
        }


        [JsonProperty(PropertyName = "ds")]
        public string Description
        {
            get { return _description; }
            set { _description = value; }
        }


        [JsonProperty(PropertyName ="ws")]
        public string Website
        {
            get { return _website; }
            set { _website = value; }
        }


        #endregion

    }


    public enum ParkingTypes
    {
        Meter = 0,
        Structure = 1,
        Lot = 2,
        Residence = 3,
        Business = 4,
        Other = 5
    }

}
