using System;
using System.Collections.Generic;
using BowlingScoreboard.Dtos;

namespace BowlingScoreboard.DataAccess.Repositories.Interfaces
{
    public interface IGameRepository
    {
        GameDto CreateGame(int lineNumber, IEnumerable<PlayerDto> player);

        GameDto GetGameById(Guid gameId);
    }
}
