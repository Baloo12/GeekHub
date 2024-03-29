using GeekHub.SteamProvider.Domain.Registration;
using GeekHub.SteamProvider.EntityFramework.Registration;
using GeekHub.SteamProvider.Web.Registration.Swagger;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace GeekHub.SteamProvider.Web
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

            services.RegisterSteamProviderDomainMapping();
            services.RegisterMediatR();
            services.RegisterSteamApiClient();
            services.RegisterSteamStoreClient();
            services.RegisterFactories();
            
            services.AddControllers();

            services.AddLogging();
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