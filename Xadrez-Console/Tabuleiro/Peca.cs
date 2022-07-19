using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tabuleiro
{
    internal class Peca
    {
        public Tabuleiro Tabuleiro { get; protected set; }
        public Posicao Posicao { get; set; }
        public Cor Cor { get; protected set; }
        public int QteMovimentos { get; protected set; }

        public Peca(Tabuleiro tabuleiro, Cor cor)
        {
            Tabuleiro = tabuleiro;
            Cor = cor;            
            Posicao = null;
            QteMovimentos = 0;
        }

        public void incrementarQteMovimentos()
        {
            QteMovimentos++;
        }
    }
}
