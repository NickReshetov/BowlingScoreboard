using System;
using BowlingScoreboard.Dtos;

namespace BowlingScoreboard.Services.Interfaces
{
    public interface IRoundService
    {
        int GetCurrentRoundNumber(Guid gameId);

        RoundDto CreateRound(RoundDto round);

        RoundDto CalculateRoundScore(RoundDto round);
    }
}
