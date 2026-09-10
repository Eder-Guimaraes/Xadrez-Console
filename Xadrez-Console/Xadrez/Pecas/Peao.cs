using Xadrez_Console.tabuleiro;

namespace Xadrez_Console.Xadrez.Pecas
{
    internal class Peao : Peca
    {

        public Peao(Cor cor, Tabuleiro tabuleiro) : base(cor, tabuleiro)
        {
        }

        public override bool[,] MovimentosPossiveis()
        {
            bool[,] mat = new bool[Tab.Linhas, Tab.Colunas];
            Posicao pos = new Posicao(0, 0);

            if (Cor == Cor.Preta)
            {
                pos.DefinirValores(Posicao.Linha + 1, Posicao.Coluna);
                if (Tab.PosicaoValida(pos) && !Tab.ExistePeca(pos))
                {
                    mat[pos.Linha, pos.Coluna] = true;
                }
                pos.DefinirValores(Posicao.Linha + 2, Posicao.Coluna);
                if (Tab.PosicaoValida(pos) && !Tab.ExistePeca(pos) && QtdeMovimentos == 0)
                {
                    mat[pos.Linha, pos.Coluna] = true;
                }

                // Captura diagonal esquerda
                pos.DefinirValores(Posicao.Linha + 1, Posicao.Coluna - 1);
                if (Tab.PosicaoValida(pos) && Tab.ExistePeca(pos) && Tab.Peca(pos).Cor != Cor)
                {
                    mat[pos.Linha, pos.Coluna] = true;
                }

                // Captura diagonal direita
                pos.DefinirValores(Posicao.Linha + 1, Posicao.Coluna + 1);
                if (Tab.PosicaoValida(pos) && Tab.ExistePeca(pos) && Tab.Peca(pos).Cor != Cor)
                {
                    mat[pos.Linha, pos.Coluna] = true;
                }
            }
            else
            {
                pos.DefinirValores(Posicao.Linha - 1, Posicao.Coluna);
                if (Tab.PosicaoValida(pos) && !Tab.ExistePeca(pos))
                {
                    mat[pos.Linha, pos.Coluna] = true;
                }
                pos.DefinirValores(Posicao.Linha - 2, Posicao.Coluna);
                if (Tab.PosicaoValida(pos) && !Tab.ExistePeca(pos) && QtdeMovimentos == 0)
                {
                    mat[pos.Linha, pos.Coluna] = true;
                }

                // Captura diagonal esquerda
                pos.DefinirValores(Posicao.Linha - 1, Posicao.Coluna - 1);
                if (Tab.PosicaoValida(pos) && Tab.ExistePeca(pos) && Tab.Peca(pos).Cor != Cor)
                {
                    mat[pos.Linha, pos.Coluna] = true;
                }

                // Captura diagonal direita
                pos.DefinirValores(Posicao.Linha - 1, Posicao.Coluna + 1);
                if (Tab.PosicaoValida(pos) && Tab.ExistePeca(pos) && Tab.Peca(pos).Cor != Cor)
                {
                    mat[pos.Linha, pos.Coluna] = true;
                }
            }

            return mat;
        }

        public override string ToString()
        {
            return Cor == Cor.Preta ? "♙": "♟";
        }
    }
}
