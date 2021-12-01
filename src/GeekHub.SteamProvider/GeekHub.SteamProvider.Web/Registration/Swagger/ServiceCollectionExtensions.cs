using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;

namespace GeekHub.SteamProvider.Web.Registration.Swagger
{
    public static class ServiceCollectionExtensions
    {
        public static void RegisterSwagger(this IServiceCollection services)
        {
            services.AddSwaggerGen(s =>
            { 
                s.EnableAnnotations();
                s.SwaggerDoc("v1", new OpenApiInfo
                {
                    Title = "Steam API", 
                    Version = "v1"
                });
            });
        }
    }
}