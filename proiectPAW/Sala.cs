using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace proiectPAW
{
    public class Sala: Data,ICloneable, IComparable
    {
        private int cod;
        private int capacitate;
        //private string[] dotari
        private String tip;

        public Sala(int cod)
        {
            this.cod = cod;
        }
        public Sala()
        {
        }
        public override string ToString()
        {
            return "\nSala "+cod+" este de "+tip+" si are o capacitate de "+capacitate+" locuri";
        }

        public object Clone()
        {
            return this.MemberwiseClone();
        }

        public int CompareTo(object obj)
        {
            Sala s=(Sala)obj;
            if (capacitate < s.capacitate) return -1;
            else if (capacitate > s.capacitate) return 1;
            else return 0;
        }

        public Sala(int cod, int capacitate,String tip)
        {
            this.cod = cod;
            this.capacitate = capacitate;
            this.tip = tip;
        }
        public int Cod { get => cod; set => cod = value; }
        public int Capacitate { get => capacitate; set => capacitate = value; }
        public string Tip { get => tip; set => tip = value; }

        public static Sala operator+(Sala s, int dif)
        {
            s.capacitate += dif;
            return s;
        }
        public static Sala operator+(int dif, Sala s)
        {
            return s+dif;
        }
        public static Sala operator -(Sala s, int dif)
        {
            s.capacitate -= dif;
            return s;
        }
        public static Sala operator -(int dif, Sala s)
        {
            return s - dif;
        }
        public static Sala operator--(Sala s)
        {
            return s - 1;
        }
        public static Sala operator ++(Sala s)
        {
            return s + 1;
        }

    }
}
