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
    public partial class pocetna : Form
    {
        public pocetna()
        {
            InitializeComponent();
        }

        private void ulaz_Click(object sender, EventArgs e)
        {
            gl_meni gm = new gl_meni();
            gm.Show();
            this.Hide();
        }
    }
}
