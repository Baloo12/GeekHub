namespace GeekHub.BoardGames.BggProvider.Domain
{
    using GeekHub.BoardGames.BggProvider.Domain.Entities;

    public interface IGameBuilder
    {
        BoardGame Build();

        IGameBuilder WithName();

        IGameBuilder WithBggId();
    }
}
