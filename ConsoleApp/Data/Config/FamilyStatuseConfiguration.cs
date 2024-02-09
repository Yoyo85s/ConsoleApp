using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using ConsoleApp.Models;

namespace PersonsDb.Data.Config
{
    internal class FamilyStatusConfiguration : IEntityTypeConfiguration<FamilyStatus>
    {
        public void Configure(EntityTypeBuilder<FamilyStatus> builder)
        {
            // Table name
            builder.ToTable("FamilyStatuses");

            // Primary key
            builder.HasKey(f => f.FamilyStatusId);

            // Properties
            builder.Property(f => f.FamilyStatusId).HasColumnName("FamilyStatusId").IsRequired();
            builder.Property(f => f.MaritalStatus).HasColumnName("MaritalStatus").IsRequired();
            builder.Property(f => f.HasChildren).HasColumnName("HasChildren").IsRequired();

            // Relationships
            builder.HasOne(f => f.Person)
                .WithOne(p => p.FamilyStatus)
                .HasForeignKey<FamilyStatus>(f => f.PersonId)
                .OnDelete(DeleteBehavior.Cascade);

            // Seed Data for FamilyStatus (if applicable)
            builder.HasData(LoadFamilyStatuses().ToArray());
        }

        private static List<FamilyStatus> LoadFamilyStatuses()
        {
            return new List<FamilyStatus>
            {
                new FamilyStatus { FamilyStatusId = 1, MaritalStatus = false, HasChildren = false, PersonId = 1 },
                new FamilyStatus { FamilyStatusId = 2, MaritalStatus = true, HasChildren = true, PersonId = 2 },
                new FamilyStatus { FamilyStatusId = 3, MaritalStatus = false, HasChildren = false, PersonId = 3 }
            };
        }
    }
}
