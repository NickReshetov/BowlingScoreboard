using System;
using BowlingScoreboard.Dtos;

namespace BowlingScoreboard.Services.Interfaces
{
    public interface IPlayerService
    {
        PlayerDto GetPlayerWhoDidNotPlayYetInTheCurrentRound(Guid gameId, int roundNumber);
    }
}