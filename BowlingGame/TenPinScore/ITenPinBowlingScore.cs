namespace BowlingGame.TenPinScore
{
    public interface ITenPinBowlingScore
    {
        int CalculateScore(int[] throws);

        void ClearScore();
    }
}
