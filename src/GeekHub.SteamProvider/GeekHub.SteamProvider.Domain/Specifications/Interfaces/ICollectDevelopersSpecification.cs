using System.Collections.Generic;
using System.Threading.Tasks;
using GeekHub.SteamProvider.Domain.Entities;

namespace GeekHub.SteamProvider.Domain.Specifications.Interfaces
{
    public interface ICollectDevelopersSpecification
    {
        Task<IEnumerable<Developer>> ExecuteAsync(List<string> developersNames);
    }
}