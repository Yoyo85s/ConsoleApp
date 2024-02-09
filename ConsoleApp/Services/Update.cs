using ConsoleApp.Data;
using PersonsDb.IRepository;
using System;

namespace PersonsDb.Services
{
    internal class Update
    {
        private readonly IUpdateRepository _updateRepository;

        public Update(IUpdateRepository updateRepository)
        {
            _updateRepository = updateRepository;
        }

        internal void UpdatePersonInformation()
        {
            _updateRepository.UpdatePersonInformation();
        }
    }
}
