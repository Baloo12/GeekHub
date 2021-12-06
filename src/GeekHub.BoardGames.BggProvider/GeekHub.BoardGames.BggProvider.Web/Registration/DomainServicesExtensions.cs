namespace GeekHub.BoardGames.BggProvider.Web.Registration
{
    using GeekHub.BoardGames.BggProvider.Domain.Api;
    using GeekHub.BoardGames.BggProvider.Domain.Api.Http;
    using GeekHub.BoardGames.BggProvider.Domain.Api.RequestParameters.Base;

    using Microsoft.Extensions.DependencyInjection;

    public static class DomainServicesExtensions
    {
        public static void RegisterBggApiCommunications(this IServiceCollection services)
        {
            services.AddTransient<IRequestParameterConstructor, RequestParameterConstructor>();
            services.AddTransient<IRequestBuilderFactory, RequestBuilderFactory>();
            services.AddTransient<IBggApiClient, BggXmlApiClient>();
            services.AddTransient<IContentParser, XmlContentParser>();
        }

        public static void RegisterHttpClients(this IServiceCollection services)
        {
            services.AddHttpClient<IHttpClientHandler, HttpClientHandler>();
        }
    }
}
