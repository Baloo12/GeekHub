using GeekHub.VideoGames.Domain.ExternalProviders;
using Microsoft.Extensions.DependencyInjection;

namespace GeekHub.VideoGames.Web.Registration.ExternalProviders
{
    public static class ServiceCollectionExtensions
    {
        public static void RegisterExternalProvidersFactory(this IServiceCollection services)
        {
            services.AddTransient<IExternalVideoGamesProvidersFactory, ExternalVideoGamesProvidersFactory>();
        }
    }
}