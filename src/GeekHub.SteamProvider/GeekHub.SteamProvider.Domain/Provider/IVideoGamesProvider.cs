using System.Threading.Tasks;
using GeekHub.SteamProvider.Domain.Models.External;

namespace GeekHub.SteamProvider.Domain.Provider
{
    public interface IVideoGamesProvider
    {
        public Task<SteamVideoGameDto> Get(string steamId);
    }
}