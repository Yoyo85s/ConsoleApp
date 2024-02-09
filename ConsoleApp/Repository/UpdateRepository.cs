using ConsoleApp.Data;
using ConsoleApp.Models;
using Microsoft.EntityFrameworkCore;
using PersonsDb.IRepository;
using PersonsDb.Services;
using PersonsDb.Services.SubServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonsDb.Repository
{
    public class UpdateRepository : IUpdateRepository
    {


        public void UpdatePersonInformation()
        {
            // Create an instance of the context
            using (var context = new AppSettings())
            {
                Console.Clear();

                // Prompt user to enter the ID of the person to update

                Console.Write("Enter the ID of the person to update: ");
                if (!int.TryParse(Console.ReadLine(), out int personId))
                {
                    Console.ForegroundColor = ConsoleColor.DarkRed;
                    Console.WriteLine("Invalid input for person ID.");
                    Console.ResetColor();
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine("Press any key to return to the main menu.");
                    Console.ResetColor();
                    Console.ReadKey();
                    Console.Clear();
                    return;
                }

                // Retrieve the existing person from the database
                var existingPerson = context.Persons
                    .Include(p => p.Address)
                    .Include(p => p.Contact)
                    .Include(p => p.FamilyStatus)
                    .Include(p => p.Employment)
                    .FirstOrDefault(p => p.PersonId == personId);

                if (existingPerson == null)
                {
                    Console.ForegroundColor = ConsoleColor.DarkRed;
                    Console.WriteLine($"Person with ID {personId} not found.");
                    Console.ResetColor();
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine("Press any key to return to the main menu.");
                    Console.ResetColor();
                    Console.ReadKey();
                    Console.Clear();
                    return;
                }

                // Prompt user for updated person details
                Console.Write("Enter Full Name: ");
                existingPerson.Name = Console.ReadLine();

                bool gender;
                if (InputValidator.TryParseGender(out gender))
                {
                    existingPerson.Gender = gender;
                }
                else
                {
                    Console.WriteLine("Failed to get valid gender after multiple attempts.");
                }

                Console.WriteLine("Enter Address Details:");
                Console.Write("Country: ");
                existingPerson.Address.Country = Console.ReadLine();
                Console.Write("City: ");
                existingPerson.Address.City = Console.ReadLine();
                Console.Write("Neighborhood: ");
                existingPerson.Address.Neighborhood = Console.ReadLine();
                Console.Write("Street: ");
                existingPerson.Address.Street = Console.ReadLine();
                Console.Write("House Number: ");
                existingPerson.Address.HouseNumber = Console.ReadLine();

                Console.WriteLine();
                Console.WriteLine("Enter Contact Details:");
                Console.Write("Phone: ");
                existingPerson.Contact.Phone1 = Console.ReadLine();
                Console.Write("Mobile Number: ");
                existingPerson.Contact.MobileNumber1 = Console.ReadLine();
                Console.Write("Email: ");
                existingPerson.Contact.Email1 = Console.ReadLine();

                Console.WriteLine();
                Console.WriteLine("Enter Family Status Details:");

                bool isMarried;
                if (InputValidator.TryParseMaritalStatus(out isMarried))
                {
                    existingPerson.FamilyStatus.MaritalStatus = isMarried;
                }
                else
                {
                    Console.WriteLine("Failed to get valid Marital status after multiple attempts.");
                }

                bool hasChildren;
                if (InputValidator.TryParseHasChildren(out hasChildren))
                {
                    existingPerson.FamilyStatus.HasChildren = hasChildren;
                }
                else
                {
                    Console.WriteLine("Failed to get valid Has Children status after multiple attempts.");
                }

                Console.WriteLine("Enter Employment Details:");
                Console.Write("Job Title: ");
                existingPerson.Employment.JobTitle = Console.ReadLine();
                Console.Write("Department: ");
                existingPerson.Employment.Department = Console.ReadLine();
                Console.Write("Salary: ");
                decimal.TryParse(Console.ReadLine(), out decimal salary);
                existingPerson.Employment.Salary = salary;

                // Assuming employment date remains unchanged
                // existingPerson.Employment.EmploymentDate = existingPerson.Employment.EmploymentDate;

                // Save changes to the database
                context.SaveChanges();

                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine($"Person with ID {existingPerson.PersonId} updated successfully.");
                Console.ResetColor();
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("Press any key to return to the main menu.");
                Console.ResetColor();
                Console.ReadKey();
                Console.Clear();
            }
        }

        // Helper method to display person information
        public  void DisplayPersonInformation(Person person)
        {
            Console.WriteLine($"Person Id: {person.PersonId}");
            Console.WriteLine($"Name: {person.Name}");
            Console.WriteLine($"Gender: {person.Gender}");
            Console.WriteLine($"Address: {person.Address?.Country} {person.Address?.City} {person.Address?.Neighborhood} {person.Address?.Street} {person.Address?.HouseNumber}");
            Console.WriteLine($"Contact: {person.Contact?.Phone1} {person.Contact?.MobileNumber1} {person.Contact?.Email1}");
            Console.WriteLine($"Family Status: {person.FamilyStatus?.MaritalStatus} {person.FamilyStatus?.HasChildren}");
            Console.WriteLine($"Employment: {person.Employment?.JobTitle} {person.Employment?.Department} {person.Employment?.Salary} {person.Employment?.EmploymentDate}");
        }


    }
}
