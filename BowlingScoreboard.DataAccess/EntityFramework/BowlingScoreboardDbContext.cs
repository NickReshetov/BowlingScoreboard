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
            var lines = new List<Line>
            {
                new Line {Id = Guid.NewGuid(), Number = 1},
                new Line {Id = Guid.NewGuid(), Number = 2},
                new Line {Id = Guid.NewGuid(), Number = 3}
            };

            modelBuilder.Entity<Line>().HasData(lines);

            modelBuilder.Entity<PlayerRound>()
                .HasKey(pr => new { pr.PlayerId, pr.RoundId });

            modelBuilder.Entity<PlayerRound>()
                .HasOne(pr => pr.Player)
                .WithMany(p => p.PlayersRounds)
                .HasForeignKey(p => p.PlayerId);

            modelBuilder.Entity<PlayerRound>()
                .HasOne(pr => pr.Round)
                .WithMany(r => r.PlayersRounds)
                .HasForeignKey(pr => pr.RoundId);
        }

        public DbSet<Line> Lines { get; set; }

        public DbSet<Game> Games { get; set; }

        public DbSet<Player> Players { get; set; }

        public DbSet<PlayerRound> PlayersRounds { get; set; }

        public DbSet<Round> Rounds { get; set; }

        public DbSet<Roll> Rolls { get; set; }
    }
}
