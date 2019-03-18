using System;

namespace BowlingScoreboard.Dtos
{
    public class RollDto
    {
        public Guid Id { get; set; }

        public int Number { get; set; }

        public int Score { get; set; }

        public Guid RoundId { get; set; }
    }
}