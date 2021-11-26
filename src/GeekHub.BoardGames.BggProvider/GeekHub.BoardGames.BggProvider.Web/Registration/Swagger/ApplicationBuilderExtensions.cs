namespace GeekHub.BoardGames.BggProvider.Web.Registration.Swagger
{
    using Microsoft.AspNetCore.Builder;

    public static class ApplicationBuilderExtensions
    {
        public static void UseSwaggerPage(this IApplicationBuilder app)
        {
            app.UseSwagger();
            app.UseSwaggerUI(
                x =>
                    {
                        x.SwaggerEndpoint("/swagger/v1/swagger.json", "Board Games Provider API V1");
                        x.RoutePrefix = "";
                    });
        }
    }
}
