using System;
using System.Collections.Generic;

namespace BowlingScoreboard.Dtos
{
    public class PlayerDto
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public int PlayOrder { get; set; }

        public IEnumerable<RoundDto> Rounds { get; set; }
    }
}