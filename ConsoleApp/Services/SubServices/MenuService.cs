namespace PersonsDb.Services.SubServices;

public class MenuService
{

    public void mainMenu()
    {
        Console.Clear();
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine("Persons-Db\n");
        Console.ResetColor();
        Console.WriteLine("1 Display All ");
        Console.WriteLine("2 Get Person info by Id");
        Console.WriteLine("3 Add New Person");
        Console.WriteLine("4 Update Person Info");
        Console.WriteLine("5 Delete Person\n");

        Console.ForegroundColor = ConsoleColor.DarkGray;
        Console.WriteLine("6 Exit");
        Console.ResetColor();
    }


}
