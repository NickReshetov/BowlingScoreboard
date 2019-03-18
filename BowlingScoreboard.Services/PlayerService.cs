using System;
using System.Linq;
using BowlingScoreboard.DataAccess.Repositories.Interfaces;
using BowlingScoreboard.Dtos;
using BowlingScoreboard.Services.Interfaces;

namespace BowlingScoreboard.Services
{
    public class PlayerService : IPlayerService
    {
        private readonly IPlayerRepository _playerRepository;

        public PlayerService(IPlayerRepository playerRepository)
        {
            _playerRepository = playerRepository;
        }

        public PlayerDto GetPlayerWhoDidNotPlayYetInTheCurrentRound(Guid gameId, int roundNumber)
        {
            PlayerDto playerWhoDidNotPlay = null;

            var playersWhoPlayed = _playerRepository
                .GetPlayersByRoundNumberOrderedByPlayOrder(gameId, roundNumber)
                .ToList();

            if (playersWhoPlayed.Any())
            {
                var lastPlayedPlayOrder = playersWhoPlayed
                    .LastOrDefault()
                    ?.PlayOrder;

                if (lastPlayedPlayOrder != null)
                {
                    var nonPlayedPlayOrder = lastPlayedPlayOrder + 1;

                    playerWhoDidNotPlay = _playerRepository
                        .GetPlayersByGameIdOrderedByPlayerOrder(gameId)
                        .SingleOrDefault(p => p.PlayOrder == nonPlayedPlayOrder);
                }
            }
            else
            {
                playerWhoDidNotPlay = _playerRepository
                   .GetPlayersByGameIdOrderedByPlayerOrder(gameId)
                   .FirstOrDefault();
            }

            return playerWhoDidNotPlay;
        }
    }
}
