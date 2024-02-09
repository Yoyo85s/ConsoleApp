using ConsoleApp.Data;
using Microsoft.EntityFrameworkCore;
using PersonsDb.IRepository;
using System;
using System.Linq;

namespace PersonsDb.Repository
{
    internal class DisplayAllRepository : IDisplayAllRepository
    {
        public void DisplayAll()
        {
            Console.Clear();

            // Create an instance of the context
            using (var context = new AppSettings())
            {
                // Ensure the database is created
                context.Database.EnsureCreated();

                // Retrieve all persons
                var allPersons = context.Persons
                    .Include(p => p.Address)
                    .Include(p => p.Contact)
                    .Include(p => p.FamilyStatus)
                    .Include(p => p.Employment)
                    .ToList();

                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("---Display All---\n");
                Console.ResetColor();

                // Display information
                foreach (var person in allPersons)
                {
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    Console.WriteLine($"Id: {person.PersonId}");
                    Console.ForegroundColor = ConsoleColor.DarkCyan;
                    Console.WriteLine($"Name: {person.Name}");
                    Console.ResetColor(); 
                    Console.WriteLine();
                    //Console.WriteLine($"Id: {person.PersonId}");
                    //Console.WriteLine($"Name: {person.Name}");
                    //Console.WriteLine();
                }
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("Press any key to return to the main menu.");
                Console.ResetColor();
                Console.ReadKey();
                Console.Clear();
            }
        }
    }
}
