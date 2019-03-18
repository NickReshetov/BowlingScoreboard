using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using BowlingScoreboard.DataAccess.EntityFramework;
using BowlingScoreboard.DataAccess.Repositories.Interfaces;
using BowlingScoreboard.Dtos;

namespace BowlingScoreboard.DataAccess.Repositories
{
    public class PlayerRepository : IPlayerRepository
    {
        private readonly IMapper _mapper;

        public PlayerRepository(IMapper mapper)
        {
            _mapper = mapper;
        }

        public IEnumerable<PlayerDto> GetPlayersByRoundNumberOrderedByPlayOrder(Guid gameId, int roundNumber)
        {
            IEnumerable<PlayerDto> playersDto;
        
            using (var context = new BowlingScoreboardDbContextFactory().CreateDbContext())
            {
                var players = context.PlayersRounds
                    .Where(pr => pr.Round.Number == roundNumber && pr.Player.GameId == gameId)
                    .Select(pr => pr.Player)
                    .OrderBy(p => p.PlayOrder)
                    .ToList();

                playersDto = _mapper.Map<IEnumerable<PlayerDto>>(players);
            }

            return playersDto;
        }

        public IEnumerable<PlayerDto> GetPlayersByGameIdOrderedByPlayerOrder(Guid gameId)
        {
            IEnumerable<PlayerDto> playersDto;

            using (var context = new BowlingScoreboardDbContextFactory().CreateDbContext())
            {
                var players = context.Players
                    .Where(p => p.GameId == gameId)
                    .OrderBy(p => p.PlayOrder)
                    .ToList();

                playersDto = _mapper.Map<IEnumerable<PlayerDto>>(players);
            }

            return playersDto;
        }
    }
}
