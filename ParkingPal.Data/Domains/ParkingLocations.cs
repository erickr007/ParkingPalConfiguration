using System;
using System.Collections.Generic;

namespace ParkingPal.Data
{
    public partial class ParkingLocations
    {
        public int Id { get; set; }
        public Guid GlobalId { get; set; }
        public Guid? CompanyIdFk { get; set; }
        public string Title { get; set; }
        public string Address { get; set; }
        public string Description { get; set; }
        public bool HasValet { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }
        public int ParkingType { get; set; }
        public string Website { get; set; }
        public DateTime DateCreated { get; set; }
    }
}
