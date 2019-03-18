using System;
using System.Collections.Generic;

namespace BowlingScoreboard.DataAccess.EntityFramework.Entities
{
    public class Player : BaseEntity
    {
        public string Name { get; set; }

        public int PlayOrder { get; set; }

        public Guid GameId { get; set; }

        public Game Game { get; set; }

        public ICollection<PlayerRound> PlayersRounds { get; set; }
    }
}