using System.Threading;
using System.Threading.Tasks;
using GeekHub.SteamProvider.Domain.Commands.Developers;
using GeekHub.SteamProvider.Domain.DataAccess;
using GeekHub.SteamProvider.Domain.Entities;
using MediatR;

namespace GeekHub.SteamProvider.Domain.Commands.Handlers.Developers
{
    public class CreateDeveloperCommandHandler : IRequestHandler<CreateDeveloperCommand, Developer>
    {
        private readonly IDevelopersRepository _repository;

        public CreateDeveloperCommandHandler(IDevelopersRepository repository)
        {
            _repository = repository;
        }
        
        public async Task<Developer> Handle(
            CreateDeveloperCommand request,
            CancellationToken cancellationToken = default)
        {
            var developer = new Developer()
            {
                Name = request.Name
            };
            
            var created = await _repository.CreateAsync(developer);
            await _repository.SaveChangesAsync();

            return created;
        }
    }
}