using System;
using System.Net.Http;
using System.Reflection;
using Microsoft.Extensions.DependencyInjection;

namespace GeekHub.VideoGames.SteamAdapter.Registration
{
    public static class ServiceCollectionExtensions
    {
        public static void RegisterSteamAdapterMapping(this IServiceCollection services)
        {
            services.AddAutoMapper(Assembly.GetExecutingAssembly());
        }
        
        public static void RegisterSteamProviderClient(this IServiceCollection services)
        {
            services.AddHttpClient<SteamProviderClient>();
        }
        
        public static void RegisterSteamProviderClient(this IServiceCollection services, Action<HttpClient> clientConfigurations)
        {
            services.AddHttpClient<SteamProviderClient>(clientConfigurations);
        }
    }
}