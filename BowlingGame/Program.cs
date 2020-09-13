using System;
using BowlingGame.TenPinGame;
using BowlingGame.TenPinScore;

namespace BowlingGame
{
    class Program
    {
        static void Main(string[] args)
        {
            JogoDeBoliche jogoDeBoliche = new JogoDeBoliche(new TenPinBowlingGame(new TenPinBowlingScore()));

            Random random = new Random();

            Console.WriteLine("\n *** Starting game 1 ***");

            while (!jogoDeBoliche.IsGameOver())
            {
                try
                {
                    jogoDeBoliche.Jogar(random.Next(0, 11));
                }
                catch (Exception)
                {
                    continue;
                }
            }

            Console.WriteLine("\n *** Game 1 is over ***\n");
            Console.WriteLine($" *** Final score for game 1 is: {jogoDeBoliche.ObterPontuacao()} ***\n");

            jogoDeBoliche.ResetGame();

            Console.WriteLine("\n *** Starting game 2 ***");

            while (!jogoDeBoliche.IsGameOver())
            {
                try
                {
                    jogoDeBoliche.Jogar(random.Next(0, 11));
                }
                catch (Exception)
                {
                    continue;
                }
            }

            Console.WriteLine("\n *** Game 2 is over ***\n");
            Console.WriteLine($" *** Final score for game 2 is: {jogoDeBoliche.ObterPontuacao()} ***\n");

            jogoDeBoliche.ResetGame();

            Console.WriteLine("\n *** Starting game 3 ***");

            while (!jogoDeBoliche.IsGameOver())
            {
                try
                {
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
                }
                catch (Exception)
                {
                    continue;
                }
            }

            Console.WriteLine("\n *** Game 3 is over ***\n");
            Console.WriteLine($" *** Final score for game 3 is: {jogoDeBoliche.ObterPontuacao()} ***\n");
        }
    }
}
