using System;
using System.Collections.Generic;

namespace BowlingScoreboard.DataAccess.EntityFramework.Entities
{
    public class Round : BaseEntity
    {
        public int Number { get; set; }

        public int Score { get; set; }

        public Guid RoundTypeId { get; set; }

        public RoundType RoundType { get; set; }

        public Guid PlayerId { get; set; }

        public Player Player { get; set; }

        public ICollection<Roll> Rolls { get; set; }
    }
}