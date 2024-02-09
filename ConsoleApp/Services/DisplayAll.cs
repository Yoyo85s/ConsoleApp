using System;
using System.Linq;
using ConsoleApp.Data;
using Microsoft.EntityFrameworkCore;
using PersonsDb.IRepository;

namespace PersonsDb.Services
{
    internal class DisplayAllService : IDisplayAllRepository  
    {
        private readonly IDisplayAllRepository _displayAllRepository;

        public DisplayAllService(IDisplayAllRepository displayAllRepository)
        {
            _displayAllRepository = displayAllRepository;
        }

        public void DisplayAll()  
        {
            _displayAllRepository.DisplayAll();
        }
    }
}
