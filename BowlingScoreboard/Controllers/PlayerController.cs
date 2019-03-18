using System;
using System.Collections.Generic;
using BowlingScoreboard.Dtos;
using BowlingScoreboard.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace BowlingScoreboard.Controllers
{
    public class PlayerController : ControllerBase
    {
        private readonly IPlayerService _playerService;
        public PlayerController(IPlayerService playerService)
        {
            _playerService = playerService;
        }

        [HttpGet("api/game/{gameId}/round/{roundNumber}/player")]
        public PlayerDto GetPlayerWhoDidNotPlayInCurrentRound(Guid gameId, int roundNumber)
        {
            return _playerService.GetPlayerWhoDidNotPlayYetInTheCurrentRound(gameId, roundNumber);
        }
    }
}
