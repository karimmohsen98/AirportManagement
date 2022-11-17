using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AM.ApplicationCore.Domain;
using AM.Infrastructure.Configuration;
using Microsoft.EntityFrameworkCore;


namespace AM.Infrastructure
{
    public class AMContext : DbContext
    {
        public AMContext()
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseLazyLoadingProxies().UseSqlServer(@"Data Source=(localdb)\mssqllocaldb;
              Initial Catalog=AirportManagementDB;Integrated Security=true");
           /* base.OnConfiguring(optionsBuilder);
           optionsBuilder.UseLazyLoadingProxies().UseSqlServer(@"Data Source=(localdb)\karimnet;
              Initial Catalog=AirportManagementDB;Integrated Securit=tue");*/
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new FlightConfiguration());
            modelBuilder.ApplyConfiguration(new PlaneConfiguration());
            modelBuilder.ApplyConfiguration(new PassengerConfiguration());
            modelBuilder.ApplyConfiguration(new TicketConfiguration());

        }
        //here we represent our entities that will be converted afterwards to tables in our db
        public DbSet<Passenger> Passengers { get; set; }    
        public DbSet<Flight> Flights { get; set; }
        public DbSet<Plane> Planes  { get; set; }
        public DbSet<Staff> Staff { get; set; }
        public DbSet<Traveler> Traveler { get; set; }
        public DbSet<Ticket> Tickets { get; set; }

        protected override void ConfigureConventions(ModelConfigurationBuilder configurationBuilder)
        {
            configurationBuilder
            .Properties<DateTime>()       //hascolumn is to only modify a specific column in the db
            .HaveColumnType("datetime2"); //havecolumn to modify all the the types in the database

        }
        public AMContext(DbContextOptions<AMContext> options) : base(options)
        {
        }

    }

}

