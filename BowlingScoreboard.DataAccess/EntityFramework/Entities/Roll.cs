using System;

namespace BowlingScoreboard.DataAccess.EntityFramework.Entities
{
    public class Roll : BaseEntity
    {
        public int Number { get; set; }

        public int Score { get; set; }

        public Guid RoundId { get; set; }

        public Round Round { get; set; }
    }
}