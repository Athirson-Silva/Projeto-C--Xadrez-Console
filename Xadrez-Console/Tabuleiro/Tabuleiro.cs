﻿namespace tabuleiro
{
    internal class Tabuleiro
    {
        public int Linhas { get; set; }
        public int Colunas { get; set; }
        private Peca[,] Pecas;

        public Tabuleiro(int linhas, int colunas)
        {
            Linhas = linhas;
            Colunas = colunas;
            Pecas = new Peca[linhas, colunas];
        }

        public Peca peca(int linha, int coluna) //Como deixamos as peças como private, precisamos criar esse método para retornar as peças no método da classe Tela
        {
            return Pecas[linha, coluna];
        }

        public Peca peca(Posicao pos)
        {
            return Pecas[pos.Linha, pos.Coluna];
        }

        public bool jaExistePeca(Posicao pos)
        {
            validarPosicao(pos); //Checa se a possição inserida é válida

            return peca(pos) != null; //Testa se existe peça na posição, se a posição for válida 
        }

        public void colocarPeca(Peca p, Posicao pos)
        {
            if (jaExistePeca(pos))
            {
                throw new TabuleiroException("Já existe uma peça aqui mano, se liga hein");
            }

            Pecas[pos.Linha, pos.Coluna] = p;
            p.Posicao = pos;
        }

        public Peca retirarPeca(Posicao pos)
        {
            if (peca(pos) == null)
            {
                return null;
            }
            Peca aux = peca(pos);
            aux.Posicao = null;
            Pecas[pos.Linha, pos.Coluna] = null;
            return aux;
        }

        public bool posicaoValida(Posicao pos)
        {
            if (pos.Linha < 0 || pos.Linha >= Linhas || pos.Coluna < 0 || pos.Coluna >= Colunas)
            {
                return false;
            }
            return true;
        }

        public void validarPosicao(Posicao pos)
        {
            if (!posicaoValida(pos))
            {
                throw new TabuleiroException("Posição nada haver mano!");
            }

        }
    }
}
