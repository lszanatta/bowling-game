namespace BowlingGame.TenPinScore
{
    /// <summary>
    /// Tradition ten-pin bowling score system
    /// </summary>
    public class TenPinBowlingScore : ITenPinBowlingScore
    {
        private int[] _throws;

        /// <summary>
        /// Calculate final game score
        /// </summary>
        /// <param name="throws">All throws made in the game, in chronological order</param>
        /// <returns>Final score</returns>
        public int CalculateScore(int[] throws)
        {
            int points = 0;

            _throws = throws;

            // Frames 1 through 9
            for (int i = 0; i <= 16; i += 2)
            {
                if (CheckStrike(i))
                    points += 10 + _throws[i + 2] + (CheckStrike(i + 2) ? _throws[i + 4] : _throws[i + 3]);
                else if (CheckSpare(i))
                    points += 10 + _throws[i + 2];
                else
                    points += _throws[i] + _throws[i + 1];
            }

            // Last frame
            points += _throws[18] + _throws[19] + _throws[20];

            return points;
        }

        /// <summary>
        /// Clear game score
        /// </summary>
        public void ClearScore()
        {
            _throws = null;
        }

        /// <summary>
        /// Check if a strike was made in a give throw
        /// </summary>
        /// <param name="t">Throw to check</param>
        /// <returns>true is a strike was made, otherwise false</returns>
        private bool CheckStrike(int t) => _throws[t] == 10;

        /// <summary>
        /// Check if a spare was made in a give throw
        /// </summary>
        /// <param name="t">Throw to check</param>
        /// <returns>true if a spare was made, otherwise false</returns>
        private bool CheckSpare(int t) => (!CheckStrike(t)) && (_throws[t] + _throws[t + 1] == 10);
    }
}
