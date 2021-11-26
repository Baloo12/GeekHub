namespace GeekHub.BoardGames.BggProvider.Web.Registration.Swagger
{
    using Microsoft.Extensions.DependencyInjection;
    using Microsoft.OpenApi.Models;

    public static class ServiceCollectionExtensions
    {
        public static void RegisterSwagger(this IServiceCollection services)
        {
            services.AddSwaggerGen(
                s =>
                    {
                        s.SwaggerDoc(
                            "v1",
                            new OpenApiInfo
                                {
                                    Title = "Board Games Provider API",
                                    Version = "v1"
                                });
                    });
        }
    }
}
