namespace GeekHub.BoardGames.BggProvider.Domain.Api.EntityBuilders.Game
{
    using GeekHub.BoardGames.BggProvider.Domain.Entities;

    public interface IGameBuilder : IEntityBuilder<BoardGame> 
    {

        IGameBuilder WithBggId();

        IGameBuilder WithName();
    }
}
