using GeekHub.SteamProvider.Domain.Collector;
using GeekHub.SteamProvider.Domain.DataAccess;
using GeekHub.SteamProvider.Domain.Provider;
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
        }
        
        public static void RegisterCollectors(this IServiceCollection services)
        {
            services.AddTransient<IVideoGamesCollector, VideoGamesCollector>();
        }
        
        public static void RegisterProviders(this IServiceCollection services)
        {
            services.AddTransient<IVideoGamesProvider, VideoGamesProvider>();
        }
    }
}