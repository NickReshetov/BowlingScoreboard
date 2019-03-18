using System;
using System.Collections.Generic;

namespace BowlingScoreboard.Dtos
{
    public class GameDto
    {
        public Guid Id { get; set; }

        public Guid LineId { get; set; }

        public IEnumerable<PlayerDto> Players { get; set; }
    }
}
