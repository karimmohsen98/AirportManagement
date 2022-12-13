        using AM.ApplicationCore.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AM.Infrastructure.Configuration
{
    public class TicketConfiguration : IEntityTypeConfiguration<Ticket>
    {
        public void Configure(EntityTypeBuilder<Ticket> builder)
        {
            builder.HasKey(t => new { t.PassengerFK , t.FlightFK, t.NumTicket });

            builder.HasOne(ti => ti.passenger)
                .WithMany(p => p.tickets)
                .HasForeignKey(ti => ti.PassengerFK);

            builder.HasOne(ti => ti.flight)
                .WithMany(f => f.Tickets)
                .HasForeignKey(ti => ti.FlightFK);

        
        
        }
    }
}
