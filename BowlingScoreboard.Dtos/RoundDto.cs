using System;
using System.Collections.Generic;

namespace BowlingScoreboard.Dtos
{
    public class RoundDto
    {
        public Guid Id { get; set; }

        public int Number { get; set; }

        public int Score { get; set; }

        public Guid? RoundTypeId { get; set; }

        public RoundTypeDto RoundType { get; set; }
        
        public Guid GameId { get; set; }

        public Guid PlayerId { get; set; }

        public IEnumerable<RollDto> Rolls { get; set; }

    }
}