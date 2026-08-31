using Xadrez_Console.tabuleiro;

namespace Xadrez_Console.Xadrez.Pecas
{
    internal class Dama : Peca
    {
        public Dama(Cor cor, Tabuleiro tabuleiro) : base(cor, tabuleiro)
        {
        }


        public override string ToString()
        {
            return Cor == Cor.Preta ? "♕" : "♛";
        }
    }
}
