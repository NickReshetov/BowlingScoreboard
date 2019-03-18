using System;
using System.Collections.Generic;
using BowlingScoreboard.Dtos;

namespace BowlingScoreboard.Services.Interfaces
{
    public interface IGameService
    {
        GameDto CreateGame(int lineNumber, IEnumerable<PlayerDto> players);

        GameDto GetGame(Guid gameId);
    }
}