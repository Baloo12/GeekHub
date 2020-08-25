namespace GamesHub.Web
{
    using AutoMapper;

    using GamesHub.Business.Contracts.Services;
    using GamesHub.Business.Services;
    using GamesHub.DataAccess.Contracts.Models;
    using GamesHub.DataAccess.Contracts.Repositories;
    using GamesHub.DataAccess.EntityFramework.Repositories;

    using Microsoft.AspNetCore.Builder;
    using Microsoft.AspNetCore.Hosting;
    using Microsoft.AspNetCore.Http;
    using Microsoft.Extensions.DependencyInjection;
    using Microsoft.Extensions.Hosting;
    using Microsoft.OpenApi.Models;

    public class Startup
    {
        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment()) app.UseDeveloperExceptionPage();

            app.UseSwagger(c =>
                {
                    c.SerializeAsV2 = true;
                });
            app.UseSwaggerUI(x =>
                {
                    x.SwaggerEndpoint("/swagger/v1/swagger.json", "GamesHub API V1");
                });


            app.UseRouting();

            app.UseEndpoints(
                endpoints =>
                    {
                        endpoints.MapControllers();
                    });


        }

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            RegisterRepositories(services);
            RegisterServices(services);

            services.AddAutoMapper(typeof(Startup));

            services.AddSwaggerGen(
                c =>
                    {
                        c.SwaggerDoc(
                            "v1",
                            new OpenApiInfo
                                {
                                    Title = "GamesHub API",
                                    Description = "DotNet Core Api 3 - with swagger",
                                    Version = "v1"
                                });
                    });
        }

        private void RegisterRepositories(IServiceCollection services)
        {
            services.AddTransient<IRepository<Game>, GameRepository>();
        }

        private void RegisterServices(IServiceCollection services)
        {
            services.AddTransient<IGameService, GameService>();
        }
    }
}