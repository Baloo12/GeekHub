using System;
using System.Linq;
using System.Threading.Tasks;
using GeekHub.SteamProvider.Domain.DataAccess;
using GeekHub.VideoGames.Contracts.Dtos.Steam;

namespace GeekHub.SteamProvider.Domain.Provider
{
    public class VideoGamesProvider : IVideoGamesProvider
    {
        private readonly IVideoGamesRepository _repository;

        public VideoGamesProvider(IVideoGamesRepository repository)
        {
            _repository = repository;
        }
        
        public async Task<VideoGameDto> Get(Guid geekHubId)
        {
            var persistedVideoGame = await _repository.GetByGeekHubIdAsync(geekHubId);

            if (persistedVideoGame == null)
            {
                return null;
            }

            var dto = new VideoGameDto()
            {
                ExternalId = persistedVideoGame.SteamId,
                Description = persistedVideoGame.Description,
                Name = persistedVideoGame.Name,
                Website = persistedVideoGame.Website,
                Developers = persistedVideoGame.Developers.Select(d => new DeveloperDto()
                {
                    Id = d.Id,
                    Name = d.Name
                }).ToList(),
                Publishers = persistedVideoGame.Publishers.Select(d => new PublisherDto()
                {
                    Id = d.Id,
                    Name = d.Name
                }).ToList(),
                IsFree = persistedVideoGame.IsFree,
                RequiredAge = persistedVideoGame.RequiredAge,
                Genres = persistedVideoGame.Genres.Select(d => new GenreDto()
                {
                    Id = d.Id,
                    Name = d.Name
                }).ToList(),
                Image = persistedVideoGame.Image,
                Platforms = persistedVideoGame.Platforms.Select(d => new PlatformDto()
                {
                    Id = d.Id,
                    Name = d.Name
                }).ToList(),
                ReleaseDate = new DateTime() //persistedVideoGame.ReleaseDate
            };

            return dto;
        }
    }
}