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
    public partial class UserControl1 : UserControl
    {
        public event EventHandler adaugareClick;
        public event EventHandler salvareClick;
        public event EventHandler afisareClick;
        public event EventHandler okClick;

        public UserControl1()
        {
            InitializeComponent();
        }
        private void btnAdaugare_Click(object sender,EventArgs e)
        {
            if (this.adaugareClick != null)
                this.adaugareClick(this, e);
        }
        private void btnSalvare_Click(object sender, EventArgs e)
        {
            if (salvareClick != null)
                salvareClick(sender, e);
        }
        private void btnAfisare_Click(object sender, EventArgs e)
        {
            if (afisareClick != null)
                afisareClick(sender, e);
        }
        private void btnOk_Click(object sender, EventArgs e)
        {
            if (okClick != null)
                okClick(sender, e);
        }
    }
}
