using GeekHub.VideoGames.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;

namespace GeekHub.VideoGames.EntityFramework.Registration
{
    public static class ServiceCollectionExtensions
    {
        public static void RegisterDbContext(this IServiceCollection services, IConfiguration configuration)
        {
            var connectionString = configuration.GetConnectionString("DefaultConnection");
            services.AddDbContext<VideoGameDbContext>(options => options.UseSqlServer(connectionString));
        }
        
        public static void RegisterRepositories(this IServiceCollection services)
        {
            services.AddTransient<IVideoGameRepository, VideoGameRepository>();
        }
    }
}