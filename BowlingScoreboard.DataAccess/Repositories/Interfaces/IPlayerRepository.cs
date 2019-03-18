using System;
using System.Collections.Generic;
using BowlingScoreboard.Dtos;

namespace BowlingScoreboard.DataAccess.Repositories.Interfaces
{
    public interface IPlayerRepository
    {
        IEnumerable<PlayerDto> GetPlayersByRoundNumberOrderedByPlayOrder(Guid gameId, int roundNumber);

        IEnumerable<PlayerDto> GetPlayersByGameIdOrderedByPlayerOrder(Guid gameId);
    }
}
