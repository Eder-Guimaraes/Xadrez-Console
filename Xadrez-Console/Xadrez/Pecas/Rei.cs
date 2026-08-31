using Xadrez_Console.tabuleiro;

namespace Xadrez_Console.Xadrez.Pecas
{
    internal class Rei : Peca
    {
        public Rei(Cor cor, Tabuleiro tabuleiro) : base(cor, tabuleiro)
        {
        }


        public override string ToString()
        {
            return Cor == Cor.Preta ? "♔" : "♚";
        }
    }
}
