using BowlingGame.TenPinGame;

namespace BowlingGame
{
    public class JogoDeBoliche : IJogoDeBoliche
    {
        private readonly ITenPinBowlingGame _tenPinBowlingGame;

        public JogoDeBoliche(ITenPinBowlingGame tenPinBowlingGame)
        {
            _tenPinBowlingGame = tenPinBowlingGame;
        }

        /// <summary>
        /// Attempt a throw in a frame
        /// </summary>
        /// <param name="pinos">Number of knocked over pins</param>
        public void Jogar(int pinos)
        {
            _tenPinBowlingGame.ThrowPins(pinos);

            if (_tenPinBowlingGame.IsFrameClosed())
                _tenPinBowlingGame.NextFrame();
        }

        /// <summary>
        /// Get final score for the game
        /// </summary>
        /// <returns></returns>
        public int ObterPontuacao() => _tenPinBowlingGame.GetFinalScore();

        /// <summary>
        /// Check if the game is over
        /// </summary>
        /// <returns></returns>
        public bool IsGameOver() => _tenPinBowlingGame.IsGameOver();

        /// <summary>
        /// Reset game and clear score
        /// </summary>
        public void ResetGame() => _tenPinBowlingGame.ResetGame();
    }
}
