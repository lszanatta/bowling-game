namespace BowlingGame.TenPinGame
{
    public interface ITenPinBowlingGame
    {
        void ThrowPins(int pins);

        bool IsFrameClosed();

        void NextFrame();

        bool IsGameOver();

        int GetFinalScore();

        void ResetGame();
    }
}
