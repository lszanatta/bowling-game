using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using BowlingGame.TenPinGame;
using BowlingGame.TenPinScore;

namespace BowlingGame.Tests
{
    [TestClass]
    public class JogoDeBolicheTests
    {
        /// <summary>
        /// Number of knocked over pins for a give frame must between 0 and 10
        /// </summary>
        [TestMethod]
        public void InvalidNumberOfPins()
        {
            JogoDeBoliche jogoDeBoliche = new JogoDeBoliche(new TenPinBowlingGame(new TenPinBowlingScore()));

            Assert.ThrowsException<ArgumentOutOfRangeException>(() => jogoDeBoliche.Jogar(-1));

            Assert.ThrowsException<ArgumentOutOfRangeException>(() => jogoDeBoliche.Jogar(11));
        }

        /// <summary>
        /// The maximum number of knocked over pins in any frame (save for the last) is 10
        /// </summary>
        [TestMethod]
        public void InvalidNumberOfPinsForThrow()
        {
            JogoDeBoliche jogoDeBoliche = new JogoDeBoliche(new TenPinBowlingGame(new TenPinBowlingScore()));

            jogoDeBoliche.Jogar(10);
            jogoDeBoliche.Jogar(1);
            jogoDeBoliche.Jogar(9);
            jogoDeBoliche.Jogar(1);

            Assert.ThrowsException<ArgumentException>(() => jogoDeBoliche.Jogar(10));
        }

        /// <summary>
        /// In the 10th frame, if the first throw was not a strike, the 2nd throw can knock over only the remaining pins
        /// </summary>
        [TestMethod]
        public void InvalidNumberOfPinsSecondThrowLastFrame()
        {
            JogoDeBoliche jogoDeBoliche = new JogoDeBoliche(new TenPinBowlingGame(new TenPinBowlingScore()));

            for (int i = 0; i < 9; i++)
                jogoDeBoliche.Jogar(10);

            jogoDeBoliche.Jogar(5);

            Assert.ThrowsException<ArgumentException>(() => jogoDeBoliche.Jogar(6));
        }

        /// <summary>
        /// In the 10th frame, the 3rd throw is only possible if either a strike or a spare was made in the first two throws
        /// </summary>
        [TestMethod]
        public void InvalidLastThrow()
        {
            JogoDeBoliche jogoDeBoliche = new JogoDeBoliche(new TenPinBowlingGame(new TenPinBowlingScore()));

            for (int i = 0; i < 20; i++)
                jogoDeBoliche.Jogar(1);

            Assert.ThrowsException<InvalidOperationException>(() => jogoDeBoliche.Jogar(1));
        }

        /// <summary>
        /// Assuming no strikes were made in frames 1 through 9 and a either a spare or strike was made in the 10th, the maximum number of throws in a game is 21
        /// </summary>
        [TestMethod]
        public void MaximumNumberOfThrowsNoStrikes()
        {
            JogoDeBoliche jogoDeBoliche = new JogoDeBoliche(new TenPinBowlingGame(new TenPinBowlingScore()));

            for (int i = 0; i < 21; i++)
                jogoDeBoliche.Jogar(5);

            Assert.ThrowsException<InvalidOperationException>(() => jogoDeBoliche.Jogar(1));
        }

        /// <summary>
        /// In the 10th frame, scoring either a strike or spare in the first two throws, a 3rd throw must be possible
        /// </summary>
        [TestMethod]
        public void MaximumNumberOfThrowsSpareOnLastFrame()
        {
            JogoDeBoliche jogoDeBoliche = new JogoDeBoliche(new TenPinBowlingGame(new TenPinBowlingScore()));

            for (int i = 0; i < 9; i++)
                jogoDeBoliche.Jogar(10);

            jogoDeBoliche.Jogar(8);
            jogoDeBoliche.Jogar(2);
            jogoDeBoliche.Jogar(5);
        }

        /// <summary>
        /// Assuming that only strikes are made in all frames, the maximum number of throws in a game is 12
        /// </summary>
        [TestMethod]
        public void MaximumNumberOfThrowsOnlyStrikes()
        {
            JogoDeBoliche jogoDeBoliche = new JogoDeBoliche(new TenPinBowlingGame(new TenPinBowlingScore()));

            for (int i = 0; i < 12; i++)
                jogoDeBoliche.Jogar(10);

            Assert.ThrowsException<InvalidOperationException>(() => jogoDeBoliche.Jogar(1));
        }

        /// <summary>
        /// Assuming that only strikes are made in all frames, the maximum score is 300
        /// </summary>
        [TestMethod]
        public void MaximumPoints()
        {
            JogoDeBoliche jogoDeBoliche = new JogoDeBoliche(new TenPinBowlingGame(new TenPinBowlingScore()));

            for (int i = 0; i < 12; i++)
                jogoDeBoliche.Jogar(10);

            int points = jogoDeBoliche.ObterPontuacao();

            Assert.AreEqual(300, points);
        }

