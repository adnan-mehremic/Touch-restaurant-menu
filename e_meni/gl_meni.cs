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
    public partial class gl_meni : Form
    {
        public gl_meni()
        {
            InitializeComponent();
        }

        private void hrana_Click(object sender, EventArgs e)
        {
            hrana h = new hrana();
            h.Show();
            this.Hide();
        }

        private void pice_Click(object sender, EventArgs e)
        {
            pice p = new pice ();
            p.Show();
            this.Hide();
        }

        private void slatko_Click(object sender, EventArgs e)
        {
            slatko s = new slatko();
            s.Show();
            this.Hide();
        }

        private void x_Click(object sender, EventArgs e)
        {

            DialogResult result1 = MessageBox.Show("Da li zaista želite poništiti narudžbu?", "Upozorenje", MessageBoxButtons.YesNo);

            if (result1 == DialogResult.Yes)
            {
                pocetna p = new pocetna();
                p.Show();
                this.Hide();

                try
                {
                    e_meni.DAO.DAO d = new e_meni.DAO.DAO("localhost", "mydb", "root", "0000");
                    d.IzbrisiNamirnice();
                    //listBoxNarudzba.Items.Clear();
                    racun.Racun = 0;
                }
                catch (Exception izuzetak)
                {
                }
            }
        }
    }
}
