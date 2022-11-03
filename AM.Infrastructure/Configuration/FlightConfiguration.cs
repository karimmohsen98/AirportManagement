using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AM.ApplicationCore.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;


namespace AM.Infrastructure.Configuration
{
    public class FlightConfiguration : IEntityTypeConfiguration<Flight>
    {
        public void Configure(EntityTypeBuilder<Flight> builder)
        {
            builder.HasMany(f => f.Passengers)
                .WithMany(p => p.Flights)
                .UsingEntity(
                j => j.ToTable("Reservation")
                );
            builder.HasOne<Plane>(f => f.Planess)
                .WithMany(p => p.Flights)
                .HasForeignKey(p => p.planeId)
                .OnDelete(DeleteBehavior.ClientSetNull);


        }
    }
}
