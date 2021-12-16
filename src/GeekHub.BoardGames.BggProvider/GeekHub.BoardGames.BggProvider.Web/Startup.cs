namespace GeekHub.BoardGames.BggProvider.Web
{
    using GeekHub.BoardGames.BggProvider.Domain.Registration;
    using GeekHub.BoardGames.BggProvider.Web.Registration;
    using GeekHub.BoardGames.BggProvider.Web.Registration.Swagger;

    using Microsoft.AspNetCore.Builder;
    using Microsoft.AspNetCore.Hosting;
    using Microsoft.Extensions.DependencyInjection;
    using Microsoft.Extensions.Hosting;

    public class Startup
    {
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseStaticFiles();
            app.UseSwaggerPage();
            app.UseRouting();

            app.UseEndpoints(endpoints => { endpoints.MapControllers(); });
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.RegisterHttpClients();
            services.RegisterBggApiCommunications();
            services.RegisterSwagger();
            services.AddControllers();
            services.RegisterMapping();
            services.RegisterMediatR();
        }
    }
}
