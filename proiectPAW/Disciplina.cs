using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace proiectPAW
{
    public class Disciplina: Data,ICloneable, IComparable<Disciplina>
    {
        private int cod;
        private string denumire;
        private int nrCredite;
        private string catedra;

        public Disciplina()
        {
        }
        public override string ToString()
        {
            return "\nDisciplina "+denumire+" are codul "+cod+", "+nrCredite+" credite si face parte din catedra "+catedra;
        }

        public object Clone()
        {
            return this.MemberwiseClone();
        }

        public int CompareTo(Disciplina other)
        {
            if (nrCredite < other.nrCredite) return -1;
            else if (nrCredite > other.nrCredite) return 1;
            else return string.Compare(this.denumire, other.denumire);
        }

        public Disciplina(int cod, string denumire, int nrCredite, string catedra)
        {
            this.cod = cod;
            this.denumire = denumire;
            this.nrCredite = nrCredite;
            this.catedra = catedra;
        }
        public int Cod { get => cod; set => cod = value; }
        public string Denumire { get => denumire; set => denumire = value; }
        public int NrCredite { get => nrCredite; set => nrCredite = value; }
        public string Catedra { get => catedra; set => catedra = value; }
    }
}
