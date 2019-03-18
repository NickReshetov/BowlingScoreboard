using System.Collections.Generic;
using BowlingScoreboard.DataAccess.Repositories.Interfaces;
using BowlingScoreboard.Dtos;
using BowlingScoreboard.Services.Interfaces;

namespace BowlingScoreboard.Services
{
    public class GameService : IGameService
    {
        private readonly IGameRepository _gameRepository;

        public GameService(IGameRepository gameRepository)
        {
            _gameRepository = gameRepository;
        }

        public GameDto CreateGame(int lineNumber, IEnumerable<PlayerDto> players)
        {
            return _gameRepository.CreateGame(lineNumber, players);
        }
    }
}
