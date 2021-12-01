namespace GeekHub.BoardGames.BggProvider.Domain.Api
{
    using GeekHub.BoardGames.BggProvider.Domain.Entities;

    public interface IGameBuilder
    {
        BoardGame Build();

        IGameBuilder WithBggId();

        IGameBuilder WithName();
    }
}
