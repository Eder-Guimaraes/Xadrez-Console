using Xadrez_Console.tabuleiro;

namespace Xadrez_Console.Xadrez.Pecas
{
    internal class Torre : Peca
    {
        public Torre(Cor cor, Tabuleiro tabuleiro) : base(cor, tabuleiro)
        {
        }


        public override string ToString()
        {
            return Cor == Cor.Preta ? "♖": "♜";
        }
    }
}
