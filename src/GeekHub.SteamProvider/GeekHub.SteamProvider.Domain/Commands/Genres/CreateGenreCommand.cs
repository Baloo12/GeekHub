using GeekHub.SteamProvider.Domain.Entities;
using MediatR;

namespace GeekHub.SteamProvider.Domain.Commands.Genres
{
    public class CreateGenreCommand : IRequest<Genre>
    {
        public string Name { get; }

        public CreateGenreCommand(string name)
        {
            Name = name;
        }
    }
}