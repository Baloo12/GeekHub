using GeekHub.SteamProvider.Domain.Entities;
using MediatR;

namespace GeekHub.SteamProvider.Domain.Commands.Developers
{
    public class CreateDeveloperCommand : IRequest<Developer>
    {
        public string Name { get; }

        public CreateDeveloperCommand(string name)
        {
            Name = name;
        }
    }
}