        /// <summary>
        /// Full game example one
        /// </summary>
        [TestMethod]
        public void FullGameExampleOne()
        {
            JogoDeBoliche jogoDeBoliche = new JogoDeBoliche(new TenPinBowlingGame(new TenPinBowlingScore()));

            // Frame 1
            jogoDeBoliche.Jogar(3);
            jogoDeBoliche.Jogar(6);

            // Frame 2
            jogoDeBoliche.Jogar(8);
            jogoDeBoliche.Jogar(2);

            // Frame 3
            jogoDeBoliche.Jogar(10);

            // Frame 4
            jogoDeBoliche.Jogar(10);

            // Frame 5
            jogoDeBoliche.Jogar(5);
            jogoDeBoliche.Jogar(4);

            // Frame 6
            jogoDeBoliche.Jogar(0);
            jogoDeBoliche.Jogar(0);

            // Frame 7
            jogoDeBoliche.Jogar(8);
            jogoDeBoliche.Jogar(1);

            // Frame 8
            jogoDeBoliche.Jogar(8);
            jogoDeBoliche.Jogar(1);

            // Frame 9
            jogoDeBoliche.Jogar(10);

            // Frame 10
            jogoDeBoliche.Jogar(7);
            jogoDeBoliche.Jogar(2);

            int points = jogoDeBoliche.ObterPontuacao();

            Assert.AreEqual(128, points);
        }

        /// <summary>
        /// Full game example two
        /// </summary>
        [TestMethod]
        public void FullGameExampleTwo()
        {
            JogoDeBoliche jogoDeBoliche = new JogoDeBoliche(new TenPinBowlingGame(new TenPinBowlingScore()));

            // Frame 1
            jogoDeBoliche.Jogar(10);

            // Frame 2
            jogoDeBoliche.Jogar(3);
            jogoDeBoliche.Jogar(0);

            // Frame 3
            jogoDeBoliche.Jogar(6);
            jogoDeBoliche.Jogar(3);

            // Frame 4
            jogoDeBoliche.Jogar(8);
            jogoDeBoliche.Jogar(2);

            // Frame 5
            jogoDeBoliche.Jogar(5);
            jogoDeBoliche.Jogar(5);

            // Frame 6
            jogoDeBoliche.Jogar(8);
            jogoDeBoliche.Jogar(1);

            // Frame 7
            jogoDeBoliche.Jogar(10);

            // Frame 8
            jogoDeBoliche.Jogar(6);
            jogoDeBoliche.Jogar(3);

            // Frame 9
            jogoDeBoliche.Jogar(6);
            jogoDeBoliche.Jogar(3);

            // Frame 10
            jogoDeBoliche.Jogar(6);
            jogoDeBoliche.Jogar(4);
            jogoDeBoliche.Jogar(3);

            int points = jogoDeBoliche.ObterPontuacao();

            Assert.AreEqual(117, points);
        }

        /// <summary>
        /// Full game example three
        /// </summary>
        [TestMethod]
        public void FullGameExampleThree()
        {
            JogoDeBoliche jogoDeBoliche = new JogoDeBoliche(new TenPinBowlingGame(new TenPinBowlingScore()));

            // Frame 1
            jogoDeBoliche.Jogar(2);
            jogoDeBoliche.Jogar(5);

            // Frame 2
            jogoDeBoliche.Jogar(0);
            jogoDeBoliche.Jogar(10);

            // Frame 3
            jogoDeBoliche.Jogar(4);
            jogoDeBoliche.Jogar(3);

            // Frame 4
            jogoDeBoliche.Jogar(6);
            jogoDeBoliche.Jogar(3);

            // Frame 5
            jogoDeBoliche.Jogar(3);
            jogoDeBoliche.Jogar(3);

            // Frame 6
            jogoDeBoliche.Jogar(5);
            jogoDeBoliche.Jogar(1);

            // Frame 7
            jogoDeBoliche.Jogar(5);
            jogoDeBoliche.Jogar(4);

            // Frame 8
            jogoDeBoliche.Jogar(9);
            jogoDeBoliche.Jogar(1);

            // Frame 9
            jogoDeBoliche.Jogar(7);
            jogoDeBoliche.Jogar(3);

            // Frame 10
            jogoDeBoliche.Jogar(0);
            jogoDeBoliche.Jogar(10);
            jogoDeBoliche.Jogar(6);

            int points = jogoDeBoliche.ObterPontuacao();

            Assert.AreEqual(101, points);
        }

        /// <summary>
        /// Full game example four
        /// </summary>
        [TestMethod]
        public void FullGameExampleFour()
        {
            JogoDeBoliche jogoDeBoliche = new JogoDeBoliche(new TenPinBowlingGame(new TenPinBowlingScore()));

            // Frame 1
            jogoDeBoliche.Jogar(2);
            jogoDeBoliche.Jogar(5);

            // Frame 2
            jogoDeBoliche.Jogar(0);
            jogoDeBoliche.Jogar(10);

            // Frame 3
            jogoDeBoliche.Jogar(4);
            jogoDeBoliche.Jogar(5);

            // Frame 4
            jogoDeBoliche.Jogar(1);
            jogoDeBoliche.Jogar(6);

            // Frame 5
            jogoDeBoliche.Jogar(0);
            jogoDeBoliche.Jogar(8);

            // Frame 6
            jogoDeBoliche.Jogar(0);
            jogoDeBoliche.Jogar(10);

            // Frame 7
            jogoDeBoliche.Jogar(5);
            jogoDeBoliche.Jogar(5);

            // Frame 8
            jogoDeBoliche.Jogar(3);
            jogoDeBoliche.Jogar(5);

            // Frame 9
            jogoDeBoliche.Jogar(1);
            jogoDeBoliche.Jogar(6);

            // Frame 10
            jogoDeBoliche.Jogar(10);
            jogoDeBoliche.Jogar(0);
            jogoDeBoliche.Jogar(7);

            int points = jogoDeBoliche.ObterPontuacao();

            Assert.AreEqual(105, points);
        }
    }
}
