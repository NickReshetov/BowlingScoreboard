using System;
using System.Collections.Generic;

namespace BowlingScoreboard.DataAccess.EntityFramework.Entities
{
    public class Round : BaseEntity
    {
        public int Number { get; set; }

        public int Score { get; set; }

        public ICollection<PlayerRound> PlayersRounds { get; set; }

        public ICollection<Roll> Rolls { get; set; }
    }
}