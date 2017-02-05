using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Text.RegularExpressions;

using System.IO;
using e_meni.Klase;
using e_meni.DAO;

namespace e_meni
{
    public partial class sendvici : Form
    {
        private int kolicinaTost = 0;
        private int kolicinaDomaci = 0;
        private int kolicinaHamburger = 0;

        
        public sendvici()
        {
            InitializeComponent();
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

        private void slatko_hr_Click(object sender, EventArgs e)
        {
            slatko s = new slatko();
            s.Show();
            this.Hide();
        }

        private void pice_hr_Click(object sender, EventArgs e)
        {
            pice p = new pice();
            p.Show();
            this.Hide();
        }

        private void nazad_pica_Click(object sender, EventArgs e)
        {
            hrana h = new hrana();
            h.Show();
            this.Hide();
        }

       

        private void dodajTost_Click(object sender, EventArgs e)
        {
            if (kolicinaTost == 0) oduzmiTost.Visible = true;
            kolicinaTost += 1;
            Namirnica n = new Namirnica("Tost sendvič", 0, 0);
            n.Kolicina = kolicinaTost;
            n.Cijena = kolicinaTost * 2;
            racun.Racun = racun.Racun + 2;

            string listBoxItem;

            try
            {
                e_meni.DAO.DAO d = new e_meni.DAO.DAO("localhost", "mydb", "root", "0000");
                if (d.NamirnicaPostoji(n.Naziv))
                {
                    d.AzurirajNamirnicu(n);

                    int x = kolicinaTost - 1;

                    string item = Convert.ToString(x) + "x " + n.Naziv + " " + Convert.ToString(2 * x) + " KM";


                    listBoxNarudzba.Items.Remove(item);

                }
                else
                {
                    d.DodajNamirnicu(n);

                }



                listBoxItem = Convert.ToString(n.Kolicina) + "x " + n.Naziv + " " + Convert.ToString(2 * n.Kolicina) + " KM";
                listBoxNarudzba.Items.Add(listBoxItem);
                RACUN.Text = Convert.ToString(racun.Racun) + " KM";



                // listBoxUkupno.Items.Add(Convert.ToString(  n.Cijena) + " KM");
            }

            catch (Exception izuzetak)
            {

            }
        }

        private void oduzmiTost_Click(object sender, EventArgs e)
        {
            kolicinaTost -= 1;
            Namirnica n = new Namirnica();
            n.Naziv = "Tost sendvič";
            n.Kolicina = kolicinaTost;
            n.Cijena = kolicinaTost * 2;
            racun.Racun = racun.Racun - 2;


            string marg;

            try
            {
                e_meni.DAO.DAO d = new e_meni.DAO.DAO("localhost", "mydb", "root", "0000");

                d.AzurirajNamirnicu(n);
                int x = kolicinaTost + 1;
                listBoxNarudzba.Items.Remove(Convert.ToString(x) + "x " + n.Naziv + " " + Convert.ToString(2 * x) + " KM");

                marg = Convert.ToString(n.Kolicina) + "x " + n.Naziv + " " + Convert.ToString(2 * n.Kolicina) + " KM";
                listBoxNarudzba.Items.Add(marg);



                if (kolicinaTost == 0)
                {
                    oduzmiTost.Visible = false;
                    listBoxNarudzba.Items.Remove(marg);
                    d.IzbrisiNamirnicu(d.VratiNamirnicaID(n.Naziv));

                }
            }

            catch (Exception izuzetak)
            {

            }
            RACUN.Text = Convert.ToString(racun.Racun) + " KM";
        }
        private void sendvici_Load(object sender, EventArgs e)
        {
            popuniListuNarudzbe();
        }

        private void dodajDomaci_Click(object sender, EventArgs e)
        {
            if (kolicinaDomaci == 0) oduzmiDomaci.Visible = true;
            kolicinaDomaci += 1;
            Namirnica n = new Namirnica("Domaći sendvič", 0, 0);
            n.Kolicina = kolicinaDomaci;
            n.Cijena = kolicinaDomaci * 5;
            racun.Racun = racun.Racun + 5;

            string listBoxItem;

            try
            {
                e_meni.DAO.DAO d = new e_meni.DAO.DAO("localhost", "mydb", "root", "0000");
                if (d.NamirnicaPostoji(n.Naziv))
                {
                    d.AzurirajNamirnicu(n);

                    int x = kolicinaDomaci - 1;

                    string item = Convert.ToString(x) + "x " + n.Naziv + " " + Convert.ToString(5 * x) + " KM";


                    listBoxNarudzba.Items.Remove(item);

                }
                else
                {
                    d.DodajNamirnicu(n);

                }



                listBoxItem = Convert.ToString(n.Kolicina) + "x " + n.Naziv + " " + Convert.ToString(5 * n.Kolicina) + " KM";
                listBoxNarudzba.Items.Add(listBoxItem);

                RACUN.Text = Convert.ToString(racun.Racun) + " KM";



            }

            catch (Exception izuzetak)
            {

            }
        }

        private void oduzmiDomaci_Click(object sender, EventArgs e)
        {
            kolicinaDomaci -= 1;
            Namirnica n = new Namirnica();
            n.Naziv = "Domaći sendvič";
            n.Kolicina = kolicinaDomaci;
            n.Cijena = kolicinaDomaci * 5;
            racun.Racun = racun.Racun - 5;

            string kapri;

            try
            {
                e_meni.DAO.DAO d = new e_meni.DAO.DAO("localhost", "mydb", "root", "0000");

                d.AzurirajNamirnicu(n);
                int x = kolicinaDomaci + 1;
                listBoxNarudzba.Items.Remove(Convert.ToString(x) + "x " + n.Naziv + " " + Convert.ToString(5 * x) + " KM");

                kapri = Convert.ToString(n.Kolicina) + "x " + n.Naziv + " " + Convert.ToString(5 * n.Kolicina) + " KM";
                listBoxNarudzba.Items.Add(kapri);



                if (kolicinaDomaci == 0)
                {
                    oduzmiDomaci.Visible = false;
                    listBoxNarudzba.Items.Remove(kapri);
                    d.IzbrisiNamirnicu(d.VratiNamirnicaID(n.Naziv));

                }
            }

            catch (Exception izuzetak)
            {

            }
            RACUN.Text = Convert.ToString(racun.Racun) + " KM";
        }

        private void dodajHamburger_Click(object sender, EventArgs e)
        {
            if (kolicinaHamburger == 0) oduzmiHamburger.Visible = true;
            kolicinaHamburger += 1;
            Namirnica n = new Namirnica("Hamburger", 0, 0);
            n.Kolicina = kolicinaHamburger;
            n.Cijena = kolicinaHamburger * 3;
            racun.Racun = racun.Racun + 3;

            string listBoxItem;

            try
            {
                e_meni.DAO.DAO d = new e_meni.DAO.DAO("localhost", "mydb", "root", "0000");
                if (d.NamirnicaPostoji(n.Naziv))
                {
                    d.AzurirajNamirnicu(n);

                    int x = kolicinaHamburger - 1;

                    string item = Convert.ToString(x) + "x " + n.Naziv + " " + Convert.ToString(3 * x) + " KM";


                    listBoxNarudzba.Items.Remove(item);

                }
                else
                {
                    d.DodajNamirnicu(n);

                }



                listBoxItem = Convert.ToString(n.Kolicina) + "x " + n.Naziv + " " + Convert.ToString(3 * n.Kolicina) + " KM";
                listBoxNarudzba.Items.Add(listBoxItem);
                RACUN.Text = Convert.ToString(racun.Racun) + " KM";



                // listBoxUkupno.Items.Add(Convert.ToString(  n.Cijena) + " KM");
            }

            catch (Exception izuzetak)
            {

            }
        }

        private void oduzmiHamburger_Click(object sender, EventArgs e)
        {
            kolicinaHamburger -= 1;
            Namirnica n = new Namirnica();
            n.Naziv = "Hamburger";
            n.Kolicina = kolicinaHamburger;
            n.Cijena = kolicinaHamburger * 3;
            racun.Racun = racun.Racun - 3;


            string marg;

            try
            {
                e_meni.DAO.DAO d = new e_meni.DAO.DAO("localhost", "mydb", "root", "0000");

                d.AzurirajNamirnicu(n);
                int x = kolicinaHamburger + 1;
                listBoxNarudzba.Items.Remove(Convert.ToString(x) + "x " + n.Naziv + " " + Convert.ToString(3 * x) + " KM");

                marg = Convert.ToString(n.Kolicina) + "x " + n.Naziv + " " + Convert.ToString(3 * n.Kolicina) + " KM";
                listBoxNarudzba.Items.Add(marg);



                if (kolicinaHamburger == 0)
                {
                    oduzmiHamburger.Visible = false;
                    listBoxNarudzba.Items.Remove(marg);
                    d.IzbrisiNamirnicu(d.VratiNamirnicaID(n.Naziv));

                }
            }

            catch (Exception izuzetak)
            {

            }
            RACUN.Text = Convert.ToString(racun.Racun) + " KM";
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


                kolicinaTost = d.VratiKolicinuNamirnice("Tost sendvič");
                kolicinaDomaci = d.VratiKolicinuNamirnice("Domaći sendvič");
                kolicinaHamburger = d.VratiKolicinuNamirnice("Hamburger");

                if (kolicinaTost == 0) oduzmiTost.Visible = false;
                if (kolicinaDomaci == 0) oduzmiDomaci.Visible = false;

                if (kolicinaHamburger == 0) oduzmiHamburger.Visible = false;

            }
            catch (Exception izuzetak)
            {

            }
        }
    }
}
