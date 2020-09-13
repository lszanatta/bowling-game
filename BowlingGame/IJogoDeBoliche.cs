namespace BowlingGame
{
    public interface IJogoDeBoliche
    {
        void Jogar(int pinos);

        int ObterPontuacao();

        bool IsGameOver();
    }
}
