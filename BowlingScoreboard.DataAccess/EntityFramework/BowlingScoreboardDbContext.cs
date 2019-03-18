using System;
using System.Collections.Generic;
using BowlingScoreboard.DataAccess.EntityFramework.Entities;
using Microsoft.EntityFrameworkCore;

namespace BowlingScoreboard.DataAccess.EntityFramework
{
    public class BowlingScoreboardDbContext : DbContext
    {
        public BowlingScoreboardDbContext(DbContextOptions<BowlingScoreboardDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            var line = new Line {Id = Guid.NewGuid(), Number = 1};

            modelBuilder.Entity<Line>().HasData(line);

            var roundTypes = new List<RoundType>
            {
                new RoundType {Id = Guid.NewGuid(), Name = "Strike"},
                new RoundType {Id = Guid.NewGuid(), Name = "Spare"},
                new RoundType {Id = Guid.NewGuid(), Name = "Open"}
            };

            modelBuilder.Entity<RoundType>().HasData(roundTypes);
        }

        public DbSet<Line> Lines { get; set; }

        public DbSet<Game> Games { get; set; }

        public DbSet<Player> Players { get; set; }
        
        public DbSet<Round> Rounds { get; set; }

        public DbSet<RoundType> RoundTypes { get; set; }

        public DbSet<Roll> Rolls { get; set; }
    }
}
