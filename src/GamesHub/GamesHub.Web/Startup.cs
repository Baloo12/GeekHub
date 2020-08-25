using Microsoft.OpenApi.Models;

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
    using Microsoft.Extensions.DependencyInjection;
    using Microsoft.Extensions.Hosting;

    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddSwaggerGen(s =>
            {
                s.SwaggerDoc("v1", new OpenApiInfo { Title = "GamesHub API", Version = "v1" });
            });

            RegisterRepositories(services);
            RegisterServices(services);

            services.AddAutoMapper(typeof(Startup));

            services.AddControllers(c => c.EnableEndpointRouting = false);
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment()) app.UseDeveloperExceptionPage();

            app.UseStaticFiles();

            app.UseSwagger();
            app.UseSwaggerUI(x =>
            {
                x.SwaggerEndpoint("/swagger/v1/swagger.json", "GamesHub API V1");
            });

            app.UseRouting();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "api/[controller]",
                    defaults: new { controller = "games" });
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