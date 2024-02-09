using ConsoleApp.Data;
using PersonsDb.IRepository;
using System;

namespace PersonsDb.Services
{
    internal class GetBy
    {
        private readonly IGetByRepository _getByRepository;

        public GetBy(IGetByRepository getByRepository)
        {
            _getByRepository = getByRepository ?? throw new ArgumentNullException(nameof(getByRepository));
        }

        internal void DisplayPersonById()
        {
            _getByRepository.DisplayPersonById();
        }
    }
}
