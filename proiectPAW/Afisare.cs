using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace proiectPAW
{
    public partial class Afisare : Form
    {
        public Afisare(ArrayList lista)
        {
            InitializeComponent();
            foreach (Object o in lista)
                textBox1.Text += o.ToString() + Environment.NewLine;
        }

        public Afisare(List<Lectie> lectii)
        {
            InitializeComponent();
            foreach (Lectie o in lectii)
                textBox1.Text += o.ToString() + Environment.NewLine;
        }

        private void copyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Clipboard.SetText(textBox1.Text);
        }

        private void pasteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Graphics g = Graphics.FromHwnd(textBox1.Handle);
            g.DrawString(Clipboard.GetText(), this.Font, new SolidBrush(Color.Black), 10, 10);
            //IDataObject o = Clipboard.GetDataObject();
            //if(o.GetDataPresent(typeof(string)))
            //{
            //    string text = o.GetData(typeof(string)).ToString();
            //    g.DrawString(text, this.Font, new SolidBrush(Color.Black), 10, 10);
            //}
            //else if (o.GetDataPresent(typeof(Lectie)))
            //{
            //    Lectie l = (Lectie)o.GetData(typeof(Lectie));
            //    g.DrawString(l.ToString(), this.Font, new SolidBrush(Color.Black), 10, 10);

            //}
        }
    }
}
