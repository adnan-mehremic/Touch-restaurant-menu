using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace e_meni
{
    public partial class kraj : Form
    {
        public kraj()
        {
            InitializeComponent();
        }

        private void internet_Click(object sender, EventArgs e)
        {
            internet h = new internet();
            h.Show();
            this.Hide();
        }

        private void home_Click(object sender, EventArgs e)
        {
            pocetna p = new pocetna();
            p.Show();
            this.Hide();
        }

        private void igrica_Click(object sender, EventArgs e)
        {
            igrica i = new igrica();
            i.Show();
            this.Hide();
        }
    }
}
