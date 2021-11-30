using GeekHub.VideoGames.Domain.Interfaces;

namespace GeekHub.VideoGames.Domain.ExternalProviders
{
    public interface IExternalVideoGamesProvidersFactory
    {
        IExternalVideoGamesProvider ResolveProvider(string source);
    }
}