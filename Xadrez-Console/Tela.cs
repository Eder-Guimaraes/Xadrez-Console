using System;
using System.Collections.Generic;

using Xadrez_Console.tabuleiro;
using Xadrez_Console.Xadrez;

namespace Xadrez_Console
{
    internal class Tela
    {
        public static void ImprimirTabuleiro(Tabuleiro tabuleiro)
        {
            for (int i = 0; i < tabuleiro.Linhas; i++)
            {
                Console.Write(8 - i + " ");
                for (int j = 0; j < tabuleiro.Colunas; j++)
                {
                    if (tabuleiro.Peca(i, j) == null)
                    {
                        Console.Write("- ");
                    }
                    else
                    {
                        Console.Write(tabuleiro.Peca(i, j) + " ");
                    }
                }
                Console.WriteLine();
            }
            Console.WriteLine("  a b c d e f g h");
        }

        public static void ImprimirTabuleiro(Tabuleiro tabuleiro, bool[,] posicoesPossiveis)
        {
            ConsoleColor fundoOriginal = Console.BackgroundColor;
            ConsoleColor fundoAlterado = ConsoleColor.DarkGray;

            for (int i = 0; i < tabuleiro.Linhas; i++)
            {
                Console.Write(8 - i + " ");
                for (int j = 0; j < tabuleiro.Colunas; j++)
                {
                    if (posicoesPossiveis[i, j])
                    {
                        Console.BackgroundColor = fundoAlterado;
                    }
                    else
                    {
                        Console.BackgroundColor = fundoOriginal;
                    }
                    ImprimirPeca(tabuleiro.Peca(i, j));     
                }
                Console.WriteLine();
            }
            Console.WriteLine("  a b c d e f g h");
            Console.BackgroundColor = fundoOriginal;
        }

        public static PosicaoXadrez LerPosicaoXadrez()
        {
            string posicao = Console.ReadLine();
            char letra = posicao[0];
            int numero = int.Parse(posicao[1].ToString());

            return new PosicaoXadrez(letra, numero);
        }

        public static void ImprimirPeca(Peca peca)
        {
            if (peca == null)
            {
                Console.Write("- ");
            }
            else
            {
                Console.Write(peca + " ");
            }
        }

        public static void ImprimirPartida(PartidaXadrez partida)
        {
            Tela.ImprimirTabuleiro(partida.Tabuleiro);
            Console.WriteLine();
            ImprimirPecasCapturadas(partida);
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine($"Turno: {partida.Turno}");

            if(!partida.Terminada) {

                Console.WriteLine($"Jogador atual: {partida.JogadorAtual}");
                if (partida.Xeque)
                {
                    Console.WriteLine("XEQUE");
                }
            }
            else
            {
                Console.WriteLine("XEQUEMATE");
                Console.WriteLine($"Vencedor: {partida.JogadorAtual}");
            }
        }

        public static void ImprimirPecasCapturadas(PartidaXadrez partida)
        {
            Console.WriteLine("Peças capturadas: ");
            Console.Write("Brancas: ");
            ImprimirConjunto(partida.PecasCapturadas(Cor.Branca));
            Console.Write("Pretas: ");
            ImprimirConjunto(partida.PecasCapturadas(Cor.Preta));
        }

        public static void ImprimirConjunto(HashSet<Peca> conjunto)
        {
            Console.Write('[');

            foreach(Peca peca in conjunto)
            {
                Console.Write($"{peca} ");
            }

            Console.WriteLine(']');
        }
    }
}