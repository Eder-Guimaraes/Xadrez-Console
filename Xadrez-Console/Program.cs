using System;

using Xadrez_Console.tabuleiro;
using Xadrez_Console.Xadrez.Pecas;

namespace Xadrez_Console
{
    class Program
    {
        static void Main(string[] args)
        {
            Tabuleiro tabuleiro = new Tabuleiro(8, 8);

            tabuleiro.ColocarPeca(new Rei(Cor.Branca, tabuleiro), new Posicao(1, 3));
            tabuleiro.ColocarPeca(new Bispo(Cor.Preta, tabuleiro), new Posicao(0, 7));
            tabuleiro.ColocarPeca(new Torre(Cor.Branca, tabuleiro), new Posicao(7, 5));

            Tela.ImprimirTabuleiro(tabuleiro);

        }
    }
}