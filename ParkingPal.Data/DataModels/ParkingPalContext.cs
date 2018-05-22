using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace ParkingPal.Data
{
    public partial class ParkingPalContext : DbContext
    {
        public virtual DbSet<ParkingLocations> ParkingLocations { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer(@"Server=tcp:shermanpark.database.windows.net,1433;Initial Catalog=parkingpal;Persist Security Info=False;User ID=erkeith;Password=ttReb00t!;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ParkingLocations>(entity =>
            {
                entity.HasKey(e => e.GlobalId);

                entity.Property(e => e.Address)
                    .IsRequired()
                    .HasMaxLength(200);

                entity.Property(e => e.CompanyIdFk).HasColumnName("CompanyID_FK");

                entity.Property(e => e.DateCreated).HasColumnType("datetime");

                entity.Property(e => e.Description).HasMaxLength(300);

                entity.Property(e => e.GlobalId).HasColumnName("GlobalID");

                entity.Property(e => e.Title)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.Website)
                    .IsRequired()
                    .HasMaxLength(100);
            });
        }
    }
}
