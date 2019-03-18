using System;
using System.Collections.Generic;
using System.Text;

namespace BowlingScoreboard.DataAccess.EntityFramework.Entities
{
    public class PlayerRound
    {
        public Guid PlayerId { get; set; }

        public Player Player { get; set; }

        public Guid RoundId { get; set; }

        public Round Round { get; set; }
    }
}
