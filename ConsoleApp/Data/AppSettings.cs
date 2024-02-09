using ConsoleApp.Data.Config;
using ConsoleApp.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using PersonsDb.Data.Config;
using System;

namespace ConsoleApp.Data
{
    public class AppSettings : DbContext
    {
        public DbSet<Person> Persons { get; set; }
        public DbSet<Address> Addresses { get; set; }
        public DbSet<Contact> Contacts { get; set; }
        public DbSet<FamilyStatus> FamilyStatuses { get; set; }
        public DbSet<Employment> Employments { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);

            var configuration = new ConfigurationBuilder()
                .AddJsonFile("AppSettings.json")
                .Build();

            var connectionString = configuration.GetSection("constr").Value;

            if (string.IsNullOrEmpty(connectionString))
            {
                throw new InvalidOperationException("Connection string is missing or empty.");
            }

            optionsBuilder.UseSqlServer(connectionString)
                          .EnableSensitiveDataLogging();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new PersonConfiguration());
            modelBuilder.ApplyConfiguration(new AddressConfiguration());
            modelBuilder.ApplyConfiguration(new ContactConfiguration());
            modelBuilder.ApplyConfiguration(new FamilyStatusConfiguration());
            modelBuilder.ApplyConfiguration(new EmploymentConfiguration());
        }
    }
}
