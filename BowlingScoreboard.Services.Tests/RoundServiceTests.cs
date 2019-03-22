using System;
using System.Collections.Generic;
using BowlingScoreboard.DataAccess.Repositories;
using BowlingScoreboard.Dtos;
using BowlingScoreboard.Services.Interfaces;
using Moq;
using Xunit;

namespace BowlingScoreboard.Services.Tests
{
    public class RoundServiceTests
    {
        private IRoundService _roundService;
        private const string Strike = "Strike";
        private readonly Guid _strikeTypeId = Guid.NewGuid();
        private const string Spare = "Spare";
        private readonly Guid _spareTypeId = Guid.NewGuid();
        private const string Open = "Open";
        private readonly Guid _openTypeId = Guid.NewGuid();
        private const int PreviousRoundScore = 7;

        private RoundDto Setup(int firstRollScore, int secondRollScore)
        {
            var previousRound = GetRoundDtoByScores(3, 4);
            previousRound.Score = PreviousRoundScore;

            var previousRounds = new List<RoundDto>{ previousRound };

            var mockRoundRepository = new Mock<RoundRepository>(null);

            mockRoundRepository
                .Setup(m => m.GetRoundsByPlayerId(It.IsAny<Guid>()))
                .Returns(previousRounds);

            mockRoundRepository
                .Setup(m => m.GetRoundTypeByName(Strike))
                .Returns(new RoundTypeDto { Id = _strikeTypeId, Name = Strike });

            mockRoundRepository
                .Setup(m => m.GetRoundTypeByName(Open))
                .Returns(new RoundTypeDto { Id = _openTypeId, Name = Open });

            mockRoundRepository
                .Setup(m => m.GetRoundTypeByName(Spare))
                .Returns(new RoundTypeDto { Id = _spareTypeId, Name = Spare });

            _roundService = new RoundService(mockRoundRepository.Object);

            var roundDto = GetRoundDtoByScores(firstRollScore, secondRollScore);

            return roundDto;
        }

        private static RoundDto GetRoundDtoByScores(int firstRollScore, int secondRollScore)
        {
            var roundDto = new RoundDto
            {
                Rolls = new List<RollDto>
                {
                    new RollDto {Number = 1, Score = firstRollScore},
                    new RollDto {Number = 2, Score = secondRollScore}
                }
            };
            return roundDto;
        }

        [Fact]
        public void CalculateRoundScore_IsStrike()
        {
            var strikeRound = Setup(10, 5);

            var calculatedStrikeRound = _roundService.CalculateRoundScore(strikeRound);

            Assert.Equal(PreviousRoundScore + 25, calculatedStrikeRound.Score);
            Assert.Equal(_strikeTypeId, calculatedStrikeRound.RoundTypeId);
            Assert.Null(calculatedStrikeRound.RoundType);
        }

        [Fact]
        public void CalculateRoundScore_IsSpare()
        {
            var strikeRound = Setup(7, 3);

            var calculatedStrikeRound = _roundService.CalculateRoundScore(strikeRound);

            Assert.Equal(PreviousRoundScore + 17, calculatedStrikeRound.Score);
            Assert.Equal(_spareTypeId, calculatedStrikeRound.RoundTypeId);
            Assert.Null(calculatedStrikeRound.RoundType);
        }

        [Fact]
        public void CalculateRoundScore_IsOpen()
        {
            var strikeRound = Setup(3, 5);

            var calculatedStrikeRound = _roundService.CalculateRoundScore(strikeRound);

            Assert.Equal(PreviousRoundScore + 8, calculatedStrikeRound.Score);
            Assert.Equal(_openTypeId, calculatedStrikeRound.RoundTypeId);
            Assert.Null(calculatedStrikeRound.RoundType);
        }
    }
}
