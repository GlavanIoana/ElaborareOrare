using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace proiectPAW
{
    public class Grupa:Data
    {
        private int cod;
        private int nrElevi;
        private int anStudiu;

        public int Cod { get => cod; set => cod = value; }
        public int NrElevi { get => nrElevi; set => nrElevi = value; }
        public int AnStudiu { get => anStudiu; set => anStudiu = value; }

        public override string ToString()
        {
            return "Grupa "+cod+" are "+nrElevi+" elevi, anul "+anStudiu;
        }

        public Grupa()
        {
        }

        public Grupa(int cod, int nrElevi, int anStudiu)
        {
            this.cod = cod;
            this.nrElevi = nrElevi;
            this.anStudiu = anStudiu;
        }
    }
}
