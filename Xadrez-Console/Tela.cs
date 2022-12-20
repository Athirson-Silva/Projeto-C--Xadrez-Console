using System;
using System.Collections.Generic;
using tabuleiro;
using xadrez;

namespace Xadrez_Console
{
    internal class Tela
    {
        public static ConsoleColor CorBranca = ConsoleColor.White;
        public static ConsoleColor CorPreta = ConsoleColor.Black;
        public static ConsoleColor CorDestaque = ConsoleColor.Blue;

        public static void imprimirPartida(PartidaDeXadrez partida)
        {
            Console.Clear();
            imprimirTabuleiro(partida.Tab);
            Console.WriteLine();
            imprimirPecasCapturadas(partida);
            Console.WriteLine($"Turno: {partida.Turno}");
            Console.WriteLine($"Aguardando peças {partida.JogadorAtual}s...");
        }

        public static void imprimirPecasCapturadas(PartidaDeXadrez partida)
        {
            Console.Clear();
            Console.WriteLine("Peças capturadas:");
            Console.Write("Brancas: ");
            imprimirConjunto(partida.pecasCapturadas(Cor.Branca));
            Console.WriteLine();

            Console.ForegroundColor = CorDestaque;

            Console.Write("Pretas: ");
            imprimirConjunto(partida.pecasCapturadas(Cor.Preta));
            Console.ForegroundColor = CorBranca;
            Console.WriteLine();
        }

        public static void imprimirConjunto(HashSet<Peca> conjunto)
        {
            Console.Write("[");
            foreach (Peca peca in conjunto)
            {
                Console.Write(peca + " ");
            }
            Console.Write("]");
        }

        public static void imprimirTabuleiro(Tabuleiro tab)
        {
            for (int i = 0; i < tab.Linhas; i++)
            {
                Console.Write(8 - i + " ");
                for (int j = 0; j < tab.Colunas; j++)
                {
                    imprimirPeca(tab.peca(i, j));
                }
                Console.WriteLine();
            }
            Console.WriteLine("  a b c d e f g h");
        }

        public static void imprimirTabuleiro(Tabuleiro tab, bool[,] posicoesPossiveis)
        {
            for (int linhas = 0; linhas < tab.Linhas; linhas++)
            {
                Console.Write(8 - linhas + " ");
                for (int colunas = 0; colunas < tab.Colunas; colunas++)
                {
                    destacarPossivelMovimento(posicoesPossiveis, linhas, colunas);
                    imprimirPeca(tab.peca(linhas, colunas));
                    Console.BackgroundColor = CorPreta;
                }
                Console.WriteLine();
            }
            Console.WriteLine("  a b c d e f g h");

            Console.BackgroundColor = CorPreta;
        }

        public static PosicaoXadrez lerPosicaoXadrez()
        {
            string s = Console.ReadLine().Trim();
            char coluna = s[0];
            int linha = int.Parse(s[1] + "");

            return new PosicaoXadrez(coluna, linha);
        }

        public static void destacarPossivelMovimento(bool[,] matPossiveisMovimentos, int linha, int coluna)
        {
            if (matPossiveisMovimentos[linha, coluna])
            {
                Console.BackgroundColor = CorBranca;
            }
            else
            {
                Console.BackgroundColor = CorPreta;
            }
        }

        public static void imprimirPeca(Peca peca)
        {

            if (peca == null)
            {
                Console.Write("- ");
                return;
            }

            if (peca.Cor == Cor.Branca)
            {
                Console.Write(peca);
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.Write(peca);
                Console.ForegroundColor = CorBranca;
            }
            Console.Write(" ");
        }
    }
}
