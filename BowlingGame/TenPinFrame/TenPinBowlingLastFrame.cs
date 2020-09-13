using System;

namespace BowlingGame.TenPinFrame
{
    public class TenPinBowlingLastFrame : TenPinBowlingFrame
    {
        public TenPinBowlingLastFrame()
        {
            Throws = new int[3];
        }

        /// <summary>
        /// Save the number of knocked over pins in a trow
        /// </summary>
        /// <param name="pins">Number of knocked over pins in the throw</param>
        /// <exception cref="ArgumentException">Number of knocked over pins for this throw is invalid</exception>
        /// <exception cref="InvalidOperationException">3rd throw is not possible</exception>
        public override void AddThrow(int pins)
        {
            if (CurrentThrow == 1 && Pins < 10 && pins + Pins > 10)
                throw new ArgumentException($"Number of knocked over pins for this throw is invalid. You have {10 - Pins} pins left for this throw.");

            if (CurrentThrow == 2 && pins + Pins < 10)
                throw new InvalidOperationException("You can't attempt the 3rd throw.");

            Throws[CurrentThrow++] = pins;
            Pins += pins;
        }

        /// <summary>
        /// Check if the frame is closed (is over)
        /// </summary>
        /// <returns></returns>
        public override bool FrameClosed() => (CurrentThrow == 2 && Pins < 10) || CurrentThrow == 3;
    }
}
