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
    public partial class internet : Form
    {
        public internet()
        {
            InitializeComponent();
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
