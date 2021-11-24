using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;

namespace GeekHub.VideoGames.Web.Registration.Swagger
{
    public static class ServiceCollectionExtensions
    {
        public static void RegisterSwagger(this IServiceCollection services)
        {
            services.AddSwaggerGen(s =>
            { 
                s.SwaggerDoc("v1", new OpenApiInfo
                {
                    Title = "Video Games Service API", 
                    Version = "v1"
                });
            });
        }
    }
}