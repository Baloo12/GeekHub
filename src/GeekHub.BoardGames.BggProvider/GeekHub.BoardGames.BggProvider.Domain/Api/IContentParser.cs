namespace GeekHub.BoardGames.BggProvider.Domain.Api
{
    using System.Collections.Generic;

    using GeekHub.BoardGames.BggProvider.Domain.Dtos;
    using GeekHub.BoardGames.BggProvider.Domain.Entities;

    public interface IContentParser
    {
        BoardGame ParseGame(string gameContent);

        IEnumerable<PlayRecord> ParsePlayRecords(string content);
    }
}
