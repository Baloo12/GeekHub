using GeekHub.VideoGames.Domain.Registration;
using GeekHub.VideoGames.EntityFramework.Registration;
using GeekHub.VideoGames.SteamAdapter.Registration;
using GeekHub.VideoGames.Web.Registration.ExternalProviders;
using GeekHub.VideoGames.Web.Registration.Swagger;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace GeekHub.VideoGames.Web
{
    public class Startup
    {
        private readonly IConfiguration _configuration;

        public Startup(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        
        public void ConfigureServices(IServiceCollection services)
        {
            services.RegisterSwagger();
            
            services.RegisterDbContext(_configuration);
            services.RegisterRepositories();
            
            services.RegisterMapping();
            
            services.RegisterSteamAdapterMapping();
            services.RegisterSteamProviderClient();
            
            services.RegisterMediatR();

            services.RegisterExternalProviders();
            
            services.AddControllers();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            
            app.UseStaticFiles();
            app.UseSwaggerPage();
            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}