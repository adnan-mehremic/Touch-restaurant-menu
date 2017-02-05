using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using System.IO;
using e_meni.Klase;
using e_meni.DAO;

namespace e_meni
{
    public partial class posaljiNarudzbu : Form
    {
        public posaljiNarudzbu()
        {
            InitializeComponent();
        }

        private void posaljiNarudzbu_Load(object sender, EventArgs e)
        {
            popuniListuNarudzbe();
        }

        private void slatko_Click(object sender, EventArgs e)
        {
            slatko s = new slatko();
            s.Show();
            this.Hide();
        }

        private void hrana_Click(object sender, EventArgs e)
        {
            hrana h = new hrana();
            h.Show();
            this.Hide();
        }

        private void pice_Click(object sender, EventArgs e)
        {
            pice p = new pice();
            p.Show();
            this.Hide();
        }

        private void potvrdi_Click(object sender, EventArgs e)
        {
            // e_meni.DAO.DAO d = new e_meni.DAO.DAO("localhost", "mydb", "root", "0000");
            DialogResult result1 = MessageBox.Show("Da li zaista želite potvrditi narudžbu?", "Upozorenje", MessageBoxButtons.YesNo);

            if (result1 == DialogResult.Yes)
            {
                kraj k = new kraj();
            k.Show();
            this.Hide();

            try
            {
                e_meni.DAO.DAO d = new e_meni.DAO.DAO("localhost", "mydb", "root", "0000");
                d.IzbrisiNamirnice();
                listBoxNarudzba.Items.Clear();
                racun.Racun = 0;
            }
            catch (Exception izuzetak)
            {
            }
            }
        }

        private void ponisti_Click(object sender, EventArgs e)
        {

            DialogResult result1 = MessageBox.Show("Da li zaista želite poništiti narudžbu?","Upozorenje", MessageBoxButtons.YesNo);

            if (result1 == DialogResult.Yes)
            {
            pocetna p = new pocetna();
            p.Show();
            this.Hide();

            try
            {
                e_meni.DAO.DAO d = new e_meni.DAO.DAO("localhost", "mydb", "root", "0000");
                d.IzbrisiNamirnice();
                listBoxNarudzba.Items.Clear();
                racun.Racun = 0;
            }
            catch (Exception izuzetak)
            {
            }
           }
        }

        private void listBoxNarudzba_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void listBoxNarudzba_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                string[] words = listBoxNarudzba.SelectedItem.ToString().Split(' ');
                e_meni.DAO.DAO d = new e_meni.DAO.DAO("localhost", "mydb", "root", "0000");
                string nazivJela = words[1];
                for (int i = 2; i < words.Count() - 2; i++)
                    nazivJela += " " + words[i];
                d.IzbrisiNamirnicu(d.VratiNamirnicaID(nazivJela));
                int cijena = Convert.ToInt16(words[words.Count() - 2]);
                racun.Racun -= cijena;
                popuniListuNarudzbe();
            }
            catch (Exception izuzetak)
            {
                Console.Write(izuzetak);
            }
        }

        private void popuniListuNarudzbe()
        {
            if (racun.Racun > 0)
            {
                potvrdi.Visible = true;
                ponisti.Visible = true;

            }
            try
            {
                listBoxNarudzba.Items.Clear();

                e_meni.DAO.DAO d = new e_meni.DAO.DAO("localhost", "mydb", "root", "0000");
                RACUN.Text = Convert.ToString(racun.Racun) + " KM";

                if (d.NamirnicePostoje())
                {

                    List<Namirnica> namirnice = new List<Namirnica>();
                    namirnice = d.VratiSveNamirnice();

                    for (int i = 0; i < namirnice.Count; i++)
                    {

                        string namirnica = Convert.ToString(namirnice[i].Kolicina) + "x " + namirnice[i].Naziv + " " + Convert.ToString(namirnice[i].Cijena) + " KM";
                        listBoxNarudzba.Items.Add(namirnica);



                    }
                }

            }

            catch (Exception izuzetak)
            {

            }
        }
    }
}
