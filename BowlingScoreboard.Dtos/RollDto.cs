using System;
using System.ComponentModel.DataAnnotations;

namespace BowlingScoreboard.Dtos
{
    public class RollDto
    {
        public Guid Id { get; set; }

        public int Number { get; set; }

        [Range(0, 10)]
        public int Score { get; set; }

        public Guid RoundId { get; set; }
    }
}