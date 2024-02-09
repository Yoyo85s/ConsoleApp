using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using ConsoleApp.Models;

namespace PersonsDb.Data.Config
{
    internal class EmploymentConfiguration : IEntityTypeConfiguration<Employment>
    {
        public void Configure(EntityTypeBuilder<Employment> builder)
        {
            // Table name
            builder.ToTable("Employments");

            // Primary key
            builder.HasKey(e => e.EmploymentId);

            // Properties
            builder.Property(e => e.EmploymentId).HasColumnName("EmploymentId").IsRequired();
            builder.Property(e => e.JobTitle).HasColumnName("JobTitle").IsRequired();
            builder.Property(e => e.Department).HasColumnName("Department").IsRequired();
            builder.Property(e => e.Salary).HasColumnName("Salary").IsRequired();
            builder.Property(e => e.EmploymentDate).HasColumnName("EmploymentDate").IsRequired();

            // Relationships
            builder.HasOne(e => e.Person)
                .WithOne(p => p.Employment)
                .HasForeignKey<Employment>(e => e.PersonId)
                .OnDelete(DeleteBehavior.Cascade);

            // Specify the store type for the 'Salary' property
            builder.Property(e => e.Salary)
                .HasColumnType("decimal(18, 2)");

            // Seed Data for Employment (if applicable)
            builder.HasData(LoadEmployments().ToArray());
        }

        private static List<Employment> LoadEmployments()
        {
            return new List<Employment>
            {
                new Employment { EmploymentId = 1, JobTitle = "Developer", Department = "IT", Salary = 60000, EmploymentDate = DateTime.Now.AddMonths(-12), PersonId = 1 },
                new Employment { EmploymentId = 2, JobTitle = "Manager", Department = "HR", Salary = 80000, EmploymentDate = DateTime.Now.AddMonths(-24), PersonId = 2 },
                new Employment { EmploymentId = 3, JobTitle = "Analyst", Department = "Finance", Salary = 70000, EmploymentDate = DateTime.Now.AddMonths(-18), PersonId = 3 }
            };
        }
    }
}
