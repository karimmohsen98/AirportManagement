using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AM.ApplicationCore.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AM.Infrastructure.Configuration
{
    public class PassengerConfiguration : IEntityTypeConfiguration<Passenger>
    {
        public void Configure(EntityTypeBuilder<Passenger> builder)
        {
            builder.HasDiscriminator<string>("IsTraveller")
                .HasValue<Traveler>("1")
                .HasValue<Staff>("2")
                .HasValue<Passenger>("0");

            builder.OwnsOne(p => p.fullName, fullN =>
                {
                    fullN.Property(f => f.FirstName)
                    .HasMaxLength(30)
                    .HasColumnName("PassFirstName");
                    fullN.Property(f => f.LastName)
                    .IsRequired()
                    .HasColumnName("PassLastName");
                }
                );
                    
                }

            }
                
               
        }

    

