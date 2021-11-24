using GeekHub.SteamProvider.Domain.DataAccess;
using GeekHub.SteamProvider.Domain.Entities;
using GeekHub.SteamProvider.Domain.Provider;
using GeekHub.SteamProvider.EntityFramework.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace GeekHub.SteamProvider.EntityFramework.Registration
{
    public static class ServiceCollectionExtensions
    {
        public static void RegisterDbContext(this IServiceCollection services, IConfiguration configuration)
        {
            var connectionString = configuration.GetConnectionString("DefaultConnection");
            services.AddDbContext<SteamDbContext>(options => options.UseSqlServer(connectionString));
        }
        
        public static void RegisterRepositories(this IServiceCollection services)
        {
            services.AddTransient<IVideoGamesRepository, VideoGamesRepository>();
            services.AddTransient<IDevelopersRepository, DevelopersRepository>();
            services.AddTransient<IGenresRepository, GenresRepository>();
            services.AddTransient<IPlatformsRepository, PlatformsRepository>();
            services.AddTransient <IPublishersRepository, PublishersRepository>();
        }
    }
}