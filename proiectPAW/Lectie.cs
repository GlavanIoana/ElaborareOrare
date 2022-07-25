using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace proiectPAW
{
    [Serializable]
    public class Lectie
    {
        private Disciplina disciplina;
        private Profesor profesor;
        private bool eCurs;
        private Sala sala;
        private Grupa grupa;
        private int zi;
        private int ora;

        public Lectie()
        {
        }

        public Lectie(Disciplina disciplina, Profesor profesor, bool eCurs, Sala sala, Grupa grupe, int zi, int ora)
        {
            this.disciplina = disciplina;
            this.profesor = profesor;
            this.eCurs = eCurs;
            this.sala = sala;
            this.grupa = grupe;
            this.zi = zi;
            this.ora = ora;
        }

        public Disciplina Disciplina { get => disciplina; set => disciplina = value; }
        public bool ECurs { get => eCurs; set => eCurs = value; }
        public int Zi { get => zi; set => zi = value; }
        public int Ora { get => ora; set => ora = value; }
        internal Profesor Profesor { get => profesor; set => profesor = value; }
        internal Sala Sala { get => sala; set => sala = value; }
        internal Grupa Grupa { get => grupa; set => grupa = value; }

        public override string ToString()
        {
            string rez = "";
            if (eCurs == true) rez += "Curs ";
            else rez += "Seminar ";
            rez += disciplina.Denumire + ", " + profesor.Nume + ", " + sala.Cod + ", "+grupa.Cod+", ";
            switch(zi)
            {
                case 1:rez += "luni";break;
                case 2: rez += "marti"; break;
                case 3: rez += "miercuri"; break;
                case 4: rez += "joi"; break;
                case 5: rez += "vineri"; break;
                case 6: rez += "sambata"; break;
            }
            rez +=", ora " + ora;
            return rez;
        }
    }
}
