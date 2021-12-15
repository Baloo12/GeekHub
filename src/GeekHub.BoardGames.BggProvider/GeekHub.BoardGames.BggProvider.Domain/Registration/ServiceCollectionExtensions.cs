namespace GeekHub.BoardGames.BggProvider.Domain.Registration
{
    using System.Reflection;
    using MediatR;
    using Microsoft.Extensions.DependencyInjection;

    public static class ServiceCollectionExtensions
    {
        public static void RegisterMapping(this IServiceCollection services)
        {
            services.AddAutoMapper(Assembly.GetExecutingAssembly());
        }
        
        public static void RegisterMediatR(this IServiceCollection services)
        {
            services.AddMediatR(Assembly.GetExecutingAssembly());
        }
    }
}