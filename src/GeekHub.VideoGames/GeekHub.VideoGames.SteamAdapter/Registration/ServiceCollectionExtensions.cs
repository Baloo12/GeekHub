using System;
using System.Net.Http;
using System.Reflection;
using GeekHub.SteamProvider.Client;
using GeekHub.VideoGames.Domain.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace GeekHub.VideoGames.SteamAdapter.Registration
{
    public static class ServiceCollectionExtensions
    {
        public static void RegisterSteamAdapterMapping(this IServiceCollection services)
        {
            services.AddAutoMapper(Assembly.GetExecutingAssembly());
        }
        
        public static void RegisterGeneratedClientClient(
            this IServiceCollection services,
            Action<HttpClient> clientConfigurations)
        {
            services.AddHttpClient<VideoGamesClient>(clientConfigurations);
        }
        
        public static void RegisterSteamProvider(this IServiceCollection services)
        {
            services.AddTransient<IExternalVideoGamesProvider, SteamVideoGamesProvider>();
        }
    }
}