using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace proiectPAW
{
    public partial class Form1 : Form
    {
        List<Disciplina> listaDiscipline = new List<Disciplina>();
        ArrayList numeDiscipline=new ArrayList();
        MeniuPrincipal mn = new MeniuPrincipal();
        public Form1(MeniuPrincipal meniu)
        {
            InitializeComponent();
            mn = meniu;

        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                int cod = Convert.ToInt32(tbCod.Text);
                String denumire = tbDenumire.Text;
                int nrCredite= Convert.ToInt32(tbCredite.Text);
                String catedra = tbCatedra.Text;

                Disciplina disciplina = new Disciplina(cod, denumire, nrCredite, catedra);
                listaDiscipline.Add(disciplina);
                numeDiscipline.Add(denumire);

            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                tbCod.Clear();
                tbDenumire.Clear();
                tbCredite.Clear();
                tbCatedra.Clear();
            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            SaveFileDialog dlg = new SaveFileDialog();
            dlg.Filter = "(*.txt)|*.txt";
            saveFileDialog1.Filter = "(*.txt)|*.txt";
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                StreamWriter sw = new StreamWriter(saveFileDialog1.FileName);
                foreach (Disciplina d in listaDiscipline)
                {
                    sw.Write(d.Cod);
                    sw.Write(",");
                    sw.Write(d.Denumire);
                    sw.Write(",");
                    sw.Write(d.NrCredite);
                    sw.Write(",");
                    sw.Write(d.Catedra);
                    sw.WriteLine();
                }
                sw.Close();
                MessageBox.Show("Date salvate!");
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            listView1.Items.Clear();
            foreach(Disciplina d in listaDiscipline)
            {
                ListViewItem itm = new ListViewItem(d.Cod.ToString());
                itm.SubItems.Add(d.Denumire);
                itm.SubItems.Add(d.NrCredite.ToString());
                itm.SubItems.Add(d.Catedra);
                listView1.Items.Add(itm);
            }
        }

        //private void button4_Click(object sender, EventArgs e)
        //{
        //    listaDiscipline.Clear();
        //    openFileDialog1.Filter = "(*.txt)|*.txt";
        //    if (openFileDialog1.ShowDialog() == DialogResult.OK)
        //    {
        //        StreamReader sr = new StreamReader(openFileDialog1.FileName);
        //        while (!sr.EndOfStream)
        //        {
        //            String linie = sr.ReadLine();
        //            String[] v_str = linie.Split(',');
        //            int cod = Convert.ToInt32(v_str[0].Trim());
        //            String denumire = v_str[1];
        //            int nrCredite = Convert.ToInt32(v_str[2].Trim());
        //            String catedra = v_str[3];
        //            Disciplina d = new Disciplina(cod, denumire, nrCredite, catedra);
        //            listaDiscipline.Add(d);
        //            numeDiscipline.Add(denumire);
        //        }
        //        sr.Close();
        //        listView1.Items.Clear();
        //        foreach (Disciplina d in listaDiscipline)
        //        {
        //            ListViewItem itm = new ListViewItem(d.Cod.ToString());
        //            itm.SubItems.Add(d.Denumire);
        //            itm.SubItems.Add(d.NrCredite.ToString());
        //            itm.SubItems.Add(d.Catedra);
        //            listView1.Items.Add(itm);
        //        }
        //    }
        //}

        private void button5_Click(object sender, EventArgs e)
        {
            this.Close();
            mn.Activate();
        }
        public List<Disciplina> preiaDate()
        {
            return listaDiscipline;
        }
        public ArrayList preiaNumeDiscipline()
        {
            return numeDiscipline;
        }
    }
}
