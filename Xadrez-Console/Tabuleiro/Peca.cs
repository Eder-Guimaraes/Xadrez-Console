
namespace Xadrez_Console.tabuleiro
{
    internal abstract class Peca
    {
        public Posicao Posicao { get; set; }
        public Cor Cor { get; protected set; }
        public int QtdeMovimentos { get; protected set; }
        public Tabuleiro Tab { get; protected set; }


        public Peca(Cor cor, Tabuleiro tab)
        {
            Posicao = null;
            Cor = cor;
            Tab = tab;
            QtdeMovimentos = 0;
        }


        public int IncrementarMovimentos()
        {
            return QtdeMovimentos++;
        }

        public abstract bool[,] MovimentosPossiveis();
    }
}
