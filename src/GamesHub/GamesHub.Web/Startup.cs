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

namespace GamesHub.Web
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            RegisterRepositories(services);
            RegisterServices(services);

            services.AddAutoMapper(typeof(Startup));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapGet("/", async context =>
                {
                    await context.Response.WriteAsync("Hello World!");
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
