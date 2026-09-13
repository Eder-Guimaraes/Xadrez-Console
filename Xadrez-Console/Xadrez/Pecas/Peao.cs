using Xadrez_Console.tabuleiro;
using System;

namespace Xadrez_Console.Xadrez.Pecas
{
    internal class Peao : Peca
    {
        private PartidaXadrez Partida;
        
        public Peao(Cor cor, Tabuleiro tabuleiro, PartidaXadrez partida) : base(cor, tabuleiro)
        {
            Partida = partida;
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
                
                //# jogada especial en passant (peão preto)
                if (Posicao.Linha == 4
                    && Partida.VulneravelElPasseant != null
                    && Partida.VulneravelElPasseant is Peao
                    && Partida.VulneravelElPasseant.Cor != Cor)
                {
                    Posicao posVulneravel = Partida.VulneravelElPasseant.Posicao;

                    // o peão branco vulnerável tem que estar na MESMA linha do preto
                    // e numa coluna vizinha (coluna - 1 ou coluna + 1)
                    if (posVulneravel.Linha == Posicao.Linha
                        && Math.Abs(posVulneravel.Coluna - Posicao.Coluna) == 1)
                    {
                        // destino do preto: uma casa "atrás" do branco (Linha + 1),
                        // na coluna do branco
                        Posicao destinoEp = new Posicao(Posicao.Linha + 1, posVulneravel.Coluna);
                        mat[destinoEp.Linha, destinoEp.Coluna] = true;
                    }
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
                
                //# jogada especial en passant (peão branco)
                if (Posicao.Linha == 3
                    && Partida.VulneravelElPasseant != null
                    && Partida.VulneravelElPasseant is Peao
                    && Partida.VulneravelElPasseant.Cor != Cor)
                {
                    Posicao posVulneravel = Partida.VulneravelElPasseant.Posicao;

                    // o peão preto vulnerável tem que estar na MESMA linha do branco
                    // e numa coluna vizinha (coluna - 1 ou coluna + 1)
                    if (posVulneravel.Linha == Posicao.Linha
                        && Math.Abs(posVulneravel.Coluna - Posicao.Coluna) == 1)
                    {
                        // destino do branco: uma casa "atrás" do preto (Linha - 1),
                        // na coluna do preto
                        Posicao destinoEp = new Posicao(Posicao.Linha - 1, posVulneravel.Coluna);
                        mat[destinoEp.Linha, destinoEp.Coluna] = true;
                    }
                }
            }

            return mat;
        }

        public override string ToString()
        {
            return Cor == Cor.Branca ? "♙": "♟";
        }
    }
}
