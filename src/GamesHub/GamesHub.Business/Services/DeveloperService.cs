using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using GamesHub.Business.Contracts.Services;
using GamesHub.DataAccess.Contracts.Models;
using GamesHub.DataAccess.Contracts.Repositories;

namespace GamesHub.Business.Services
{
    public class DeveloperService : IDeveloperService
    {
        private readonly IDeveloperRepository _developerRepository;

        public DeveloperService(IDeveloperRepository developerRepository)
        {
            _developerRepository = developerRepository;
        }

        public async Task Create(Developer developer)
        {
            var gameExists = await IsExisted(developer);

            if (gameExists == false)
            {
                await _developerRepository.Add(developer);
            }
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

        private async Task<bool> IsExisted(Developer developer)
        {
            var entity = await _developerRepository.GetByName(developer.Name);
            if (entity != null)
            {
                // TODO: Merge with existing data. For now just ignore
            }

            return entity != null;
        }
    }
}
