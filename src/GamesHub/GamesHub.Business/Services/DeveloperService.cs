namespace GamesHub.Business.Services
{
    using GamesHub.Business.Contracts.Services;
    using GamesHub.DataAccess.Contracts.Models;
    using GamesHub.DataAccess.Contracts.Repositories;
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public class DeveloperService : IDeveloperService
    {
        private readonly IDeveloperRepository _developerRepository;

        public DeveloperService(IDeveloperRepository developerRepository)
        {
            _developerRepository = developerRepository;
        }

        public async Task Create(Developer developer)
        {
            await _developerRepository.Add(developer);
        }

        public async Task<IEnumerable<Developer>> GetAll()
        {
            var developers = await _developerRepository.GetAll();
            return developers;
        }

        public async Task<Guid> GetIdByName(string name)
        {
            var entity = await _developerRepository.GetByName(name);
            return entity.Id;
        }

        public async Task<bool> IsExistWithName(string developerName)
        {
            var developer = await _developerRepository.GetByName(developerName);
            return developer != null;
        }
    }
}
