using GeekHub.VideoGames.Domain.ExternalProviders;
using GeekHub.VideoGames.Domain.Interfaces;
using GeekHub.VideoGames.SteamAdapter;
using Microsoft.Extensions.DependencyInjection;

namespace GeekHub.VideoGames.Web.Registration.ExternalProviders
{
    public static class ServiceCollectionExtensions
    {
        public static void RegisterExternalProviders(this IServiceCollection services)
        {
            services.AddTransient<IExternalVideoGamesProvider, SteamVideoGamesProvider>();
            services.AddTransient<IExternalVideoGamesProvidersFactory, ExternalVideoGamesProvidersFactory>();
        }
    }
}