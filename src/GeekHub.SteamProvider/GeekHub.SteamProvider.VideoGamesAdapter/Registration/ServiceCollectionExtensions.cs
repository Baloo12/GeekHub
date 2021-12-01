using System;
using System.Net.Http;
using System.Reflection;
using GeekHub.SteamProvider.Domain.ExternalConsumers;
using Microsoft.Extensions.DependencyInjection;

namespace GeekHub.SteamProvider.VideoGamesAdapter.Registration
{
    public static class ServiceCollectionExtensions
    {
        public static void RegisterVideoGamesAdapterMapping(this IServiceCollection services)
        {
            services.AddAutoMapper(Assembly.GetExecutingAssembly());
        }
        
        public static void RegisterVideoGamesConsumer(this IServiceCollection services)
        {
            services.AddTransient<IExternalVideoGamesConsumer, VideoGamesConsumer>();
        }
        
        public static void RegisterVideoGamesConsumerClient(this IServiceCollection services)
        {
            services.AddHttpClient<VideoGamesConsumerClient>();
        }
        
        public static void RegisterVideoGamesConsumerClient(this IServiceCollection services, Action<HttpClient> clientConfigurations)
        {
            services.AddHttpClient<VideoGamesConsumerClient>(clientConfigurations);
        }
        
            
    }
}