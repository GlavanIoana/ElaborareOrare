using System;
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
    public partial class MeniuAfisare : Form
    {
        public MeniuAfisare(List<Data> lista)
        {
            InitializeComponent();
            foreach (Data d in lista)
                textBox1.Text += d.ToString() + Environment.NewLine;
        }
    }
}
