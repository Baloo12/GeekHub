namespace GeekHub.BoardGames.BggProvider.Domain.Queries
{
    using GeekHub.BoardGames.BggProvider.Domain.Dtos;

    using MediatR;

    public class QueryGameByIdRequest : IRequest<BoardGameModel>
    {
        public QueryGameByIdRequest(int gameId)
        {
            GameId = gameId;
        }

        public int GameId { get; }
    }
}
