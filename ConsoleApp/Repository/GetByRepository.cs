using ConsoleApp.Data;
using ConsoleApp.Models;
using Microsoft.EntityFrameworkCore;
using PersonsDb.IRepository;
using PersonsDb.Services.SubServices;
using System;
using System.Linq;

namespace PersonsDb.Repository
{
    internal class GetByRepository : IGetByRepository
    {
        public void DisplayPersonById()
        {
            Console.Clear();

            // Prompt the user to input a person ID
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write("---Get Persone Info---\n\n");
            Console.ResetColor();
            GetAllMini getAllMiniService = new GetAllMini();
            getAllMiniService.getAllMini();
            Console.Write("Enter Person ID: ");
            if (int.TryParse(Console.ReadLine(), out int personId))
            {
                // Create an instance of the context
                // ...

                using (var context = new AppSettings())
                {
                    // Ensure the database is created
                    context.Database.EnsureCreated();

                    // Retrieve person by ID with related entities
                    var person = context.Persons
                        .Include(p => p.Address)
                        .Include(p => p.Contact)
                        .Include(p => p.FamilyStatus)
                        .Include(p => p.Employment)
                        .FirstOrDefault(p => p.PersonId == personId);

                    if (person != null)
                    {
                        // Display person information
                        Console.Clear();
                        Console.ForegroundColor = ConsoleColor.DarkGreen;
                        Console.WriteLine("---Person Details---\n");
                        Console.ResetColor();
                        Console.WriteLine($"Person Id: {person.PersonId}");
                        Console.WriteLine($"Name: {person.Name}");
                        Console.WriteLine($"Gender: {(person.Gender ? "Male" : "Female")}");



                        // Display Address information
                        Console.ForegroundColor = ConsoleColor.DarkGreen;
                        Console.WriteLine("Address:");
                        Console.ResetColor();
                        Console.WriteLine($"Country: {person.Address?.Country ?? "Not available"}");
                        Console.WriteLine($"City: {person.Address?.City ?? "Not available"}");
                        Console.WriteLine($"Neighborhood: {person.Address?.Neighborhood ?? "Not available"}");
                        Console.WriteLine($"Street: {person.Address?.Street ?? "Not available"}");
                        Console.WriteLine($"House Number: {person.Address?.HouseNumber ?? "Not available"}");

                        // Display Contact information
                        Console.ForegroundColor = ConsoleColor.DarkGreen;
                        Console.WriteLine("Contact:");
                        Console.ResetColor();
                        Console.WriteLine($"Phone: {person.Contact?.Phone1 ?? "Not available"}");
                        Console.WriteLine($"Mobile Number: {person.Contact?.MobileNumber1 ?? "Not available"}");
                        Console.WriteLine($"Email: {person.Contact?.Email1 ?? "Not available"}");

                        // Display Family Status information
                        Console.ForegroundColor = ConsoleColor.DarkGreen;
                        Console.WriteLine("Family Status:");
                        Console.ResetColor();
                        Console.WriteLine($"Is Married: {(person.FamilyStatus?.MaritalStatus ?? false ? "Yes" : "No")}");
                        Console.WriteLine($"Has Children: {(person.FamilyStatus?.HasChildren ?? false ? "Yes" : "No")}");



                        // Display Employment information
                        Console.ForegroundColor = ConsoleColor.DarkGreen;
                        Console.WriteLine("Employment:");
                        Console.ResetColor();
                        Console.WriteLine($"Job Title: {person.Employment?.JobTitle ?? "Not available"}");
                        Console.WriteLine($"Department: {person.Employment?.Department ?? "Not available"}");
                        Console.WriteLine($"Salary: {person.Employment?.Salary ?? 0}");
                        Console.WriteLine($"Employment Date: {person.Employment?.EmploymentDate ?? DateTime.MinValue}");

                        Console.WriteLine();
                    }
                    else
                    {
                        Console.Clear();
                        Console.ForegroundColor = ConsoleColor.DarkRed;
                        Console.WriteLine($"Person with ID {personId} not found.\n");
                        Console.ResetColor();
                    }
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine("Press any key to return to main menu.");
                    Console.ResetColor();
                    Console.ReadKey();
                    Console.Clear();
                }

                // ...

            }
            else
            {
                Console.WriteLine("Invalid input. Please enter a valid numeric Person ID.");
            }
        }

    }
}
