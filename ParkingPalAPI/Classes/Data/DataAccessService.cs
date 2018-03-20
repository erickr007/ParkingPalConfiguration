
using ParkingPalAPI.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
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
            _connectionString = @"Server=tcp:shermanpark.database.windows.net,1433;Initial Catalog=parkingpal;Persist Security Info=False;User ID=erkeith;Password=ttReb00t!;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";
        }

        #endregion


        #region Parking Location Methods

        #region SELECT

        public List<ParkingLocation> GetAllLocations()
        {

            List<ParkingLocation> locations = new List<ParkingLocation>();

            #region Mock locations

            ParkingLocation p1 = new ParkingLocation();
            p1.Address = "4221 34th Street";
            p1.GlobalID = Guid.NewGuid().ToString();
            p1.HasValet = false;
            p1.Latitude = -117.3241;
            p1.Longitude = 32.8375;
            p1.ParkingType = ParkingTypes.Lot;
            p1.Title = "Ace Parking San Diego - 32";
            p1.Website = "http://aceparkingsd.com";

            ParkingLocation p2 = new ParkingLocation();
            p2.Address = "1330 Market Street";
            p2.GlobalID = Guid.NewGuid().ToString();
            p2.HasValet = false;
            p2.Latitude = -117.5241;
            p2.Longitude = 32.5895;
            p2.ParkingType = ParkingTypes.Structure;
            p2.Title = "Airport Terminal Parking";
            p2.Website = "http://airportparksd.com";

            locations.AddRange(new[] { p1, p2 });

            #endregion

            /*
            string selectCommand = "SELECT GlobalID, Title, Address, Latitude, Longitude, ParkingType, HasValet, Description, Website FROM ParkingLocations";

            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();

                using (SqlCommand command = new SqlCommand(selectCommand, connection))
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            ParkingLocation location = new ParkingLocation();
                            location.GlobalID = reader.GetGuid(0).ToString();
                            location.Title = reader.GetString(1);
                            
                            if(!reader.IsDBNull(2))
                                location.Address = reader.GetString(2);

                            location.Latitude = reader.GetFloat(3);
                            location.Longitude = reader.GetFloat(4);
                            location.ParkingType = (ParkingTypes)reader.GetInt32(5);
                            location.HasValet = reader.GetBoolean(6);

                            if(!reader.IsDBNull(7))
                                location.Description = reader.GetString(7);

                            if (!reader.IsDBNull(8))
                                location.Website = reader.GetString(8);

                            locations.Add(location);

                        }
                        
                    }
                }
            }
            */

            return locations;
        }


        public ParkingLocation GetParkingLocation(string id)
        {
            ParkingLocation location = new ParkingLocation();

            #region Mock Location

            location.Address = "5160 Carroll Canyon Rd";
            location.GlobalID = Guid.NewGuid().ToString();
            location.HasValet = false;
            location.Latitude = -117.5241;
            location.Longitude = 32.9154;
            location.ParkingType = ParkingTypes.Street;
            location.Title = "San Diego City Metered Parking";
            location.Website = "http://sandiegometered.com";

            #endregion

            /*
            string selectCommand = "SELECT GlobalID, Title, Address, Latitude, Longitude, ParkingType, HasValet, Description, Website FROM ParkingLocations ";
            selectCommand += "WHERE GlobalID = @GlobalID";

            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();

                using (SqlCommand command = new SqlCommand(selectCommand, connection))
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            
                            location.GlobalID = reader.GetGuid(0).ToString();
                            location.Title = reader.GetString(1);

                            if (!reader.IsDBNull(2))
                                location.Address = reader.GetString(2);

                            location.Latitude = reader.GetFloat(3);
                            location.Longitude = reader.GetFloat(4);
                            location.ParkingType = (ParkingTypes)reader.GetInt32(5);
                            location.HasValet = reader.GetBoolean(6);

                            if (!reader.IsDBNull(7))
                                location.Description = reader.GetString(7);

                            if (!reader.IsDBNull(8))
                                location.Website = reader.GetString(8);

                        }

                    }
                }
            }
            */

            return location;
        }


        public List<ParkingLocation> GetLocationsWithinEnvelope()
        {
            List<ParkingLocation> locations = new List<ParkingLocation>();

            string selectCommand = "SELECT * FROM ParkingLocations WHERE @Envelope.STContains(LocationPoint)";
            //32.709528, -117.170906
            //32.710729, -117.128088
            //32.739684, -117.128903
            //32.744172, -117.180230

            using (SqlConnection connection= new SqlConnection(_connectionString))
            {
                connection.Open();
                using(SqlCommand command = new SqlCommand(selectCommand, connection))
                {
                    SqlParameter envelopeParam = new SqlParameter("@Envelope", "POLYGON((-117.170906 32.709528, -117.128088 32.710729,-117.128903 32.739684,-117.180230 32.744172), 4326)");
                    command.Parameters.Add(envelopeParam);

                    using (SqlDataReader reader = command.ExecuteReader())
                    {

                    }
                }
            }

            return locations;
        }

        #endregion


        #region INSERT
        
        public void InsertParkingLocation(ParkingLocation location)
        {
            string insertComand = "INSERT INTO ParkingLocations(";
            insertComand += "GlobalID, Title, Address, Latitude, Longitude, ParkingType, HasValet, Description, Website, DateCreated, LocationPoint) ";
            insertComand += "Values(@GlobalID, @Title, @Address, @Latitude, @Longitude, @ParkingType, @HasValet, @Description, @Website, @DateCreated, @LocationPoint)";

            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();

                using (SqlCommand command = new SqlCommand(insertComand, connection))
                {
                    command.Parameters.Add(new SqlParameter("@GlobalID", location.GlobalID));
                    command.Parameters.Add(new SqlParameter("@Title", location.Title));
                    command.Parameters.Add(new SqlParameter("@Address", location.Address));
                    command.Parameters.Add(new SqlParameter("@Latitude", location.Latitude));
                    command.Parameters.Add(new SqlParameter("@Longitude", location.Longitude));
                    command.Parameters.Add(new SqlParameter("@ParkingType", location.ParkingType));
                    command.Parameters.Add(new SqlParameter("@HasValet", location.HasValet));
                    command.Parameters.Add(new SqlParameter("@Description", location.Description));
                    command.Parameters.Add(new SqlParameter("@Website", location.Website));
                    command.Parameters.Add(new SqlParameter("@DateCreated", DateTime.UtcNow));
                    string locationPoint = $"POINT({location.Longitude} {location.Latitude})";
                    command.Parameters.Add(new SqlParameter("@LocationPoint", locationPoint));

                    command.ExecuteNonQuery();
                }
            }
        }

        #endregion


        #region DELETE

        public void DeleteParkingLocation(string globalid)
        {
            string deleteCommand = "DELETE FROM ParkingLocations WHERE GlobalID = @GlobalID";

            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();

                using (SqlCommand command = new SqlCommand(deleteCommand, connection))
                {
                    command.Parameters.Add(new SqlParameter("@GlobalID", globalid));

                    command.ExecuteNonQuery();
                }
            }
        }

        #endregion


        #endregion

    }
}
