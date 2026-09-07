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
                PartidaXadrez partida = new PartidaXadrez();

                while (!partida.Terminada)
                {
                    try
                    {
                        Console.Clear();
                        Tela.ImprimirTabuleiro(partida.Tabuleiro);
                        Console.WriteLine();
                        Console.WriteLine($"Turno: {partida.Turno}");
                        Console.WriteLine($"Jogador atual: {partida.JogadorAtual}");

                        Console.WriteLine();
                        Console.Write("Origem: ");

                        PosicaoXadrez origemXadrez = Tela.LerPosicaoXadrez();
                        Posicao origem = origemXadrez.ToPosicao();

                        partida.ValidarPosicaoOrigem(origem);

                        bool[,] posicoesPossiveis = partida.Tabuleiro.Peca(origem).MovimentosPossiveis();

                        Console.Clear();
                        Tela.ImprimirTabuleiro(partida.Tabuleiro, posicoesPossiveis);

                        Console.WriteLine();
                        Console.WriteLine($"Origem: {origemXadrez}");
                        Console.Write("Destino: ");
                        Posicao destino = Tela.LerPosicaoXadrez().ToPosicao();
                        partida.ValidarPosicaoDestino(origem, destino);

                        partida.RealizaJogada(origem, destino);
                    }
                    catch (TabuleiroException ex)
                    {
                        Console.WriteLine(ex.Message);
                        Console.ReadLine();
                    }
                }
            }
            catch (TabuleiroException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}