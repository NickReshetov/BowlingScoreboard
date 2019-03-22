using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using BowlingScoreboard.DataAccess.EntityFramework;
using BowlingScoreboard.DataAccess.EntityFramework.Entities;
using BowlingScoreboard.DataAccess.Repositories.Interfaces;
using BowlingScoreboard.Dtos;
using Microsoft.EntityFrameworkCore;

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
                    .Select(p => p.Rounds.Count)
                    .ToList();

                var lastRoundNumber = allPlayersRoundsCount.Min();

                currentRoundNumber = lastRoundNumber == 10 ? lastRoundNumber : lastRoundNumber + 1;
            }

            return currentRoundNumber;
        }

        public virtual IEnumerable<RoundDto> GetRoundsByPlayerId(Guid playerId)
        {
            IEnumerable<RoundDto> roundDtos;

            using (var context = new BowlingScoreboardDbContextFactory().CreateDbContext())
            {
                var rounds = context.Rounds
                    .Include(r => r.Player)
                    .Where(r => r.Player.Id == playerId)
                    .ToList();

                roundDtos = _mapper.Map<IEnumerable<RoundDto>>(rounds);
            }

            return roundDtos;
        }

        public virtual RoundTypeDto GetRoundTypeByName(string roundTypeName)
        {
            RoundTypeDto roundTypeDto;

            using (var context = new BowlingScoreboardDbContextFactory().CreateDbContext())
            {
                var roundType = context
                    .RoundTypes
                    .SingleOrDefault(rt => rt.Name == roundTypeName);


                roundTypeDto = _mapper.Map<RoundTypeDto>(roundType);                
            }

            return roundTypeDto;
        }
    }
}
