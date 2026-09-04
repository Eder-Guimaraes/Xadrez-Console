using System;

using Xadrez_Console.tabuleiro;
using Xadrez_Console.Xadrez;
using Xadrez_Console.Xadrez.Pecas;
using Xadrez_Console.Exceptions;

namespace Xadrez_Console
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Tabuleiro tabuleiro = new Tabuleiro(8, 8);
                
                tabuleiro.ColocarPeca(new Rei(Cor.Branca, tabuleiro), new Posicao(1, 6));
                tabuleiro.ColocarPeca(new Bispo(Cor.Preta, tabuleiro), new Posicao(1, 3));
                tabuleiro.ColocarPeca(new Torre(Cor.Branca, tabuleiro), new Posicao(7, 5));

                Tela.ImprimirTabuleiro(tabuleiro);
            }
            catch (TabuleiroException ex)
            {
                Console.WriteLine(ex.Message);
            }

            PosicaoXadrez posicao = new PosicaoXadrez('a', 1);
            Console.WriteLine(posicao);

            Console.WriteLine(posicao.ToPosicao());

        }
    }
}