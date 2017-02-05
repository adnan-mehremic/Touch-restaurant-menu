using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using e_meni.Klase;
using e_meni.DAO;
using System.Text.RegularExpressions;

namespace e_meni
{
    public partial class voda : Form
    {
        public voda()
        {
            InitializeComponent();
        }
        private int kolicinaOaza = 0;
        private int kolicinaKiseljak = 0;

        private void dodajOaza_Click(object sender, EventArgs e)
        {
            if (kolicinaOaza == 0) oduzmiOaza.Visible = true;
            kolicinaOaza += 1;
            Namirnica n = new Namirnica("Tešanjski kiseljak", 0, 0);
            n.Kolicina = kolicinaOaza;
            n.Cijena = kolicinaOaza * 1;
            racun.Racun = racun.Racun + 1;

            string listBoxItem;

            try
            {
                e_meni.DAO.DAO d = new e_meni.DAO.DAO("localhost", "mydb", "root", "0000");
                if (d.NamirnicaPostoji(n.Naziv))
                {
                    d.AzurirajNamirnicu(n);

                    int x = kolicinaOaza - 1;

                    string item = Convert.ToString(x) + "x " + n.Naziv + " " + Convert.ToString(1 * x) + " KM";


                    listBoxNarudzba.Items.Remove(item);

                }
                else
                {
                    d.DodajNamirnicu(n);

                }



                listBoxItem = Convert.ToString(n.Kolicina) + "x " + n.Naziv + " " + Convert.ToString(1 * n.Kolicina) + " KM";
                listBoxNarudzba.Items.Add(listBoxItem);
                RACUN.Text = Convert.ToString(racun.Racun) + " KM";



                // listBoxUkupno.Items.Add(Convert.ToString(  n.Cijena) + " KM");
            }

            catch (Exception izuzetak)
            {

            }
        }

        private void oduzmiOaza_Click(object sender, EventArgs e)
        {
            kolicinaOaza -= 1;
            Namirnica n = new Namirnica();
            n.Naziv = "Tešanjski kiseljak";
            n.Kolicina = kolicinaOaza;
            n.Cijena = kolicinaOaza * 1;
            racun.Racun = racun.Racun - 1;




            try
            {
                e_meni.DAO.DAO d = new e_meni.DAO.DAO("localhost", "mydb", "root", "0000");

                d.AzurirajNamirnicu(n);
                int x = kolicinaOaza + 1;
                listBoxNarudzba.Items.Remove(Convert.ToString(x) + "x " + n.Naziv + " " + Convert.ToString(1 * x) + " KM");

                string marg = Convert.ToString(n.Kolicina) + "x " + n.Naziv + " " + Convert.ToString(1 * n.Kolicina) + " KM";
                listBoxNarudzba.Items.Add(marg);



                if (kolicinaOaza == 0)
                {
                    oduzmiOaza.Visible = false;
                    listBoxNarudzba.Items.Remove(marg);
                    d.IzbrisiNamirnicu(d.VratiNamirnicaID(n.Naziv));

                }
            }

            catch (Exception izuzetak)
            {

            }
            RACUN.Text = Convert.ToString(racun.Racun) + " KM";
        }

        private void dodajKiseljak_Click(object sender, EventArgs e)
        {
            if (kolicinaKiseljak == 0) oduzmiKiseljak.Visible = true;
            kolicinaKiseljak += 1;
            Namirnica n = new Namirnica("Sarajevski kiseljak", 0, 0);
            n.Kolicina = kolicinaKiseljak;
            n.Cijena = kolicinaKiseljak * 1;
            racun.Racun = racun.Racun + 1;

            string listBoxItem;

            try
            {
                e_meni.DAO.DAO d = new e_meni.DAO.DAO("localhost", "mydb", "root", "0000");
                if (d.NamirnicaPostoji(n.Naziv))
                {
                    d.AzurirajNamirnicu(n);

                    int x = kolicinaKiseljak - 1;

                    string item = Convert.ToString(x) + "x " + n.Naziv + " " + Convert.ToString(1 * x) + " KM";


                    listBoxNarudzba.Items.Remove(item);

                }
                else
                {
                    d.DodajNamirnicu(n);

                }



                listBoxItem = Convert.ToString(n.Kolicina) + "x " + n.Naziv + " " + Convert.ToString(1 * n.Kolicina) + " KM";
                listBoxNarudzba.Items.Add(listBoxItem);
                RACUN.Text = Convert.ToString(racun.Racun) + " KM";



                // listBoxUkupno.Items.Add(Convert.ToString(  n.Cijena) + " KM");
            }

            catch (Exception izuzetak)
            {

            }
        }

        private void oduzmiKiseljak_Click(object sender, EventArgs e)
        {

            kolicinaKiseljak -= 1;
            Namirnica n = new Namirnica();
            n.Naziv = "Sarajevski kiseljak";
            n.Kolicina = kolicinaKiseljak;
            n.Cijena = kolicinaKiseljak * 1;
            racun.Racun = racun.Racun - 1;
            try
            {
                e_meni.DAO.DAO d = new e_meni.DAO.DAO("localhost", "mydb", "root", "0000");

                d.AzurirajNamirnicu(n);
                int x = kolicinaKiseljak + 1;
                listBoxNarudzba.Items.Remove(Convert.ToString(x) + "x " + n.Naziv + " " + Convert.ToString(1 * x) + " KM");

                string marg = Convert.ToString(n.Kolicina) + "x " + n.Naziv + " " + Convert.ToString(1 * n.Kolicina) + " KM";
                listBoxNarudzba.Items.Add(marg);

                if (kolicinaKiseljak == 0)
                {
                    oduzmiKiseljak.Visible = false;
                    listBoxNarudzba.Items.Remove(marg);
                    d.IzbrisiNamirnicu(d.VratiNamirnicaID(n.Naziv));

                }
            }

            catch (Exception izuzetak)
            {

            }
            RACUN.Text = Convert.ToString(racun.Racun) + " KM";
        }

        private void voda_Load(object sender, EventArgs e)
        {
            popuniListuNarudzbe();
        }

        private void nazad_pica_Click(object sender, EventArgs e)
        {
            pice h = new pice();
            h.Show();
            this.Hide();
        }

        private void hrana_Click(object sender, EventArgs e)
        {
            hrana h = new hrana();
            h.Show();
            this.Hide();
        }

        private void slatko_Click(object sender, EventArgs e)
        {
            slatko h = new slatko();
            h.Show();
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
                    listBoxNarudzba.Items.Clear();
                    racun.Racun = 0;
                }
                catch (Exception izuzetak)
                {
                }
            }
        }

        private void PosaljiNarudzbu_Click(object sender, EventArgs e)
        {
            posaljiNarudzbu pn = new posaljiNarudzbu();
            pn.Show();
            this.Hide();
        }

        private void help_Click(object sender, EventArgs e)
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
            listBoxNarudzba.Items.Clear();
            RACUN.Text = Convert.ToString(racun.Racun) + " KM";
            try
            {
                e_meni.DAO.DAO d = new e_meni.DAO.DAO("localhost", "mydb", "root", "0000");


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
                else listBoxNarudzba.Items.Clear();

                kolicinaKiseljak = d.VratiKolicinuNamirnice("Sarajevski kiseljak");
                kolicinaOaza = d.VratiKolicinuNamirnice("Tešanjski kiseljak");


                if (kolicinaKiseljak == 0) oduzmiKiseljak.Visible = false;
                if (kolicinaOaza == 0) oduzmiOaza.Visible = false;

            }
            catch (Exception izuzetak)
            {

            }
        }
    }
}

