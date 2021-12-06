using GeekHub.SteamProvider.Domain.Entities;
using MediatR;

namespace GeekHub.SteamProvider.Domain.Commands.Platforms
{
    public class CreatePlatformCommand : IRequest<Platform>
    {
        public string Name { get; }

        public CreatePlatformCommand(string name)
        {
            Name = name;
        }
    }
}