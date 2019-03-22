﻿using System;
using System.Linq;
using BowlingScoreboard.DataAccess.Repositories.Interfaces;
using BowlingScoreboard.Dtos;
using BowlingScoreboard.Services.Interfaces;

namespace BowlingScoreboard.Services
{
    public class RoundService : IRoundService
    {
        private readonly IRoundRepository _roundRepository;

        private const int PinsCount = 10;

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
            var previousRoundsScoresSum = GetPreviousRoundScoresSum(round);

            var currentRoundRollsSum = GetCurrentRoundScore(round);

            var firstRollScore = round.Rolls.FirstOrDefault().Score;

            RoundTypeDto roundTypeDto = null;

            var isStrike = firstRollScore == PinsCount;
            if (isStrike)
            {
                round.Score = previousRoundsScoresSum + currentRoundRollsSum + 10;
                roundTypeDto = _roundRepository.GetRoundTypeByName("Strike");
            }

            var isOpen = currentRoundRollsSum < PinsCount ;
            if (isOpen)
            {
                round.Score = previousRoundsScoresSum + currentRoundRollsSum;
                roundTypeDto = _roundRepository.GetRoundTypeByName("Open");                
            }

            var isSpare = (currentRoundRollsSum == PinsCount && firstRollScore != PinsCount);
            if (isSpare)
            {
                round.Score = previousRoundsScoresSum + firstRollScore + 10;
                roundTypeDto = _roundRepository.GetRoundTypeByName("Spare");
            }
            
            if (!isSpare && !isOpen & !isStrike)
                throw new ArgumentOutOfRangeException();

            round.RoundTypeId = roundTypeDto?.Id;
            
            return round;
        }

        private int GetCurrentRoundScore(RoundDto round)
        {
            var roundScore = round.Rolls.Select(r => r.Score).Sum();

            if (roundScore > PinsCount)
                throw new ArgumentOutOfRangeException();

            return roundScore;
        }

        private int GetPreviousRoundScoresSum(RoundDto round)
        {
            var playerRounds = _roundRepository.GetRoundsByPlayerId(round.PlayerId);

            var playerRoundScoresSum = playerRounds?.LastOrDefault()?.Score ?? 0;

            return playerRoundScoresSum;
        }
    }
}
