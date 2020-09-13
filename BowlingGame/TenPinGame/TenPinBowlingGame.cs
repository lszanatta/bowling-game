using System;
using System.Linq;
using BowlingGame.TenPinFrame;
using BowlingGame.TenPinScore;

namespace BowlingGame.TenPinGame
{
    /// <summary>
    /// Ten-pin bowling game
    /// </summary>
    public class TenPinBowlingGame : ITenPinBowlingGame
    {
        private TenPinBowlingFrame[] _tenPinBowlingFrames;

        private readonly ITenPinBowlingScore _tenPinBowlingScore;

        private int _currentFrame;

        public TenPinBowlingGame(ITenPinBowlingScore tenPinBowlingScore)
        {
            _tenPinBowlingFrames = new TenPinBowlingFrame[10];
            _tenPinBowlingFrames[0] = new TenPinBowlingNormalFrame();

            _tenPinBowlingScore = tenPinBowlingScore;
        }

        /// <summary>
        /// Attempt a throw in a frame
        /// </summary>
        /// <param name="pins">Number of knocked over pins</param>
        /// <exception cref="ArgumentOutOfRangeException">Number of knocked over pins is invalid (must be between 0 and 10)</exception>
        /// <exception cref="InvalidOperationException">Attempting a throw when the game is over</exception>
        public void ThrowPins(int pins)
        {
            if (pins < 0 || pins > 10)
                throw new ArgumentOutOfRangeException("Number of knocked over pins must be between 0 and 10.");

            if (IsGameOver())
                throw new InvalidOperationException("Game is over.");

            _tenPinBowlingFrames[_currentFrame].AddThrow(pins);
        }

        /// <summary>
        /// Check if the current frame is closed (is over)
        /// </summary>
        /// <returns></returns>
        public bool IsFrameClosed() => _tenPinBowlingFrames[_currentFrame].FrameClosed();

        /// <summary>
        /// Setup the next frame in the game
        /// </summary>
        public void NextFrame()
        {
            if (!IsGameOver())
            {
                if (_currentFrame < 8)
                    _tenPinBowlingFrames[++_currentFrame] = new TenPinBowlingNormalFrame();
                else
                    _tenPinBowlingFrames[++_currentFrame] = new TenPinBowlingLastFrame();
            }
        }

        /// <summary>
        /// Check if the game is over
        /// </summary>
        /// <returns></returns>
        public bool IsGameOver() => (_tenPinBowlingFrames[9] != null) && _tenPinBowlingFrames[9].FrameClosed();

        /// <summary>
        /// Get the final score for the game
        /// </summary>
        /// <returns>Final score</returns>
        /// <exception cref="InvalidOperationException">Trying to get the score before the game is over</exception>
        public int GetFinalScore()
        {
            if (!IsGameOver())
                throw new InvalidOperationException("The game is not over yet. Finish the game to calculate the final score.");

            // Get all throws made in the game, in chronological order, into a single array
            var allThrows = _tenPinBowlingFrames.Where(x => x != null).SelectMany(row => row.Throws).ToArray();

            return _tenPinBowlingScore.CalculateScore(allThrows);
        }

        /// <summary>
        /// Reset game and clear score
        /// </summary>
        public void ResetGame()
        {
            _tenPinBowlingFrames = new TenPinBowlingFrame[10];
            _tenPinBowlingFrames[0] = new TenPinBowlingNormalFrame();
            _currentFrame = 0;
            _tenPinBowlingScore.ClearScore();
        }
    }
}
