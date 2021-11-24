using System.Collections.Generic;
using System.Threading.Tasks;
using GeekHub.SteamProvider.Domain.Entities;

namespace GeekHub.SteamProvider.Domain.Specifications.Interfaces
{
    public interface ICollectPublishersSpecification
    {
        Task<IEnumerable<Publisher>> ExecuteAsync(List<string> publishersNames);
    }
}