namespace GeekHub.BoardGames.BggProvider.Domain.Queries
{
    using System.Collections.Generic;

    using GeekHub.BoardGames.BggProvider.Domain.Dtos;

    using MediatR;

    public class QueryPlaysByUserNameRequest : IRequest<IEnumerable<PlayRecordModel>>
    {
        public string Username { get; }

        public QueryPlaysByUserNameRequest(string username)
        {
            Username = username;
        }
    }
}
