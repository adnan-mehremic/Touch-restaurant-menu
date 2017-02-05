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
using System.Text.RegularExpressions;

namespace e_meni
{
    public partial class salate : Form
    {

        private int kolicinaSezonska = 0;
        private int kolicinaPileca = 0;
        private int kolicinaRiblja = 0;
        public salate()
        {
            InitializeComponent();
        }

        private void pice_hr_Click(object sender, EventArgs e)
        {
            pice p = new pice();
            p.Show();
            this.Hide();
        }

        private void slatko_hr_Click(object sender, EventArgs e)
        {
            slatko s = new slatko();
            s.Show();
            this.Hide();
        }

        private void PosaljiNarudzbu_Click(object sender, EventArgs e)
        {
            posaljiNarudzbu pn = new posaljiNarudzbu();
            pn.Show();
            this.Hide();
        }

        private void nazad_pica_Click(object sender, EventArgs e)
        {
            hrana h = new hrana();
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

        private void dodajSezonska_Click(object sender, EventArgs e)
        {
            if (kolicinaSezonska == 0) oduzmiSezonska.Visible = true;
            kolicinaSezonska += 1;
            Namirnica n = new Namirnica("Sezonska salata", 0, 0);
            n.Kolicina = kolicinaSezonska;
            n.Cijena = kolicinaSezonska * 2;
            racun.Racun = racun.Racun + 2;

            string listBoxItem;

            try
            {
                e_meni.DAO.DAO d = new e_meni.DAO.DAO("localhost", "mydb", "root", "0000");
                if (d.NamirnicaPostoji(n.Naziv))
                {
                    d.AzurirajNamirnicu(n);

                    int x = kolicinaSezonska - 1;

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

        private void oduzmiSezonska_Click(object sender, EventArgs e)
        {
            kolicinaSezonska -= 1;
            Namirnica n = new Namirnica();
            n.Naziv = "Sezonska salata";
            n.Kolicina = kolicinaSezonska;
            n.Cijena = kolicinaSezonska * 2;
            racun.Racun = racun.Racun - 2;


            string sez;

            try
            {
                e_meni.DAO.DAO d = new e_meni.DAO.DAO("localhost", "mydb", "root", "0000");

                d.AzurirajNamirnicu(n);
                int x = kolicinaSezonska + 1;
                listBoxNarudzba.Items.Remove(Convert.ToString(x) + "x " + n.Naziv + " " + Convert.ToString(2 * x) + " KM");

                sez = Convert.ToString(n.Kolicina) + "x " + n.Naziv + " " + Convert.ToString(2 * n.Kolicina) + " KM";
                listBoxNarudzba.Items.Add(sez);



                if (kolicinaSezonska == 0)
                {
                    oduzmiSezonska.Visible = false;
                    listBoxNarudzba.Items.Remove(sez);
                    d.IzbrisiNamirnicu(d.VratiNamirnicaID(n.Naziv));

                }
            }

            catch (Exception izuzetak)
            {

            }
            RACUN.Text = Convert.ToString(racun.Racun) + " KM";
        }

        private void oduzmiPileca_Click(object sender, EventArgs e)
        {
            kolicinaPileca -= 1;
            Namirnica n = new Namirnica();
            n.Naziv = "Pileća salata";
            n.Kolicina = kolicinaPileca;
            n.Cijena = kolicinaPileca * 5;
            racun.Racun = racun.Racun - 5;


            string marg;

            try
            {
                e_meni.DAO.DAO d = new e_meni.DAO.DAO("localhost", "mydb", "root", "0000");

                d.AzurirajNamirnicu(n);
                int x = kolicinaPileca + 1;
                listBoxNarudzba.Items.Remove(Convert.ToString(x) + "x " + n.Naziv + " " + Convert.ToString(5 * x) + " KM");

                marg = Convert.ToString(n.Kolicina) + "x " + n.Naziv + " " + Convert.ToString(5 * n.Kolicina) + " KM";
                listBoxNarudzba.Items.Add(marg);



                if (kolicinaPileca == 0)
                {
                    oduzmiPileca.Visible = false;
                    listBoxNarudzba.Items.Remove(marg);
                    d.IzbrisiNamirnicu(d.VratiNamirnicaID(n.Naziv));

                }
            }

            catch (Exception izuzetak)
            {

            }
            RACUN.Text = Convert.ToString(racun.Racun) + " KM";
        }

        private void dodajPileca_Click(object sender, EventArgs e)
        {
            if (kolicinaPileca == 0) oduzmiPileca.Visible = true;
            kolicinaPileca += 1;
            Namirnica n = new Namirnica("Pileća salata", 0, 0);
            n.Kolicina = kolicinaPileca;
            n.Cijena = kolicinaPileca * 5;
            racun.Racun = racun.Racun + 5;

            string listBoxItem;

            try
            {
                e_meni.DAO.DAO d = new e_meni.DAO.DAO("localhost", "mydb", "root", "0000");
                if (d.NamirnicaPostoji(n.Naziv))
                {
                    d.AzurirajNamirnicu(n);

                    int x = kolicinaPileca - 1;

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



                // listBoxUkupno.Items.Add(Convert.ToString(  n.Cijena) + " KM");
            }

            catch (Exception izuzetak)
            {

            }
        }

        private void dodajRiblja_Click(object sender, EventArgs e)
        {
            if (kolicinaRiblja == 0) oduzmiRiblja.Visible = true;
            kolicinaRiblja += 1;
            Namirnica n = new Namirnica("Riblja salata", 0, 0);
            n.Kolicina = kolicinaRiblja;
            n.Cijena = kolicinaRiblja * 7;
            racun.Racun = racun.Racun + 7;

            string listBoxItem;

            try
            {
                e_meni.DAO.DAO d = new e_meni.DAO.DAO("localhost", "mydb", "root", "0000");
                if (d.NamirnicaPostoji(n.Naziv))
                {
                    d.AzurirajNamirnicu(n);

                    int x = kolicinaRiblja - 1;

                    string item = Convert.ToString(x) + "x " + n.Naziv + " " + Convert.ToString(7 * x) + " KM";


                    listBoxNarudzba.Items.Remove(item);

                }
                else
                {
                    d.DodajNamirnicu(n);

                }



                listBoxItem = Convert.ToString(n.Kolicina) + "x " + n.Naziv + " " + Convert.ToString(7 * n.Kolicina) + " KM";
                listBoxNarudzba.Items.Add(listBoxItem);
                RACUN.Text = Convert.ToString(racun.Racun) + " KM";



                // listBoxUkupno.Items.Add(Convert.ToString(  n.Cijena) + " KM");
            }

            catch (Exception izuzetak)
            {

            }
        }

        private void oduzmiRiblja_Click(object sender, EventArgs e)
        {
            kolicinaRiblja -= 1;
            Namirnica n = new Namirnica();
            n.Naziv = "Riblja salata";
            n.Kolicina = kolicinaRiblja;
            n.Cijena = kolicinaRiblja * 7;
            racun.Racun = racun.Racun - 7;


            string marg;

            try
            {
                e_meni.DAO.DAO d = new e_meni.DAO.DAO("localhost", "mydb", "root", "0000");

                d.AzurirajNamirnicu(n);
                int x = kolicinaRiblja + 1;
                listBoxNarudzba.Items.Remove(Convert.ToString(x) + "x " + n.Naziv + " " + Convert.ToString(7 * x) + " KM");

                marg = Convert.ToString(n.Kolicina) + "x " + n.Naziv + " " + Convert.ToString(7 * n.Kolicina) + " KM";
                listBoxNarudzba.Items.Add(marg);



                if (kolicinaRiblja == 0)
                {
                    oduzmiRiblja.Visible = false;
                    listBoxNarudzba.Items.Remove(marg);
                    d.IzbrisiNamirnicu(d.VratiNamirnicaID(n.Naziv));

                }
            }

            catch (Exception izuzetak)
            {

            }
            RACUN.Text = Convert.ToString(racun.Racun) + " KM";
        }

        private void salate_Load(object sender, EventArgs e)
        {
            popuniListuNarudzbe();
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


                kolicinaSezonska = d.VratiKolicinuNamirnice("Sezonska salata");
                kolicinaPileca = d.VratiKolicinuNamirnice("Pileća salata");
                kolicinaRiblja = d.VratiKolicinuNamirnice("Riblja salata");

                if (kolicinaSezonska == 0) oduzmiSezonska.Visible = false;
                if (kolicinaPileca == 0) oduzmiPileca.Visible = false;

                if (kolicinaRiblja == 0) oduzmiRiblja.Visible = false;

            }
            catch (Exception izuzetak)
            {

            }
        }
    }
}
