using ApplicationCore;
using ApplicationCore.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Data
{
    public class CabsBookingDbContext: DbContext
    {
        public CabsBookingDbContext(DbContextOptions<CabsBookingDbContext> options): base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Delegates for Fluent api rules

            modelBuilder.Entity<Bookings>(ConfigureBookings);
            modelBuilder.Entity<BookingsHistory>(ConfigureBookingsHistory);
            modelBuilder.Entity<CabTypes>(ConfigureCabTypes);
            modelBuilder.Entity<Places>(ConfigurePlaces);
            modelBuilder.Entity<Location>(ConfigureLocation);
            modelBuilder.Entity<LocationHistory>(ConfigureLocationHistory);
        }

        private void ConfigureLocationHistory(EntityTypeBuilder<LocationHistory> builder)
        {
            builder.ToTable("LocationHistory");
            builder.HasKey(l => l.Id);
            builder.Property(l => l.PickupAddress).HasMaxLength(200);
            builder.Property(b => b.DropoffAddress).HasMaxLength(200);
            builder.Property(b => b.Landmark).HasMaxLength(30);
        }

        private void ConfigureLocation(EntityTypeBuilder<Location> builder)
        {
            builder.ToTable("Location");
            builder.HasKey(l => l.Id);
            builder.Property(l => l.PickupAddress).HasMaxLength(200);
            builder.Property(b => b.DropoffAddress).HasMaxLength(200);
            builder.Property(b => b.Landmark).HasMaxLength(30);
        }

        private void ConfigurePlaces(EntityTypeBuilder<Places> builder)
        {
            // rules
            builder.ToTable("Places");
            builder.HasKey(p => p.Id);
            builder.Property(p => p.PlaceName).HasMaxLength(30);
        }

        private void ConfigureCabTypes(EntityTypeBuilder<CabTypes> builder)
        {
            // rules
            builder.ToTable("CabTypes");
            builder.HasKey(c => c.Id);
            builder.Property(c => c.CabTypeName).HasMaxLength(30);
        }

        private void ConfigureBookingsHistory(EntityTypeBuilder<BookingsHistory> builder)
        {
            // rules
            builder.ToTable("BookingsHistory");
            builder.HasKey(b => b.Id);
            builder.Property(b => b.Email).HasMaxLength(50);
            builder.Property(b => b.BookingDate).HasColumnType("date");
            builder.Property(b => b.BookingTime).HasMaxLength(5);
            builder.Property(b => b.PickupDate).HasColumnType("date");
            builder.Property(b => b.PickupTime).HasMaxLength(5);
            builder.Property(b => b.ContactNo).HasMaxLength(25);
            builder.Property(b => b.Status).HasMaxLength(30);
            builder.Property(b => b.Comp_time).HasMaxLength(5);
            builder.Property(b => b.Charge).HasColumnType("money");
            builder.Property(b => b.Feedback).HasMaxLength(1000);
        }

        private void ConfigureBookings(EntityTypeBuilder<Bookings> builder)
        {
            // rules
            builder.ToTable("Bookings");
            builder.HasKey(b => b.Id);
            builder.Property(b => b.Email).HasMaxLength(50);
            builder.Property(b => b.BookingDate).HasColumnType("date");
            builder.Property(b => b.BookingTime).HasMaxLength(5);
            builder.Property(b => b.PickupDate).HasColumnType("date");
            builder.Property(b => b.PickupTime).HasMaxLength(5);
            builder.Property(b => b.ContactNo).HasMaxLength(25);
            builder.Property(b => b.Status).HasMaxLength(30);
        }

        // entity sets
        public DbSet<Bookings> Bookings { get; set; }
        public DbSet<BookingsHistory> BookingsHistories { get; set; }
        public DbSet<CabTypes> CabTypes { get; set; }
        public DbSet<Places> Places { get; set; }
    }
}
