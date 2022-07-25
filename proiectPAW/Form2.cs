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
    public partial class Form2 : Form
    {
        List<Sala> listaSali = new List<Sala>();
        MeniuPrincipal meniu = new MeniuPrincipal();
        public Form2(MeniuPrincipal menu)
        {
            InitializeComponent();
            meniu = menu;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                int cod = Convert.ToInt32(tbCod.Text);
                int capacitate = Convert.ToInt32(tbCapacitate.Text);
                String tip = cbTip.Text;

                Sala sala = new Sala(cod, capacitate, tip);
                listaSali.Add(sala);

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                tbCod.Clear();
                tbCapacitate.Clear();
                cbTip.Text="";
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
                foreach (Sala d in listaSali)
                {
                    sw.Write(d.Cod);
                    sw.Write(",");
                    sw.Write(d.Capacitate);
                    sw.Write(",");
                    sw.Write(d.Tip);
                    sw.WriteLine();
                }
                sw.Close();
                MessageBox.Show("Date salvate!");
            }
        }

        internal List<Sala> preiaDate()
        {
            return listaSali;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Afisare a = new Afisare(new ArrayList(listaSali));
            a.ShowDialog();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Close();
            meniu.Activate();
        }
    }
}
