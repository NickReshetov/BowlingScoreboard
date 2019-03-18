using System;
using System.Linq;
using BowlingScoreboard.DataAccess.Repositories.Interfaces;
using BowlingScoreboard.Dtos;
using BowlingScoreboard.Services.Interfaces;

namespace BowlingScoreboard.Services
{
    public class RoundService : IRoundService
    {
        private readonly IRoundRepository _roundRepository;

        public RoundService(IRoundRepository roundRepository)
        {
            _roundRepository = roundRepository;
        }

        public int GetCurrentRoundNumber(Guid gameId)
        {
            return _roundRepository.GetCurrentRoundNumber(gameId);
        }

        public RoundDto CreateRound(RoundDto round)
        {
            var roundWithCalculatedScore = CalculateRoundScore(round);

            var createdRound = _roundRepository.CreateRound(roundWithCalculatedScore);

            return createdRound;
        }

        public RoundDto CalculateRoundScore(RoundDto round)
        {
            var previousRoundsScoresSum = GetPreviousRoundsScoresSum(round);

            var currentRoundRollsSum = GetCurrentRoundScore(round);

            var firstRollScore = round.Rolls.FirstOrDefault().Score;

            RoundTypeDto roundTypeDto = null;

            var isOpen = currentRoundRollsSum < 10;
            if (isOpen)
            {
                round.Score = previousRoundsScoresSum + currentRoundRollsSum;
                roundTypeDto = _roundRepository.GetRoundTypeByName("Open");
                
            }

            var isStrike = firstRollScore == 10;
            if (isStrike)
            {
                round.Score = previousRoundsScoresSum + currentRoundRollsSum + 10;
                roundTypeDto = _roundRepository.GetRoundTypeByName("Strike");
            }

            var isSpare = currentRoundRollsSum == 10;
            if (isSpare)
            {
                round.Score = previousRoundsScoresSum + firstRollScore + 10;
                roundTypeDto = _roundRepository.GetRoundTypeByName("Spare");
            }

            round.RoundTypeId = roundTypeDto.Id;
            round.RoundTypeName = roundTypeDto.Name;

            return round;
        }

        private int GetCurrentRoundScore(RoundDto round)
        {
            return round.Rolls.Select(r => r.Score).Sum();
        }

        private int GetPreviousRoundsScoresSum(RoundDto round)
        {
            var playerRounds = _roundRepository.GetRoundsByPlayerId(round.PlayerId);

            var playerRoundScoresSum = playerRounds.Select(r => r.Score).Sum();

            return playerRoundScoresSum;
        }
    }
}
