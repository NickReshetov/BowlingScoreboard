using System;
using System.Collections.Generic;
using BowlingScoreboard.Dtos;
using BowlingScoreboard.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace BowlingScoreboard.Controllers
{
    public class RoundController : ControllerBase
    {
        private readonly IRoundService _roundService;

        public RoundController(IRoundService roundService)
        {
            _roundService = roundService;
        }

        [HttpGet("api/game/{gameId}/round/number")]
        public int GetCurrentRoundNumber(Guid gameId)
        {
            return _roundService.GetCurrentRoundNumber(gameId);
        }

        [HttpPost("api/game/{gameId}/player/{playerId}/round")]
        public RoundDto CreateRound(Guid gameId, Guid playerId, [FromBody] RoundDto round)
        {
            return _roundService.CreateRound(round);
        }
    }
}
