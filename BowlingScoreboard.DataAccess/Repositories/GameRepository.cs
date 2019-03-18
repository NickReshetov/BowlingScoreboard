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
    public class GameRepository : IGameRepository
    {
        private readonly IMapper _mapper;

        public GameRepository(IMapper mapper)
        {
            _mapper = mapper;
        }

        public GameDto CreateGame(int lineNumber, IEnumerable<PlayerDto> players)
        {
            GameDto gameDto;

            using (var context = new BowlingScoreboardDbContextFactory().CreateDbContext())
            {
                var lineId = context.Lines.SingleOrDefault(l => l.Number == lineNumber).Id;

                var playerEntities = _mapper.Map<ICollection<Player>>(players);

                var game = new Game()
                {
                    LineId = lineId,
                    Players = playerEntities
                };

                context.Games.Add(game);
                context.SaveChanges();

                gameDto = _mapper.Map<GameDto>(game);
            }

            return gameDto;
        }

        public GameDto GetGameById(Guid gameId)
        {
            GameDto gameDto;

            using (var context = new BowlingScoreboardDbContextFactory().CreateDbContext())
            {
                var game = context.Games
                    .Include(g => g.Players)
                    .ThenInclude(p => p.Rounds)
                    .ThenInclude(r => r.RoundType)
                    .SingleOrDefault(g => g.Id == gameId);

                gameDto = _mapper.Map<GameDto>(game);

                gameDto.Players
                    .ToList()
                    .ForEach(p => p.Rounds.ToList().ForEach(r => r.GameId = gameId));
            }

            return gameDto;
        }
    }
}
