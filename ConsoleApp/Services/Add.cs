using ConsoleApp.Data;
using ConsoleApp.Models;
using PersonsDb.Repository;
using System;

namespace PersonsDb.Services
{
    internal class Add
    {
        internal static void AddPerson()
        {
            
            AddRepository addRepository = new AddRepository();

            // invoke the method to add a person
            addRepository.AddPerson();
        }
    }
}
