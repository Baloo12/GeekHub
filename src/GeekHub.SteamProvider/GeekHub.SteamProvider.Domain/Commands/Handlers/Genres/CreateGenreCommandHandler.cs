using System.Threading;
using System.Threading.Tasks;
using GeekHub.SteamProvider.Domain.Commands.Genres;
using GeekHub.SteamProvider.Domain.DataAccess;
using GeekHub.SteamProvider.Domain.Entities;
using MediatR;

namespace GeekHub.SteamProvider.Domain.Commands.Handlers.Genres
{
    public class CreateGenreCommandHandler : IRequestHandler<CreateGenreCommand, Genre>
    {
        private readonly IGenresRepository _repository;

        public CreateGenreCommandHandler(IGenresRepository repository)
        {
            _repository = repository;
        }
        
        public async Task<Genre> Handle(
            CreateGenreCommand request,
            CancellationToken cancellationToken = default)
        {
            var genre = new Genre()
            {
                Name = request.Name
            };
            
            var created = await _repository.CreateAsync(genre);
            await _repository.SaveChangesAsync();

            return created;
        }
    }
}