using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ConsoleApp.Models;
using System;
using System.Collections.Generic;

namespace PersonsDb.Data.Config
{
    public class PersonConfiguration : IEntityTypeConfiguration<Person>
    {
        public void Configure(EntityTypeBuilder<Person> builder)
        {
            // Table name
            builder.ToTable("Persons");

            // Primary key
            builder.HasKey(p => p.PersonId);

            // Properties
            builder.Property(p => p.PersonId).HasColumnName("PersonId").IsRequired();
            builder.Property(p => p.Name).HasColumnName("Name").IsRequired();
            builder.Property(p => p.Gender).HasColumnName("Gender").IsRequired();

            // Relationships
            builder.HasOne(p => p.Address)
                .WithOne(a => a.Person)
                .HasForeignKey<Address>(a => a.PersonId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(p => p.FamilyStatus)
                .WithOne(f => f.Person)
                .HasForeignKey<FamilyStatus>(f => f.PersonId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(p => p.Employment)
                .WithOne(e => e.Person)
                .HasForeignKey<Employment>(e => e.PersonId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(p => p.Contact)
                .WithOne(c => c.Person)
                .HasForeignKey<Contact>(c => c.PersonId)
                .OnDelete(DeleteBehavior.Cascade);

            // Seed Data
            builder.HasData(LoadPersons().ToArray());
        }

        private static List<Person> LoadPersons()
        {
            return new List<Person>
            {
                new Person { PersonId = 1,  Name = "Alexander Andersson", Gender = true },
                new Person { PersonId = 2, Name = "Sofie Larsson", Gender = false },
                new Person { PersonId = 3,  Name = "Yasser Sahli", Gender = true },
            };
        }
    }
}
