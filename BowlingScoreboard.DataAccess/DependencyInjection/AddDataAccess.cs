using BowlingScoreboard.DataAccess.Repositories;
using BowlingScoreboard.DataAccess.Repositories.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace BowlingScoreboard.DataAccess.DependencyInjection
{

    public static class IServiceCollectionExtension
    {
        public static IServiceCollection AddDataAccess(this IServiceCollection services)
        {
            services.AddTransient<IGameRepository, GameRepository>();

            services.AddTransient<IPlayerRepository, PlayerRepository>();

            services.AddTransient<IRoundRepository, RoundRepository>();

            return services;
        }
    }
}
