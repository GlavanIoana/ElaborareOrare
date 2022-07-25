using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace proiectPAW
{
    public partial class MeniuPrincipal : Form
    {
        ArrayList listaControale = new ArrayList();
        List<Data> listaDate = new List<Data>();
        ArrayList numeDiscipline = new ArrayList();
        List<Disciplina> listaDiscipline = new List<Disciplina>();
        List<Profesor> listaProfesori = new List<Profesor>();
        List<Sala> listaSali = new List<Sala>();
        List<Grupa> listaGrupe = new List<Grupa>();

        string connStringDisc, connStringProf, connStringSali, connStringGr;

        public MeniuPrincipal(List<Data> listaParam)
        {
            listaDate.AddRange(listaParam);
            
        }

        public MeniuPrincipal()
        {
            InitializeComponent();
            listaControale.Add(groupBox1);
            connStringDisc = "Provider = Microsoft.ACE.OLEDB.12.0; Data Source = Discipline.accdb";
            connStringProf= "Provider = Microsoft.ACE.OLEDB.12.0; Data Source = Profesori.accdb";
            connStringSali= "Provider = Microsoft.ACE.OLEDB.12.0; Data Source = Sali.accdb";
            connStringGr= "Provider = Microsoft.ACE.OLEDB.12.0; Data Source = Grupe.accdb";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (radioButton1.Checked == false &&
                radioButton2.Checked == false)
                MessageBox.Show("Selectati o optiune!");
            else
            {
                if (radioButton1.Checked)
                {
                    this.Controls.Clear();
                    this.Controls.Add(groupBox1);
                    this.Controls.Add(button1);
                    this.Controls.Add(menuStrip1);
                    this.Controls.Add(button2);

                    //inserez 3 radioButton-uri
                    int x = groupBox1.Location.X;
                    int y = groupBox1.Location.Y;
                    int dist = radioButton2.Location.Y -radioButton1.Location.Y;
                    int latime = groupBox1.Width;
                    int inaltime = groupBox1.Height + 2*dist;

                    GroupBox grupNou= new GroupBox();
                    grupNou.Location = new Point(x + latime+50, y);
                    grupNou.Height = inaltime;
                    grupNou.Width = latime;
                    grupNou.Text = "Ce date doriti sa introduceti?";

                    RadioButton r1 = new RadioButton();
                    r1.Text = "Discipline";
                    RadioButton r2 = new RadioButton();
                    r2.Text = "Sali";
                    RadioButton r3 = new RadioButton();
                    r3.Text = "Profesori";
                    RadioButton r4 = new RadioButton();
                    r4.Text = "Grupe";

                    grupNou.Controls.Add(r1);
                    grupNou.Controls.Add(r2);
                    grupNou.Controls.Add(r3);
                    grupNou.Controls.Add(r4);

                    r1.Location = new Point(20, 30);
                    r2.Location = new Point(20, 30 + dist);
                    r3.Location = new Point(20, 30 + dist+dist);
                    r4.Location = new Point(20, 30 + 3*dist);

                    r1.CheckedChanged += rb1_checkChanged;
                    r2.CheckedChanged += rb2_checkChanged;
                    r3.CheckedChanged += rb3_checkChanged;
                    r4.CheckedChanged += rb4_checkChanged;

                    listaControale.Add(r1);
                    listaControale.Add(r2);
                    listaControale.Add(r3);
                    listaControale.Add(r4);

                    this.Controls.Add(grupNou);
                    
                }
                else
                if (radioButton2.Checked)
                {
                    this.Controls.Clear();
                    this.Controls.Add(groupBox1);
                    this.Controls.Add(button1);
                    this.Controls.Add(menuStrip1);
                    this.Controls.Add(button2);

                    //inserez 3 checkBoxuri
                    int x = groupBox1.Location.X;
                    int y = groupBox1.Location.Y;
                    int dist = radioButton2.Location.Y - radioButton1.Location.Y;
                    int latime = groupBox1.Width;
                    int inaltime = groupBox1.Height + 2*dist;

                    GroupBox grupNou = new GroupBox();
                    grupNou.Location = new Point(x + latime + 50, y);
                    grupNou.Height = inaltime;
                    grupNou.Width = latime;
                    grupNou.Text = "Ce date doriti sa importati?";

                    CheckBox c1 = new CheckBox();
                    c1.Text = "Discipline";
                    CheckBox c2 = new CheckBox();
                    c2.Text = "Sali";
                    CheckBox c3 = new CheckBox();
                    c3.Text = "Profesori";
                    CheckBox c4 = new CheckBox();
                    c4.Text = "Grupe";

                    grupNou.Controls.Add(c1);
                    grupNou.Controls.Add(c2);
                    grupNou.Controls.Add(c3);
                    grupNou.Controls.Add(c4);

                    c1.Location = new Point(20, 30);
                    c2.Location = new Point(20, 30 + dist);
                    c3.Location = new Point(20, 30 + dist + dist);
                    c4.Location = new Point(20, 30 + 3*dist);

                    c1.CheckedChanged += new EventHandler(custom_event_handler1);
                    c2.CheckedChanged += new EventHandler(custom_event_handler2);
                    c3.CheckedChanged += new EventHandler(custom_event_handler3);
                    c4.CheckedChanged += new EventHandler(custom_event_handler4);


                    //Button buton = new Button();
                    //buton.Location = new Point(40, 30 + 3*dist);
                    //buton.Text = "OK";

                    //buton.Click += buton_Click;

                    //grupNou.Controls.Add(buton);
                    listaControale.Add(c1);
                    listaControale.Add(c2);
                    listaControale.Add(c3);
                    this.Controls.Add(grupNou);
                }

                //MessageBox.Show();
            }
        }
        private void custom_event_handler4(object sender, EventArgs e)
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
                    int cod = Convert.ToInt32(v_str[0].Trim());
                    int numar = Convert.ToInt32(v_str[1].Trim());
                    int an = Convert.ToInt32(v_str[2].Trim());
                    Grupa grupa = new Grupa(cod, numar, an);
                    Boolean ok = true;
                    for (int j = 0; j < listaGrupe.Count && ok == true; j++)
                        if (grupa.Cod == listaGrupe[j].Cod)
                            ok = false;
                    if (ok == true)
                    {
                        listaGrupe.Add(grupa);
                        listaDate.Add(grupa);
                    }
                }
                sr.Close();
            }
        }
        private void custom_event_handler3(object sender, EventArgs e)
        {
            try
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

                        int cod = Convert.ToInt32(v_str[0].Trim());
                        String nume = v_str[1];
                        DateTime dataAng;
                        dataAng = DateTime.Parse(v_str[2]);
                        float salariu = (float)Convert.ToDouble(v_str[3].Trim());
                        //List<String> discipline = new List<String>();
                        //for (int i = 4; i < v_str.Length; i++)
                        //    discipline.Add(v_str[i]);
                        String[] discipline = null;
                        int k = 0;
                        for (int i = 4; i < v_str.Length; i++)
                            discipline[k++] = v_str[i];
                        Profesor prof = new Profesor(cod, nume, discipline, dataAng, salariu);
                        Boolean ok = true;
                        for (int j = 0; j < listaProfesori.Count && ok == true; j++)
                            if (prof.Cod == listaProfesori[j].Cod)
                                ok = false;
                        if (ok == true)
                        {
                            listaProfesori.Add(prof);
                            listaDate.Add(prof);
                        }
                    }
                    sr.Close();
                }
            }
            catch (IOException ioex)
            {
                MessageBox.Show(ioex.Message);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void custom_event_handler2(object sender, EventArgs e)
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
                    int cod = Convert.ToInt32(v_str[0].Trim());
                    int capacitate = Convert.ToInt32(v_str[1].Trim());
                    String tip = v_str[2];
                    Sala d = new Sala(cod, capacitate, tip);
                    Boolean ok = true;
                    for (int j = 0; j < listaSali.Count && ok == true; j++)
                        if (d.Cod == listaSali[j].Cod)
                            ok = false;
                    if (ok == true)
                    {
                        listaSali.Add(d);
                        listaDate.Add(d);
                    }
                }
                sr.Close();
            }
        }

        private void custom_event_handler1(object sender, EventArgs e)
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
                    int cod = Convert.ToInt32(v_str[0].Trim());
                    String denumire = v_str[1];
                    numeDiscipline.Add(denumire);
                    int nrCredite = Convert.ToInt32(v_str[2].Trim());
                    String catedra = v_str[3];
                    Disciplina d = new Disciplina(cod, denumire, nrCredite, catedra);
                    Boolean ok = true;
                        for (int j = 0; j < listaDiscipline.Count && ok == true; j++)
                            if (d.Cod == listaDiscipline[j].Cod)
                                ok = false;
                        if (ok == true)
                        {
                            listaDiscipline.Add(d);
                            listaDate.Add(d);
                        }
                }
                sr.Close();
            }
        }

        //private void buton_Click(object sender, EventArgs e)
        //{
        //    CheckBox c1 = (CheckBox)listaControale[4];
        //    CheckBox c2 = (CheckBox)listaControale[5];
        //    CheckBox c3 = (CheckBox)listaControale[6];
        //    if(c1.Checked)
        //    {
        //        OpenFileDialog openFileDialog1 = new OpenFileDialog();
        //        openFileDialog1.Filter = "(*.txt)|*.txt";
        //        if (openFileDialog1.ShowDialog() == DialogResult.OK)
        //        {
        //            StreamReader sr = new StreamReader(openFileDialog1.FileName);
        //            while (!sr.EndOfStream)
        //            {
        //                String linie = sr.ReadLine();
        //                String[] v_str = linie.Split(',');
        //                int cod = Convert.ToInt32(v_str[0].Trim());
        //                String denumire = v_str[1];
        //                int nrCredite = Convert.ToInt32(v_str[2].Trim());
        //                String catedra = v_str[3];
        //                Disciplina d = new Disciplina(cod, denumire, nrCredite, catedra);
        //                listaDate.Add(d);
        //            }
        //            sr.Close();
        //        }
        //    }
        //    if(c2.Checked)
        //    {
        //        OpenFileDialog openFileDialog1 = new OpenFileDialog();
        //        openFileDialog1.Filter = "(*.txt)|*.txt";
        //        if (openFileDialog1.ShowDialog() == DialogResult.OK)
        //        {
        //            StreamReader sr = new StreamReader(openFileDialog1.FileName);
        //            while (!sr.EndOfStream)
        //            {
        //                String linie = sr.ReadLine();
        //                String[] v_str = linie.Split(',');
        //                int cod = Convert.ToInt32(v_str[0].Trim());
        //                int capacitate = Convert.ToInt32(v_str[1].Trim());
        //                String tip = v_str[3];
        //                Sala d = new Sala(cod, capacitate, tip);
        //                listaDate.Add(d);
        //            }
        //            sr.Close();
        //        }
        //    }
        //    if(c3.Checked)
        //    {
        //        try
        //        {
        //            OpenFileDialog openFileDialog1 = new OpenFileDialog();
        //            openFileDialog1.Filter = "(*.txt)|*.txt";
        //            if (openFileDialog1.ShowDialog() == DialogResult.OK)
        //            {
        //                StreamReader sr = new StreamReader(openFileDialog1.FileName);
        //                while (!sr.EndOfStream)
        //                {
        //                    String linie = sr.ReadLine();
        //                    String[] v_str = linie.Split(',');

        //                    int cod = Convert.ToInt32(v_str[0].Trim());
        //                    String nume = v_str[1];
        //                    DateTime dataAng;
        //                    dataAng = DateTime.Parse(v_str[2]);
        //                    float salariu = (float)Convert.ToDouble(v_str[3].Trim());
        //                    List<String> discipline = new List<String>();
        //                    for (int i = 4; i < v_str.Length; i++)
        //                        discipline.Add(v_str[i]);
        //                    Profesor prof = new Profesor(cod, nume, discipline, dataAng, salariu);
        //                    listaDate.Add(prof);
        //                }
        //                sr.Close();
        //            }
        //        }
        //        catch (IOException ioex)
        //        {
        //            MessageBox.Show(ioex.Message);
        //        }
        //        catch(Exception ex)
        //        {
        //            MessageBox.Show(ex.Message);
        //        }
        //    }


        //}

        private void rb4_checkChanged(object sender, EventArgs e)
        {
            RadioButton rb = new RadioButton();
            rb = (RadioButton)sender;
            if(rb!=null)
            {
                if(rb.Checked)
                {
                    Form4 f4 = new Form4(this);
                    f4.ShowDialog();
                    List<Grupa> lista = f4.preiaDate();//PROBLEMA
                    Boolean ok = true;
                    for (int i = 0; i < lista.Count; i++)
                    {
                        for (int j = 0; j < listaGrupe.Count && ok == true; j++)
                            if (lista[i].Cod == listaGrupe[j].Cod)
                                ok = false;
                        if (ok == true)
                        {
                            listaGrupe.Add(lista[i]);
                            listaDate.Add(lista[i]);
                        }
                    }
                    //listaDate.AddRange(listaGrupe);
                }
            }
            
        }
        private void rb3_checkChanged(object sender, EventArgs e)
        {
            RadioButton rb = new RadioButton();
            rb = (RadioButton)sender;
            if (rb != null)
            {
                if (rb.Checked)
                {
                    Form3 f3 = new Form3(this, numeDiscipline);
                    f3.ShowDialog();
                    List<Profesor> lista = f3.preiaDate();//PROBLEMA
                    Boolean ok = true;
                    for (int i = 0; i < lista.Count; i++)
                    {
                        for (int j = 0; j < listaProfesori.Count && ok == true; j++)
                            if (lista[i].Cod == listaProfesori[j].Cod)
                                ok = false;
                        if (ok == true)
                        {
                            listaProfesori.Add(lista[i]);
                            listaDate.Add(lista[i]);
                        }
                    }
                    //listaDate.AddRange(listaProfesori);
                }
            }
        }

        private void rb2_checkChanged(object sender, EventArgs e)
        {
            RadioButton rb = new RadioButton();
            rb = (RadioButton)sender;
            if (rb != null)
            {
                if (rb.Checked)
                {
                    Form2 f2 = new Form2(this);
                    f2.ShowDialog();
                    List<Sala> lista = f2.preiaDate();//PROBLEMA
                    Boolean ok = true;
                    for (int i = 0; i < lista.Count; i++)
                    {
                        for (int j = 0; j < listaSali.Count && ok == true; j++)
                            if (lista[i].Cod == listaSali[j].Cod)
                                ok = false;
                        if (ok == true)
                        {
                            listaSali.Add(lista[i]);
                            listaDate.Add(lista[i]);
                        }
                    }
                    //listaDate.AddRange(listaSali);
                }
            }
        }

        private void rb1_checkChanged(object sender, EventArgs e)
        {
            RadioButton rb = new RadioButton();
            rb = (RadioButton)sender;
            if (rb != null)
            {
                if (rb.Checked)
                {
                    Form1 f1 = new Form1(this);
                    f1.ShowDialog();
                    List<Disciplina> lista = f1.preiaDate();//PROBLEMA
                    Boolean ok = true;
                    for (int i = 0; i < lista.Count; i++)
                    {
                        for (int j = 0; j < listaDiscipline.Count && ok == true; j++)
                            if (lista[i].Cod == listaDiscipline[j].Cod)
                                ok = false;
                        if (ok == true)
                        {
                            listaDiscipline.Add(lista[i]);
                            listaDate.Add(lista[i]);
                        }
                    }
                    //listaDate.AddRange(listaDiscipline);
                    numeDiscipline.AddRange(f1.preiaNumeDiscipline());
                }
            }
        }

        private void afiseazaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MeniuAfisare frm = new MeniuAfisare(listaDate);
            frm.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {

            //Orar orar = new Orar();
            ////pentru fiecare profesor
            //// incerc sa adaug lectie
            ////verific restrictiile(sa nu se suprapuna, sa nu depaseasca anumite limite: 10h/zi si 40/sapt)
            ////daca se suprapune, caut sala/-profesor-/grupa/moment disponibil
            ////adaug lectie
            ////trec la urmatoarea incercare pana cand atng 20 lectii sau pana cand nu mai am cum sa adaug

            //listaProfesori.Sort();
            //foreach(Profesor p in listaProfesori)
            //{
            //    int nrLectii = 0;
            //    int nrGrupeDisponibile = 1;
            //    while(nrLectii<=20&& nrGrupeDisponibile!=0)
            //    {
            //        foreach(string d in p.Discipline)
            //        {
            //            Disciplina disciplina = new Disciplina();
            //            for (int i = 0; i < listaDiscipline.Count; i++)
            //                if (listaDiscipline[i].Denumire == d)
            //                    disciplina = listaDiscipline[i];
            //            for(int i=1;i<=6;i++)//luam fiecare zi
            //                for (int j=8;j<20;j+=2)
            //                {
            //                    adaugaLectie(p, disciplina, i, j);

            //                }
            //        }
            //    }
            //}


            ElaborareOrar elab = new ElaborareOrar(listaDate,listaDiscipline,listaProfesori,listaSali,listaGrupe);
            elab.ShowDialog();
        }

        //private void adaugaLectie(Profesor p, Disciplina d, int zi, int ora)
        //{
        //    List<Lectie> lista = new List<Lectie>();
        //    Orar o = new Orar();
        //    if (o.grupeDisponibile(zi,ora)!=null)
        //    {
        //        Grupa g = new Grupa();
        //        g=o.grupeDisponibile(zi, ora)[0];
        //        if(o.saliDisponibile(zi,ora)!=null)
        //        {
        //            Sala s = o.saliDisponibile(zi, ora)[0];
        //            Lectie l = new Lectie(d, p, true, s, g, zi, ora);
        //        }
        //    }

        //}

        //private void importDinBazaDeDateToolStripMenuItem_Click(object sender, EventArgs e)
        //{
        //    AfisareListView afisareListView = new AfisareListView(listaDiscipline);
        //    OleDbConnection conexiune = new OleDbConnection(connString);
        //    try
        //    {
        //        conexiune.Open();
        //        //MessageBox.Show("Conexiune cu succes");
        //        OleDbCommand comanda = new OleDbCommand();
        //        comanda.Connection = conexiune;
        //        comanda.CommandText = "SELECT * FROM studenti";
        //        OleDbDataReader reader = comanda.ExecuteReader();
        //        ListView listView1 = new ListView();
        //        afisareListView.Controls.Add(listView1);
        //        while (reader.Read())
        //        {
        //            ListViewItem itm = new ListViewItem(reader["cod"].ToString());
        //            itm.SubItems.Add(reader["nume"].ToString());
        //            itm.SubItems.Add(reader["varsta"].ToString());
        //            itm.SubItems.Add(reader["nota"].ToString());
        //            itm.SubItems.Add(reader["forma"].ToString());
        //            afisareListView.
        //            listView1.Items.Add(itm);
        //        }
        //        reader.Close();
        //        afisareListView.ShowDialog();
        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show(ex.Message);
        //    }
        //    finally
        //    {
        //        conexiune.Close();
        //    }
        //}

        private void disciplineToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AfisareListView frm = new AfisareListView(connStringDisc,1);
            frm.ShowDialog();
            List<Disciplina> lista = frm.preiaDiscipline();
            Boolean ok = true;
            for(int i = 0;i<lista.Count;i++)
            {
                for (int j = 0; j < listaDiscipline.Count && ok == true; j++)
                    if (lista[i].Cod == listaDiscipline[j].Cod)
                        ok = false;
                if (ok == true)
                {
                    listaDiscipline.Add(lista[i]);
                    listaDate.Add(lista[i]);
                }
            }
            //listaDate.AddRange(listaDiscipline);
        }

        private void grupeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AfisareListView frm = new AfisareListView(connStringGr, 4);
            frm.ShowDialog();
            List<Grupa> lista = frm.preiaGrupe();
            Boolean ok = true;
            for (int i = 0; i < lista.Count; i++)
            {
                for (int j = 0; j < listaGrupe.Count && ok == true; j++)
                    if (lista[i].Cod == listaGrupe[j].Cod)
                        ok = false;
                if (ok == true)
                {
                    listaGrupe.Add(lista[i]);
                    listaDate.Add(lista[i]);
                }
            }
            //listaDate.AddRange(listaGrupe);
        }

        private void saliToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AfisareListView frm = new AfisareListView(connStringSali, 3);
            frm.ShowDialog();
            List<Sala> lista = frm.preiaSali();
            Boolean ok = true;
            for (int i = 0; i < lista.Count; i++)
            {
                for (int j = 0; j < listaSali.Count && ok == true; j++)
                    if (lista[i].Cod == listaSali[j].Cod)
                        ok = false;
                if (ok == true)
                {
                    listaSali.Add(lista[i]);
                    listaDate.Add(lista[i]);
                }
            }
            //listaDate.AddRange(listaSali);
        }

        private void profesoriToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AfisareListView frm = new AfisareListView(connStringProf,2);
            frm.ShowDialog();
            List<Profesor> lista = frm.preiaProfesori();
            Boolean ok = true;
            for (int i = 0; i < lista.Count; i++)
            {
                for (int j = 0; j < listaProfesori.Count && ok == true; j++)
                    if (lista[i].Cod == listaProfesori[j].Cod)
                        ok = false;
                if (ok == true)
                {
                    listaProfesori.Add(lista[i]);
                    listaDate.Add(lista[i]);
                }
            }
            //listaDate.AddRange(listaProfesori);
        }
    }
}
