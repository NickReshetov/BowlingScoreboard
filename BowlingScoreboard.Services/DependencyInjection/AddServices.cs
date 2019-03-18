using BowlingScoreboard.Services.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace BowlingScoreboard.Services.DependencyInjection
{

    public static class IServiceCollectionExtension
    {
        public static IServiceCollection AddServices(this IServiceCollection services)
        {
            services.AddTransient<IGameService, GameService>();

            services.AddTransient<IPlayerService, PlayerService>();

            services.AddTransient<IRoundService, RoundService>();

            return services;
        }
    }
}
