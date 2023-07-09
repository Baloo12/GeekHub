using System.Threading;
using System.Threading.Tasks;
using GeekHub.SteamProvider.Domain.Commands.Platforms;
using GeekHub.SteamProvider.Domain.DataAccess;
using GeekHub.SteamProvider.Domain.Entities;
using MediatR;

namespace GeekHub.SteamProvider.Domain.Commands.Handlers.Platforms
{
    public class CreatePlatformCommandHandler : IRequestHandler<CreatePlatformCommand, Platform>
    {
        private readonly IPlatformsRepository _repository;

        public CreatePlatformCommandHandler(IPlatformsRepository repository)
        {
            _repository = repository;
        }
        
        public async Task<Platform> Handle(
            CreatePlatformCommand request,
            CancellationToken cancellationToken = default)
        {
            var platform = new Platform()
            {
                Name = request.Name
            };
            
            var created = await _repository.CreateAsync(platform);
            await _repository.SaveChangesAsync();

            return created;
        }
    }
}