namespace BowlingGame.TenPinFrame
{
    public abstract class TenPinBowlingFrame
    {
        public int[] Throws { get; protected set; }

        public int CurrentThrow { get; protected set; }

        public int Pins { get; protected set; }

        public abstract void AddThrow(int pins);

        public abstract bool FrameClosed();
    }
}
