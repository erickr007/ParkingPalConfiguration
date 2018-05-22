using Microsoft.EntityFrameworkCore;
using ParkingPalAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ParkingPalAPI.Data
{
    public class ParkingLocationContext : DbContext
    {
        private string _connectionString = @"Server=tcp:shermanpark.database.windows.net,1433;Initial Catalog=parkingpal;Persist Security Info=False;User ID=erkeith;Password=ttReb00t!;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";

        public DbSet<ParkingLocation> ParkingLocations { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(_connectionString);
        }
    }
}
