using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace proiectPAW
{
    public class Profesor:Persoana,IPrima,IMarire,IComparable<Profesor>
    {
        private String[] discipline;
        private DateTime data_angajare;
        private float salariu;

        public override string ToString()
        {
            String rezultat="";
            rezultat += Nume + " are codul " + Cod + " preda ";
            foreach (String s in discipline)
                rezultat += s.ToString() + ", ";
            rezultat += " s-a angajat pe " + data_angajare.ToShortDateString() + " si are un salariu de " + salariu + " lei";
            return rezultat;
        }

        public Profesor()
        {
        }
        public Profesor(int c):base(c)
        {
        }
        public Profesor(int cod, string n, String[] discipline, DateTime data_angajare,float salariu):base(cod,n)
        {
            this.discipline = discipline;
            this.data_angajare = data_angajare;
            this.salariu = salariu;
        }
        public DateTime Data_angajare { get => data_angajare; set => data_angajare = value; }
        internal String[] Discipline { get => discipline; set => discipline = value; }
        public float Salariu { get => salariu; set => salariu = value; }

        public String this[int index]
        {
            get
            {
                if (discipline != null && index >= 0 && index < discipline.Length)
                    return discipline[index];
                else return null;
            }
            set
            {
                if (discipline != null && index >= 0 && index < discipline.Length && value != null)
                    discipline[index] = value;
            }
        }
        public int CompareTo(Profesor other)
        {
            if (this.discipline.Length < other.discipline.Length) return -1;
            else if (this.discipline.Length > other.discipline.Length) return 1;
            else return 0;
        }
        public float CalculeazaPrima(float procent)
        {
            float prima=0;
            prima =(System.DateTime.Now.Year - data_angajare.Year) * procent;
            return prima;
        }

        public float MarireSalariu(float procent)
        {
            salariu += this.CalculeazaPrima(procent);
            return salariu;
        }

        
    }
}
