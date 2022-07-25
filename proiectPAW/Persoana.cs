using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace proiectPAW
{
    public class Persoana:Data
    {
        private int cod;
        private string nume;

        public Persoana(int cod)
        {
            this.cod = cod;
        }

        public Persoana()
        {
        }

        public Persoana(int cod, string nume)
        {
            this.cod = cod;
            this.nume = nume;
        }

        public int Cod { get => cod; set => cod = value; }
        public string Nume { get => nume; set => nume = value; }
    }
}
