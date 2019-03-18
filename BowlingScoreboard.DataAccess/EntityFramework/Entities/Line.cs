using System.Collections.Generic;

namespace BowlingScoreboard.DataAccess.EntityFramework.Entities
{
    public class Line : BaseEntity
    {
        public int Number { get; set; }

        public ICollection<Game> Games { get; set; }
    }
}