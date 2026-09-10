using System;
using System.Collections.Generic;
using Xadrez_Console.tabuleiro;
using Xadrez_Console.Xadrez.Pecas;
using Xadrez_Console.Exceptions;


namespace Xadrez_Console.Xadrez
{
    internal class PartidaXadrez
    {
        public Tabuleiro Tabuleiro { get; private set; }
        public int Turno { get; private set; }
        public Cor JogadorAtual { get; private set; }
        public bool Terminada { get; private set; }
        private HashSet<Peca> Pecas;
        private HashSet<Peca> Capturadas;

        public PartidaXadrez()
        {
            Tabuleiro = new Tabuleiro(8, 8);
            Turno = 1;
            JogadorAtual = Cor.Branca;
            Terminada = false;
            Pecas = new HashSet<Peca>();
            Capturadas = new HashSet<Peca>();
            ColocarPecas();
        }

        public void ExecutarMovimento(Posicao origem, Posicao destino)
        {
            Peca peca = Tabuleiro.RetirarPeca(origem);
            peca.IncrementarMovimentos();

            Peca pecaCapturada = null;
            if (Tabuleiro.ExistePeca(destino))
            {
                pecaCapturada = Tabuleiro.RetirarPeca(destino);
                Capturadas.Add(pecaCapturada);
            }

            Tabuleiro.ColocarPeca(peca, destino);
        }

        public void RealizaJogada(Posicao origem, Posicao destino)
        {
            ExecutarMovimento(origem, destino);
            Turno++;
            MudarJogador();
        }

        private void MudarJogador()
        {
            if (JogadorAtual == Cor.Branca)
            {
                JogadorAtual = Cor.Preta;
            }
            else
            {
                JogadorAtual = Cor.Branca;
            }
        }

        public HashSet<Peca> PecasCapturadas(Cor cor)
        {
            HashSet<Peca> aux = new HashSet<Peca>();

            foreach(Peca peca in Capturadas)
            {
                if (peca.Cor == cor)
                {
                    aux.Add(peca);
                }
            }

            return aux;
        }

        public HashSet<Peca> PecasJogando(Cor cor)
        {
            HashSet<Peca> aux = new HashSet<Peca>();

            foreach (Peca peca in Pecas)
            {
                if (peca.Cor == cor)
                {
                    aux.Add(peca);
                }
            }

            aux.ExceptWith(PecasCapturadas(cor));
            return aux;
        }

        public void ValidarPosicaoOrigem(Posicao posicao)
        {
            if (Tabuleiro.Peca(posicao) == null)
            {
                throw new TabuleiroException("Não existe peça na posição de origem escolhida!");
            }

            if (JogadorAtual != Tabuleiro.Peca(posicao).Cor)
            {
                throw new TabuleiroException("A peça de origem escolhida não é sua!");
            }

            if (!Tabuleiro.Peca(posicao).ExisteMovimentosPossiveis())
            {
                throw new TabuleiroException("A peça não pode se mover!");
            }
        }

        public void ValidarPosicaoDestino(Posicao origem, Posicao destino)
        {
            if(!Tabuleiro.Peca(origem).PodeMoverPara(destino))
            {
                throw new TabuleiroException("Posição de destino inválida!");
            }
        }

        public void ColocarNovaPeca(char coluna, int linha, Peca peca)
        {
            Tabuleiro.ColocarPeca(peca, new PosicaoXadrez(coluna, linha).ToPosicao());
            Pecas.Add(peca);
        }

        private void ColocarPecas()
        {
            // Peças Brancas
            ColocarNovaPeca('a', 1, new Torre(Cor.Branca, Tabuleiro));
            ColocarNovaPeca('b', 1, new Cavalo(Cor.Branca, Tabuleiro));
            ColocarNovaPeca('c', 1, new Bispo(Cor.Branca, Tabuleiro));
            ColocarNovaPeca('d', 1, new Dama(Cor.Branca, Tabuleiro));
            ColocarNovaPeca('e', 1, new Rei(Cor.Branca, Tabuleiro));
            ColocarNovaPeca('f', 1, new Bispo(Cor.Branca, Tabuleiro));
            ColocarNovaPeca('g', 1, new Cavalo(Cor.Branca, Tabuleiro));
            ColocarNovaPeca('h', 1, new Torre(Cor.Branca, Tabuleiro));

            for (char c = 'a'; c <= 'h'; c++)
            {
                ColocarNovaPeca(c, 2, new Peao(Cor.Branca, Tabuleiro));
            }

            // Peças Pretas
            ColocarNovaPeca('a', 8, new Torre(Cor.Preta, Tabuleiro));
            ColocarNovaPeca('b', 8, new Cavalo(Cor.Preta, Tabuleiro));
            ColocarNovaPeca('c', 8, new Bispo(Cor.Preta, Tabuleiro));
            ColocarNovaPeca('d', 8, new Dama(Cor.Preta, Tabuleiro));
            ColocarNovaPeca('e', 8, new Rei(Cor.Preta, Tabuleiro));
            ColocarNovaPeca('f', 8, new Bispo(Cor.Preta, Tabuleiro));
            ColocarNovaPeca('g', 8, new Cavalo(Cor.Preta, Tabuleiro));
            ColocarNovaPeca('h', 8, new Torre(Cor.Preta, Tabuleiro));

            for (char c = 'a'; c <= 'h'; c++)
            {
                ColocarNovaPeca(c, 7, new Peao(Cor.Preta, Tabuleiro));
            }
        }

    }
}