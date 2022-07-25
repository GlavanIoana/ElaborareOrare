using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace proiectPAW
{
    public partial class AfisareListView : Form
    {
        List<Disciplina> discipline = new List<Disciplina>();
        List<Profesor> profesori = new List<Profesor>();
        List<Sala> sali = new List<Sala>();
        List<Grupa> grupe = new List<Grupa>();
        public AfisareListView(List<Lectie> lista)
        {
            InitializeComponent();
            listView1.Items.Clear();
            listView1.Columns.Add("Profesor");
            listView1.Columns.Add("Disciplina");
            listView1.Columns.Add("E curs?");
            listView1.Columns.Add("Sala");
            listView1.Columns.Add("Grupa");
            listView1.Columns.Add("Zi");
            listView1.Columns.Add("Ora");

            foreach (Lectie l in lista)
            {
                ListViewItem itm = new ListViewItem(l.Profesor.Nume);
                itm.SubItems.Add(l.Disciplina.Denumire);
                string str = l.ECurs == true ? "Da" : "Nu";
                itm.SubItems.Add(str);
                itm.SubItems.Add(l.Sala.Cod.ToString());
                itm.SubItems.Add(l.Grupa.Cod.ToString());
                //itm.SubItems.Add(l.Zi.ToString());
                switch (l.Zi)
                {
                    case 1: itm.SubItems.Add("Luni"); break;
                    case 2: itm.SubItems.Add("Marti"); break;
                    case 3: itm.SubItems.Add("Miercuri"); break;
                    case 4: itm.SubItems.Add("Joi"); break;
                    case 5: itm.SubItems.Add("Vineri"); break;
                    case 6: itm.SubItems.Add("Sambata"); break;
                    default: itm.SubItems.Add("Sambata"); break;
                }
                itm.SubItems.Add(l.Ora.ToString());
                listView1.Items.Add(itm);

            }
        }
        public AfisareListView(string connString,int i)
        {
            InitializeComponent();
            if (i == 1)
            {
                listView1.Items.Clear();
                listView1.Columns.Add("cod");
                listView1.Columns.Add("denumire");
                listView1.Columns.Add("nrCredite");
                listView1.Columns.Add("catedra");


                OleDbConnection conexiune = new OleDbConnection(connString);
                try
                {
                    conexiune.Open();
                    //MessageBox.Show("Conexiune cu succes");
                    OleDbCommand comanda = new OleDbCommand();
                    comanda.Connection = conexiune;
                    comanda.CommandText = "SELECT * FROM discipline";
                    OleDbDataReader reader = comanda.ExecuteReader();
                    //ListView listView1 = new ListView();
                    //this.Controls.Add(listView1);
                    while (reader.Read())
                    {
                        Disciplina d = new Disciplina();
                        d.Cod = Convert.ToInt32(reader["cod"].ToString());
                        d.Denumire = reader["denumire"].ToString();
                        d.NrCredite = Convert.ToInt32(reader["nrCredite".ToString()]);
                        d.Catedra = reader["catedra"].ToString();
                        ListViewItem itm = new ListViewItem(reader["cod"].ToString());
                        itm.SubItems.Add(reader["denumire"].ToString());
                        itm.SubItems.Add(reader["nrCredite"].ToString());
                        itm.SubItems.Add(reader["catedra"].ToString());
                        listView1.Items.Add(itm);
                        
                        discipline.Add(d);
                    }
                    reader.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                finally
                {
                    conexiune.Close();
                }
            }
            else if(i==2)
            {
                listView1.Items.Clear();
                listView1.Columns.Add("cod");
                listView1.Columns.Add("nume");
                listView1.Columns.Add("discipline");
                listView1.Columns.Add("data_angajare");
                listView1.Columns.Add("salariu");

                OleDbConnection conexiune = new OleDbConnection(connString);
                try
                {
                    conexiune.Open();
                    //MessageBox.Show("Conexiune cu succes");
                    OleDbCommand comanda = new OleDbCommand();
                    comanda.Connection = conexiune;
                    comanda.CommandText = "SELECT * FROM profesori";
                    OleDbDataReader reader = comanda.ExecuteReader();
                    //ListView listView1 = new ListView();
                    //this.Controls.Add(listView1);
                    while (reader.Read())
                    {
                        Profesor p = new Profesor();
                        p.Cod = Convert.ToInt32(reader["cod"].ToString());
                        p.Nume = reader["nume"].ToString();
                        p.Discipline = reader["discipline"].ToString().Split(',');
                        //string[] str = reader["discipline"].ToString().Split(',');
                        //for (int j = 0; j < str.Length-1; j++)
                        //    p.Discipline.Add(str[j]);
                        p.Data_angajare = Convert.ToDateTime(reader["data_angajare"].ToString());
                        p.Salariu =(float) Convert.ToDouble(reader["salariu"].ToString());
                        ListViewItem itm = new ListViewItem(reader["cod"].ToString());
                        itm.SubItems.Add(reader["nume"].ToString());
                        itm.SubItems.Add(reader["discipline"].ToString());
                        itm.SubItems.Add(reader["data_angajare"].ToString());
                        itm.SubItems.Add(reader["salariu"].ToString());
                        listView1.Items.Add(itm);
                        profesori.Add(p);
                    }
                    reader.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                finally
                {
                    conexiune.Close();
                }
            }
            else if(i==3)
            {
                listView1.Items.Clear();
                listView1.Columns.Add("cod");
                listView1.Columns.Add("capacitate");
                listView1.Columns.Add("tip");

                OleDbConnection conexiune = new OleDbConnection(connString);
                try
                {
                    conexiune.Open();
                    //MessageBox.Show("Conexiune cu succes");
                    OleDbCommand comanda = new OleDbCommand();
                    comanda.Connection = conexiune;
                    comanda.CommandText = "SELECT * FROM sali";
                    OleDbDataReader reader = comanda.ExecuteReader();
                    //ListView listView1 = new ListView();
                    //this.Controls.Add(listView1);
                    while (reader.Read())
                    {
                        Sala s = new Sala();
                        s.Cod = Convert.ToInt32(reader["cod"].ToString());
                        s.Capacitate = Convert.ToInt32(reader["capacitate"].ToString());
                        s.Tip = reader["tip"].ToString();
                        ListViewItem itm = new ListViewItem(reader["cod"].ToString());
                        itm.SubItems.Add(reader["capacitate"].ToString());
                        itm.SubItems.Add(reader["tip"].ToString());
                        listView1.Items.Add(itm);
                        sali.Add(s);
                    }
                    reader.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                finally
                {
                    conexiune.Close();
                }
            }
            else if(i==4)
            {
                listView1.Items.Clear();
                listView1.Columns.Add("cod");
                listView1.Columns.Add("nrStudenti");
                listView1.Columns.Add("anStudiu");

                OleDbConnection conexiune = new OleDbConnection(connString);
                try
                {
                    conexiune.Open();
                    //MessageBox.Show("Conexiune cu succes");
                    OleDbCommand comanda = new OleDbCommand();
                    comanda.Connection = conexiune;
                    comanda.CommandText = "SELECT * FROM grupe";
                    OleDbDataReader reader = comanda.ExecuteReader();
                    //ListView listView1 = new ListView();
                    //this.Controls.Add(listView1);
                    while (reader.Read())
                    {
                        Grupa g = new Grupa();
                        g.Cod = Convert.ToInt32(reader["cod"].ToString());
                        g.NrElevi = Convert.ToInt32(reader["nrStudenti"].ToString());
                        g.AnStudiu = Convert.ToInt32(reader["anStudiu"].ToString());
                        ListViewItem itm = new ListViewItem(reader["cod"].ToString());
                        itm.SubItems.Add(reader["nrStudenti"].ToString());
                        itm.SubItems.Add(reader["anStudiu"].ToString());
                        listView1.Items.Add(itm);
                        grupe.Add(g);
                    }
                    reader.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                finally
                {
                    conexiune.Close();
                }
            }


        }
        public List<Disciplina> preiaDiscipline()
        {
            return discipline;
        }
        public List<Profesor> preiaProfesori()
        {
            return profesori;
        }
        public List<Sala> preiaSali()
        {
            return sali;
        }
        public List<Grupa> preiaGrupe()
        {
            return grupe;
        }
    }
}
