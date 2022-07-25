using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace proiectPAW
{
    public partial class ElaborareOrar : Form
    {
        //List<Data> lista = new List<Data>();
        List<Disciplina> listaDiscipline = new List<Disciplina>();
        List<Profesor> listaProfesori = new List<Profesor>();
        List<Sala> listaSali = new List<Sala>();
        List<Grupa> listaGrupe = new List<Grupa>();
        List<Lectie> lectii = new List<Lectie>();
        List<Control> casute = new List<Control>();
        

        public ElaborareOrar(List<Data> list, List<Disciplina> listD, List<Profesor> listP, List<Sala> listS, List<Grupa> listG)
        {
            InitializeComponent();
            foreach (Disciplina d in listD)
                cbDisciplina.Items.Add(d.Denumire);
            foreach (Profesor d in listP)
            {
                cbProf.Items.Add(d.Nume);
                //cbOrar.Items.Add(d.Nume);
            }
            foreach (Grupa d in listG)
                cbGrupa.Items.Add(d.Cod);
            foreach (Sala d in listS)
                cbSala.Items.Add(d.Cod);
            listaDiscipline = listD;
            //lista = list;
            listaGrupe = listG;
            listaProfesori = listP;
            listaSali = listS;
            casute.Add(tb11);casute.Add(tb12); casute.Add(tb13); casute.Add(tb14); casute.Add(tb15); casute.Add(tb16);
            casute.Add(tb21); casute.Add(tb22); casute.Add(tb23); casute.Add(tb24); casute.Add(tb25); casute.Add(tb26);
            casute.Add(tb31); casute.Add(tb32); casute.Add(tb33); casute.Add(tb34); casute.Add(tb35); casute.Add(tb36);
            casute.Add(tb41); casute.Add(tb42); casute.Add(tb43); casute.Add(tb44); casute.Add(tb45); casute.Add(tb46);
            casute.Add(tb51); casute.Add(tb52); casute.Add(tb53); casute.Add(tb54); casute.Add(tb55); casute.Add(tb56);
            casute.Add(tb61); casute.Add(tb62); casute.Add(tb63); casute.Add(tb64); casute.Add(tb65); casute.Add(tb66);

        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                //if (cbCurs.Text == "Nu" && tvGrupa.SelectedNode.Nodes.Count > 1)
                //{
                //    errorProvider1.SetError(tvGrupa,"Selectati o singura grupa!");
                //}
                //else if(cbCurs.Text=="Da"&&tvGrupa.SelectedNode.GetNodeCount(true)<=1)
                //{
                //    errorProvider1.SetError(tvGrupa, "Selectati o serie!");
                //}
                ////else if (cbCurs.Text == "Da" && cbSala.Text.Capacitate < 90)
                ////    errorProvider1.SetError(cbSala, "Sala este neincapatoare!Alegeti alta valoare!");
                ////else if (eCurs == false && s.Capacitate >= 90)
                ////    errorProvider1.SetError(cbSala, "Sala este de curs!Alegeti alta valoare!");
                //else
                //{
                Profesor p = new Profesor();
                foreach (Profesor prof in listaProfesori)
                    if (prof.Nume == cbProf.Text)
                    {
                        p = prof;
                        break;
                    }
                Disciplina d = new Disciplina();
                foreach (Disciplina disc in listaDiscipline)
                    if (disc.Denumire == cbDisciplina.Text)
                    {
                        d = disc;
                        break;
                    }
                bool eCurs = cbCurs.Text == "Da" ? true : false;
                Grupa g = new Grupa();
                //foreach(TreeNode node in tvGrupa.Nodes)
                //{
                //    if(node.Checked==true && !node.Text.ToString().StartsWith("Serie"))
                //    {
                //        foreach (Grupa gr in listaGrupe)
                //            if (gr.Cod == Convert.ToInt32(node.Text.Trim()))
                //            {
                //                g.Add(gr); 
                //            }
                //    }
                //}
                foreach (Grupa gr in listaGrupe)
                    if (gr.Cod == Convert.ToInt32(cbGrupa.Text.Trim()))
                    {
                        g = gr; break;
                    }
                Sala s = new Sala();
                foreach (Sala sala in listaSali)
                    if (sala.Cod == Convert.ToInt32(cbSala.Text.Trim()))
                    {
                        s = sala; break;
                    }

                int zi;
                switch (cbZi.Text)
                {
                    case "Luni": zi = 1; break;
                    case "Marti": zi = 2; break;
                    case "Miercuri": zi = 3; break;
                    case "Joi": zi = 4; break;
                    case "Vineri": zi = 5; break;
                    case "Sambata": zi = 6; break;
                    default: zi = 1; break;
                }
                int i = 1;
                if (cbOra.Text.Length > 4) i = 2;
                int ora = Convert.ToInt32(cbOra.Text.Substring(0, i));

                //string err = "";
                //Orar o = new Orar();
                //if (o.IsRoomClash(zi, ora, s.Cod) == true)
                //    errorProvider1.SetError(cbSala, "Sala nu este disponibila in acest interval orar!");
                //if (o.IsClassClash(zi, ora, g[0].Cod) == true)
                //    errorProvider1.SetError(cbGrupa, "Grupa are deja atribuita o alta lectie!");

                Lectie lectie = new Lectie(d, p, eCurs, s, g, zi, ora);

                //o.GrupaOrar[zi][ora][g[0].Cod] = lectie;
                //o.SalaOrar[zi][ora][s.Cod] = lectie;
                //o.ProfOrar[zi][ora][p.Cod] = lectie;
                //o.Discipline.Add(d);
                //o.Profesori.Add(p);
                //o.Sali.Add(s);
                //o.Grupe.Add(g[0]);


                foreach(Lectie lectieLista in lectii)
                {
                    if(lectieLista.Zi==lectie.Zi&&
                        lectieLista.Ora==lectie.Ora)
                    {
                        if (lectie.Profesor.Nume == lectieLista.Profesor.Nume) throw new MyException("Profesorul are deja o activitate programata acea ora!");
                        else if (lectieLista.Grupa.Cod == lectie.Grupa.Cod) throw new MyException("Grupa are deja o activitate programata la acea ora!");
                        else if (lectie.Sala.Cod == lectieLista.Sala.Cod) throw new MyException("Sala este deja ocupata cu o alta activitate!");
                    }
                    if(lectie.Grupa==lectieLista.Grupa&&
                        lectie.Disciplina==lectieLista.Disciplina)
                    {
                        if (lectie.ECurs == lectieLista.ECurs) throw new MyException("O grupa nu poate avea mai mult de un curs si seminar la aceeasi materie");
                    }
                    //if(lectie.Profesor==lectieLista.Profesor)
                    int ok = 0;
                    for (i = 0; i < lectie.Profesor.Discipline.Count(); i++)
                        if (lectie.Disciplina.Denumire == lectie.Profesor.Discipline[i])
                        { ok = 1; break; }
                    if (ok == 0) {
                        string discip = "";
                        for (i = 0; i < lectie.Profesor.Discipline.Count(); i++)
                            discip += lectie.Profesor.Discipline[i] + ", ";
                            throw new MyException("Profesorul nu preda aceasta disciplina!Preda doar " +discip+"!");
                    }

                }
                lectii.Add(lectie);

                //cbProf.Text = "";
                //cbDisciplina.Text = "";
                //cbCurs.Text = "";
                //cbGrupa.Text = "";
                //cbSala.Text = "";
                //cbZi.Text = "";
                //cbOra.Text = "";

                if(cbOrar.Text==""||comboBox1.Text=="")
                {
                    cbOrar.Text = "Profesor";
                    comboBox1.Text = lectie.Profesor.Nume;
                }
                button2_Click(sender, e);
            }
            catch(MyException ex)
            {
                MessageBox.Show(ex.Message);
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            
            
        }

        private void afiseazaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //AfisareListView frm = new AfisareListView(lectii);
            //frm.ShowDialog();
            Afisare frm = new Afisare(lectii);
            frm.Show();
        }

        private void cbOrar_SelectedIndexChanged(object sender, EventArgs e)
        {
            //ComboBox combo = (ComboBox)sender;
            //if(combo.SelectedText=="Profesor")
            if(cbOrar.Text=="Profesor")
            {
                comboBox1.Items.Clear();
                foreach (Profesor d in listaProfesori)
                {
                    comboBox1.Items.Add(d.Nume);
                }


            }
            else if(cbOrar.Text=="Grupa")
            {
                comboBox1.Items.Clear();
                foreach (Grupa d in listaGrupe)
                {
                    comboBox1.Items.Add(d.Cod);
                }
            }
            else if(cbOrar.Text=="Sala")
            {
                comboBox1.Items.Clear();
                foreach (Sala d in listaSali)
                {
                    comboBox1.Items.Add(d.Cod);
                }
            }
            comboBox1.Text = "";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                foreach (Control c in casute)
                { c.Text = ""; c.BackColor = Color.White; }
                if (cbOrar.Text == "")
                    errorProvider1.SetError(cbOrar, "Alegeti o optiune!");
                else if (comboBox1.Text == "")
                    errorProvider1.SetError(comboBox1, "Alegeti o optiune!");
                else
                {

                    if (cbOrar.Text == "Profesor")
                    {
                        foreach (Lectie l in lectii)
                        {
                            if (l.Profesor.Nume.ToString() == comboBox1.Text)
                            {
                                //int i = 1;
                                //if (l.Ora > 4) i = 2;
                                //int ora = Convert.ToInt32(cbOra.Text.Substring(0, i));
                                switch (l.Zi)
                                {
                                    case 1:
                                        switch (l.Ora)
                                        {
                                            case 8: { tb11.Text = "S" + l.Sala.Cod + ",G" + l.Grupa.Cod; tb11.BackColor = Color.DarkCyan; tb11.ForeColor = Color.White; break; }
                                            case 10: { tb12.Text = "S" + l.Sala.Cod + ",G" + l.Grupa.Cod; tb12.BackColor = Color.DarkCyan; tb12.ForeColor = Color.White; break; }
                                            case 12: { tb13.Text = "S" + l.Sala.Cod + ",G" + l.Grupa.Cod; tb13.BackColor = Color.DarkCyan; tb13.ForeColor = Color.White; break; }
                                            case 14: { tb14.Text = "S" + l.Sala.Cod + ",G" + l.Grupa.Cod; tb14.BackColor = Color.DarkCyan; tb14.ForeColor = Color.White; break; }
                                            case 16: { tb15.Text = "S" + l.Sala.Cod + ",G" + l.Grupa.Cod; tb15.BackColor = Color.DarkCyan; tb15.ForeColor = Color.White; break; }
                                            case 18: { tb16.Text = "S" + l.Sala.Cod + ",G" + l.Grupa.Cod; tb16.BackColor = Color.DarkCyan; tb16.ForeColor = Color.White; break; }
                                        }
                                        break;
                                    case 2:
                                        switch (l.Ora)
                                        {
                                            case 8: { tb21.Text = "S" + l.Sala.Cod + ",G" + l.Grupa.Cod; tb21.BackColor = Color.DarkCyan; tb21.ForeColor = Color.White; break; }
                                            case 10: { tb22.Text = "S" + l.Sala.Cod + ",G" + l.Grupa.Cod; tb22.BackColor = Color.DarkCyan; tb22.ForeColor = Color.White; break; }
                                            case 12: { tb23.Text = "S" + l.Sala.Cod + ",G" + l.Grupa.Cod; tb23.BackColor = Color.DarkCyan; tb23.ForeColor = Color.White; break; }
                                            case 14: { tb24.Text = "S" + l.Sala.Cod + ",G" + l.Grupa.Cod; tb24.BackColor = Color.DarkCyan; tb24.ForeColor = Color.White; break; }
                                            case 16: { tb25.Text = "S" + l.Sala.Cod + ",G" + l.Grupa.Cod; tb25.BackColor = Color.DarkCyan; tb25.ForeColor = Color.White; break; }
                                            case 18: { tb26.Text = "S" + l.Sala.Cod + ",G" + l.Grupa.Cod; tb26.BackColor = Color.White; tb26.ForeColor = Color.DarkCyan; break; }
                                        }
                                        break;
                                    case 3:
                                        switch (l.Ora)
                                        {
                                            case 8: { tb31.Text = "S" + l.Sala.Cod + ",G" + l.Grupa.Cod; tb31.BackColor = Color.DarkCyan; tb31.ForeColor = Color.White; break; }
                                            case 10: { tb32.Text = "S" + l.Sala.Cod + ",G" + l.Grupa.Cod; tb32.BackColor = Color.DarkCyan; tb32.ForeColor = Color.White; break; }
                                            case 12: { tb33.Text = "S" + l.Sala.Cod + ",G" + l.Grupa.Cod; tb33.BackColor = Color.DarkCyan; tb33.ForeColor = Color.White; break; }
                                            case 14: { tb34.Text = "S" + l.Sala.Cod + ",G" + l.Grupa.Cod; tb34.BackColor = Color.DarkCyan; tb34.ForeColor = Color.White; break; }
                                            case 16: { tb35.Text = "S" + l.Sala.Cod + ",G" + l.Grupa.Cod; tb35.BackColor = Color.DarkCyan; tb35.ForeColor = Color.White; break; }
                                            case 18: { tb36.Text = "S" + l.Sala.Cod + ",G" + l.Grupa.Cod; tb36.BackColor = Color.DarkCyan; tb36.ForeColor = Color.White; break; }
                                        }
                                        break;
                                    case 4:
                                        switch (l.Ora)
                                        {
                                            case 8: { tb41.Text = "S" + l.Sala.Cod + ",G" + l.Grupa.Cod; tb41.BackColor = Color.DarkCyan; tb41.ForeColor = Color.White; break; }
                                            case 10: { tb42.Text = "S" + l.Sala.Cod + ",G" + l.Grupa.Cod; tb42.BackColor = Color.DarkCyan; tb42.ForeColor = Color.White; break; }
                                            case 12: { tb43.Text = "S" + l.Sala.Cod + ",G" + l.Grupa.Cod; tb43.BackColor = Color.DarkCyan; tb43.ForeColor = Color.White; break; }
                                            case 14: { tb44.Text = "S" + l.Sala.Cod + ",G" + l.Grupa.Cod; tb44.BackColor = Color.DarkCyan; tb44.ForeColor = Color.White; break; }
                                            case 16: { tb45.Text = "S" + l.Sala.Cod + ",G" + l.Grupa.Cod; tb45.BackColor = Color.DarkCyan; tb45.ForeColor = Color.White; break; }
                                            case 18: { tb46.Text = "S" + l.Sala.Cod + ",G" + l.Grupa.Cod; tb46.BackColor = Color.DarkCyan; tb46.ForeColor = Color.White; break; }
                                        }
                                        break;
                                    case 5:
                                        switch (l.Ora)
                                        {
                                            case 8: { tb51.Text = "S" + l.Sala.Cod + ",G" + l.Grupa.Cod; tb51.BackColor = Color.DarkCyan; tb51.ForeColor = Color.White; break; }
                                            case 10: { tb52.Text = "S" + l.Sala.Cod + ",G" + l.Grupa.Cod; tb52.BackColor = Color.DarkCyan; tb52.ForeColor = Color.White; break; }
                                            case 12: { tb53.Text = "S" + l.Sala.Cod + ",G" + l.Grupa.Cod; tb53.BackColor = Color.DarkCyan; tb53.ForeColor = Color.White; break; }
                                            case 14: { tb54.Text = "S" + l.Sala.Cod + ",G" + l.Grupa.Cod; tb54.BackColor = Color.DarkCyan; tb54.ForeColor = Color.White; break; }
                                            case 16: { tb55.Text = "S" + l.Sala.Cod + ",G" + l.Grupa.Cod; tb55.BackColor = Color.DarkCyan; tb55.ForeColor = Color.White; break; }
                                            case 18: { tb56.Text = "S" + l.Sala.Cod + ",G" + l.Grupa.Cod; tb56.BackColor = Color.DarkCyan; tb56.ForeColor = Color.White; break; }
                                        }
                                        break;
                                    case 6:
                                        switch (l.Ora)
                                        {
                                            case 8: { tb61.Text = "S" + l.Sala.Cod + ",G" + l.Grupa.Cod; tb61.BackColor = Color.DarkCyan; tb61.ForeColor = Color.White; break; }
                                            case 10: { tb62.Text = "S" + l.Sala.Cod + ",G" + l.Grupa.Cod; tb62.BackColor = Color.DarkCyan; tb62.ForeColor = Color.White; break; }
                                            case 12: { tb63.Text = "S" + l.Sala.Cod + ",G" + l.Grupa.Cod; tb63.BackColor = Color.DarkCyan; tb63.ForeColor = Color.White; break; }
                                            case 14: { tb64.Text = "S" + l.Sala.Cod + ",G" + l.Grupa.Cod; tb64.BackColor = Color.DarkCyan; tb64.ForeColor = Color.White; break; }
                                            case 16: { tb65.Text = "S" + l.Sala.Cod + ",G" + l.Grupa.Cod; tb65.BackColor = Color.DarkCyan; tb65.ForeColor = Color.White; break; }
                                            case 18: { tb66.Text = "S" + l.Sala.Cod + ",G" + l.Grupa.Cod; tb66.BackColor = Color.DarkCyan; tb66.ForeColor = Color.White; break; }
                                        }
                                        break;

                                }
                            }
                        }
                    }
                    else if (cbOrar.Text == "Grupa")
                    {
                        foreach(Lectie l in lectii)
                        {
                            if (comboBox1.Text == l.Grupa.Cod.ToString())
                            {
                                switch (l.Zi)
                                {
                                    case 1:
                                        switch (l.Ora)
                                        {
                                            case 8: { tb11.Text = l.Disciplina.Denumire + ",S" + l.Sala.Cod; tb11.BackColor = Color.DarkOrchid;tb11.ForeColor = Color.White; break; }
                                            case 10: { tb12.Text = l.Disciplina.Denumire + ",S" + l.Sala.Cod; tb12.BackColor = Color.DarkOrchid; tb12.ForeColor = Color.White; break; }
                                            case 12: { tb13.Text = l.Disciplina.Denumire + ",S" + l.Sala.Cod; tb13.BackColor = Color.DarkOrchid; tb13.ForeColor = Color.White; break; }
                                            case 14: { tb14.Text = l.Disciplina.Denumire + ",S" + l.Sala.Cod; tb14.BackColor = Color.DarkOrchid; tb14.ForeColor = Color.White; break; }
                                            case 16: { tb15.Text = l.Disciplina.Denumire + ",S" + l.Sala.Cod; tb15.BackColor = Color.DarkOrchid; tb15.ForeColor = Color.White; break; }
                                            case 18: { tb16.Text = l.Disciplina.Denumire + ",S" + l.Sala.Cod; tb16.BackColor = Color.DarkOrchid; tb16.ForeColor = Color.White; break; }
                                        }
                                        break;
                                    case 2:
                                        switch (l.Ora)
                                        {
                                            case 8: { tb21.Text = l.Disciplina.Denumire + ",S" + l.Sala.Cod; tb21.BackColor = Color.DarkOrchid; tb21.ForeColor = Color.White; break; }
                                            case 10: { tb22.Text = l.Disciplina.Denumire + ",S" + l.Sala.Cod; tb22.BackColor = Color.DarkOrchid; tb22.ForeColor = Color.White; break; }
                                            case 12: { tb23.Text = l.Disciplina.Denumire + ",S" + l.Sala.Cod; tb23.BackColor = Color.DarkOrchid; tb23.ForeColor = Color.White; break; }
                                            case 14: { tb24.Text = l.Disciplina.Denumire + ",S" + l.Sala.Cod; tb24.BackColor = Color.DarkOrchid; tb24.ForeColor = Color.White; break; }
                                            case 16: { tb25.Text = l.Disciplina.Denumire + ",S" + l.Sala.Cod; tb25.BackColor = Color.DarkOrchid; tb25.ForeColor = Color.White; break; }
                                            case 18: { tb26.Text = l.Disciplina.Denumire + ",S" + l.Sala.Cod; tb26.BackColor = Color.DarkOrchid; tb26.ForeColor = Color.White; break; }
                                        }
                                        break;
                                    case 3:
                                        switch (l.Ora)
                                        {
                                            case 8: { tb31.Text = l.Disciplina.Denumire + ",S" + l.Sala.Cod; tb31.BackColor = Color.DarkOrchid; tb31.ForeColor = Color.White; break; }
                                            case 10: { tb32.Text = l.Disciplina.Denumire + ",S" + l.Sala.Cod; tb32.BackColor = Color.DarkOrchid; tb32.ForeColor = Color.White; break; }
                                            case 12: { tb33.Text = l.Disciplina.Denumire + ",S" + l.Sala.Cod; tb33.BackColor = Color.DarkOrchid; tb33.ForeColor = Color.White; break; }
                                            case 14: { tb34.Text = l.Disciplina.Denumire + ",S" + l.Sala.Cod; tb34.BackColor = Color.DarkOrchid; tb34.ForeColor = Color.White; break; }
                                            case 16: { tb35.Text = l.Disciplina.Denumire + ",S" + l.Sala.Cod; tb35.BackColor = Color.DarkOrchid; tb35.ForeColor = Color.White; break; }
                                            case 18: { tb36.Text = l.Disciplina.Denumire + ",S" + l.Sala.Cod; tb36.BackColor = Color.DarkOrchid; tb36.ForeColor = Color.White; break; }
                                        }
                                        break;
                                    case 4:
                                        switch (l.Ora)
                                        {
                                            case 8: { tb41.Text = l.Disciplina.Denumire + ",S" + l.Sala.Cod; tb41.BackColor = Color.DarkOrchid; tb41.ForeColor = Color.White; break; }
                                            case 10: { tb42.Text = l.Disciplina.Denumire + ",S" + l.Sala.Cod; tb42.BackColor = Color.DarkOrchid; tb42.ForeColor = Color.White; break; }
                                            case 12: { tb43.Text = l.Disciplina.Denumire + ",S" + l.Sala.Cod; tb43.BackColor = Color.DarkOrchid; tb43.ForeColor = Color.White; break; }
                                            case 14: { tb44.Text = l.Disciplina.Denumire + ",S" + l.Sala.Cod; tb44.BackColor = Color.DarkOrchid; tb44.ForeColor = Color.White; break; }
                                            case 16: { tb45.Text = l.Disciplina.Denumire + ",S" + l.Sala.Cod; tb45.BackColor = Color.DarkOrchid; tb45.ForeColor = Color.White; break; }
                                            case 18: { tb46.Text = l.Disciplina.Denumire + ",S" + l.Sala.Cod; tb46.BackColor = Color.DarkOrchid; tb46.ForeColor = Color.White; break; }
                                        }
                                        break;
                                    case 5:
                                        switch (l.Ora)
                                        {
                                            case 8: { tb51.Text = l.Disciplina.Denumire + ",S" + l.Sala.Cod; tb51.BackColor = Color.DarkOrchid; tb51.ForeColor = Color.White; break; }
                                            case 10: { tb52.Text = l.Disciplina.Denumire + ",S" + l.Sala.Cod; tb52.BackColor = Color.DarkOrchid; tb52.ForeColor = Color.White; break; }
                                            case 12: { tb53.Text = l.Disciplina.Denumire + ",S" + l.Sala.Cod; tb53.BackColor = Color.DarkOrchid; tb53.ForeColor = Color.White; break; }
                                            case 14: { tb54.Text = l.Disciplina.Denumire + ",S" + l.Sala.Cod; tb54.BackColor = Color.DarkOrchid; tb54.ForeColor = Color.White; break; }
                                            case 16: { tb55.Text = l.Disciplina.Denumire + ",S" + l.Sala.Cod; tb55.BackColor = Color.DarkOrchid; tb55.ForeColor = Color.White; break; }
                                            case 18: { tb56.Text = l.Disciplina.Denumire + ",S" + l.Sala.Cod; tb56.BackColor = Color.DarkOrchid; tb56.ForeColor = Color.White; break; }
                                        }
                                        break;
                                    case 6:
                                        switch (l.Ora)
                                        {
                                            case 8: { tb61.Text = l.Disciplina.Denumire + ",S" + l.Sala.Cod; tb61.BackColor = Color.DarkOrchid; tb61.ForeColor = Color.White; break; }
                                            case 10: { tb62.Text = l.Disciplina.Denumire + ",S" + l.Sala.Cod; tb62.BackColor = Color.DarkOrchid; tb62.ForeColor = Color.White; break; }
                                            case 12: { tb63.Text = l.Disciplina.Denumire + ",S" + l.Sala.Cod; tb63.BackColor = Color.DarkOrchid; tb63.ForeColor = Color.White; break; }
                                            case 14: { tb64.Text = l.Disciplina.Denumire + ",S" + l.Sala.Cod; tb64.BackColor = Color.DarkOrchid; tb64.ForeColor = Color.White; break; }
                                            case 16: { tb65.Text = l.Disciplina.Denumire + ",S" + l.Sala.Cod; tb65.BackColor = Color.DarkOrchid; tb65.ForeColor = Color.White; break; }
                                            case 18: { tb66.Text = l.Disciplina.Denumire + ",S" + l.Sala.Cod; tb66.BackColor = Color.DarkOrchid; tb66.ForeColor = Color.White; break; }
                                        }
                                        break;
                                }
                            }
                        }
                    }
                    else if(cbOrar.Text=="Sala")
                    {
                        foreach (Lectie l in lectii)
                        {
                            if (comboBox1.Text == l.Sala.Cod.ToString())
                            {
                                switch (l.Zi)
                                {
                                    case 1:
                                        switch (l.Ora)
                                        {
                                            case 8: { tb11.Text ="G"+ l.Grupa.Cod + "," + l.Profesor.Nume; tb11.BackColor = Color.DarkOrange; tb11.ForeColor = Color.White; break; }
                                            case 10: { tb12.Text ="G"+ l.Grupa.Cod + "," + l.Profesor.Nume; tb12.BackColor = Color.DarkOrange; tb12.ForeColor = Color.White; break; }
                                            case 12: { tb13.Text ="G"+ l.Grupa.Cod + "," + l.Profesor.Nume; tb13.BackColor = Color.DarkOrange; tb13.ForeColor = Color.White; break; }
                                            case 14: { tb14.Text ="G"+ l.Grupa.Cod + "," + l.Profesor.Nume; tb14.BackColor = Color.DarkOrange; tb14.ForeColor = Color.White; break; }
                                            case 16: { tb15.Text ="G"+ l.Grupa.Cod + "," + l.Profesor.Nume; tb15.BackColor = Color.DarkOrange; tb15.ForeColor = Color.White; break; }
                                            case 18: { tb16.Text ="G"+ l.Grupa.Cod + "," + l.Profesor.Nume; tb16.BackColor = Color.DarkOrange; tb16.ForeColor = Color.White; break; }
                                        }
                                        break;
                                    case 2:
                                        switch (l.Ora)
                                        {
                                            case 8: { tb21.Text ="G"+ l.Grupa.Cod + "," + l.Profesor.Nume; tb21.BackColor = Color.DarkOrange; tb21.ForeColor = Color.White; break; }
                                            case 10: { tb22.Text ="G"+ l.Grupa.Cod + "," + l.Profesor.Nume; tb22.BackColor = Color.DarkOrange; tb22.ForeColor = Color.White; break; }
                                            case 12: { tb23.Text ="G"+ l.Grupa.Cod + "," + l.Profesor.Nume; tb23.BackColor = Color.DarkOrange; tb23.ForeColor = Color.White; break; }
                                            case 14: { tb24.Text ="G"+ l.Grupa.Cod + "," + l.Profesor.Nume; tb24.BackColor = Color.DarkOrange; tb24.ForeColor = Color.White; break; }
                                            case 16: { tb25.Text ="G"+ l.Grupa.Cod + "," + l.Profesor.Nume; tb25.BackColor = Color.DarkOrange; tb25.ForeColor = Color.White; break; }
                                            case 18: { tb26.Text ="G"+ l.Grupa.Cod + "," + l.Profesor.Nume; tb26.BackColor = Color.DarkOrange; tb26.ForeColor = Color.White; break; }
                                        }
                                        break;
                                    case 3:
                                        switch (l.Ora)
                                        {
                                            case 8: { tb31.Text ="G"+ l.Grupa.Cod + "," + l.Profesor.Nume; tb31.BackColor = Color.DarkOrange; tb31.ForeColor = Color.White; break; }
                                            case 10: { tb32.Text ="G"+ l.Grupa.Cod + "," + l.Profesor.Nume; tb32.BackColor = Color.DarkOrange; tb32.ForeColor = Color.White; break; }
                                            case 12: { tb33.Text ="G"+ l.Grupa.Cod + "," + l.Profesor.Nume; tb33.BackColor = Color.DarkOrange; tb33.ForeColor = Color.White; break; }
                                            case 14: { tb34.Text ="G"+ l.Grupa.Cod + "," + l.Profesor.Nume; tb34.BackColor = Color.DarkOrange; tb34.ForeColor = Color.White; break; }
                                            case 16: { tb35.Text ="G"+ l.Grupa.Cod + "," + l.Profesor.Nume; tb35.BackColor = Color.DarkOrange; tb35.ForeColor = Color.White; break; }
                                            case 18: { tb36.Text ="G"+ l.Grupa.Cod + "," + l.Profesor.Nume; tb36.BackColor = Color.DarkOrange; tb36.ForeColor = Color.White; break; }
                                        }
                                        break;
                                    case 4:
                                        switch (l.Ora)
                                        {
                                            case 8: { tb41.Text ="G"+ l.Grupa.Cod + "," + l.Profesor.Nume; tb41.BackColor = Color.DarkOrange; tb41.ForeColor = Color.White; break; }
                                            case 10: { tb42.Text ="G"+ l.Grupa.Cod + "," + l.Profesor.Nume; tb42.BackColor = Color.DarkOrange; tb42.ForeColor = Color.White; break; }
                                            case 12: { tb43.Text ="G"+ l.Grupa.Cod + "," + l.Profesor.Nume; tb43.BackColor = Color.DarkOrange; tb43.ForeColor = Color.White; break; }
                                            case 14: { tb44.Text ="G"+ l.Grupa.Cod + "," + l.Profesor.Nume; tb44.BackColor = Color.DarkOrange; tb44.ForeColor = Color.White; break; }
                                            case 16: { tb45.Text ="G"+ l.Grupa.Cod + "," + l.Profesor.Nume; tb45.BackColor = Color.DarkOrange; tb45.ForeColor = Color.White; break; }
                                            case 18: { tb46.Text ="G"+ l.Grupa.Cod + "," + l.Profesor.Nume; tb46.BackColor = Color.DarkOrange; tb46.ForeColor = Color.White; break; }
                                        }
                                        break;
                                    case 5:
                                        switch (l.Ora)
                                        {
                                            case 8: { tb51.Text ="G"+ l.Grupa.Cod + "," + l.Profesor.Nume; tb51.BackColor = Color.DarkOrange; tb51.ForeColor = Color.White; break; }
                                            case 10: { tb52.Text ="G"+ l.Grupa.Cod + "," + l.Profesor.Nume; tb52.BackColor = Color.DarkOrange; tb52.ForeColor = Color.White; break; }
                                            case 12: { tb53.Text ="G"+ l.Grupa.Cod + "," + l.Profesor.Nume; tb53.BackColor = Color.DarkOrange; tb53.ForeColor = Color.White; break; }
                                            case 14: { tb54.Text ="G"+ l.Grupa.Cod + "," + l.Profesor.Nume; tb54.BackColor = Color.DarkOrange; tb54.ForeColor = Color.White; break; }
                                            case 16: { tb55.Text ="G"+ l.Grupa.Cod + "," + l.Profesor.Nume; tb55.BackColor = Color.DarkOrange; tb55.ForeColor = Color.White; break; }
                                            case 18: { tb56.Text ="G"+ l.Grupa.Cod + "," + l.Profesor.Nume; tb56.BackColor = Color.DarkOrange; tb56.ForeColor = Color.White; break; }
                                        }
                                        break;
                                    case 6:
                                        switch (l.Ora)
                                        {
                                            case 8: { tb61.Text ="G"+ l.Grupa.Cod + "," + l.Profesor.Nume; tb61.BackColor = Color.DarkOrange; tb61.ForeColor = Color.White; break; }
                                            case 10: { tb62.Text ="G"+ l.Grupa.Cod + "," + l.Profesor.Nume; tb62.BackColor = Color.DarkOrange; tb62.ForeColor = Color.White; break; }
                                            case 12: { tb63.Text ="G"+ l.Grupa.Cod + "," + l.Profesor.Nume; tb63.BackColor = Color.DarkOrange; tb63.ForeColor = Color.White; break; }
                                            case 14: { tb64.Text ="G"+ l.Grupa.Cod + "," + l.Profesor.Nume; tb64.BackColor = Color.DarkOrange; tb64.ForeColor = Color.White; break; }
                                            case 16: { tb65.Text ="G"+ l.Grupa.Cod + "," + l.Profesor.Nume; tb65.BackColor = Color.DarkOrange; tb65.ForeColor = Color.White; break; }
                                            case 18: { tb66.Text ="G"+ l.Grupa.Cod + "," + l.Profesor.Nume; tb66.BackColor = Color.DarkOrange; tb66.ForeColor = Color.White; break; }
                                        }
                                        break;
                                }
                            }
                        }
                    }

                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                cbProf.Text = "";
                cbDisciplina.Text = "";
                cbCurs.Text = "";
                cbGrupa.Text = "";
                cbSala.Text = "";
                cbZi.Text = "";
                cbOra.Text = "";
            }

        }

        private void button3_Click(object sender, EventArgs e)
        {
            SaveFileDialog dlg = new SaveFileDialog();
            dlg.Filter = "(*.txt)|*.txt";
            saveFileDialog1.Filter = "(*.txt)|*.txt";
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                StreamWriter sw = new StreamWriter(saveFileDialog1.FileName);
                foreach (Lectie d in lectii)
                {
                    sw.Write(d.Disciplina.Denumire);
                    sw.Write(",");
                    sw.Write(d.Profesor.Nume);
                    sw.Write(",");
                    sw.Write(d.ECurs?"Curs":"Seminar");
                    sw.Write(",");
                    sw.Write(d.Sala.Cod);
                    sw.Write(",");
                    sw.Write(d.Grupa.Cod);
                    sw.Write(",");
                    sw.Write(d.Zi);
                    sw.Write(",");
                    sw.Write(d.Ora);
                    sw.WriteLine();
                    //sw.Write(d.ToString());
                    //sw.WriteLine();
                }
                sw.Close();
                MessageBox.Show("Date salvate!");
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog();
            openFileDialog1.Filter = "(*.txt)|*.txt";
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                StreamReader sr = new StreamReader(openFileDialog1.FileName);
                while (!sr.EndOfStream)
                {
                    String linie = sr.ReadLine();
                    String[] v_str = linie.Split(',');
                    Disciplina disciplina = new Disciplina();
                    foreach (Disciplina disc in listaDiscipline)
                        if (disc.Denumire == v_str[0])
                        {
                            disciplina = disc;
                            break;
                        }
                    Profesor profesor = new Profesor();
                    foreach (Profesor prof in listaProfesori)
                        if (prof.Nume == v_str[1])
                        {
                            profesor = prof;
                            break;
                        }
                    bool eCurs = v_str[2] == "Curs" ? true : false;
                    Sala sala = new Sala();
                    foreach (Sala s in listaSali)
                        if (s.Cod == Convert.ToInt32(v_str[3].Trim()))
                        {
                            sala = s; break;
                        }
                    Grupa grupa = new Grupa();
                    foreach (Grupa gr in listaGrupe)
                        if (gr.Cod == Convert.ToInt32(v_str[4].Trim()))
                        {
                            grupa = gr; break;
                        }
                    int zi = Convert.ToInt32(v_str[5].Trim());
                    int ora = Convert.ToInt32(v_str[6].Trim());


                    Lectie d = new Lectie(disciplina, profesor, eCurs, sala, grupa, zi, ora);
                    lectii.Add(d);
                    //lista.Add(d);
                }
                sr.Close();
            }
        }

        private void cbCurs_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(cbCurs.Text=="Da")
            {
                cbSala.Items.Clear();
                foreach (Sala s in listaSali)
                {
                    if(s.Capacitate>=70)
                    cbSala.Items.Add(s.Cod);
                }
            }
            else
            {
                cbSala.Items.Clear();
                foreach (Sala s in listaSali)
                {
                    if (s.Capacitate < 70)
                        cbSala.Items.Add(s.Cod);
                }
            }
        }

        private void cbProf_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(cbProf.Text!="")
            {
                cbDisciplina.Items.Clear();
                foreach(Profesor p in listaProfesori)
                {
                    if(p.Nume==cbProf.Text)
                    {
                        for (int i = 0; i < p.Discipline.Length; i++)
                            cbDisciplina.Items.Add(p.Discipline[i]);
                        break;
                    }
                }
            }
        }

        private void tb11_Click(object sender, EventArgs e)
        {
            cbProf.Text = "";
            cbDisciplina.Text = "";
            cbCurs.Text = "";
            cbGrupa.Text = "";
            cbSala.Text = "";
            cbZi.Text = cbZi.Items[0].ToString();
            cbOra.Text = cbOra.Items[0].ToString();
            if (cbOrar.Text != "")
            {
                switch (cbOrar.Text)
                {
                    case "Profesor":
                        if (comboBox1.Text != "") cbProf.Text = comboBox1.Text;
                        if (tb11.Text != "")
                        {
                            foreach (Lectie l in lectii)
                                if (l.Profesor.Nume == comboBox1.Text && l.Zi == 1 && l.Ora == 8)
                                {
                                    cbDisciplina.Text = l.Disciplina.Denumire;
                                    cbCurs.Text = l.ECurs == true ? "Da" : "Nu";
                                    cbGrupa.Text = l.Grupa.Cod.ToString();
                                    cbSala.Text = l.Sala.Cod.ToString();
                                }
                        }
                        break;
                    case "Grupa":
                        if (comboBox1.Text != "") cbGrupa.Text = comboBox1.Text;
                        if (tb11.Text != "")
                        {
                            foreach (Lectie l in lectii)
                                if (l.Grupa.Cod.ToString() == comboBox1.Text && l.Zi == 1 && l.Ora == 8)
                                {
                                    cbDisciplina.Text = l.Disciplina.Denumire;
                                    cbCurs.Text = l.ECurs == true ? "Da" : "Nu";
                                    cbProf.Text = l.Profesor.Nume;
                                    cbSala.Text = l.Sala.Cod.ToString();
                                }
                        }
                        break;
                    case "Sala":
                        if (comboBox1.Text != "") cbSala.Text = comboBox1.Text;
                        if (tb11.Text != "")
                        {
                            foreach (Lectie l in lectii)
                                if (l.Sala.Cod.ToString() == comboBox1.Text && l.Zi == 1 && l.Ora == 8)
                                {
                                    cbDisciplina.Text = l.Disciplina.Denumire;
                                    cbCurs.Text = l.ECurs == true ? "Da" : "Nu";
                                    cbGrupa.Text = l.Grupa.Cod.ToString();
                                    cbProf.Text = l.Profesor.Nume;
                                }
                        }
                        break;
                }

            }
        }

        private void tb12_Click(object sender, EventArgs e)
        {
            cbProf.Text = "";
            cbDisciplina.Text = "";
            cbCurs.Text = "";
            cbGrupa.Text = "";
            cbSala.Text = "";
            cbZi.Text = cbZi.Items[0].ToString();
            cbOra.Text = cbOra.Items[1].ToString();
            if (cbOrar.Text != "")
            {
                switch (cbOrar.Text)
                {
                    case "Profesor":
                        if (comboBox1.Text != "") cbProf.Text = comboBox1.Text;
                        if (tb12.Text != "")
                        {
                            foreach (Lectie l in lectii)
                                if (l.Profesor.Nume == comboBox1.Text && l.Zi == 1 && l.Ora == 10)
                                {
                                    cbDisciplina.Text = l.Disciplina.Denumire;
                                    cbCurs.Text = l.ECurs == true ? "Da" : "Nu";
                                    cbGrupa.Text = l.Grupa.Cod.ToString();
                                    cbSala.Text = l.Sala.Cod.ToString();
                                }
                        }
                        break;
                    case "Grupa":
                        if (comboBox1.Text != "") cbGrupa.Text = comboBox1.Text;
                        if (tb12.Text != "")
                        {
                            foreach (Lectie l in lectii)
                                if (l.Grupa.Cod.ToString() == comboBox1.Text && l.Zi == 1 && l.Ora == 10)
                                {
                                    cbDisciplina.Text = l.Disciplina.Denumire;
                                    cbCurs.Text = l.ECurs == true ? "Da" : "Nu";
                                    cbProf.Text = l.Profesor.Nume;
                                    cbSala.Text = l.Sala.Cod.ToString();
                                }
                        }
                        break;
                    case "Sala":
                        if (comboBox1.Text != "") cbSala.Text = comboBox1.Text;
                        if (tb12.Text != "")
                        {
                            foreach (Lectie l in lectii)
                                if (l.Sala.Cod.ToString() == comboBox1.Text && l.Zi == 1 && l.Ora == 10)
                                {
                                    cbDisciplina.Text = l.Disciplina.Denumire;
                                    cbCurs.Text = l.ECurs == true ? "Da" : "Nu";
                                    cbGrupa.Text = l.Grupa.Cod.ToString();
                                    cbProf.Text = l.Profesor.Nume;
                                }
                        }
                        break;
                }

            }
        }

        private void tb13_Click(object sender, EventArgs e)
        {
            cbProf.Text = "";
            cbDisciplina.Text = "";
            cbCurs.Text = "";
            cbGrupa.Text = "";
            cbSala.Text = "";
            cbZi.Text = cbZi.Items[0].ToString();
            cbOra.Text = cbOra.Items[2].ToString();
            if (cbOrar.Text != "")
            {
                switch (cbOrar.Text)
                {
                    case "Profesor":
                        if (comboBox1.Text != "") cbProf.Text = comboBox1.Text;
                        if (tb13.Text != "")
                        {
                            foreach (Lectie l in lectii)
                                if (l.Profesor.Nume == comboBox1.Text && l.Zi == 1 && l.Ora == 12)
                                {
                                    cbDisciplina.Text = l.Disciplina.Denumire;
                                    cbCurs.Text = l.ECurs == true ? "Da" : "Nu";
                                    cbGrupa.Text = l.Grupa.Cod.ToString();
                                    cbSala.Text = l.Sala.Cod.ToString();
                                }
                        }
                        break;
                    case "Grupa":
                        if (comboBox1.Text != "") cbGrupa.Text = comboBox1.Text;
                        if (tb13.Text != "")
                        {
                            foreach (Lectie l in lectii)
                                if (l.Grupa.Cod.ToString() == comboBox1.Text && l.Zi == 1 && l.Ora == 12)
                                {
                                    cbDisciplina.Text = l.Disciplina.Denumire;
                                    cbCurs.Text = l.ECurs == true ? "Da" : "Nu";
                                    cbProf.Text = l.Profesor.Nume;
                                    cbSala.Text = l.Sala.Cod.ToString();
                                }
                        }
                        break;
                    case "Sala":
                        if (comboBox1.Text != "") cbSala.Text = comboBox1.Text;
                        if (tb13.Text != "")
                        {
                            foreach (Lectie l in lectii)
                                if (l.Sala.Cod.ToString() == comboBox1.Text && l.Zi == 1 && l.Ora == 12)
                                {
                                    cbDisciplina.Text = l.Disciplina.Denumire;
                                    cbCurs.Text = l.ECurs == true ? "Da" : "Nu";
                                    cbGrupa.Text = l.Grupa.Cod.ToString();
                                    cbProf.Text = l.Profesor.Nume;
                                }
                        }
                        break;
                }

            }
        }

        private void tb14_Click(object sender, EventArgs e)
        {
            cbProf.Text = "";
            cbDisciplina.Text = "";
            cbCurs.Text = "";
            cbGrupa.Text = "";
            cbSala.Text = "";
            cbZi.Text = cbZi.Items[0].ToString();
            cbOra.Text = cbOra.Items[3].ToString();
            if (cbOrar.Text != "")
            {
                switch (cbOrar.Text)
                {
                    case "Profesor":
                        if (comboBox1.Text != "") cbProf.Text = comboBox1.Text;
                        if (tb14.Text != "")
                        {
                            foreach (Lectie l in lectii)
                                if (l.Profesor.Nume == comboBox1.Text && l.Zi == 1 && l.Ora == 14)
                                {
                                    cbDisciplina.Text = l.Disciplina.Denumire;
                                    cbCurs.Text = l.ECurs == true ? "Da" : "Nu";
                                    cbGrupa.Text = l.Grupa.Cod.ToString();
                                    cbSala.Text = l.Sala.Cod.ToString();
                                }
                        }
                        break;
                    case "Grupa":
                        if (comboBox1.Text != "") cbGrupa.Text = comboBox1.Text;
                        if (tb14.Text != "")
                        {
                            foreach (Lectie l in lectii)
                                if (l.Grupa.Cod.ToString() == comboBox1.Text && l.Zi == 1 && l.Ora == 14)
                                {
                                    cbDisciplina.Text = l.Disciplina.Denumire;
                                    cbCurs.Text = l.ECurs == true ? "Da" : "Nu";
                                    cbProf.Text = l.Profesor.Nume;
                                    cbSala.Text = l.Sala.Cod.ToString();
                                }
                        }
                        break;
                    case "Sala":
                        if (comboBox1.Text != "") cbSala.Text = comboBox1.Text;
                        if (tb14.Text != "")
                        {
                            foreach (Lectie l in lectii)
                                if (l.Sala.Cod.ToString() == comboBox1.Text && l.Zi == 1 && l.Ora == 14)
                                {
                                    cbDisciplina.Text = l.Disciplina.Denumire;
                                    cbCurs.Text = l.ECurs == true ? "Da" : "Nu";
                                    cbGrupa.Text = l.Grupa.Cod.ToString();
                                    cbProf.Text = l.Profesor.Nume;
                                }
                        }
                        break;
                }

            }
        }

        private void tb15_Click(object sender, EventArgs e)
        {
            cbProf.Text = "";
            cbDisciplina.Text = "";
            cbCurs.Text = "";
            cbGrupa.Text = "";
            cbSala.Text = "";
            cbZi.Text = cbZi.Items[0].ToString();
            cbOra.Text = cbOra.Items[4].ToString();
            if (cbOrar.Text != "")
            {
                switch (cbOrar.Text)
                {
                    case "Profesor":
                        if (comboBox1.Text != "") cbProf.Text = comboBox1.Text;
                        if (tb15.Text != "")
                        {
                            foreach (Lectie l in lectii)
                                if (l.Profesor.Nume == comboBox1.Text && l.Zi == 1 && l.Ora == 16)
                                {
                                    cbDisciplina.Text = l.Disciplina.Denumire;
                                    cbCurs.Text = l.ECurs == true ? "Da" : "Nu";
                                    cbGrupa.Text = l.Grupa.Cod.ToString();
                                    cbSala.Text = l.Sala.Cod.ToString();
                                }
                        }
                        break;
                    case "Grupa":
                        if (comboBox1.Text != "") cbGrupa.Text = comboBox1.Text;
                        if (tb15.Text != "")
                        {
                            foreach (Lectie l in lectii)
                                if (l.Grupa.Cod.ToString() == comboBox1.Text && l.Zi == 1 && l.Ora == 16)
                                {
                                    cbDisciplina.Text = l.Disciplina.Denumire;
                                    cbCurs.Text = l.ECurs == true ? "Da" : "Nu";
                                    cbProf.Text = l.Profesor.Nume;
                                    cbSala.Text = l.Sala.Cod.ToString();
                                }
                        }
                        break;
                    case "Sala":
                        if (comboBox1.Text != "") cbSala.Text = comboBox1.Text;
                        if (tb15.Text != "")
                        {
                            foreach (Lectie l in lectii)
                                if (l.Sala.Cod.ToString() == comboBox1.Text && l.Zi == 1 && l.Ora == 16)
                                {
                                    cbDisciplina.Text = l.Disciplina.Denumire;
                                    cbCurs.Text = l.ECurs == true ? "Da" : "Nu";
                                    cbGrupa.Text = l.Grupa.Cod.ToString();
                                    cbProf.Text = l.Profesor.Nume;
                                }
                        }
                        break;
                }

            }

        }

        private void tb16_Click(object sender, EventArgs e)
        {
            cbProf.Text = "";
            cbDisciplina.Text = "";
            cbCurs.Text = "";
            cbGrupa.Text = "";
            cbSala.Text = "";
            cbZi.Text = cbZi.Items[0].ToString();
            cbOra.Text = cbOra.Items[5].ToString();
            if (cbOrar.Text != "")
            {
                switch (cbOrar.Text)
                {
                    case "Profesor":
                        if (comboBox1.Text != "") cbProf.Text = comboBox1.Text;
                        if (tb16.Text != "")
                        {
                            foreach (Lectie l in lectii)
                                if (l.Profesor.Nume == comboBox1.Text && l.Zi == 1 && l.Ora == 18)
                                {
                                    cbDisciplina.Text = l.Disciplina.Denumire;
                                    cbCurs.Text = l.ECurs == true ? "Da" : "Nu";
                                    cbGrupa.Text = l.Grupa.Cod.ToString();
                                    cbSala.Text = l.Sala.Cod.ToString();
                                }
                        }
                        break;
                    case "Grupa":
                        if (comboBox1.Text != "") cbGrupa.Text = comboBox1.Text;
                        if (tb16.Text != "")
                        {
                            foreach (Lectie l in lectii)
                                if (l.Grupa.Cod.ToString() == comboBox1.Text && l.Zi == 1 && l.Ora == 18)
                                {
                                    cbDisciplina.Text = l.Disciplina.Denumire;
                                    cbCurs.Text = l.ECurs == true ? "Da" : "Nu";
                                    cbProf.Text = l.Profesor.Nume;
                                    cbSala.Text = l.Sala.Cod.ToString();
                                }
                        }
                        break;
                    case "Sala":
                        if (comboBox1.Text != "") cbSala.Text = comboBox1.Text;
                        if (tb16.Text != "")
                        {
                            foreach (Lectie l in lectii)
                                if (l.Sala.Cod.ToString() == comboBox1.Text && l.Zi == 1 && l.Ora == 18)
                                {
                                    cbDisciplina.Text = l.Disciplina.Denumire;
                                    cbCurs.Text = l.ECurs == true ? "Da" : "Nu";
                                    cbGrupa.Text = l.Grupa.Cod.ToString();
                                    cbProf.Text = l.Profesor.Nume;
                                }
                        }
                        break;
                }

            }

        }

        private void tb21_Click(object sender, EventArgs e)
        {
            cbProf.Text = "";
            cbDisciplina.Text = "";
            cbCurs.Text = "";
            cbGrupa.Text = "";
            cbSala.Text = "";
            cbZi.Text = cbZi.Items[1].ToString();
            cbOra.Text = cbOra.Items[0].ToString();
            if (cbOrar.Text != "")
            {
                switch (cbOrar.Text)
                {
                    case "Profesor":
                        if (comboBox1.Text != "") cbProf.Text = comboBox1.Text;
                        if (tb21.Text != "")
                        {
                            foreach (Lectie l in lectii)
                                if (l.Profesor.Nume == comboBox1.Text && l.Zi == 2 && l.Ora == 8)
                                {
                                    cbDisciplina.Text = l.Disciplina.Denumire;
                                    cbCurs.Text = l.ECurs == true ? "Da" : "Nu";
                                    cbGrupa.Text = l.Grupa.Cod.ToString();
                                    cbSala.Text = l.Sala.Cod.ToString();
                                }
                        }
                        break;
                    case "Grupa":
                        if (comboBox1.Text != "") cbGrupa.Text = comboBox1.Text;
                        if (tb21.Text != "")
                        {
                            foreach (Lectie l in lectii)
                                if (l.Grupa.Cod.ToString() == comboBox1.Text && l.Zi == 2 && l.Ora == 8)
                                {
                                    cbDisciplina.Text = l.Disciplina.Denumire;
                                    cbCurs.Text = l.ECurs == true ? "Da" : "Nu";
                                    cbProf.Text = l.Profesor.Nume;
                                    cbSala.Text = l.Sala.Cod.ToString();
                                }
                        }
                        break;
                    case "Sala":
                        if (comboBox1.Text != "") cbSala.Text = comboBox1.Text;
                        if (tb21.Text != "")
                        {
                            foreach (Lectie l in lectii)
                                if (l.Sala.Cod.ToString() == comboBox1.Text && l.Zi == 2 && l.Ora == 8)
                                {
                                    cbDisciplina.Text = l.Disciplina.Denumire;
                                    cbCurs.Text = l.ECurs == true ? "Da" : "Nu";
                                    cbGrupa.Text = l.Grupa.Cod.ToString();
                                    cbProf.Text = l.Profesor.Nume;
                                }
                        }
                        break;
                }

            }

        }

        private void tb22_Click(object sender, EventArgs e)
        {
            cbProf.Text = "";
            cbDisciplina.Text = "";
            cbCurs.Text = "";
            cbGrupa.Text = "";
            cbSala.Text = "";
            cbZi.Text = cbZi.Items[1].ToString();
            cbOra.Text = cbOra.Items[1].ToString();
            if (cbOrar.Text != "")
            {
                switch (cbOrar.Text)
                {
                    case "Profesor":
                        if (comboBox1.Text != "") cbProf.Text = comboBox1.Text;
                        if (tb22.Text != "")
                        {
                            foreach (Lectie l in lectii)
                                if (l.Profesor.Nume == comboBox1.Text && l.Zi == 2 && l.Ora == 10)
                                {
                                    cbDisciplina.Text = l.Disciplina.Denumire;
                                    cbCurs.Text = l.ECurs == true ? "Da" : "Nu";
                                    cbGrupa.Text = l.Grupa.Cod.ToString();
                                    cbSala.Text = l.Sala.Cod.ToString();
                                }
                        }
                        break;
                    case "Grupa":
                        if (comboBox1.Text != "") cbGrupa.Text = comboBox1.Text;
                        if (tb22.Text != "")
                        {
                            foreach (Lectie l in lectii)
                                if (l.Grupa.Cod.ToString() == comboBox1.Text && l.Zi == 2 && l.Ora == 10)
                                {
                                    cbDisciplina.Text = l.Disciplina.Denumire;
                                    cbCurs.Text = l.ECurs == true ? "Da" : "Nu";
                                    cbProf.Text = l.Profesor.Nume;
                                    cbSala.Text = l.Sala.Cod.ToString();
                                }
                        }
                        break;
                    case "Sala":
                        if (comboBox1.Text != "") cbSala.Text = comboBox1.Text;
                        if (tb22.Text != "")
                        {
                            foreach (Lectie l in lectii)
                                if (l.Sala.Cod.ToString() == comboBox1.Text && l.Zi == 2 && l.Ora == 10)
                                {
                                    cbDisciplina.Text = l.Disciplina.Denumire;
                                    cbCurs.Text = l.ECurs == true ? "Da" : "Nu";
                                    cbGrupa.Text = l.Grupa.Cod.ToString();
                                    cbProf.Text = l.Profesor.Nume;
                                }
                        }
                        break;
                }

            }

        }

        private void tb23_Click(object sender, EventArgs e)
        {
            cbProf.Text = "";
            cbDisciplina.Text = "";
            cbCurs.Text = "";
            cbGrupa.Text = "";
            cbSala.Text = "";
            cbZi.Text = cbZi.Items[1].ToString();
            cbOra.Text = cbOra.Items[2].ToString();
            if (cbOrar.Text != "")
            {
                switch (cbOrar.Text)
                {
                    case "Profesor":
                        if (comboBox1.Text != "") cbProf.Text = comboBox1.Text;
                        if (tb23.Text != "")
                        {
                            foreach (Lectie l in lectii)
                                if (l.Profesor.Nume == comboBox1.Text && l.Zi == 2 && l.Ora == 12)
                                {
                                    cbDisciplina.Text = l.Disciplina.Denumire;
                                    cbCurs.Text = l.ECurs == true ? "Da" : "Nu";
                                    cbGrupa.Text = l.Grupa.Cod.ToString();
                                    cbSala.Text = l.Sala.Cod.ToString();
                                }
                        }
                        break;
                    case "Grupa":
                        if (comboBox1.Text != "") cbGrupa.Text = comboBox1.Text;
                        if (tb23.Text != "")
                        {
                            foreach (Lectie l in lectii)
                                if (l.Grupa.Cod.ToString() == comboBox1.Text && l.Zi == 2 && l.Ora == 12)
                                {
                                    cbDisciplina.Text = l.Disciplina.Denumire;
                                    cbCurs.Text = l.ECurs == true ? "Da" : "Nu";
                                    cbProf.Text = l.Profesor.Nume;
                                    cbSala.Text = l.Sala.Cod.ToString();
                                }
                        }
                        break;
                    case "Sala":
                        if (comboBox1.Text != "") cbSala.Text = comboBox1.Text;
                        if (tb23.Text != "")
                        {
                            foreach (Lectie l in lectii)
                                if (l.Sala.Cod.ToString() == comboBox1.Text && l.Zi == 2 && l.Ora == 12)
                                {
                                    cbDisciplina.Text = l.Disciplina.Denumire;
                                    cbCurs.Text = l.ECurs == true ? "Da" : "Nu";
                                    cbGrupa.Text = l.Grupa.Cod.ToString();
                                    cbProf.Text = l.Profesor.Nume;
                                }
                        }
                        break;
                }

            }

        }

        private void tb24_Click(object sender, EventArgs e)
        {
            cbProf.Text = "";
            cbDisciplina.Text = "";
            cbCurs.Text = "";
            cbGrupa.Text = "";
            cbSala.Text = "";
            cbZi.Text = cbZi.Items[1].ToString();
            cbOra.Text = cbOra.Items[3].ToString();
            if (cbOrar.Text != "")
            {
                switch (cbOrar.Text)
                {
                    case "Profesor":
                        if (comboBox1.Text != "") cbProf.Text = comboBox1.Text;
                        if (tb24.Text != "")
                        {
                            foreach (Lectie l in lectii)
                                if (l.Profesor.Nume == comboBox1.Text && l.Zi == 2 && l.Ora == 14)
                                {
                                    cbDisciplina.Text = l.Disciplina.Denumire;
                                    cbCurs.Text = l.ECurs == true ? "Da" : "Nu";
                                    cbGrupa.Text = l.Grupa.Cod.ToString();
                                    cbSala.Text = l.Sala.Cod.ToString();
                                }
                        }
                        break;
                    case "Grupa":
                        if (comboBox1.Text != "") cbGrupa.Text = comboBox1.Text;
                        if (tb24.Text != "")
                        {
                            foreach (Lectie l in lectii)
                                if (l.Grupa.Cod.ToString() == comboBox1.Text && l.Zi == 2 && l.Ora == 14)
                                {
                                    cbDisciplina.Text = l.Disciplina.Denumire;
                                    cbCurs.Text = l.ECurs == true ? "Da" : "Nu";
                                    cbProf.Text = l.Profesor.Nume;
                                    cbSala.Text = l.Sala.Cod.ToString();
                                }
                        }
                        break;
                    case "Sala":
                        if (comboBox1.Text != "") cbSala.Text = comboBox1.Text;
                        if (tb24.Text != "")
                        {
                            foreach (Lectie l in lectii)
                                if (l.Sala.Cod.ToString() == comboBox1.Text && l.Zi == 2 && l.Ora == 14)
                                {
                                    cbDisciplina.Text = l.Disciplina.Denumire;
                                    cbCurs.Text = l.ECurs == true ? "Da" : "Nu";
                                    cbGrupa.Text = l.Grupa.Cod.ToString();
                                    cbProf.Text = l.Profesor.Nume;
                                }
                        }
                        break;
                }
            }            
        }

        private void tb25_Click(object sender, EventArgs e)
        {
            cbProf.Text = "";
            cbDisciplina.Text = "";
            cbCurs.Text = "";
            cbGrupa.Text = "";
            cbSala.Text = "";
            cbZi.Text = cbZi.Items[1].ToString();
            cbOra.Text = cbOra.Items[4].ToString();
            if (cbOrar.Text != "")
            {
                switch (cbOrar.Text)
                {
                    case "Profesor":
                        if (comboBox1.Text != "") cbProf.Text = comboBox1.Text;
                        if (tb25.Text != "")
                        {
                            foreach (Lectie l in lectii)
                                if (l.Profesor.Nume == comboBox1.Text && l.Zi == 2 && l.Ora == 16)
                                {
                                    cbDisciplina.Text = l.Disciplina.Denumire;
                                    cbCurs.Text = l.ECurs == true ? "Da" : "Nu";
                                    cbGrupa.Text = l.Grupa.Cod.ToString();
                                    cbSala.Text = l.Sala.Cod.ToString();
                                }
                        }
                        break;
                    case "Grupa":
                        if (comboBox1.Text != "") cbGrupa.Text = comboBox1.Text;
                        if (tb25.Text != "")
                        {
                            foreach (Lectie l in lectii)
                                if (l.Grupa.Cod.ToString() == comboBox1.Text && l.Zi == 2 && l.Ora == 16)
                                {
                                    cbDisciplina.Text = l.Disciplina.Denumire;
                                    cbCurs.Text = l.ECurs == true ? "Da" : "Nu";
                                    cbProf.Text = l.Profesor.Nume;
                                    cbSala.Text = l.Sala.Cod.ToString();
                                }
                        }
                        break;
                    case "Sala":
                        if (comboBox1.Text != "") cbSala.Text = comboBox1.Text;
                        if (tb25.Text != "")
                        {
                            foreach (Lectie l in lectii)
                                if (l.Sala.Cod.ToString() == comboBox1.Text && l.Zi == 2 && l.Ora == 16)
                                {
                                    cbDisciplina.Text = l.Disciplina.Denumire;
                                    cbCurs.Text = l.ECurs == true ? "Da" : "Nu";
                                    cbGrupa.Text = l.Grupa.Cod.ToString();
                                    cbProf.Text = l.Profesor.Nume;
                                }
                        }
                        break;
                }
            }
        }

        private void tb26_Click(object sender, EventArgs e)
        {
            cbProf.Text = "";
            cbDisciplina.Text = "";
            cbCurs.Text = "";
            cbGrupa.Text = "";
            cbSala.Text = "";
            cbZi.Text = cbZi.Items[1].ToString();
            cbOra.Text = cbOra.Items[5].ToString();
            if (cbOrar.Text != "")
            {
                switch (cbOrar.Text)
                {
                    case "Profesor":
                        if (comboBox1.Text != "") cbProf.Text = comboBox1.Text;
                        if (tb26.Text != "")
                        {
                            foreach (Lectie l in lectii)
                                if (l.Profesor.Nume == comboBox1.Text && l.Zi == 2 && l.Ora == 18)
                                {
                                    cbDisciplina.Text = l.Disciplina.Denumire;
                                    cbCurs.Text = l.ECurs == true ? "Da" : "Nu";
                                    cbGrupa.Text = l.Grupa.Cod.ToString();
                                    cbSala.Text = l.Sala.Cod.ToString();
                                }
                        }
                        break;
                    case "Grupa":
                        if (comboBox1.Text != "") cbGrupa.Text = comboBox1.Text;
                        if (tb26.Text != "")
                        {
                            foreach (Lectie l in lectii)
                                if (l.Grupa.Cod.ToString() == comboBox1.Text && l.Zi == 2 && l.Ora == 18)
                                {
                                    cbDisciplina.Text = l.Disciplina.Denumire;
                                    cbCurs.Text = l.ECurs == true ? "Da" : "Nu";
                                    cbProf.Text = l.Profesor.Nume;
                                    cbSala.Text = l.Sala.Cod.ToString();
                                }
                        }
                        break;
                    case "Sala":
                        if (comboBox1.Text != "") cbSala.Text = comboBox1.Text;
                        if (tb26.Text != "")
                        {
                            foreach (Lectie l in lectii)
                                if (l.Sala.Cod.ToString() == comboBox1.Text && l.Zi == 2 && l.Ora == 18)
                                {
                                    cbDisciplina.Text = l.Disciplina.Denumire;
                                    cbCurs.Text = l.ECurs == true ? "Da" : "Nu";
                                    cbGrupa.Text = l.Grupa.Cod.ToString();
                                    cbProf.Text = l.Profesor.Nume;
                                }
                        }
                        break;
                }
            }
        }

        private void tb31_Click(object sender, EventArgs e)
        {
            cbProf.Text = "";
            cbDisciplina.Text = "";
            cbCurs.Text = "";
            cbGrupa.Text = "";
            cbSala.Text = "";
            cbZi.Text = cbZi.Items[2].ToString();
            cbOra.Text = cbOra.Items[0].ToString();
            if (cbOrar.Text != "")
            {
                switch (cbOrar.Text)
                {
                    case "Profesor":
                        if (comboBox1.Text != "") cbProf.Text = comboBox1.Text;
                        if (tb31.Text != "")
                        {
                            foreach (Lectie l in lectii)
                                if (l.Profesor.Nume == comboBox1.Text && l.Zi == 3 && l.Ora == 8)
                                {
                                    cbDisciplina.Text = l.Disciplina.Denumire;
                                    cbCurs.Text = l.ECurs == true ? "Da" : "Nu";
                                    cbGrupa.Text = l.Grupa.Cod.ToString();
                                    cbSala.Text = l.Sala.Cod.ToString();
                                }
                        }
                        break;
                    case "Grupa":
                        if (comboBox1.Text != "") cbGrupa.Text = comboBox1.Text;
                        if (tb31.Text != "")
                        {
                            foreach (Lectie l in lectii)
                                if (l.Grupa.Cod.ToString() == comboBox1.Text && l.Zi == 3 && l.Ora == 8)
                                {
                                    cbDisciplina.Text = l.Disciplina.Denumire;
                                    cbCurs.Text = l.ECurs == true ? "Da" : "Nu";
                                    cbProf.Text = l.Profesor.Nume;
                                    cbSala.Text = l.Sala.Cod.ToString();
                                }
                        }
                        break;
                    case "Sala":
                        if (comboBox1.Text != "") cbSala.Text = comboBox1.Text;
                        if (tb31.Text != "")
                        {
                            foreach (Lectie l in lectii)
                                if (l.Sala.Cod.ToString() == comboBox1.Text && l.Zi == 3 && l.Ora == 8)
                                {
                                    cbDisciplina.Text = l.Disciplina.Denumire;
                                    cbCurs.Text = l.ECurs == true ? "Da" : "Nu";
                                    cbGrupa.Text = l.Grupa.Cod.ToString();
                                    cbProf.Text = l.Profesor.Nume;
                                }
                        }
                        break;
                }
            }
        }

        private void tb32_Click(object sender, EventArgs e)
        {
            cbProf.Text = "";
            cbDisciplina.Text = "";
            cbCurs.Text = "";
            cbGrupa.Text = "";
            cbSala.Text = "";
            cbZi.Text = cbZi.Items[2].ToString();
            cbOra.Text = cbOra.Items[1].ToString();
            if (cbOrar.Text != "")
            {
                switch (cbOrar.Text)
                {
                    case "Profesor":
                        if (comboBox1.Text != "") cbProf.Text = comboBox1.Text;
                        if (tb32.Text != "")
                        {
                            foreach (Lectie l in lectii)
                                if (l.Profesor.Nume == comboBox1.Text && l.Zi == 3 && l.Ora == 10)
                                {
                                    cbDisciplina.Text = l.Disciplina.Denumire;
                                    cbCurs.Text = l.ECurs == true ? "Da" : "Nu";
                                    cbGrupa.Text = l.Grupa.Cod.ToString();
                                    cbSala.Text = l.Sala.Cod.ToString();
                                }
                        }
                        break;
                    case "Grupa":
                        if (comboBox1.Text != "") cbGrupa.Text = comboBox1.Text;
                        if (tb32.Text != "")
                        {
                            foreach (Lectie l in lectii)
                                if (l.Grupa.Cod.ToString() == comboBox1.Text && l.Zi == 3 && l.Ora == 10)
                                {
                                    cbDisciplina.Text = l.Disciplina.Denumire;
                                    cbCurs.Text = l.ECurs == true ? "Da" : "Nu";
                                    cbProf.Text = l.Profesor.Nume;
                                    cbSala.Text = l.Sala.Cod.ToString();
                                }
                        }
                        break;
                    case "Sala":
                        if (comboBox1.Text != "") cbSala.Text = comboBox1.Text;
                        if (tb32.Text != "")
                        {
                            foreach (Lectie l in lectii)
                                if (l.Sala.Cod.ToString() == comboBox1.Text && l.Zi == 3 && l.Ora == 10)
                                {
                                    cbDisciplina.Text = l.Disciplina.Denumire;
                                    cbCurs.Text = l.ECurs == true ? "Da" : "Nu";
                                    cbGrupa.Text = l.Grupa.Cod.ToString();
                                    cbProf.Text = l.Profesor.Nume;
                                }
                        }
                        break;
                }
            }
        }

        private void tb33_Click(object sender, EventArgs e)
        {
            cbProf.Text = "";
            cbDisciplina.Text = "";
            cbCurs.Text = "";
            cbGrupa.Text = "";
            cbSala.Text = "";
            cbZi.Text = cbZi.Items[2].ToString();
            cbOra.Text = cbOra.Items[2].ToString();
            if (cbOrar.Text != "")
            {
                switch (cbOrar.Text)
                {
                    case "Profesor":
                        if (comboBox1.Text != "") cbProf.Text = comboBox1.Text;
                        if (tb33.Text != "")
                        {
                            foreach (Lectie l in lectii)
                                if (l.Profesor.Nume == comboBox1.Text && l.Zi == 3 && l.Ora == 12)
                                {
                                    cbDisciplina.Text = l.Disciplina.Denumire;
                                    cbCurs.Text = l.ECurs == true ? "Da" : "Nu";
                                    cbGrupa.Text = l.Grupa.Cod.ToString();
                                    cbSala.Text = l.Sala.Cod.ToString();
                                }
                        }
                        break;
                    case "Grupa":
                        if (comboBox1.Text != "") cbGrupa.Text = comboBox1.Text;
                        if (tb33.Text != "")
                        {
                            foreach (Lectie l in lectii)
                                if (l.Grupa.Cod.ToString() == comboBox1.Text && l.Zi == 3 && l.Ora == 12)
                                {
                                    cbDisciplina.Text = l.Disciplina.Denumire;
                                    cbCurs.Text = l.ECurs == true ? "Da" : "Nu";
                                    cbProf.Text = l.Profesor.Nume;
                                    cbSala.Text = l.Sala.Cod.ToString();
                                }
                        }
                        break;
                    case "Sala":
                        if (comboBox1.Text != "") cbSala.Text = comboBox1.Text;
                        if (tb33.Text != "")
                        {
                            foreach (Lectie l in lectii)
                                if (l.Sala.Cod.ToString() == comboBox1.Text && l.Zi == 3 && l.Ora == 12)
                                {
                                    cbDisciplina.Text = l.Disciplina.Denumire;
                                    cbCurs.Text = l.ECurs == true ? "Da" : "Nu";
                                    cbGrupa.Text = l.Grupa.Cod.ToString();
                                    cbProf.Text = l.Profesor.Nume;
                                }
                        }
                        break;
                }
            }
        }

        private void tb34_Click(object sender, EventArgs e)
        {
            cbProf.Text = "";
            cbDisciplina.Text = "";
            cbCurs.Text = "";
            cbGrupa.Text = "";
            cbSala.Text = "";
            cbZi.Text = cbZi.Items[2].ToString();
            cbOra.Text = cbOra.Items[3].ToString();
            if (cbOrar.Text != "")
            {
                switch (cbOrar.Text)
                {
                    case "Profesor":
                        if (comboBox1.Text != "") cbProf.Text = comboBox1.Text;
                        if (tb34.Text != "")
                        {
                            foreach (Lectie l in lectii)
                                if (l.Profesor.Nume == comboBox1.Text && l.Zi == 3 && l.Ora == 14)
                                {
                                    cbDisciplina.Text = l.Disciplina.Denumire;
                                    cbCurs.Text = l.ECurs == true ? "Da" : "Nu";
                                    cbGrupa.Text = l.Grupa.Cod.ToString();
                                    cbSala.Text = l.Sala.Cod.ToString();
                                }
                        }
                        break;
                    case "Grupa":
                        if (comboBox1.Text != "") cbGrupa.Text = comboBox1.Text;
                        if (tb34.Text != "")
                        {
                            foreach (Lectie l in lectii)
                                if (l.Grupa.Cod.ToString() == comboBox1.Text && l.Zi == 3 && l.Ora == 14)
                                {
                                    cbDisciplina.Text = l.Disciplina.Denumire;
                                    cbCurs.Text = l.ECurs == true ? "Da" : "Nu";
                                    cbProf.Text = l.Profesor.Nume;
                                    cbSala.Text = l.Sala.Cod.ToString();
                                }
                        }
                        break;
                    case "Sala":
                        if (comboBox1.Text != "") cbSala.Text = comboBox1.Text;
                        if (tb34.Text != "")
                        {
                            foreach (Lectie l in lectii)
                                if (l.Sala.Cod.ToString() == comboBox1.Text && l.Zi == 3 && l.Ora == 14)
                                {
                                    cbDisciplina.Text = l.Disciplina.Denumire;
                                    cbCurs.Text = l.ECurs == true ? "Da" : "Nu";
                                    cbGrupa.Text = l.Grupa.Cod.ToString();
                                    cbProf.Text = l.Profesor.Nume;
                                }
                        }
                        break;
                }
            }
        }

        private void tb35_Click(object sender, EventArgs e)
        {
            cbProf.Text = "";
            cbDisciplina.Text = "";
            cbCurs.Text = "";
            cbGrupa.Text = "";
            cbSala.Text = "";
            cbZi.Text = cbZi.Items[2].ToString();
            cbOra.Text = cbOra.Items[4].ToString();
            if (cbOrar.Text != "")
            {
                switch (cbOrar.Text)
                {
                    case "Profesor":
                        if (comboBox1.Text != "") cbProf.Text = comboBox1.Text;
                        if (tb35.Text != "")
                        {
                            foreach (Lectie l in lectii)
                                if (l.Profesor.Nume == comboBox1.Text && l.Zi == 3 && l.Ora == 16)
                                {
                                    cbDisciplina.Text = l.Disciplina.Denumire;
                                    cbCurs.Text = l.ECurs == true ? "Da" : "Nu";
                                    cbGrupa.Text = l.Grupa.Cod.ToString();
                                    cbSala.Text = l.Sala.Cod.ToString();
                                }
                        }
                        break;
                    case "Grupa":
                        if (comboBox1.Text != "") cbGrupa.Text = comboBox1.Text;
                        if (tb35.Text != "")
                        {
                            foreach (Lectie l in lectii)
                                if (l.Grupa.Cod.ToString() == comboBox1.Text && l.Zi == 3 && l.Ora == 16)
                                {
                                    cbDisciplina.Text = l.Disciplina.Denumire;
                                    cbCurs.Text = l.ECurs == true ? "Da" : "Nu";
                                    cbProf.Text = l.Profesor.Nume;
                                    cbSala.Text = l.Sala.Cod.ToString();
                                }
                        }
                        break;
                    case "Sala":
                        if (comboBox1.Text != "") cbSala.Text = comboBox1.Text;
                        if (tb35.Text != "")
                        {
                            foreach (Lectie l in lectii)
                                if (l.Sala.Cod.ToString() == comboBox1.Text && l.Zi == 3 && l.Ora == 16)
                                {
                                    cbDisciplina.Text = l.Disciplina.Denumire;
                                    cbCurs.Text = l.ECurs == true ? "Da" : "Nu";
                                    cbGrupa.Text = l.Grupa.Cod.ToString();
                                    cbProf.Text = l.Profesor.Nume;
                                }
                        }
                        break;
                }
            }
        }

        private void tb36_Click(object sender, EventArgs e)
        {
            cbProf.Text = "";
            cbDisciplina.Text = "";
            cbCurs.Text = "";
            cbGrupa.Text = "";
            cbSala.Text = "";
            cbZi.Text = cbZi.Items[2].ToString();
            cbOra.Text = cbOra.Items[5].ToString();
            if (cbOrar.Text != "")
            {
                switch (cbOrar.Text)
                {
                    case "Profesor":
                        if (comboBox1.Text != "") cbProf.Text = comboBox1.Text;
                        if (tb36.Text != "")
                        {
                            foreach (Lectie l in lectii)
                                if (l.Profesor.Nume == comboBox1.Text && l.Zi == 3 && l.Ora == 18)
                                {
                                    cbDisciplina.Text = l.Disciplina.Denumire;
                                    cbCurs.Text = l.ECurs == true ? "Da" : "Nu";
                                    cbGrupa.Text = l.Grupa.Cod.ToString();
                                    cbSala.Text = l.Sala.Cod.ToString();
                                }
                        }
                        break;
                    case "Grupa":
                        if (comboBox1.Text != "") cbGrupa.Text = comboBox1.Text;
                        if (tb36.Text != "")
                        {
                            foreach (Lectie l in lectii)
                                if (l.Grupa.Cod.ToString() == comboBox1.Text && l.Zi == 3 && l.Ora == 18)
                                {
                                    cbDisciplina.Text = l.Disciplina.Denumire;
                                    cbCurs.Text = l.ECurs == true ? "Da" : "Nu";
                                    cbProf.Text = l.Profesor.Nume;
                                    cbSala.Text = l.Sala.Cod.ToString();
                                }
                        }
                        break;
                    case "Sala":
                        if (comboBox1.Text != "") cbSala.Text = comboBox1.Text;
                        if (tb36.Text != "")
                        {
                            foreach (Lectie l in lectii)
                                if (l.Sala.Cod.ToString() == comboBox1.Text && l.Zi == 3 && l.Ora == 18)
                                {
                                    cbDisciplina.Text = l.Disciplina.Denumire;
                                    cbCurs.Text = l.ECurs == true ? "Da" : "Nu";
                                    cbGrupa.Text = l.Grupa.Cod.ToString();
                                    cbProf.Text = l.Profesor.Nume;
                                }
                        }
                        break;
                }
            }
        }

        private void tb41_Click(object sender, EventArgs e)
        {
            cbProf.Text = "";
            cbDisciplina.Text = "";
            cbCurs.Text = "";
            cbGrupa.Text = "";
            cbSala.Text = "";
            cbZi.Text = cbZi.Items[3].ToString();
            cbOra.Text = cbOra.Items[0].ToString();
            if (cbOrar.Text != "")
            {
                switch (cbOrar.Text)
                {
                    case "Profesor":
                        if (comboBox1.Text != "") cbProf.Text = comboBox1.Text;
                        if (tb41.Text != "")
                        {
                            foreach (Lectie l in lectii)
                                if (l.Profesor.Nume == comboBox1.Text && l.Zi == 4 && l.Ora == 8)
                                {
                                    cbDisciplina.Text = l.Disciplina.Denumire;
                                    cbCurs.Text = l.ECurs == true ? "Da" : "Nu";
                                    cbGrupa.Text = l.Grupa.Cod.ToString();
                                    cbSala.Text = l.Sala.Cod.ToString();
                                }
                        }
                        break;
                    case "Grupa":
                        if (comboBox1.Text != "") cbGrupa.Text = comboBox1.Text;
                        if (tb41.Text != "")
                        {
                            foreach (Lectie l in lectii)
                                if (l.Grupa.Cod.ToString() == comboBox1.Text && l.Zi == 4 && l.Ora == 8)
                                {
                                    cbDisciplina.Text = l.Disciplina.Denumire;
                                    cbCurs.Text = l.ECurs == true ? "Da" : "Nu";
                                    cbProf.Text = l.Profesor.Nume;
                                    cbSala.Text = l.Sala.Cod.ToString();
                                }
                        }
                        break;
                    case "Sala":
                        if (comboBox1.Text != "") cbSala.Text = comboBox1.Text;
                        if (tb41.Text != "")
                        {
                            foreach (Lectie l in lectii)
                                if (l.Sala.Cod.ToString() == comboBox1.Text && l.Zi == 4 && l.Ora == 8)
                                {
                                    cbDisciplina.Text = l.Disciplina.Denumire;
                                    cbCurs.Text = l.ECurs == true ? "Da" : "Nu";
                                    cbGrupa.Text = l.Grupa.Cod.ToString();
                                    cbProf.Text = l.Profesor.Nume;
                                }
                        }
                        break;
                }
            }
        }

        private void tb42_Click(object sender, EventArgs e)
        {
            cbProf.Text = "";
            cbDisciplina.Text = "";
            cbCurs.Text = "";
            cbGrupa.Text = "";
            cbSala.Text = "";
            cbZi.Text = cbZi.Items[3].ToString();
            cbOra.Text = cbOra.Items[1].ToString();
            if (cbOrar.Text != "")
            {
                switch (cbOrar.Text)
                {
                    case "Profesor":
                        if (comboBox1.Text != "") cbProf.Text = comboBox1.Text;
                        if (tb42.Text != "")
                        {
                            foreach (Lectie l in lectii)
                                if (l.Profesor.Nume == comboBox1.Text && l.Zi == 4 && l.Ora == 10)
                                {
                                    cbDisciplina.Text = l.Disciplina.Denumire;
                                    cbCurs.Text = l.ECurs == true ? "Da" : "Nu";
                                    cbGrupa.Text = l.Grupa.Cod.ToString();
                                    cbSala.Text = l.Sala.Cod.ToString();
                                }
                        }
                        break;
                    case "Grupa":
                        if (comboBox1.Text != "") cbGrupa.Text = comboBox1.Text;
                        if (tb42.Text != "")
                        {
                            foreach (Lectie l in lectii)
                                if (l.Grupa.Cod.ToString() == comboBox1.Text && l.Zi == 4 && l.Ora == 10)
                                {
                                    cbDisciplina.Text = l.Disciplina.Denumire;
                                    cbCurs.Text = l.ECurs == true ? "Da" : "Nu";
                                    cbProf.Text = l.Profesor.Nume;
                                    cbSala.Text = l.Sala.Cod.ToString();
                                }
                        }
                        break;
                    case "Sala":
                        if (comboBox1.Text != "") cbSala.Text = comboBox1.Text;
                        if (tb42.Text != "")
                        {
                            foreach (Lectie l in lectii)
                                if (l.Sala.Cod.ToString() == comboBox1.Text && l.Zi == 4 && l.Ora == 10)
                                {
                                    cbDisciplina.Text = l.Disciplina.Denumire;
                                    cbCurs.Text = l.ECurs == true ? "Da" : "Nu";
                                    cbGrupa.Text = l.Grupa.Cod.ToString();
                                    cbProf.Text = l.Profesor.Nume;
                                }
                        }
                        break;
                }
            }
        }

        private void tb43_Click(object sender, EventArgs e)
        {
            cbProf.Text = "";
            cbDisciplina.Text = "";
            cbCurs.Text = "";
            cbGrupa.Text = "";
            cbSala.Text = "";
            cbZi.Text = cbZi.Items[3].ToString();
            cbOra.Text = cbOra.Items[2].ToString();
            if (cbOrar.Text != "")
            {
                switch (cbOrar.Text)
                {
                    case "Profesor":
                        if (comboBox1.Text != "") cbProf.Text = comboBox1.Text;
                        if (tb43.Text != "")
                        {
                            foreach (Lectie l in lectii)
                                if (l.Profesor.Nume == comboBox1.Text && l.Zi == 4 && l.Ora == 12)
                                {
                                    cbDisciplina.Text = l.Disciplina.Denumire;
                                    cbCurs.Text = l.ECurs == true ? "Da" : "Nu";
                                    cbGrupa.Text = l.Grupa.Cod.ToString();
                                    cbSala.Text = l.Sala.Cod.ToString();
                                }
                        }
                        break;
                    case "Grupa":
                        if (comboBox1.Text != "") cbGrupa.Text = comboBox1.Text;
                        if (tb43.Text != "")
                        {
                            foreach (Lectie l in lectii)
                                if (l.Grupa.Cod.ToString() == comboBox1.Text && l.Zi == 4 && l.Ora == 12)
                                {
                                    cbDisciplina.Text = l.Disciplina.Denumire;
                                    cbCurs.Text = l.ECurs == true ? "Da" : "Nu";
                                    cbProf.Text = l.Profesor.Nume;
                                    cbSala.Text = l.Sala.Cod.ToString();
                                }
                        }
                        break;
                    case "Sala":
                        if (comboBox1.Text != "") cbSala.Text = comboBox1.Text;
                        if (tb43.Text != "")
                        {
                            foreach (Lectie l in lectii)
                                if (l.Sala.Cod.ToString() == comboBox1.Text && l.Zi == 4 && l.Ora == 12)
                                {
                                    cbDisciplina.Text = l.Disciplina.Denumire;
                                    cbCurs.Text = l.ECurs == true ? "Da" : "Nu";
                                    cbGrupa.Text = l.Grupa.Cod.ToString();
                                    cbProf.Text = l.Profesor.Nume;
                                }
                        }
                        break;
                }
            }
        }

        private void tb44_Click(object sender, EventArgs e)
        {
            cbProf.Text = "";
            cbDisciplina.Text = "";
            cbCurs.Text = "";
            cbGrupa.Text = "";
            cbSala.Text = "";
            cbZi.Text = cbZi.Items[3].ToString();
            cbOra.Text = cbOra.Items[3].ToString();
            if (cbOrar.Text != "")
            {
                switch (cbOrar.Text)
                {
                    case "Profesor":
                        if (comboBox1.Text != "") cbProf.Text = comboBox1.Text;
                        if (tb44.Text != "")
                        {
                            foreach (Lectie l in lectii)
                                if (l.Profesor.Nume == comboBox1.Text && l.Zi == 4 && l.Ora == 14)
                                {
                                    cbDisciplina.Text = l.Disciplina.Denumire;
                                    cbCurs.Text = l.ECurs == true ? "Da" : "Nu";
                                    cbGrupa.Text = l.Grupa.Cod.ToString();
                                    cbSala.Text = l.Sala.Cod.ToString();
                                }
                        }
                        break;
                    case "Grupa":
                        if (comboBox1.Text != "") cbGrupa.Text = comboBox1.Text;
                        if (tb44.Text != "")
                        {
                            foreach (Lectie l in lectii)
                                if (l.Grupa.Cod.ToString() == comboBox1.Text && l.Zi == 4 && l.Ora == 14)
                                {
                                    cbDisciplina.Text = l.Disciplina.Denumire;
                                    cbCurs.Text = l.ECurs == true ? "Da" : "Nu";
                                    cbProf.Text = l.Profesor.Nume;
                                    cbSala.Text = l.Sala.Cod.ToString();
                                }
                        }
                        break;
                    case "Sala":
                        if (comboBox1.Text != "") cbSala.Text = comboBox1.Text;
                        if (tb44.Text != "")
                        {
                            foreach (Lectie l in lectii)
                                if (l.Sala.Cod.ToString() == comboBox1.Text && l.Zi == 4 && l.Ora == 14)
                                {
                                    cbDisciplina.Text = l.Disciplina.Denumire;
                                    cbCurs.Text = l.ECurs == true ? "Da" : "Nu";
                                    cbGrupa.Text = l.Grupa.Cod.ToString();
                                    cbProf.Text = l.Profesor.Nume;
                                }
                        }
                        break;
                }
            }
        }

        private void tb45_Click(object sender, EventArgs e)
        {
            cbProf.Text = "";
            cbDisciplina.Text = "";
            cbCurs.Text = "";
            cbGrupa.Text = "";
            cbSala.Text = "";
            cbZi.Text = cbZi.Items[3].ToString();
            cbOra.Text = cbOra.Items[4].ToString();
            if (cbOrar.Text != "")
            {
                switch (cbOrar.Text)
                {
                    case "Profesor":
                        if (comboBox1.Text != "") cbProf.Text = comboBox1.Text;
                        if (tb45.Text != "")
                        {
                            foreach (Lectie l in lectii)
                                if (l.Profesor.Nume == comboBox1.Text && l.Zi == 4 && l.Ora == 16)
                                {
                                    cbDisciplina.Text = l.Disciplina.Denumire;
                                    cbCurs.Text = l.ECurs == true ? "Da" : "Nu";
                                    cbGrupa.Text = l.Grupa.Cod.ToString();
                                    cbSala.Text = l.Sala.Cod.ToString();
                                }
                        }
                        break;
                    case "Grupa":
                        if (comboBox1.Text != "") cbGrupa.Text = comboBox1.Text;
                        if (tb45.Text != "")
                        {
                            foreach (Lectie l in lectii)
                                if (l.Grupa.Cod.ToString() == comboBox1.Text && l.Zi == 4 && l.Ora == 16)
                                {
                                    cbDisciplina.Text = l.Disciplina.Denumire;
                                    cbCurs.Text = l.ECurs == true ? "Da" : "Nu";
                                    cbProf.Text = l.Profesor.Nume;
                                    cbSala.Text = l.Sala.Cod.ToString();
                                }
                        }
                        break;
                    case "Sala":
                        if (comboBox1.Text != "") cbSala.Text = comboBox1.Text;
                        if (tb45.Text != "")
                        {
                            foreach (Lectie l in lectii)
                                if (l.Sala.Cod.ToString() == comboBox1.Text && l.Zi == 4 && l.Ora == 16)
                                {
                                    cbDisciplina.Text = l.Disciplina.Denumire;
                                    cbCurs.Text = l.ECurs == true ? "Da" : "Nu";
                                    cbGrupa.Text = l.Grupa.Cod.ToString();
                                    cbProf.Text = l.Profesor.Nume;
                                }
                        }
                        break;
                }
            }
        }

        private void tb46_Click(object sender, EventArgs e)
        {
            cbProf.Text = "";
            cbDisciplina.Text = "";
            cbCurs.Text = "";
            cbGrupa.Text = "";
            cbSala.Text = "";
            cbZi.Text = cbZi.Items[3].ToString();
            cbOra.Text = cbOra.Items[5].ToString();
            if (cbOrar.Text != "")
            {
                switch (cbOrar.Text)
                {
                    case "Profesor":
                        if (comboBox1.Text != "") cbProf.Text = comboBox1.Text;
                        if (tb46.Text != "")
                        {
                            foreach (Lectie l in lectii)
                                if (l.Profesor.Nume == comboBox1.Text && l.Zi == 4 && l.Ora == 18)
                                {
                                    cbDisciplina.Text = l.Disciplina.Denumire;
                                    cbCurs.Text = l.ECurs == true ? "Da" : "Nu";
                                    cbGrupa.Text = l.Grupa.Cod.ToString();
                                    cbSala.Text = l.Sala.Cod.ToString();
                                }
                        }
                        break;
                    case "Grupa":
                        if (comboBox1.Text != "") cbGrupa.Text = comboBox1.Text;
                        if (tb46.Text != "")
                        {
                            foreach (Lectie l in lectii)
                                if (l.Grupa.Cod.ToString() == comboBox1.Text && l.Zi == 4 && l.Ora == 18)
                                {
                                    cbDisciplina.Text = l.Disciplina.Denumire;
                                    cbCurs.Text = l.ECurs == true ? "Da" : "Nu";
                                    cbProf.Text = l.Profesor.Nume;
                                    cbSala.Text = l.Sala.Cod.ToString();
                                }
                        }
                        break;
                    case "Sala":
                        if (comboBox1.Text != "") cbSala.Text = comboBox1.Text;
                        if (tb46.Text != "")
                        {
                            foreach (Lectie l in lectii)
                                if (l.Sala.Cod.ToString() == comboBox1.Text && l.Zi == 4 && l.Ora == 18)
                                {
                                    cbDisciplina.Text = l.Disciplina.Denumire;
                                    cbCurs.Text = l.ECurs == true ? "Da" : "Nu";
                                    cbGrupa.Text = l.Grupa.Cod.ToString();
                                    cbProf.Text = l.Profesor.Nume;
                                }
                        }
                        break;
                }
            }
        }

        private void tb51_Click(object sender, EventArgs e)
        {
            cbProf.Text = "";
            cbDisciplina.Text = "";
            cbCurs.Text = "";
            cbGrupa.Text = "";
            cbSala.Text = "";
            cbZi.Text = cbZi.Items[4].ToString();
            cbOra.Text = cbOra.Items[0].ToString();
            if (cbOrar.Text != "")
            {
                switch (cbOrar.Text)
                {
                    case "Profesor":
                        if (comboBox1.Text != "") cbProf.Text = comboBox1.Text;
                        if (tb51.Text != "")
                        {
                            foreach (Lectie l in lectii)
                                if (l.Profesor.Nume == comboBox1.Text && l.Zi == 5 && l.Ora == 8)
                                {
                                    cbDisciplina.Text = l.Disciplina.Denumire;
                                    cbCurs.Text = l.ECurs == true ? "Da" : "Nu";
                                    cbGrupa.Text = l.Grupa.Cod.ToString();
                                    cbSala.Text = l.Sala.Cod.ToString();
                                }
                        }
                        break;
                    case "Grupa":
                        if (comboBox1.Text != "") cbGrupa.Text = comboBox1.Text;
                        if (tb51.Text != "")
                        {
                            foreach (Lectie l in lectii)
                                if (l.Grupa.Cod.ToString() == comboBox1.Text && l.Zi == 5 && l.Ora == 8)
                                {
                                    cbDisciplina.Text = l.Disciplina.Denumire;
                                    cbCurs.Text = l.ECurs == true ? "Da" : "Nu";
                                    cbProf.Text = l.Profesor.Nume;
                                    cbSala.Text = l.Sala.Cod.ToString();
                                }
                        }
                        break;
                    case "Sala":
                        if (comboBox1.Text != "") cbSala.Text = comboBox1.Text;
                        if (tb51.Text != "")
                        {
                            foreach (Lectie l in lectii)
                                if (l.Sala.Cod.ToString() == comboBox1.Text && l.Zi == 5 && l.Ora == 8)
                                {
                                    cbDisciplina.Text = l.Disciplina.Denumire;
                                    cbCurs.Text = l.ECurs == true ? "Da" : "Nu";
                                    cbGrupa.Text = l.Grupa.Cod.ToString();
                                    cbProf.Text = l.Profesor.Nume;
                                }
                        }
                        break;
                }
            }
        }

        private void tb52_Click(object sender, EventArgs e)
        {
            cbProf.Text = "";
            cbDisciplina.Text = "";
            cbCurs.Text = "";
            cbGrupa.Text = "";
            cbSala.Text = "";
            cbZi.Text = cbZi.Items[4].ToString();
            cbOra.Text = cbOra.Items[1].ToString();
            if (cbOrar.Text != "")
            {
                switch (cbOrar.Text)
                {
                    case "Profesor":
                        if (comboBox1.Text != "") cbProf.Text = comboBox1.Text;
                        if (tb52.Text != "")
                        {
                            foreach (Lectie l in lectii)
                                if (l.Profesor.Nume == comboBox1.Text && l.Zi == 5 && l.Ora == 10)
                                {
                                    cbDisciplina.Text = l.Disciplina.Denumire;
                                    cbCurs.Text = l.ECurs == true ? "Da" : "Nu";
                                    cbGrupa.Text = l.Grupa.Cod.ToString();
                                    cbSala.Text = l.Sala.Cod.ToString();
                                }
                        }
                        break;
                    case "Grupa":
                        if (comboBox1.Text != "") cbGrupa.Text = comboBox1.Text;
                        if (tb52.Text != "")
                        {
                            foreach (Lectie l in lectii)
                                if (l.Grupa.Cod.ToString() == comboBox1.Text && l.Zi == 5 && l.Ora == 10)
                                {
                                    cbDisciplina.Text = l.Disciplina.Denumire;
                                    cbCurs.Text = l.ECurs == true ? "Da" : "Nu";
                                    cbProf.Text = l.Profesor.Nume;
                                    cbSala.Text = l.Sala.Cod.ToString();
                                }
                        }
                        break;
                    case "Sala":
                        if (comboBox1.Text != "") cbSala.Text = comboBox1.Text;
                        if (tb52.Text != "")
                        {
                            foreach (Lectie l in lectii)
                                if (l.Sala.Cod.ToString() == comboBox1.Text && l.Zi == 5 && l.Ora == 10)
                                {
                                    cbDisciplina.Text = l.Disciplina.Denumire;
                                    cbCurs.Text = l.ECurs == true ? "Da" : "Nu";
                                    cbGrupa.Text = l.Grupa.Cod.ToString();
                                    cbProf.Text = l.Profesor.Nume;
                                }
                        }
                        break;
                }
            }
        }

        private void tb53_Click(object sender, EventArgs e)
        {
            cbProf.Text = "";
            cbDisciplina.Text = "";
            cbCurs.Text = "";
            cbGrupa.Text = "";
            cbSala.Text = "";
            cbZi.Text = cbZi.Items[4].ToString();
            cbOra.Text = cbOra.Items[2].ToString();
            if (cbOrar.Text != "")
            {
                switch (cbOrar.Text)
                {
                    case "Profesor":
                        if (comboBox1.Text != "") cbProf.Text = comboBox1.Text;
                        if (tb53.Text != "")
                        {
                            foreach (Lectie l in lectii)
                                if (l.Profesor.Nume == comboBox1.Text && l.Zi == 5 && l.Ora == 12)
                                {
                                    cbDisciplina.Text = l.Disciplina.Denumire;
                                    cbCurs.Text = l.ECurs == true ? "Da" : "Nu";
                                    cbGrupa.Text = l.Grupa.Cod.ToString();
                                    cbSala.Text = l.Sala.Cod.ToString();
                                }
                        }
                        break;
                    case "Grupa":
                        if (comboBox1.Text != "") cbGrupa.Text = comboBox1.Text;
                        if (tb53.Text != "")
                        {
                            foreach (Lectie l in lectii)
                                if (l.Grupa.Cod.ToString() == comboBox1.Text && l.Zi == 5 && l.Ora == 12)
                                {
                                    cbDisciplina.Text = l.Disciplina.Denumire;
                                    cbCurs.Text = l.ECurs == true ? "Da" : "Nu";
                                    cbProf.Text = l.Profesor.Nume;
                                    cbSala.Text = l.Sala.Cod.ToString();
                                }
                        }
                        break;
                    case "Sala":
                        if (comboBox1.Text != "") cbSala.Text = comboBox1.Text;
                        if (tb53.Text != "")
                        {
                            foreach (Lectie l in lectii)
                                if (l.Sala.Cod.ToString() == comboBox1.Text && l.Zi == 5 && l.Ora == 12)
                                {
                                    cbDisciplina.Text = l.Disciplina.Denumire;
                                    cbCurs.Text = l.ECurs == true ? "Da" : "Nu";
                                    cbGrupa.Text = l.Grupa.Cod.ToString();
                                    cbProf.Text = l.Profesor.Nume;
                                }
                        }
                        break;
                }
            }
        }

        private void tb54_Click(object sender, EventArgs e)
        {
            cbProf.Text = "";
            cbDisciplina.Text = "";
            cbCurs.Text = "";
            cbGrupa.Text = "";
            cbSala.Text = "";
            cbZi.Text = cbZi.Items[4].ToString();
            cbOra.Text = cbOra.Items[3].ToString();
            if (cbOrar.Text != "")
            {
                switch (cbOrar.Text)
                {
                    case "Profesor":
                        if (comboBox1.Text != "") cbProf.Text = comboBox1.Text;
                        if (tb54.Text != "")
                        {
                            foreach (Lectie l in lectii)
                                if (l.Profesor.Nume == comboBox1.Text && l.Zi == 5 && l.Ora == 14)
                                {
                                    cbDisciplina.Text = l.Disciplina.Denumire;
                                    cbCurs.Text = l.ECurs == true ? "Da" : "Nu";
                                    cbGrupa.Text = l.Grupa.Cod.ToString();
                                    cbSala.Text = l.Sala.Cod.ToString();
                                }
                        }
                        break;
                    case "Grupa":
                        if (comboBox1.Text != "") cbGrupa.Text = comboBox1.Text;
                        if (tb54.Text != "")
                        {
                            foreach (Lectie l in lectii)
                                if (l.Grupa.Cod.ToString() == comboBox1.Text && l.Zi == 5 && l.Ora == 14)
                                {
                                    cbDisciplina.Text = l.Disciplina.Denumire;
                                    cbCurs.Text = l.ECurs == true ? "Da" : "Nu";
                                    cbProf.Text = l.Profesor.Nume;
                                    cbSala.Text = l.Sala.Cod.ToString();
                                }
                        }
                        break;
                    case "Sala":
                        if (comboBox1.Text != "") cbSala.Text = comboBox1.Text;
                        if (tb54.Text != "")
                        {
                            foreach (Lectie l in lectii)
                                if (l.Sala.Cod.ToString() == comboBox1.Text && l.Zi == 5 && l.Ora == 14)
                                {
                                    cbDisciplina.Text = l.Disciplina.Denumire;
                                    cbCurs.Text = l.ECurs == true ? "Da" : "Nu";
                                    cbGrupa.Text = l.Grupa.Cod.ToString();
                                    cbProf.Text = l.Profesor.Nume;
                                }
                        }
                        break;
                }
            }
        }

        private void tb55_Click(object sender, EventArgs e)
        {
            cbProf.Text = "";
            cbDisciplina.Text = "";
            cbCurs.Text = "";
            cbGrupa.Text = "";
            cbSala.Text = "";
            cbZi.Text = cbZi.Items[4].ToString();
            cbOra.Text = cbOra.Items[4].ToString();
            if (cbOrar.Text != "")
            {
                switch (cbOrar.Text)
                {
                    case "Profesor":
                        if (comboBox1.Text != "") cbProf.Text = comboBox1.Text;
                        if (tb55.Text != "")
                        {
                            foreach (Lectie l in lectii)
                                if (l.Profesor.Nume == comboBox1.Text && l.Zi == 5 && l.Ora == 16)
                                {
                                    cbDisciplina.Text = l.Disciplina.Denumire;
                                    cbCurs.Text = l.ECurs == true ? "Da" : "Nu";
                                    cbGrupa.Text = l.Grupa.Cod.ToString();
                                    cbSala.Text = l.Sala.Cod.ToString();
                                }
                        }
                        break;
                    case "Grupa":
                        if (comboBox1.Text != "") cbGrupa.Text = comboBox1.Text;
                        if (tb55.Text != "")
                        {
                            foreach (Lectie l in lectii)
                                if (l.Grupa.Cod.ToString() == comboBox1.Text && l.Zi == 5 && l.Ora == 16)
                                {
                                    cbDisciplina.Text = l.Disciplina.Denumire;
                                    cbCurs.Text = l.ECurs == true ? "Da" : "Nu";
                                    cbProf.Text = l.Profesor.Nume;
                                    cbSala.Text = l.Sala.Cod.ToString();
                                }
                        }
                        break;
                    case "Sala":
                        if (comboBox1.Text != "") cbSala.Text = comboBox1.Text;
                        if (tb55.Text != "")
                        {
                            foreach (Lectie l in lectii)
                                if (l.Sala.Cod.ToString() == comboBox1.Text && l.Zi == 5 && l.Ora == 16)
                                {
                                    cbDisciplina.Text = l.Disciplina.Denumire;
                                    cbCurs.Text = l.ECurs == true ? "Da" : "Nu";
                                    cbGrupa.Text = l.Grupa.Cod.ToString();
                                    cbProf.Text = l.Profesor.Nume;
                                }
                        }
                        break;
                }
            }
        }

        private void tb56_Click(object sender, EventArgs e)
        {
            cbProf.Text = "";
            cbDisciplina.Text = "";
            cbCurs.Text = "";
            cbGrupa.Text = "";
            cbSala.Text = "";
            cbZi.Text = cbZi.Items[4].ToString();
            cbOra.Text = cbOra.Items[5].ToString();
            if (cbOrar.Text != "")
            {
                switch (cbOrar.Text)
                {
                    case "Profesor":
                        if (comboBox1.Text != "") cbProf.Text = comboBox1.Text;
                        if (tb56.Text != "")
                        {
                            foreach (Lectie l in lectii)
                                if (l.Profesor.Nume == comboBox1.Text && l.Zi == 5 && l.Ora == 18)
                                {
                                    cbDisciplina.Text = l.Disciplina.Denumire;
                                    cbCurs.Text = l.ECurs == true ? "Da" : "Nu";
                                    cbGrupa.Text = l.Grupa.Cod.ToString();
                                    cbSala.Text = l.Sala.Cod.ToString();
                                }
                        }
                        break;
                    case "Grupa":
                        if (comboBox1.Text != "") cbGrupa.Text = comboBox1.Text;
                        if (tb56.Text != "")
                        {
                            foreach (Lectie l in lectii)
                                if (l.Grupa.Cod.ToString() == comboBox1.Text && l.Zi == 5 && l.Ora == 18)
                                {
                                    cbDisciplina.Text = l.Disciplina.Denumire;
                                    cbCurs.Text = l.ECurs == true ? "Da" : "Nu";
                                    cbProf.Text = l.Profesor.Nume;
                                    cbSala.Text = l.Sala.Cod.ToString();
                                }
                        }
                        break;
                    case "Sala":
                        if (comboBox1.Text != "") cbSala.Text = comboBox1.Text;
                        if (tb56.Text != "")
                        {
                            foreach (Lectie l in lectii)
                                if (l.Sala.Cod.ToString() == comboBox1.Text && l.Zi == 5 && l.Ora == 18)
                                {
                                    cbDisciplina.Text = l.Disciplina.Denumire;
                                    cbCurs.Text = l.ECurs == true ? "Da" : "Nu";
                                    cbGrupa.Text = l.Grupa.Cod.ToString();
                                    cbProf.Text = l.Profesor.Nume;
                                }
                        }
                        break;
                }
            }
        }

        private void tb61_Click(object sender, EventArgs e)
        {
            cbProf.Text = "";
            cbDisciplina.Text = "";
            cbCurs.Text = "";
            cbGrupa.Text = "";
            cbSala.Text = "";
            cbZi.Text = cbZi.Items[5].ToString();
            cbOra.Text = cbOra.Items[0].ToString();
            if (cbOrar.Text != "")
            {
                switch (cbOrar.Text)
                {
                    case "Profesor":
                        if (comboBox1.Text != "") cbProf.Text = comboBox1.Text;
                        if (tb61.Text != "")
                        {
                            foreach (Lectie l in lectii)
                                if (l.Profesor.Nume == comboBox1.Text && l.Zi == 6 && l.Ora == 8)
                                {
                                    cbDisciplina.Text = l.Disciplina.Denumire;
                                    cbCurs.Text = l.ECurs == true ? "Da" : "Nu";
                                    cbGrupa.Text = l.Grupa.Cod.ToString();
                                    cbSala.Text = l.Sala.Cod.ToString();
                                }
                        }
                        break;
                    case "Grupa":
                        if (comboBox1.Text != "") cbGrupa.Text = comboBox1.Text;
                        if (tb61.Text != "")
                        {
                            foreach (Lectie l in lectii)
                                if (l.Grupa.Cod.ToString() == comboBox1.Text && l.Zi == 6 && l.Ora == 8)
                                {
                                    cbDisciplina.Text = l.Disciplina.Denumire;
                                    cbCurs.Text = l.ECurs == true ? "Da" : "Nu";
                                    cbProf.Text = l.Profesor.Nume;
                                    cbSala.Text = l.Sala.Cod.ToString();
                                }
                        }
                        break;
                    case "Sala":
                        if (comboBox1.Text != "") cbSala.Text = comboBox1.Text;
                        if (tb61.Text != "")
                        {
                            foreach (Lectie l in lectii)
                                if (l.Sala.Cod.ToString() == comboBox1.Text && l.Zi == 6 && l.Ora == 8)
                                {
                                    cbDisciplina.Text = l.Disciplina.Denumire;
                                    cbCurs.Text = l.ECurs == true ? "Da" : "Nu";
                                    cbGrupa.Text = l.Grupa.Cod.ToString();
                                    cbProf.Text = l.Profesor.Nume;
                                }
                        }
                        break;
                }
            }
        }

        private void tb62_Click(object sender, EventArgs e)
        {
            cbProf.Text = "";
            cbDisciplina.Text = "";
            cbCurs.Text = "";
            cbGrupa.Text = "";
            cbSala.Text = "";
            cbZi.Text = cbZi.Items[5].ToString();
            cbOra.Text = cbOra.Items[1].ToString();
            if (cbOrar.Text != "")
            {
                switch (cbOrar.Text)
                {
                    case "Profesor":
                        if (comboBox1.Text != "") cbProf.Text = comboBox1.Text;
                        if (tb62.Text != "")
                        {
                            foreach (Lectie l in lectii)
                                if (l.Profesor.Nume == comboBox1.Text && l.Zi == 6 && l.Ora == 10)
                                {
                                    cbDisciplina.Text = l.Disciplina.Denumire;
                                    cbCurs.Text = l.ECurs == true ? "Da" : "Nu";
                                    cbGrupa.Text = l.Grupa.Cod.ToString();
                                    cbSala.Text = l.Sala.Cod.ToString();
                                }
                        }
                        break;
                    case "Grupa":
                        if (comboBox1.Text != "") cbGrupa.Text = comboBox1.Text;
                        if (tb62.Text != "")
                        {
                            foreach (Lectie l in lectii)
                                if (l.Grupa.Cod.ToString() == comboBox1.Text && l.Zi == 6 && l.Ora == 10)
                                {
                                    cbDisciplina.Text = l.Disciplina.Denumire;
                                    cbCurs.Text = l.ECurs == true ? "Da" : "Nu";
                                    cbProf.Text = l.Profesor.Nume;
                                    cbSala.Text = l.Sala.Cod.ToString();
                                }
                        }
                        break;
                    case "Sala":
                        if (comboBox1.Text != "") cbSala.Text = comboBox1.Text;
                        if (tb62.Text != "")
                        {
                            foreach (Lectie l in lectii)
                                if (l.Sala.Cod.ToString() == comboBox1.Text && l.Zi == 6 && l.Ora == 10)
                                {
                                    cbDisciplina.Text = l.Disciplina.Denumire;
                                    cbCurs.Text = l.ECurs == true ? "Da" : "Nu";
                                    cbGrupa.Text = l.Grupa.Cod.ToString();
                                    cbProf.Text = l.Profesor.Nume;
                                }
                        }
                        break;
                }
            }
        }

        private void tb63_Click(object sender, EventArgs e)
        {
            cbProf.Text = "";
            cbDisciplina.Text = "";
            cbCurs.Text = "";
            cbGrupa.Text = "";
            cbSala.Text = "";
            cbZi.Text = cbZi.Items[5].ToString();
            cbOra.Text = cbOra.Items[2].ToString();
            if (cbOrar.Text != "")
            {
                switch (cbOrar.Text)
                {
                    case "Profesor":
                        if (comboBox1.Text != "") cbProf.Text = comboBox1.Text;
                        if (tb63.Text != "")
                        {
                            foreach (Lectie l in lectii)
                                if (l.Profesor.Nume == comboBox1.Text && l.Zi == 6 && l.Ora == 12)
                                {
                                    cbDisciplina.Text = l.Disciplina.Denumire;
                                    cbCurs.Text = l.ECurs == true ? "Da" : "Nu";
                                    cbGrupa.Text = l.Grupa.Cod.ToString();
                                    cbSala.Text = l.Sala.Cod.ToString();
                                }
                        }
                        break;
                    case "Grupa":
                        if (comboBox1.Text != "") cbGrupa.Text = comboBox1.Text;
                        if (tb63.Text != "")
                        {
                            foreach (Lectie l in lectii)
                                if (l.Grupa.Cod.ToString() == comboBox1.Text && l.Zi == 6 && l.Ora == 12)
                                {
                                    cbDisciplina.Text = l.Disciplina.Denumire;
                                    cbCurs.Text = l.ECurs == true ? "Da" : "Nu";
                                    cbProf.Text = l.Profesor.Nume;
                                    cbSala.Text = l.Sala.Cod.ToString();
                                }
                        }
                        break;
                    case "Sala":
                        if (comboBox1.Text != "") cbSala.Text = comboBox1.Text;
                        if (tb63.Text != "")
                        {
                            foreach (Lectie l in lectii)
                                if (l.Sala.Cod.ToString() == comboBox1.Text && l.Zi == 6 && l.Ora == 12)
                                {
                                    cbDisciplina.Text = l.Disciplina.Denumire;
                                    cbCurs.Text = l.ECurs == true ? "Da" : "Nu";
                                    cbGrupa.Text = l.Grupa.Cod.ToString();
                                    cbProf.Text = l.Profesor.Nume;
                                }
                        }
                        break;
                }
            }
        }

        private void tb64_Click(object sender, EventArgs e)
        {
            cbProf.Text = "";
            cbDisciplina.Text = "";
            cbCurs.Text = "";
            cbGrupa.Text = "";
            cbSala.Text = "";
            cbZi.Text = cbZi.Items[5].ToString();
            cbOra.Text = cbOra.Items[3].ToString();
            if (cbOrar.Text != "")
            {
                switch (cbOrar.Text)
                {
                    case "Profesor":
                        if (comboBox1.Text != "") cbProf.Text = comboBox1.Text;
                        if (tb64.Text != "")
                        {
                            foreach (Lectie l in lectii)
                                if (l.Profesor.Nume == comboBox1.Text && l.Zi == 6 && l.Ora == 14)
                                {
                                    cbDisciplina.Text = l.Disciplina.Denumire;
                                    cbCurs.Text = l.ECurs == true ? "Da" : "Nu";
                                    cbGrupa.Text = l.Grupa.Cod.ToString();
                                    cbSala.Text = l.Sala.Cod.ToString();
                                }
                        }
                        break;
                    case "Grupa":
                        if (comboBox1.Text != "") cbGrupa.Text = comboBox1.Text;
                        if (tb64.Text != "")
                        {
                            foreach (Lectie l in lectii)
                                if (l.Grupa.Cod.ToString() == comboBox1.Text && l.Zi == 6 && l.Ora == 14)
                                {
                                    cbDisciplina.Text = l.Disciplina.Denumire;
                                    cbCurs.Text = l.ECurs == true ? "Da" : "Nu";
                                    cbProf.Text = l.Profesor.Nume;
                                    cbSala.Text = l.Sala.Cod.ToString();
                                }
                        }
                        break;
                    case "Sala":
                        if (comboBox1.Text != "") cbSala.Text = comboBox1.Text;
                        if (tb64.Text != "")
                        {
                            foreach (Lectie l in lectii)
                                if (l.Sala.Cod.ToString() == comboBox1.Text && l.Zi == 6 && l.Ora == 14)
                                {
                                    cbDisciplina.Text = l.Disciplina.Denumire;
                                    cbCurs.Text = l.ECurs == true ? "Da" : "Nu";
                                    cbGrupa.Text = l.Grupa.Cod.ToString();
                                    cbProf.Text = l.Profesor.Nume;
                                }
                        }
                        break;
                }
            }
        }

        private void tb65_Click(object sender, EventArgs e)
        {
            cbProf.Text = "";
            cbDisciplina.Text = "";
            cbCurs.Text = "";
            cbGrupa.Text = "";
            cbSala.Text = "";
            cbZi.Text = cbZi.Items[5].ToString();
            cbOra.Text = cbOra.Items[4].ToString();
            if (cbOrar.Text != "")
            {
                switch (cbOrar.Text)
                {
                    case "Profesor":
                        if (comboBox1.Text != "") cbProf.Text = comboBox1.Text;
                        if (tb65.Text != "")
                        {
                            foreach (Lectie l in lectii)
                                if (l.Profesor.Nume == comboBox1.Text && l.Zi == 6 && l.Ora == 16)
                                {
                                    cbDisciplina.Text = l.Disciplina.Denumire;
                                    cbCurs.Text = l.ECurs == true ? "Da" : "Nu";
                                    cbGrupa.Text = l.Grupa.Cod.ToString();
                                    cbSala.Text = l.Sala.Cod.ToString();
                                }
                        }
                        break;
                    case "Grupa":
                        if (comboBox1.Text != "") cbGrupa.Text = comboBox1.Text;
                        if (tb65.Text != "")
                        {
                            foreach (Lectie l in lectii)
                                if (l.Grupa.Cod.ToString() == comboBox1.Text && l.Zi == 6 && l.Ora == 16)
                                {
                                    cbDisciplina.Text = l.Disciplina.Denumire;
                                    cbCurs.Text = l.ECurs == true ? "Da" : "Nu";
                                    cbProf.Text = l.Profesor.Nume;
                                    cbSala.Text = l.Sala.Cod.ToString();
                                }
                        }
                        break;
                    case "Sala":
                        if (comboBox1.Text != "") cbSala.Text = comboBox1.Text;
                        if (tb65.Text != "")
                        {
                            foreach (Lectie l in lectii)
                                if (l.Sala.Cod.ToString() == comboBox1.Text && l.Zi == 6 && l.Ora == 16)
                                {
                                    cbDisciplina.Text = l.Disciplina.Denumire;
                                    cbCurs.Text = l.ECurs == true ? "Da" : "Nu";
                                    cbGrupa.Text = l.Grupa.Cod.ToString();
                                    cbProf.Text = l.Profesor.Nume;
                                }
                        }
                        break;
                }
            }
        }

        private void tb66_Click(object sender, EventArgs e)
        {
            cbProf.Text = "";
            cbDisciplina.Text = "";
            cbCurs.Text = "";
            cbGrupa.Text = "";
            cbSala.Text = "";
            cbZi.Text = cbZi.Items[5].ToString();
            cbOra.Text = cbOra.Items[5].ToString();
            if (cbOrar.Text != "")
            {
                switch (cbOrar.Text)
                {
                    case "Profesor":
                        if (comboBox1.Text != "") cbProf.Text = comboBox1.Text;
                        if (tb66.Text != "")
                        {
                            foreach (Lectie l in lectii)
                                if (l.Profesor.Nume == comboBox1.Text && l.Zi == 6 && l.Ora == 18)
                                {
                                    cbDisciplina.Text = l.Disciplina.Denumire;
                                    cbCurs.Text = l.ECurs == true ? "Da" : "Nu";
                                    cbGrupa.Text = l.Grupa.Cod.ToString();
                                    cbSala.Text = l.Sala.Cod.ToString();
                                }
                        }
                        break;
                    case "Grupa":
                        if (comboBox1.Text != "") cbGrupa.Text = comboBox1.Text;
                        if (tb66.Text != "")
                        {
                            foreach (Lectie l in lectii)
                                if (l.Grupa.Cod.ToString() == comboBox1.Text && l.Zi == 6 && l.Ora == 18)
                                {
                                    cbDisciplina.Text = l.Disciplina.Denumire;
                                    cbCurs.Text = l.ECurs == true ? "Da" : "Nu";
                                    cbProf.Text = l.Profesor.Nume;
                                    cbSala.Text = l.Sala.Cod.ToString();
                                }
                        }
                        break;
                    case "Sala":
                        if (comboBox1.Text != "") cbSala.Text = comboBox1.Text;
                        if (tb66.Text != "")
                        {
                            foreach (Lectie l in lectii)
                                if (l.Sala.Cod.ToString() == comboBox1.Text && l.Zi == 6 && l.Ora == 18)
                                {
                                    cbDisciplina.Text = l.Disciplina.Denumire;
                                    cbCurs.Text = l.ECurs == true ? "Da" : "Nu";
                                    cbGrupa.Text = l.Grupa.Cod.ToString();
                                    cbProf.Text = l.Profesor.Nume;
                                }
                        }
                        break;
                }
            }
        }

        private void stergeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ToolStripItem menuItem = sender as ToolStripItem;
            if(menuItem!=null)
            {
                ContextMenuStrip owner = menuItem.Owner as ContextMenuStrip;
                if(owner!=null)
                {
                    Control sourceControl = owner.SourceControl;
                    if (sourceControl.Text != "")
                    {
                        String zi = sourceControl.Name.Substring(2, 1);
                        String ora = sourceControl.Name.Substring(3, 1);

                        cbZi.Text = cbZi.Items[Convert.ToInt32(zi) - 1].ToString();
                        cbOra.Text = cbOra.Items[Convert.ToInt32(ora) - 1].ToString();
                        //try
                        //{
                            int oraTabel = 0;
                            switch (Convert.ToInt32(ora))
                            {
                                case 1: oraTabel = 8; break;
                                case 2: oraTabel = 10; break;
                                case 3: oraTabel = 12; break;
                                case 4: oraTabel = 14; break;
                                case 5: oraTabel = 16; break;
                                case 6: oraTabel = 18; break;
                            }
                            switch (cbOrar.Text)
                            {
                                case "Profesor":
                                    // if (comboBox1.Text != "") cbProf.Text = comboBox1.Text;
                                    
                                        foreach (Lectie l in lectii)
                                            if (l.Profesor.Nume == comboBox1.Text && l.Zi == Convert.ToInt32(zi) && l.Ora == oraTabel)
                                            {
                                                cbDisciplina.Text = l.Disciplina.Denumire;
                                                cbCurs.Text = l.ECurs == true ? "Da" : "Nu";
                                                cbGrupa.Text = l.Grupa.Cod.ToString();
                                                cbSala.Text = l.Sala.Cod.ToString();
                                        cbProf.Text = l.Profesor.Nume;
                                            lectii.Remove(l);
                                        break;
                                            }
                                    break;
                                case "Grupa":
                                    //if (comboBox1.Text != "") cbGrupa.Text = comboBox1.Text;
                                    
                                        foreach (Lectie l in lectii)
                                            if (l.Grupa.Cod.ToString() == comboBox1.Text && l.Zi == Convert.ToInt32(zi) && l.Ora == oraTabel)
                                            {
                                        cbGrupa.Text = l.Grupa.Cod.ToString();
                                                cbDisciplina.Text = l.Disciplina.Denumire;
                                                cbCurs.Text = l.ECurs == true ? "Da" : "Nu";
                                                cbProf.Text = l.Profesor.Nume;
                                                cbSala.Text = l.Sala.Cod.ToString();
                                            lectii.Remove(l);
                                        break;
                                            }
                                    break;
                                case "Sala":
                                    //if (comboBox1.Text != "") cbSala.Text = comboBox1.Text;
                                        foreach (Lectie l in lectii)
                                            if (l.Sala.Cod.ToString() == comboBox1.Text && l.Zi == Convert.ToInt32(zi) && l.Ora == oraTabel)
                                            {
                                        cbSala.Text = l.Sala.Cod.ToString();
                                                cbDisciplina.Text = l.Disciplina.Denumire;
                                                cbCurs.Text = l.ECurs == true ? "Da" : "Nu";
                                                cbGrupa.Text = l.Grupa.Cod.ToString();
                                                cbProf.Text = l.Profesor.Nume;
                                            lectii.Remove(l);
                                        break;
                                            }
                                    break;
                            }
                            sourceControl.Text = "";
                        sourceControl.BackColor = Color.LightGray;
                        //}
                        //catch
                        //{
                        //    MessageBox.Show("Orarul afisat nu este sincronizat cu selectiile de deasupra!");
                        //}
                    }
                   
                    
                    
                }
            }
            //this.
            //switch (litere[2])
            //{
            //    case 1:
            //}
            foreach (Lectie l in lectii)
            {

            }
        }

        //private void print(object sender,PrintPageEventArgs e)
        //{
        //    Bitmap img = new Bitmap(panel1.Width, panel1.Height);
        //    panel1.DrawToBitmap(img, new Rectangle(panel1.ClientRectangle.X,
        //        panel1.ClientRectangle.Y, panel1.ClientRectangle.Width, panel1.ClientRectangle.Height));

        //    using (Image image = (Image)img)
        //    {
        //        Bitmap cropped = new Bitmap(image.Width, image.Height - 30);
        //        using (Graphics g = Graphics.FromImage(cropped))
        //        {
        //            g.DrawImage(image, new Rectangle(0, 0, cropped.Width, cropped.Height), new Rectangle(0, 30, cropped.Width, cropped.Height), GraphicsUnit.Pixel);
        //            Rectangle dr = new Rectangle(0, 0, cropped.Width, 30);
        //            Brush br = new SolidBrush(Color.White);
        //            g.FillRectangle(br, dr);
        //            String titlu = "Orar " + cbOrar.Text + " - " + comboBox1.Text;
        //            Font font = new Font(FontFamily.GenericSerif, 20, FontStyle.Bold);
        //            g.DrawString(titlu, font, new SolidBrush(Color.Black),
        //                new Point(20, 0));
        //            //cropped.Save(denumire);
        //            //cropped.Dispose();
        //        }
        //    }
        //}

        //private void printToolStripMenuItem_Click(object sender, EventArgs e)
        //{
        //    PrintDocument pd = new PrintDocument();
        //    pd.PrintPage += new PrintPageEventHandler(print);
        //    PrintPreviewDialog dlg = new PrintPreviewDialog();
        //    dlg.Document = pd;
        //    dlg.ShowDialog();
        //}

        private void save(Control c, string denumire)
        {
            Bitmap img = new Bitmap(c.Width, c.Height);
            c.DrawToBitmap(img, new Rectangle(c.ClientRectangle.X,
                c.ClientRectangle.Y, c.ClientRectangle.Width, c.ClientRectangle.Height));
                      
            using(Image image = (Image)img)
            {
                Bitmap cropped = new Bitmap(image.Width, image.Height - 30);
                using(Graphics g=Graphics.FromImage(cropped))
                {
                    g.DrawImage(image, new Rectangle(0, 0, cropped.Width, cropped.Height), new Rectangle(0, 30, cropped.Width, cropped.Height), GraphicsUnit.Pixel);
                    Rectangle dr = new Rectangle(0, 0, cropped.Width, 30);
                    Brush br = new SolidBrush(Color.White);
                    g.FillRectangle(br, dr);
                    String titlu = "Orar " + cbOrar.Text + " - " + comboBox1.Text;
                    Font font = new Font(FontFamily.GenericSerif, 20, FontStyle.Bold);
                    g.DrawString(titlu, font, new SolidBrush(Color.Black),
                        new Point(20,0));
                    cropped.Save(denumire);
                    cropped.Dispose();
                }
            }
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog dlg = new SaveFileDialog();
            dlg.Filter = "(*.bmp)|*.bmp";
            //saveFileDialog1.Filter = "(*.txt)|*.txt";
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                save(panel1, dlg.FileName);
                MessageBox.Show("Imagine salvata!");
            }
        }





        //private void treeView1_AfterCheck(object sender, TreeViewEventArgs e)
        //{
        //    if(e.Action!=TreeViewAction.Unknown)
        //    {
        //        if (e.Node.Nodes.Count > 0)
        //            this.CheckAllChildNodes(e.Node, e.Node.Checked);
        //    }
        //}

        //private void CheckAllChildNodes(TreeNode treeNode, bool nodeChecked)
        //{
        //    foreach(TreeNode node in treeNode.Nodes)
        //    {
        //        node.Checked = nodeChecked;
        //        if(node.Nodes.Count>0)
        //        {
        //            this.CheckAllChildNodes(node, nodeChecked);
        //        }
        //    }
        //}

        //private void cbCurs_SelectedIndexChanged(object sender, EventArgs e)
        //{
        //    List<Sala> saliCurs = new List<Sala>();
        //    List<Sala> saliSeminar = new List<Sala>();
        //    foreach (Sala s in listaSali)
        //        if (s.Capacitate >= 90)
        //            saliCurs.Add(s);
        //        else
        //            saliSeminar.Add(s);
        //    cbSala.Items.Clear();

        //    if (cbCurs.Text == "Da")
        //    {
        //        cbSala.Items.AddRange(saliCurs.ToArray());

        //    }
        //    else cbSala.Items.AddRange(saliSeminar.ToArray());
        //}
    }
}
