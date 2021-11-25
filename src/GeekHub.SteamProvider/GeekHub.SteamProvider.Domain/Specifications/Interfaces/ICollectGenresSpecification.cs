using System.Collections.Generic;
using System.Threading.Tasks;
using GeekHub.SteamProvider.Domain.Entities;

namespace GeekHub.SteamProvider.Domain.Specifications.Interfaces
{
    public interface ICollectGenresSpecification
    {
        Task<IEnumerable<Genre>> ExecuteAsync(List<string> genresNames);
    }
}