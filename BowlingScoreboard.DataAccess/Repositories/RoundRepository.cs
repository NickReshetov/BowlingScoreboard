using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using BowlingScoreboard.DataAccess.EntityFramework;
using BowlingScoreboard.DataAccess.EntityFramework.Entities;
using BowlingScoreboard.DataAccess.Repositories.Interfaces;
using BowlingScoreboard.Dtos;

namespace BowlingScoreboard.DataAccess.Repositories
{
    public class RoundRepository : IRoundRepository
    {
        private readonly IMapper _mapper;

        public RoundRepository(IMapper mapper)
        {
            _mapper = mapper;
        }

        public RoundDto CreateRound(RoundDto round)
        {
            RoundDto roundDto;

            using (var context = new BowlingScoreboardDbContextFactory().CreateDbContext())
            {
                var roundEntity = _mapper.Map<Round>(round);

                var roundPlayer = new PlayerRound
                {
                    PlayerId = round.PlayerId,
                    RoundId = round.Id
                };

                roundEntity.PlayersRounds = new List<PlayerRound> { roundPlayer };

                context.Rounds.Add(roundEntity);

                context.SaveChanges();

                roundDto = _mapper.Map<RoundDto>(roundEntity);

                roundDto.GameId = round.GameId;

                roundDto.PlayerId = round.PlayerId;
            }

            return roundDto;
        }

        public int GetCurrentRoundNumber(Guid gameId)
        {
            int currentRoundNumber;

            using (var context = new BowlingScoreboardDbContextFactory().CreateDbContext())
            {
                var allPlayersRoundsCount = context.Players
                    .Where(p => p.GameId == gameId)
                    .Select(p => p.PlayersRounds.Select(pr => pr.Round).Count())
                    .ToList();

                var lastRoundNumber = allPlayersRoundsCount.Min();

                currentRoundNumber = lastRoundNumber == 10 ? lastRoundNumber : lastRoundNumber + 1;
            }

            return currentRoundNumber;
        }

        public IEnumerable<RoundDto> GetRoundsByPlayerId(Guid playerId)
        {
            IEnumerable<RoundDto> rounds;

            using (var context = new BowlingScoreboardDbContextFactory().CreateDbContext())
            {
                var playerRounds = context.PlayersRounds
                    .Where(p => p.PlayerId == playerId)
                    .Select(pr => pr.Round)
                    .ToList();

                rounds = _mapper.Map<IEnumerable<RoundDto>>(playerRounds);
            }

            return rounds;
        }
    }
}
