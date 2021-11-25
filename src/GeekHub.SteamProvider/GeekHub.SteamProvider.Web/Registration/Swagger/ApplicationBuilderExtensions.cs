using Microsoft.AspNetCore.Builder;

namespace GeekHub.SteamProvider.Web.Registration.Swagger
{
    public static class ApplicationBuilderExtensions
    {
        public static void UseSwaggerPage(this IApplicationBuilder app)
        {
            app.UseSwagger();
            app.UseSwaggerUI(x =>
            {
                x.SwaggerEndpoint("/swagger/v1/swagger.json", "Steam API V1");
                x.RoutePrefix = "";
            });
        }
    }
}