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
    public partial class Form4 : Form
    {
        List<Grupa> listaGrupe = new List<Grupa>();
        MeniuPrincipal mn = new MeniuPrincipal();
        public Form4(MeniuPrincipal meniu)
        {
            InitializeComponent();
            mn = meniu;
        }

        private void Form4_Load(object sender, EventArgs e)
        {
            userControl11.adaugareClick += new EventHandler(adaugare_click);
            userControl11.salvareClick += new EventHandler(salvare_click);
            userControl11.afisareClick += new EventHandler(afisare_click);
            userControl11.okClick += new EventHandler(ok_click);
        }
        private void adaugare_click(object sender, EventArgs e)
        {
            //try
            //{
                int cod = Convert.ToInt32(tbCod.Text.Trim());
                int numar = Convert.ToInt32(tbNumar.Text.Trim());
                int an = Convert.ToInt32(tbAn.Text.Trim());

                Grupa grupa = new Grupa(cod, numar, an);
                listaGrupe.Add(grupa);

            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show(ex.Message);
            //}
            //finally
            //{
            //    tbCod.Clear();
            //    tbNumar.Clear();
            //    tbAn.Clear();
            //}
        }
        private void salvare_click(object sender, EventArgs e)
        {
            SaveFileDialog dlg = new SaveFileDialog();
            dlg.Filter = "(*.txt)|*.txt";
            saveFileDialog1.Filter = "(*.txt)|*.txt";
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                StreamWriter sw = new StreamWriter(saveFileDialog1.FileName);
                foreach (Grupa d in listaGrupe)
                {
                    sw.Write(d.Cod);
                    sw.Write(",");
                    sw.Write(d.NrElevi);
                    sw.Write(",");
                    sw.Write(d.AnStudiu);
                    sw.WriteLine();
                }
                sw.Close();
                MessageBox.Show("Date salvate!");
            }
        }
        private void afisare_click(object sender, EventArgs e)
        {
            Afisare a = new Afisare(new ArrayList(listaGrupe));
            a.ShowDialog();
        }
        private void ok_click(object sender, EventArgs e)
        {
            this.Close();
            mn.Activate();
        }

        internal List<Grupa> preiaDate()
        {
            return listaGrupe;
        }
    }
}
