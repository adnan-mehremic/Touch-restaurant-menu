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
    public partial class slatko : Form
    {
        private int kolicinaPalacinci = 0;
        private int kolicinaKolac = 0;
        private int kolicinaBanana = 0;
        public slatko()
        {
            InitializeComponent();
        }

        private void hrana_Click(object sender, EventArgs e)
        {
            hrana h = new hrana();
            h.Show();
            this.Hide();
        }

        private void pice_hr_Click(object sender, EventArgs e)
        {
            pice h = new pice();
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

        private void slatko_Load(object sender, EventArgs e)
        {
            popuniListuNarudzbe();
        }

        private void RACUN_TextChanged(object sender, EventArgs e)
        {

        }

        private void help_Click(object sender, EventArgs e)
        {

        }

        private void dodajPalacinci_Click(object sender, EventArgs e)
        {
            if (kolicinaPalacinci == 0) oduzmiPalacinci.Visible = true;
            kolicinaPalacinci += 1;
            Namirnica n = new Namirnica("Palačinci", 0, 0);
            n.Kolicina = kolicinaPalacinci;
            n.Cijena = kolicinaPalacinci * 2;
            racun.Racun = racun.Racun + 2;

            string listBoxItem;

            try
            {
                e_meni.DAO.DAO d = new e_meni.DAO.DAO("localhost", "mydb", "root", "0000");
                if (d.NamirnicaPostoji(n.Naziv))
                {
                    d.AzurirajNamirnicu(n);

                    int x = kolicinaPalacinci - 1;

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

        private void oduzmiPalacinci_Click(object sender, EventArgs e)
        {
            kolicinaPalacinci -= 1;
            Namirnica n = new Namirnica();
            n.Naziv = "Palačinci";
            n.Kolicina = kolicinaPalacinci;
            n.Cijena = kolicinaPalacinci * 2;
            racun.Racun = racun.Racun - 2;


            string espr;

            try
            {
                e_meni.DAO.DAO d = new e_meni.DAO.DAO("localhost", "mydb", "root", "0000");

                d.AzurirajNamirnicu(n);
                int x = kolicinaPalacinci + 1;
                listBoxNarudzba.Items.Remove(Convert.ToString(x) + "x " + n.Naziv + " " + Convert.ToString(2 * x) + " KM");

                espr = Convert.ToString(n.Kolicina) + "x " + n.Naziv + " " + Convert.ToString(2 * n.Kolicina) + " KM";
                listBoxNarudzba.Items.Add(espr);



                if (kolicinaPalacinci == 0)
                {
                    oduzmiPalacinci.Visible = false;
                    listBoxNarudzba.Items.Remove(espr);
                    d.IzbrisiNamirnicu(d.VratiNamirnicaID(n.Naziv));

                }
            }

            catch (Exception izuzetak)
            {

            }
            RACUN.Text = Convert.ToString(racun.Racun) + " KM";
        }

        private void dodajKolac_Click(object sender, EventArgs e)
        {
            if (kolicinaKolac == 0) oduzmiKolac.Visible = true;
            kolicinaKolac += 1;
            Namirnica n = new Namirnica("Kolač", 0, 0);
            n.Kolicina = kolicinaKolac;
            n.Cijena = kolicinaKolac * 3;
            racun.Racun = racun.Racun + 3;

            string listBoxItem;

            try
            {
                e_meni.DAO.DAO d = new e_meni.DAO.DAO("localhost", "mydb", "root", "0000");
                if (d.NamirnicaPostoji(n.Naziv))
                {
                    d.AzurirajNamirnicu(n);

                    int x = kolicinaKolac - 1;

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
            }

            catch (Exception izuzetak)
            {

            }
        }

        private void oduzmiKolac_Click(object sender, EventArgs e)
        {
            kolicinaKolac -= 1;
            Namirnica n = new Namirnica();
            n.Naziv = "Kolač";
            n.Kolicina = kolicinaKolac;
            n.Cijena = kolicinaKolac * 3;
            racun.Racun = racun.Racun - 3;
            try
            {
                e_meni.DAO.DAO d = new e_meni.DAO.DAO("localhost", "mydb", "root", "0000");

                d.AzurirajNamirnicu(n);
                int x = kolicinaKolac + 1;
                listBoxNarudzba.Items.Remove(Convert.ToString(x) + "x " + n.Naziv + " " + Convert.ToString(3 * x) + " KM");

                string kap = Convert.ToString(n.Kolicina) + "x " + n.Naziv + " " + Convert.ToString(3 * n.Kolicina) + " KM";
                listBoxNarudzba.Items.Add(kap);



                if (kolicinaKolac == 0)
                {
                    oduzmiKolac.Visible = false;
                    listBoxNarudzba.Items.Remove(kap);
                    d.IzbrisiNamirnicu(d.VratiNamirnicaID(n.Naziv));

                }
            }

            catch (Exception izuzetak)
            {

            }
            RACUN.Text = Convert.ToString(racun.Racun) + " KM";
        }

        private void dodajBanana_Click(object sender, EventArgs e)
        {
            if (kolicinaBanana == 0) oduzmiBanana.Visible = true;
            kolicinaBanana += 1;
            Namirnica n = new Namirnica("Banana split", 0, 0);
            n.Kolicina = kolicinaBanana;
            n.Cijena = kolicinaBanana * 6;
            racun.Racun = racun.Racun + 6;

            string listBoxItem;

            try
            {
                e_meni.DAO.DAO d = new e_meni.DAO.DAO("localhost", "mydb", "root", "0000");
                if (d.NamirnicaPostoji(n.Naziv))
                {
                    d.AzurirajNamirnicu(n);

                    int x = kolicinaBanana - 1;

                    string item = Convert.ToString(x) + "x " + n.Naziv + " " + Convert.ToString(6 * x) + " KM";


                    listBoxNarudzba.Items.Remove(item);

                }
                else
                {
                    d.DodajNamirnicu(n);

                }



                listBoxItem = Convert.ToString(n.Kolicina) + "x " + n.Naziv + " " + Convert.ToString(6 * n.Kolicina) + " KM";
                listBoxNarudzba.Items.Add(listBoxItem);

                RACUN.Text = Convert.ToString(racun.Racun) + " KM";



            }

            catch (Exception izuzetak)
            {

            }
        }

        private void oduzmiBanana_Click(object sender, EventArgs e)
        {
            kolicinaBanana -= 1;
            Namirnica n = new Namirnica();
            n.Naziv = "Banana split";
            n.Kolicina = kolicinaBanana;
            n.Cijena = kolicinaBanana * 6;
            racun.Racun = racun.Racun - 6;

            string mex;

            try
            {
                e_meni.DAO.DAO d = new e_meni.DAO.DAO("localhost", "mydb", "root", "0000");

                d.AzurirajNamirnicu(n);
                int x = kolicinaBanana + 1;
                listBoxNarudzba.Items.Remove(Convert.ToString(x) + "x " + n.Naziv + " " + Convert.ToString(6 * x) + " KM");

                mex = Convert.ToString(n.Kolicina) + "x " + n.Naziv + " " + Convert.ToString(6 * n.Kolicina) + " KM";
                listBoxNarudzba.Items.Add(mex);



                if (kolicinaBanana == 0)
                {
                    oduzmiBanana.Visible = false;
                    listBoxNarudzba.Items.Remove(mex);
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


                kolicinaPalacinci = d.VratiKolicinuNamirnice("Palačinci");
                kolicinaKolac = d.VratiKolicinuNamirnice("Kolač");
                kolicinaBanana = d.VratiKolicinuNamirnice("Banana split");

                if (kolicinaPalacinci == 0) oduzmiPalacinci.Visible = false;
                if (kolicinaKolac == 0) oduzmiKolac.Visible = false;

                if (kolicinaBanana == 0) oduzmiBanana.Visible = false;

            }



            catch (Exception izuzetak)
            {

            }
        }
    }
}
