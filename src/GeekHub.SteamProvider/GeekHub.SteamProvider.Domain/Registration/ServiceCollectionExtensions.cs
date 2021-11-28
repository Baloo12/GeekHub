﻿using System;
using System.Net.Http;
using GeekHub.SteamProvider.Domain.Constants;
using GeekHub.SteamProvider.Domain.HttpClients;
using GeekHub.SteamProvider.Domain.Provider;
using GeekHub.SteamProvider.Domain.Specifications;
using GeekHub.SteamProvider.Domain.Specifications.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace GeekHub.SteamProvider.Domain.Registration
{
    public static class ServiceCollectionExtensions
    {
        public static void RegisterSteamApiClient(this IServiceCollection services)
        {
            services.AddHttpClient<SteamApiClient>();
        }
        
        public static void RegisterSteamApiClient(this IServiceCollection services, Action<HttpClient> clientConfigurations)
        {
            services.AddHttpClient<SteamApiClient>(clientConfigurations);
        }
        
        public static void RegisterSteamStoreClient(this IServiceCollection services)
        {
            services.AddHttpClient<SteamStoreClient>();
        }
        
        public static void RegisterSteamStoreClient(this IServiceCollection services, Action<HttpClient> clientConfigurations)
        {
            services.AddHttpClient<SteamStoreClient>(clientConfigurations);
        }
        
        public static void RegisterSpecifications(this IServiceCollection services)
        {
            services.AddTransient<ICollectVideoGameFromSteamApiSpecification, CollectVideoGameFromSteamApiSpecification>();
            services.AddTransient<ICollectIdsFromSteamApiSpecification, CollectIdsFromSteamApiSpecification>();
            services.AddTransient<ICollectAllVideoGamesFromSteamApiSpecification, CollectAllVideoGamesFromSteamApiSpecification>();
            
            services.AddTransient<ICollectDevelopersSpecification, CollectDevelopersSpecification>();
            services.AddTransient<ICollectPublishersSpecification, CollectPublishersSpecification>();
            services.AddTransient<ICollectGenresSpecification, CollectGenresSpecification>();
            services.AddTransient<ICollectPlatformsSpecification, CollectPlatformsSpecification>();
        }
        
        public static void RegisterProviders(this IServiceCollection services)
        {
            services.AddTransient<IVideoGamesProvider, VideoGamesProvider>();
        }
    }
}