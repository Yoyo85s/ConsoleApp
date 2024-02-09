using ConsoleApp.Data;
using PersonsDb.IRepository;
using PersonsDb.Services.SubServices;


namespace PersonsDb.Repository
{
    internal class DeleteRepository : IDeleteRepository
    {
        private readonly AppSettings _context;

        public DeleteRepository(AppSettings context)
        {
            _context = context;
        }

        public void DeletePersonById()
        {
            Console.Clear();
            // Ensure the database is created
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("---delete Person---\n");
            Console.ResetColor();
            _context.Database.EnsureCreated();
            GetAllMini getAllMiniService = new GetAllMini();
            getAllMiniService.getAllMini();
            // Prompt user for person ID to delete
            Console.Write("Enter the Person ID to delete: ");
            if (int.TryParse(Console.ReadLine(), out int personId))
            {
                // Find the person by ID
                var personToDelete = _context.Persons.Find(personId);

                if (personToDelete != null)
                {
                    // Remove the person from the context
                    _context.Persons.Remove(personToDelete);

                    // Save changes to the database
                    _context.SaveChanges();
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine($"Person with ID {personId} deleted successfully.");
                    Console.ResetColor();
                }
                else
                {
                    Console.WriteLine();
                    Console.ForegroundColor = ConsoleColor.DarkRed;
                    Console.WriteLine($"Person with ID {personId} not found.\n");
                    Console.ResetColor();
                   
                }
            }
            else
            {
                Console.WriteLine("Invalid input. Please enter a valid integer for Person ID.");
            }
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("Press any key to return to main menu.");
            Console.ResetColor();
            Console.ReadKey();
            Console.Clear();
        }
    }
}
