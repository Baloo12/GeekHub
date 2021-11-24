using System.Collections.Generic;
using System.Threading.Tasks;
using GeekHub.SteamProvider.Domain.Entities;

namespace GeekHub.SteamProvider.Domain.Specifications.Interfaces
{
    public interface ICollectPlatformsSpecification
    {
        Task<IEnumerable<Platform>> ExecuteAsync(List<string> platformsNames);
    }
}