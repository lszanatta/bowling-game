using System;

namespace BowlingGame.TenPinFrame
{
    public class TenPinBowlingNormalFrame : TenPinBowlingFrame
    {
        public TenPinBowlingNormalFrame()
        {
            Throws = new int[2];
        }

        /// <summary>
        /// Save the number of knocked over pins in a trow
        /// </summary>
        /// <param name="pins">Number of knocked over pins in the throw</param>
        /// <exception cref="ArgumentException">Number of knocked over pins for this throw is invalid</exception>
        public override void AddThrow(int pins)
        {
            if (pins + Pins > 10)
                throw new ArgumentException($"Number of knocked over pins for this throw is invalid. You have {10 - Pins} pins left in this frame.");

            Throws[CurrentThrow++] = pins;
            Pins += pins;
        }

        /// <summary>
        /// Check if the frame is closed (is over)
        /// </summary>
        /// <returns></returns>
        public override bool FrameClosed() => CurrentThrow == 2 || Pins == 10;
    }
}
