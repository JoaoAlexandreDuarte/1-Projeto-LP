using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simplexity_Game {
    public enum Cor {
        Vermelho = 0,
        Branco
    }

    public enum Forma {
        Cilindro = 0,
        Cubo
    }

    class Peca {
        private Cor color;
        private Forma shape;

        public Peca(Cor color, Forma shape) {

            this.color = color;
            this.shape = shape;
        }
    }
}
