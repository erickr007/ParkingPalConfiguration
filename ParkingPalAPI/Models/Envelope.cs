using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace ParkingPalAPI.Models
{
    [Serializable]
    [JsonObject("Envelope")]
    public class Envelope
    {

        #region Private Fields

        private double _xmin;
        private double _xmax;
        private double _ymin;
        private double _ymax;
        private int _wkid;

        #endregion


        #region Public Properties

        [JsonProperty("xmin")]
        public double Xmin
        {
            get { return _xmin; }
            set { _xmin = value; }
        }

        [JsonProperty("xmax")]
        public double Xmax
        {
            get { return _xmax; }
            set { _xmax = value; }
        }

        [JsonProperty("ymin")]
        public double Ymin
        {
            get { return _ymin; }
            set { _ymin = value; }
        }

        [JsonProperty("ymax")]
        public double Ymax
        {
            get { return _ymax; }
            set { _ymax = value; }
        }

        [JsonProperty("wkid")]
        public int Wkid
        {
            get { return _wkid; }
            set { _wkid = value; }
        }

        #endregion


        public Envelope()
        {
            this.Xmin = 0;
            this.Xmax = 0;
            this.Ymin = 0;
            this.Ymax = 0;
            this.Wkid = 4326;
        }

    }
}
