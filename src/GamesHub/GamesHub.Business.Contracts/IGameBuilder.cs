namespace GamesHub.Business.Contracts
{
    using GamesHub.DataAccess.Contracts.Models;
    using GamesHub.GamesProvider.Contracts.Models;

    public interface IGameBuilder
    {
        Game Build(GameDetails gameDetails, string sourceEntityId);
    }
}