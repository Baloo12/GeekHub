using System;
using System.Net.Http;
using System.Reflection;
using GeekHub.SteamProvider.Domain.HttpClients;
using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace GeekHub.SteamProvider.Domain.Registration
{
    public static class ServiceCollectionExtensions
    {
        public static void RegisterSteamApiClient(this IServiceCollection services)
        {
            services.AddHttpClient<ISteamApiClient, SteamApiClient>();
        }
        
        public static void RegisterSteamApiClient(this IServiceCollection services, Action<HttpClient> clientConfigurations)
        {
            services.AddHttpClient<ISteamApiClient, SteamApiClient>(clientConfigurations);
        }
        
        public static void RegisterSteamStoreClient(this IServiceCollection services)
        {
            services.AddHttpClient<ISteamStoreClient, SteamStoreClient>();
        }
        
        public static void RegisterSteamStoreClient(this IServiceCollection services, Action<HttpClient> clientConfigurations)
        {
            services.AddHttpClient<ISteamStoreClient, SteamStoreClient>(clientConfigurations);
        }
        
        public static void RegisterSteamProviderDomainMapping(this IServiceCollection services)
        {
            services.AddAutoMapper(Assembly.GetExecutingAssembly());
        }
        
        public static void RegisterMediatR(this IServiceCollection services)
        {
            services.AddMediatR(Assembly.GetExecutingAssembly());
        }
    }
}