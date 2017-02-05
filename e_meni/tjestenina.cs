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
    public partial class tjestenina : Form
    {
        private int kolicinaSpageti = 0;
        private int kolicinaMakaroni = 0;
        private int kolicinaLazanje = 0;
        public tjestenina()
        {
            InitializeComponent();
        }

        private void slatko_Click(object sender, EventArgs e)
        {
            slatko s = new slatko();
            s.Show();
            this.Hide();
        }

        private void nazad_pica_Click(object sender, EventArgs e)
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

        private void PosaljiNarudzbu_Click(object sender, EventArgs e)
        {
            posaljiNarudzbu p = new posaljiNarudzbu();
            p.Show();
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

        private void dodajLazanje_Click(object sender, EventArgs e)
        {
            if (kolicinaLazanje == 0) oduzmiLazanje.Visible = true;
            kolicinaLazanje += 1;
            Namirnica n = new Namirnica("Lazanje", 0, 0);
            n.Kolicina = kolicinaLazanje;
            n.Cijena = kolicinaLazanje * 7;
            racun.Racun = racun.Racun + 7;

            string listBoxItem;

            try
            {
                e_meni.DAO.DAO d = new e_meni.DAO.DAO("localhost", "mydb", "root", "0000");
                if (d.NamirnicaPostoji(n.Naziv))
                {
                    d.AzurirajNamirnicu(n);

                    int x = kolicinaLazanje - 1;

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



            }

            catch (Exception izuzetak)
            {

            }
        }

        private void tjestenina_Load(object sender, EventArgs e)
        {
            popuniListuNarudzbe();
        }

        private void oduzmiLazanje_Click(object sender, EventArgs e)
        {
            kolicinaLazanje -= 1;
            Namirnica n = new Namirnica();
            n.Naziv = "Lazanje";
            n.Kolicina = kolicinaLazanje;
            n.Cijena = kolicinaLazanje * 7;
            racun.Racun = racun.Racun - 7;

            string mex;

            try
            {
                e_meni.DAO.DAO d = new e_meni.DAO.DAO("localhost", "mydb", "root", "0000");

                d.AzurirajNamirnicu(n);
                int x = kolicinaLazanje + 1;
                listBoxNarudzba.Items.Remove(Convert.ToString(x) + "x " + n.Naziv + " " + Convert.ToString(7 * x) + " KM");

                mex = Convert.ToString(n.Kolicina) + "x " + n.Naziv + " " + Convert.ToString(7 * n.Kolicina) + " KM";
                listBoxNarudzba.Items.Add(mex);



                if (kolicinaLazanje == 0)
                {
                    oduzmiLazanje.Visible = false;
                    listBoxNarudzba.Items.Remove(mex);
                    d.IzbrisiNamirnicu(d.VratiNamirnicaID(n.Naziv));

                }
            }

            catch (Exception izuzetak)
            {

            }
            RACUN.Text = Convert.ToString(racun.Racun) + " KM";
        }

        private void dodajMakaroni_Click(object sender, EventArgs e)
        {
            if (kolicinaMakaroni == 0) oduzmiMakaroni.Visible = true;
            kolicinaMakaroni += 1;
            Namirnica n = new Namirnica("Makaroni", 0, 0);
            n.Kolicina = kolicinaMakaroni;
            n.Cijena = kolicinaMakaroni * 5;
            racun.Racun = racun.Racun + 5;

            string listBoxItem;

            try
            {
                e_meni.DAO.DAO d = new e_meni.DAO.DAO("localhost", "mydb", "root", "0000");
                if (d.NamirnicaPostoji(n.Naziv))
                {
                    d.AzurirajNamirnicu(n);

                    int x = kolicinaMakaroni - 1;

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

        private void dodajSpageti_Click(object sender, EventArgs e)
        {
            if (kolicinaSpageti == 0) oduzmiSpageti.Visible = true;
            kolicinaSpageti += 1;
            Namirnica n = new Namirnica("Špageti", 0, 0);
            n.Kolicina = kolicinaSpageti;
            n.Cijena = kolicinaSpageti * 6;
            racun.Racun = racun.Racun + 6;

            string listBoxItem;

            try
            {
                e_meni.DAO.DAO d = new e_meni.DAO.DAO("localhost", "mydb", "root", "0000");
                if (d.NamirnicaPostoji(n.Naziv))
                {
                    d.AzurirajNamirnicu(n);

                    int x = kolicinaSpageti - 1;

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

        private void oduzmiSpageti_Click(object sender, EventArgs e)
        {
            kolicinaSpageti -= 1;
            Namirnica n = new Namirnica();
            n.Naziv = "Špageti";
            n.Kolicina = kolicinaSpageti;
            n.Cijena = kolicinaSpageti * 6;
            racun.Racun = racun.Racun - 6;

            string mex;

            try
            {
                e_meni.DAO.DAO d = new e_meni.DAO.DAO("localhost", "mydb", "root", "0000");

                d.AzurirajNamirnicu(n);
                int x = kolicinaSpageti + 1;
                listBoxNarudzba.Items.Remove(Convert.ToString(x) + "x " + n.Naziv + " " + Convert.ToString(6 * x) + " KM");

                mex = Convert.ToString(n.Kolicina) + "x " + n.Naziv + " " + Convert.ToString(6 * n.Kolicina) + " KM";
                listBoxNarudzba.Items.Add(mex);



                if (kolicinaSpageti == 0)
                {
                    oduzmiSpageti.Visible = false;
                    listBoxNarudzba.Items.Remove(mex);
                    d.IzbrisiNamirnicu(d.VratiNamirnicaID(n.Naziv));

                }
            }

            catch (Exception izuzetak)
            {

            }
            RACUN.Text = Convert.ToString(racun.Racun) + " KM";
        }

        private void oduzmiMakaroni_Click(object sender, EventArgs e)
        {
            kolicinaMakaroni -= 1;
            Namirnica n = new Namirnica();
            n.Naziv = "Makaroni";
            n.Kolicina = kolicinaMakaroni;
            n.Cijena = kolicinaMakaroni * 5;
            racun.Racun = racun.Racun - 5;

            string kapri;

            try
            {
                e_meni.DAO.DAO d = new e_meni.DAO.DAO("localhost", "mydb", "root", "0000");

                d.AzurirajNamirnicu(n);
                int x = kolicinaMakaroni + 1;
                listBoxNarudzba.Items.Remove(Convert.ToString(x) + "x " + n.Naziv + " " + Convert.ToString(5 * x) + " KM");

                kapri = Convert.ToString(n.Kolicina) + "x " + n.Naziv + " " + Convert.ToString(5 * n.Kolicina) + " KM";
                listBoxNarudzba.Items.Add(kapri);



                if (kolicinaMakaroni == 0)
                {
                    oduzmiMakaroni.Visible = false;
                    listBoxNarudzba.Items.Remove(kapri);
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


                kolicinaSpageti = d.VratiKolicinuNamirnice("Špageti");
                kolicinaMakaroni = d.VratiKolicinuNamirnice("Makaroni");
                kolicinaLazanje = d.VratiKolicinuNamirnice("Lazanje");

                if (kolicinaSpageti == 0) oduzmiSpageti.Visible = false;
                if (kolicinaMakaroni == 0) oduzmiMakaroni.Visible = false;

                if (kolicinaLazanje == 0) oduzmiLazanje.Visible = false;

            }



            catch (Exception izuzetak)
            {

            }
        }
    }
}
