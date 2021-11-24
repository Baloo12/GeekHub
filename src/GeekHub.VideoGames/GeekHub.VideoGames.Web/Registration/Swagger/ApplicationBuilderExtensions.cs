using Microsoft.AspNetCore.Builder;

namespace GeekHub.VideoGames.Web.Registration.Swagger
{
    public static class ApplicationBuilderExtensions
    {
        public static void UseSwaggerPage(this IApplicationBuilder app)
        {
            app.UseSwagger();
            app.UseSwaggerUI(x =>
            {
                x.SwaggerEndpoint("/swagger/v1/swagger.json", "Video Games Service API V1");
                x.RoutePrefix = "";
            });
        }
    }
}