using ConsoleApp.Data;
using PersonsDb.Repository;
using PersonsDb.Services;
using PersonsDb.Services.SubServices;

class Program
{
    private static readonly AppSettings context = new AppSettings();

    static void Main()
    {
        Console.Title = " Persons-Db ";
        char UserChoice;

        MenuService menus = new MenuService();
        DisplayAllService displayAllService = new DisplayAllService(new DisplayAllRepository());
        var deletePersonService = new DeleteService(new DeleteRepository(context));
        var updatePersonInfoService = new Update(new UpdateRepository());
        var getByService = new GetBy(new GetByRepository());

        while (true)
        {
            menus.mainMenu();

            ConsoleKeyInfo key = Console.ReadKey(intercept: true);

            switch (key.KeyChar)
            {
                case '1':

                    displayAllService.DisplayAll();

                    break;

                case '2':

                    getByService.DisplayPersonById();

                    break;

                case '3':

                    Add.AddPerson();

                    break;

                case '4':

                    updatePersonInfoService.UpdatePersonInformation();

                    break;

                case '5':

                    deletePersonService.DeletePersonById();

                    break;

                case '6':

                    Console.Clear();
                    Console.WriteLine("Exiting the application. Goodbye!");
                    Thread.Sleep(2000); // Sleep for 2000 milliseconds (2 seconds)
                    Environment.Exit(0);

                    break;

            }
        }
    }
}
