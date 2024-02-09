using ConsoleApp.Data;


namespace PersonsDb.Services
{
    internal static class InputValidator
    {
        public static bool TryParseGender(out bool gender)
        {
            do
            {
                Console.Write("Enter Gender(1 for Male, 0 for Female): ");

                string userInput = Console.ReadLine();

                if (userInput == "1" || userInput == "0")
                {
                    gender = userInput == "1";

                    if (gender)
                    {
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine("Male selected.\n");
                        Console.ResetColor();
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine("Female selected.\n");
                        Console.ResetColor();
                    }

                    return true;
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.DarkRed;
                    Console.WriteLine("Invalid input. Please enter 1 for Male or 0 for Female. Try again.");
                    Console.ResetColor();
                }
            } while (true);
        }


        public static bool TryParseMaritalStatus(out bool isMarried)
        {
            do
            {
                Console.Write("Enter Marital Status (1 for Married, 0 for Single): ");

                string userInput = Console.ReadLine();

                if (userInput == "1" || userInput == "0")
                {
                    isMarried = userInput == "1";

                    if (isMarried)
                    {
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine("Married selected.\n");
                        Console.ResetColor();
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine("Single selected.\n");
                        Console.ResetColor();
                    }

                    return true;
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.DarkRed;
                    Console.WriteLine("Invalid input. Please enter 1 for Married or 0 for Single. Try again.");
                    Console.ResetColor();
                }
            } while (true);
        }


        public static bool TryParseHasChildren(out bool hasChildren)
        {
            do
            {
                Console.Write("Has Children (1 for YES, 0 for NO): ");
                string userInput = Console.ReadLine();

                if (userInput == "1" || userInput == "0")
                {
                    hasChildren = userInput == "1";

                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine($"Has Children set to: {(hasChildren ? "YES" : "NO")}\n");
                    Console.ResetColor();

                    return true;
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.DarkRed;
                    Console.WriteLine("Invalid input. Please enter '1' for YES or '0' for NO. Try again.");
                    Console.ResetColor();
                }
            } while (true);
        }



        public static bool IsPersonIdAvailable(int personId)
        {
            using (var context = new AppSettings())
            {
                // Check if a person with the given ID exists in the database
                return context.Persons.Any(p => p.PersonId == personId);

            }
        }






    }
}
