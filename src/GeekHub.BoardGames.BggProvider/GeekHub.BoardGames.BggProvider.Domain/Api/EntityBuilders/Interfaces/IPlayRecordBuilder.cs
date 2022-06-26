namespace GeekHub.BoardGames.BggProvider.Domain.Api.EntityBuilders.Interfaces
{
    using GeekHub.BoardGames.BggProvider.Domain.Entities;

    public interface IPlayRecordBuilder : IEntityBuilder<PlayRecord>
    {
        IPlayRecordBuilder WithBggId();

        IPlayRecordBuilder WithComment();

        IPlayRecordBuilder WithDate();

        IPlayRecordBuilder WithGame();

        IPlayRecordBuilder WithLocation();
    }
}
