namespace GamesHub.Web
{
    using AutoMapper;
    using GamesHub.Business.Contracts.Services;
    using GamesHub.Business.Services;
    using GamesHub.DataAccess.Contracts.Models;
    using GamesHub.DataAccess.Contracts.Repositories;
    using GamesHub.DataAccess.EntityFramework;
    using GamesHub.DataAccess.EntityFramework.Repositories;
    using GamesHub.GamesProvider.Contracts.Interfaces;
    using GamesHub.SteamGamesProvider.Services;
    using Microsoft.AspNetCore.Builder;
    using Microsoft.AspNetCore.Hosting;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;
    using Microsoft.Extensions.Hosting;
    using Microsoft.OpenApi.Models;

    public class Startup
    {
        private readonly IConfiguration _configuration;

        public Startup(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddSwaggerGen(s =>
            {
                s.SwaggerDoc("v1", new OpenApiInfo { Title = "GamesHub API", Version = "v1" });
            });

            RegisterRepositories(services);
            RegisterServices(services);
            RegisterProviders(services);

            services.AddAutoMapper(typeof(Startup));

            var connectionString = _configuration.GetConnectionString("DefaultConnection");
            services.AddDbContext<GamesHubContext>(options =>
                options.UseSqlServer(connectionString));

            // Add CORS policy
            services.AddCors(options =>
            {
                options.AddPolicy("cors",
                    builder =>
                    {
                        // Not a permanent solution, but just trying to isolate the problem
                        builder.WithOrigins("http://localhost:4200").AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader();
                    });
            });

            services.AddControllers(c => c.EnableEndpointRouting = false);
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment()) app.UseDeveloperExceptionPage();

            app.UseDeveloperExceptionPage();
            app.UseStaticFiles();

            app.UseSwagger();
            app.UseSwaggerUI(x =>
            {
                x.SwaggerEndpoint("/swagger/v1/swagger.json", "GamesHub API V1");
            });

            app.UseRouting();

            // Use the CORS policy
            app.UseCors("cors");

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
            services.AddTransient<ISyncService, SyncService>();            
        }

        private void RegisterProviders(IServiceCollection services)
        {
            services.AddTransient<ISteamGamesProvider, SteamGamesProvider>();
        }
    }
}