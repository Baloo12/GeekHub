namespace GeekHub.BoardGames.BggProvider.Domain.Api.EntityBuilders.PlayRecord
{
    using System;

    using GeekHub.BoardGames.BggProvider.Domain.Api.EntityBuilders.Game;
    using GeekHub.BoardGames.BggProvider.Domain.Entities;

    public interface IPlayRecordBuilder : IEntityBuilder<PlayRecord>
    {
        IPlayRecordBuilder WithBggId();

        IPlayRecordBuilder WithLocation();
    }
}
