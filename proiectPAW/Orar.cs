//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace proiectPAW
//{
//    public class Orar
//    {
//        //private List<zile> zile;
//        private List<Disciplina> discipline;
//        private List<Profesor> profesori;
//        private List<Sala> sali;
//        private List<Grupa> grupe;
//        private Lectie[][][] salaOrar=null;//[zi][ora][sala]
//        private Lectie[][][] profOrar=null;//[zi][ora][prof]
//        private Lectie[][][] grupaOrar=null;//[zi][ora][grupa]

//        public Orar()
//        {
//            discipline = new List<Disciplina>();
//            profesori = new List<Profesor>();
//            sali = new List<Sala>();
//            grupe = new List<Grupa>();
//            salaOrar = null;
//            grupaOrar = null;
//            profOrar = null;
//        }

//        public List<Disciplina> Discipline { get => discipline; set => discipline = value; }
//        internal List<Profesor> Profesori { get => profesori; set => profesori = value; }
//        internal List<Sala> Sali { get => sali; set => sali = value; }
//        internal List<Grupa> Grupe { get => grupe; set => grupe = value; }
//        internal Lectie[][][] SalaOrar { get => salaOrar; set => salaOrar = value; }
//        internal Lectie[][][] ProfOrar { get => profOrar; set => profOrar = value; }
//        internal Lectie[][][] GrupaOrar { get => grupaOrar; set => grupaOrar = value; }

//        public Grupa[] grupeDisponibile(int zi, int ora)
//        {

//            Grupa[] str=null;
//            bool gasit = false;
//            int k = 0;
//            for (int s = 0; s < grupe.Count; s++)
//            {
//                if (grupaOrar[zi][ora][s] == null)
//                {
//                    str[k++] = grupe[s];
//                    gasit = true;
//                }
//            }
//            return str;
//        }
//        public Sala[] saliDisponibile(int zi, int ora)
//        {

//            Sala[] str = null;
//            bool gasit = false;
//            int k = 0;
//            for (int s = 0; s < sali.Count; s++)
//            {
//                if (salaOrar[zi][ora][s] == null)
//                {
//                    str[k++] = sali[s];
//                    gasit = true;
//                }
//            }
//            return str;
//        }
//        public bool IsRoomClash(int zi, int ora, int codSala/*, out string errorMessage*/)
//        {
//            //bool rtn = salaOrar[zi][ora][codSala] != null? true:false;
//            ////if (rtn) errorMessage = "A room clash has occured. " + saliDisponibile(zi, ora) + Environment.NewLine;
//            ////else errorMessage = "";
//            //return rtn;
//            if (salaOrar[zi][ora][codSala] == null) return false;
//            return true;
//        }
//        public string profesoriDisponibili(int zi, int ora)
//        {

//            string str = "Profi disponibili: ";
//            bool gasit = false;
//            for (int s = 0; s < profesori.Count; s++)
//            {
//                if (profOrar[zi][ora][s] == null)
//                {
//                    str += profesori[s].Nume + ", ";
//                    gasit = true;
//                }
//            }
//            str = str.Remove(str.Length - 2, 2);
//            return gasit == true ? str : "Profi disponibili: Niciunul";
//        }
//        public bool IsClassClash(int zi, int ora, int codGrupa/*, out string errorMessage*/)
//        {
//            bool rtn = grupaOrar[zi][ora][codGrupa] != null?true:false;
//            //if (rtn) errorMessage = "A class clash has occured. Please set the year to other value, and try again." + Environment.NewLine;
//            //else errorMessage = "";
//            return rtn;
//        }
//        public void adaugaLectie(Profesor p,Disciplina d,int zi, int ora)
//        {

//        }
//    }
//}
