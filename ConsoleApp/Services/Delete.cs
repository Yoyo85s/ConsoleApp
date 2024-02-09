using ConsoleApp.Data;
using PersonsDb.IRepository;
using PersonsDb.Repository;
using System;

namespace PersonsDb.Services
{
    internal class DeleteService : IDeleteRepository
    {
        private readonly IDeleteRepository _deleteRepository;

        public DeleteService(IDeleteRepository deleteRepository)
        {
            _deleteRepository = deleteRepository;
        }

        public void DeletePersonById()
        {
            _deleteRepository.DeletePersonById();
        }
    }
}
