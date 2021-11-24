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

            if (persistedVideoGame == null)
            {
                return null;
            }

            var dto = new SteamVideoGameDto()
            {
                SteamId = persistedVideoGame.SteamId,
                Description = persistedVideoGame.Description,
                Name = persistedVideoGame.Name,
                Website = persistedVideoGame.Website,
                Developers = persistedVideoGame.Developers,
                Publishers = persistedVideoGame.Publishers,
                IsFree = persistedVideoGame.IsFree,
                RequiredAge = persistedVideoGame.RequiredAge,
                Type = persistedVideoGame.Type,
                Genres = persistedVideoGame.Genres,
                Image = persistedVideoGame.Image,
                Platforms = persistedVideoGame.Platforms,
                ReleaseDate = persistedVideoGame.ReleaseDate
            };

            return dto;
        }
    }
}