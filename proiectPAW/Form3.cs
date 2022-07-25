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
    public partial class Form3 : Form
    {
        MeniuPrincipal mn = new MeniuPrincipal();
        List<Profesor> listaProfi = new List<Profesor>();


        public Form3(MeniuPrincipal meniu,ArrayList numeDiscipline)
        {
            InitializeComponent();
            mn = meniu;
            for(int i = 0; i < numeDiscipline.Count; i++)
            {
                checkedListBox1.Items.Add(numeDiscipline[i], false);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                int cod = Convert.ToInt32(tbCod.Text);
                String nume = tbNume.Text;
                DateTime dataAng = dateTimePicker1.Value;
                float salariu = (float)Convert.ToDouble(tbSalariu.Text);
                //List<String> discipline=new List<String>();
                //for (int i = 0; i < checkedListBox1.CheckedItems.Count; i++)
                //    discipline.Add(checkedListBox1.CheckedItems[i].ToString());
                String[] discipline=null;
                for (int i = 0; i < checkedListBox1.CheckedItems.Count; i++)
                    discipline[i] = checkedListBox1.CheckedItems[i].ToString();
                Profesor prof = new Profesor(cod, nume, discipline, dataAng,salariu);
                listaProfi.Add(prof);

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                tbCod.Clear();
                tbNume.Clear();
                dateTimePicker1.ResetText();
                tbSalariu.Clear();
                foreach (int i in checkedListBox1.CheckedIndices)
                {
                    checkedListBox1.SetItemCheckState(i, CheckState.Unchecked);
                }
                checkedListBox1.SelectedItems.Clear();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Afisare a = new Afisare(new ArrayList(listaProfi));
            a.ShowDialog();

        }

        private void button3_Click(object sender, EventArgs e)
        {
            SaveFileDialog dlg = new SaveFileDialog();
            dlg.Filter = "(*.txt)|*.txt";
            saveFileDialog1.Filter = "(*.txt)|*.txt";
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                StreamWriter sw = new StreamWriter(saveFileDialog1.FileName);
                foreach (Profesor d in listaProfi)
                {
                    sw.Write(d.Cod);
                    sw.Write(",");
                    sw.Write(d.Nume);
                    sw.Write(",");
                    sw.Write(d.Data_angajare);
                    sw.Write(",");
                    sw.Write(d.Salariu);
                    foreach (String s in d.Discipline)
                    {
                        sw.Write(",");
                        sw.Write(s);
                    }
                    sw.WriteLine();
                }
                sw.Close();
                MessageBox.Show("Date salvate!");
            }
        }

        internal List<Profesor> preiaDate()
        {
            return listaProfi;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Close();
            mn.Activate();
        }
    }
}
