using ConsoleApp.Data;
using Microsoft.EntityFrameworkCore;


namespace PersonsDb.Services.SubServices
{
    internal class GetAllMini
    {
        public void getAllMini()
        {

            // create an instance of the context
            using (var context = new AppSettings())
            {
                // ensure the database is created
                context.Database.EnsureCreated();

                // retrieve all persons
                var allPersons = context.Persons
                    .Include(p => p.Address)
                    .Include(p => p.Contact)
                    .Include(p => p.FamilyStatus)
                    .Include(p => p.Employment)
                    .ToList();

                
                foreach (var person in allPersons)
                {
                    Console.ForegroundColor = ConsoleColor.DarkGray;
                    Console.WriteLine($"Id: {person.PersonId}");
                    Console.WriteLine($"Name: {person.Name}");
                    Console.WriteLine();
                    Console.ResetColor();
                }
            }
        }
    }
}
