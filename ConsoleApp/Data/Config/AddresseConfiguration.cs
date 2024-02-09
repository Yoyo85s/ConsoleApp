using ConsoleApp.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;

namespace ConsoleApp.Data.Config
{
    internal class AddressConfiguration : IEntityTypeConfiguration<Address>
    {
        public void Configure(EntityTypeBuilder<Address> builder)
        {
            // Table name
            builder.ToTable("Addresses");

            // Primary key
            builder.HasKey(a => a.AddressId);

            // Properties
            builder.Property(a => a.AddressId).HasColumnName("AddressId").IsRequired();
            builder.Property(a => a.Country).HasColumnName("Country").IsRequired();
            builder.Property(a => a.City).HasColumnName("City").IsRequired();
            builder.Property(a => a.Neighborhood).HasColumnName("Neighborhood").IsRequired();
            builder.Property(a => a.Street).HasColumnName("Street").IsRequired();
            builder.Property(a => a.HouseNumber).HasColumnName("HouseNumber").IsRequired();



            builder.HasOne(a => a.Person)
      .WithOne(p => p.Address)
      .HasForeignKey<Address>(a => a.PersonId)
      .OnDelete(DeleteBehavior.Cascade);




            // Seed Data for Address (if applicable)
            builder.HasData(LoadAddresses().ToArray());
        }

        private static List<Address> LoadAddresses()
        {
            return new List<Address>
            {
                new Address { AddressId = 1, Country = "Country1", City = "City1", Neighborhood = "Neighborhood1", Street = "Street1", HouseNumber = "123", PersonId = 1 },
                new Address { AddressId = 2, Country = "Country2", City = "City2", Neighborhood = "Neighborhood2", Street = "Street2", HouseNumber = "456", PersonId = 2 },
                new Address { AddressId = 3, Country = "Country3", City = "City3", Neighborhood = "Neighborhood3", Street = "Street3", HouseNumber = "789", PersonId = 3 }
            };
        }
    }
}
