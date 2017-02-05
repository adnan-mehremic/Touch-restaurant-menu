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
    public partial class caj : Form
    {
        public caj()
        {
            InitializeComponent();
        }

        private int kolicinaKamilica = 0;
        private int kolicinaMenta = 0;
        private int kolicinaVocni = 0;
        private int kolicinaTurski = 0;
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

        private void nazad_pica_Click(object sender, EventArgs e)
        {
            pice p = new pice();
            p.Show();
            this.Hide();

        }

        private void dodajKamilica_Click(object sender, EventArgs e)
        {
            if (kolicinaKamilica == 0) oduzmiKamilica.Visible = true;
            kolicinaKamilica += 1;
            Namirnica n = new Namirnica("Kamilica čaj", 0, 0);
            n.Kolicina = kolicinaKamilica;
            n.Cijena = kolicinaKamilica * 2;
            racun.Racun = racun.Racun + 2;

            string listBoxItem;

            try
            {
                e_meni.DAO.DAO d = new e_meni.DAO.DAO("localhost", "mydb", "root", "0000");
                if (d.NamirnicaPostoji(n.Naziv))
                {
                    d.AzurirajNamirnicu(n);

                    int x = kolicinaKamilica - 1;

                    string item = Convert.ToString(x) + "x " + n.Naziv + " " + Convert.ToString(2 * x) + " KM";


                    listBoxNarudzba.Items.Remove(item);

                }
                else
                {
                    d.DodajNamirnicu(n);

                }



                listBoxItem = Convert.ToString(n.Kolicina) + "x " + n.Naziv + " " + Convert.ToString(2* n.Kolicina) + " KM";
                listBoxNarudzba.Items.Add(listBoxItem);
                RACUN.Text = Convert.ToString(racun.Racun) + " KM";



                // listBoxUkupno.Items.Add(Convert.ToString(  n.Cijena) + " KM");
            }

            catch (Exception izuzetak)
            {

            }
        }

        private void oduzmiKamilica_Click(object sender, EventArgs e)
        {
            kolicinaKamilica -= 1;
            Namirnica n = new Namirnica();
            n.Naziv = "Kamilica čaj";
            n.Kolicina = kolicinaKamilica;
            n.Cijena = kolicinaKamilica * 2;
            racun.Racun = racun.Racun - 2;


           

            try
            {
                e_meni.DAO.DAO d = new e_meni.DAO.DAO("localhost", "mydb", "root", "0000");

                d.AzurirajNamirnicu(n);
                int x = kolicinaKamilica + 1;
                listBoxNarudzba.Items.Remove(Convert.ToString(x) + "x " + n.Naziv + " " + Convert.ToString(2 * x) + " KM");

                string marg = Convert.ToString(n.Kolicina) + "x " + n.Naziv + " " + Convert.ToString(2 * n.Kolicina) + " KM";
                listBoxNarudzba.Items.Add(marg);



                if (kolicinaKamilica == 0)
                {
                    oduzmiKamilica.Visible = false;
                    listBoxNarudzba.Items.Remove(marg);
                    d.IzbrisiNamirnicu(d.VratiNamirnicaID(n.Naziv));

                }
            }

            catch (Exception izuzetak)
            {

            }
            RACUN.Text = Convert.ToString(racun.Racun) + " KM";
        }

        private void dodajMenta_Click(object sender, EventArgs e)
        {
            if (kolicinaMenta == 0) oduzmiMenta.Visible = true;
            kolicinaMenta += 1;
            Namirnica n = new Namirnica("Menta čaj", 0, 0);
            n.Kolicina = kolicinaMenta;
            n.Cijena = kolicinaMenta * 2;
            racun.Racun = racun.Racun + 2;

            string listBoxItem;

            try
            {
                e_meni.DAO.DAO d = new e_meni.DAO.DAO("localhost", "mydb", "root", "0000");
                if (d.NamirnicaPostoji(n.Naziv))
                {
                    d.AzurirajNamirnicu(n);

                    int x = kolicinaMenta - 1;

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

        private void oduzmiMenta_Click(object sender, EventArgs e)
        {
            kolicinaMenta -= 1;
            Namirnica n = new Namirnica();
            n.Naziv = "Menta čaj";
            n.Kolicina = kolicinaMenta;
            n.Cijena = kolicinaMenta * 2;
            racun.Racun = racun.Racun - 2;


           

            try
            {
                e_meni.DAO.DAO d = new e_meni.DAO.DAO("localhost", "mydb", "root", "0000");

                d.AzurirajNamirnicu(n);
                int x = kolicinaMenta + 1;
                listBoxNarudzba.Items.Remove(Convert.ToString(x) + "x " + n.Naziv + " " + Convert.ToString(2 * x) + " KM");

                string marg = Convert.ToString(n.Kolicina) + "x " + n.Naziv + " " + Convert.ToString(2 * n.Kolicina) + " KM";
                listBoxNarudzba.Items.Add(marg);



                if (kolicinaMenta == 0)
                {
                    oduzmiMenta.Visible = false;
                    listBoxNarudzba.Items.Remove(marg);
                    d.IzbrisiNamirnicu(d.VratiNamirnicaID(n.Naziv));

                }
            }

            catch (Exception izuzetak)
            {

            }
            RACUN.Text = Convert.ToString(racun.Racun) + " KM";
        }

        

        

        private void dodajTurski_Click(object sender, EventArgs e)
        {
            if (kolicinaTurski == 0) oduzmiTurski.Visible = true;
            kolicinaTurski += 1;
            Namirnica n = new Namirnica("Turski čaj", 0, 0);
            n.Kolicina = kolicinaTurski;
            n.Cijena = kolicinaTurski * 1;
            racun.Racun = racun.Racun + 1;

            string listBoxItem;

            try
            {
                e_meni.DAO.DAO d = new e_meni.DAO.DAO("localhost", "mydb", "root", "0000");
                if (d.NamirnicaPostoji(n.Naziv))
                {
                    d.AzurirajNamirnicu(n);

                    int x = kolicinaTurski - 1;

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

        private void oduzmiTurski_Click(object sender, EventArgs e)
        {
            kolicinaTurski -= 1;
            Namirnica n = new Namirnica();
            n.Naziv = "Turski čaj";
            n.Kolicina = kolicinaTurski;
            n.Cijena = kolicinaTurski * 1;
            racun.Racun = racun.Racun - 1;
            try
            {
                e_meni.DAO.DAO d = new e_meni.DAO.DAO("localhost", "mydb", "root", "0000");

                d.AzurirajNamirnicu(n);
                int x = kolicinaTurski + 1;
                listBoxNarudzba.Items.Remove(Convert.ToString(x) + "x " + n.Naziv + " " + Convert.ToString(1 * x) + " KM");

                string marg = Convert.ToString(n.Kolicina) + "x " + n.Naziv + " " + Convert.ToString(1 * n.Kolicina) + " KM";
                listBoxNarudzba.Items.Add(marg);



                if (kolicinaTurski == 0)
                {
                    oduzmiTurski.Visible = false;
                    listBoxNarudzba.Items.Remove(marg);
                    d.IzbrisiNamirnicu(d.VratiNamirnicaID(n.Naziv));

                }
            }

            catch (Exception izuzetak)
            {

            }
            RACUN.Text = Convert.ToString(racun.Racun) + " KM";
        }

        private void caj_Load(object sender, EventArgs e)
        {
            popuniListuNarudzbe();
        }

        private void hrana_Click(object sender, EventArgs e)
        {
            hrana p = new hrana();
            p.Show();
            this.Hide();
        }

        private void slatko_Click(object sender, EventArgs e)
        {
            slatko p = new slatko();
            p.Show();
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

                kolicinaKamilica = d.VratiKolicinuNamirnice("Kamilica čaj");
                kolicinaMenta = d.VratiKolicinuNamirnice("Menta čaj");
                kolicinaVocni = d.VratiKolicinuNamirnice("Voćni čaj");
                kolicinaTurski = d.VratiKolicinuNamirnice("Turski čaj");

                if (kolicinaKamilica == 0) oduzmiKamilica.Visible = false;
                if (kolicinaMenta == 0) oduzmiMenta.Visible = false;
               
                if (kolicinaTurski == 0) oduzmiTurski.Visible = false;

            }



            catch (Exception izuzetak)
            {

            }
}

private void listBoxNarudzba_Click(object sender, EventArgs e)
{

}
}
}
