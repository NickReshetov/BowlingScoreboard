using System.Collections.Generic;
using BowlingScoreboard.Dtos;
using BowlingScoreboard.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace BowlingScoreboard.Controllers
{
    public class GameController : ControllerBase
    {
        private readonly IGameService _gameService;
        public GameController(IGameService gameService)
        {
            _gameService = gameService;
        }

        [HttpPost("api/line/{lineNumber}/game")]
        public GameDto CreateGame(int lineNumber, [FromBody] IEnumerable<PlayerDto> players)
        {
            return _gameService.CreateGame(lineNumber, players);
        }
    }
}
