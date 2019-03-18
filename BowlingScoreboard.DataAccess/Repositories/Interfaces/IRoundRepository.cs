using System;
using System.Collections.Generic;
using BowlingScoreboard.Dtos;

namespace BowlingScoreboard.DataAccess.Repositories.Interfaces
{
    public interface IRoundRepository
    {
        RoundDto CreateRound(RoundDto round);

        int GetCurrentRoundNumber(Guid gameId);

        IEnumerable<RoundDto> GetRoundsByPlayerId(Guid playerId);

        RoundTypeDto GetRoundTypeByName(string roundTypeName);
    }
}
