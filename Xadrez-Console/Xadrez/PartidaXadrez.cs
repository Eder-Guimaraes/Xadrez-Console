using System;
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

        public PartidaXadrez()
        {
            Tabuleiro = new Tabuleiro(8, 8);
            Turno = 1;
            JogadorAtual = Cor.Branca;
            Terminada = false;
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

        private void ColocarPecas()
        {
            // Peças Brancas
            Tabuleiro.ColocarPeca(new Torre(Cor.Branca, Tabuleiro), new PosicaoXadrez('a', 1).ToPosicao());
            Tabuleiro.ColocarPeca(new Cavalo(Cor.Branca, Tabuleiro), new PosicaoXadrez('b', 1).ToPosicao());
            Tabuleiro.ColocarPeca(new Bispo(Cor.Branca, Tabuleiro), new PosicaoXadrez('c', 1).ToPosicao());
            Tabuleiro.ColocarPeca(new Dama(Cor.Branca, Tabuleiro), new PosicaoXadrez('d', 1).ToPosicao());
            Tabuleiro.ColocarPeca(new Rei(Cor.Branca, Tabuleiro), new PosicaoXadrez('e', 1).ToPosicao());
            Tabuleiro.ColocarPeca(new Bispo(Cor.Branca, Tabuleiro), new PosicaoXadrez('f', 1).ToPosicao());
            Tabuleiro.ColocarPeca(new Cavalo(Cor.Branca, Tabuleiro), new PosicaoXadrez('g', 1).ToPosicao());
            Tabuleiro.ColocarPeca(new Torre(Cor.Branca, Tabuleiro), new PosicaoXadrez('h', 1).ToPosicao());

            for (char c = 'a'; c <= 'h'; c++)
            {
                Tabuleiro.ColocarPeca(new Peao(Cor.Branca, Tabuleiro), new PosicaoXadrez(c, 2).ToPosicao());
            }

            // Peças Pretas
            Tabuleiro.ColocarPeca(new Torre(Cor.Preta, Tabuleiro), new PosicaoXadrez('a', 8).ToPosicao());
            Tabuleiro.ColocarPeca(new Cavalo(Cor.Preta, Tabuleiro), new PosicaoXadrez('b', 8).ToPosicao());
            Tabuleiro.ColocarPeca(new Bispo(Cor.Preta, Tabuleiro), new PosicaoXadrez('c', 8).ToPosicao());
            Tabuleiro.ColocarPeca(new Dama(Cor.Preta, Tabuleiro), new PosicaoXadrez('d', 8).ToPosicao());
            Tabuleiro.ColocarPeca(new Rei(Cor.Preta, Tabuleiro), new PosicaoXadrez('e', 8).ToPosicao());
            Tabuleiro.ColocarPeca(new Bispo(Cor.Preta, Tabuleiro), new PosicaoXadrez('f', 8).ToPosicao());
            Tabuleiro.ColocarPeca(new Cavalo(Cor.Preta, Tabuleiro), new PosicaoXadrez('g', 8).ToPosicao());
            Tabuleiro.ColocarPeca(new Torre(Cor.Preta, Tabuleiro), new PosicaoXadrez('h', 8).ToPosicao());

            for (char c = 'a'; c <= 'h'; c++)
            {
                Tabuleiro.ColocarPeca(new Peao(Cor.Preta, Tabuleiro), new PosicaoXadrez(c, 7).ToPosicao());
            }
        }

    }
}