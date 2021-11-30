namespace GeekHub.BoardGames.BggProvider.Domain.Api
{
    using GeekHub.BoardGames.BggProvider.Domain.Entities;

    public interface IContentParser
    {
        BoardGame ParseGame(string gameContent);
    }
}
