using System.Threading.Tasks;
using GeekHub.SteamProvider.Domain.DataAccess;
using GeekHub.SteamProvider.Domain.Models.External;

namespace GeekHub.SteamProvider.Domain.Provider
{
    public class VideoGamesProvider : IVideoGamesProvider
    {
        private readonly IVideoGamesRepository _repository;

        public VideoGamesProvider(IVideoGamesRepository repository)
        {
            _repository = repository;
        }
        
        public async Task<SteamVideoGameDto> Get(string steamId)
        {
            var persistedVideoGame = await _repository.GetBySteamIdAsync(steamId);

            var dto = new SteamVideoGameDto()
            {
                Description = persistedVideoGame.Description,
                Name = persistedVideoGame.Name,
                Website = persistedVideoGame.Website,
                // Developers = details.Data.Developers,
                // Publishers = details.Data.Publishers,
                IsFree = persistedVideoGame.IsFree,
                RequiredAge = persistedVideoGame.RequiredAge,
                Type = persistedVideoGame.Type,
                // Genres = details.Data.Genres?.Select(g => g.Description).ToList(),
                Image = persistedVideoGame.Image,
                // Platforms = details.Data.Platforms?.Where(p => p.Value).Select(p => p.Key).ToList(),
                ReleaseDate = persistedVideoGame.ReleaseDate
            };

            return dto;
        }
    }
}