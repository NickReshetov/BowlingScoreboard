using System;
using System.Collections.Generic;

namespace BowlingScoreboard.DataAccess.EntityFramework.Entities
{
    public class Game : BaseEntity
    {
        public Guid LineId { get; set; }

        public Line Line { get; set; }

        public ICollection<Player> Players { get; set; }
    }
}
