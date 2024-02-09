using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using ConsoleApp.Models;

namespace PersonsDb.Data.Config
{
    internal class ContactConfiguration : IEntityTypeConfiguration<Contact>
    {
        public void Configure(EntityTypeBuilder<Contact> builder)
        {
            // Table name
            builder.ToTable("Contacts");

            // Primary key
            builder.HasKey(c => c.ContactId);

            // Properties
            builder.Property(c => c.ContactId).HasColumnName("ContactId").IsRequired();
            builder.Property(c => c.Phone1).HasColumnName("Phone1").IsRequired();
            builder.Property(c => c.MobileNumber1).HasColumnName("MobileNumber1").IsRequired();
            builder.Property(c => c.Email1).HasColumnName("Email1").IsRequired();
            builder.Property(c => c.Email2).HasColumnName("Email2").IsRequired(false); // Make Email2 nullable if needed


            // Relationships
            builder.HasOne(c => c.Person)
                .WithOne(p => p.Contact)
                .HasForeignKey<Contact>(c => c.PersonId)
                .OnDelete(DeleteBehavior.Cascade);

            // Seed Data for Contact (if applicable)
            builder.HasData(LoadContacts().ToArray());
        }

        private static List<Contact> LoadContacts()
        {
            return new List<Contact>
        {
            new Contact { ContactId = 1, Phone1 = "111-111-1111", MobileNumber1 = "222-222-2222", Email1 = "john@example.com", PersonId = 1 },
            new Contact { ContactId = 2, Phone1 = "333-333-3333", MobileNumber1 = "444-444-4444", Email1 = "jane@example.com", PersonId = 2 },
            new Contact { ContactId = 3, Phone1 = "555-555-5555", MobileNumber1 = "666-666-6666", Email1 = "alex@example.com", PersonId = 3 }
        };
        }
    }

}
