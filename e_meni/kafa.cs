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
    public partial class kafa : Form
    {
        public kafa()
        {
            InitializeComponent();
        }
        private int kolicinaEspreso=0;
        private int kolicinaMakiato = 0;
        private int kolicinaKapucino = 0;
        private int kolicinaBosanska = 0;

        private void nazad_pica_Click(object sender, EventArgs e)
        {
            pice h = new pice();
            h.Show();
            this.Hide();
        }

        private void PosaljiNarudzbu_Click(object sender, EventArgs e)
        {
            posaljiNarudzbu pn = new posaljiNarudzbu();
            pn.Show();
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

        private void dodajEspreso_Click(object sender, EventArgs e)
        {
            if (kolicinaEspreso == 0) oduzmiEspreso.Visible = true;
            kolicinaEspreso += 1;
            Namirnica n = new Namirnica("Espresso", 0, 0);
            n.Kolicina = kolicinaEspreso;
            n.Cijena = kolicinaEspreso * 2;
            racun.Racun = racun.Racun + 2;

            string listBoxItem;

            try
            {
                e_meni.DAO.DAO d = new e_meni.DAO.DAO("localhost", "mydb", "root", "0000");
                if (d.NamirnicaPostoji(n.Naziv))
                {
                    d.AzurirajNamirnicu(n);

                    int x = kolicinaEspreso - 1;

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

        private void oduzmiEspreso_Click(object sender, EventArgs e)
        {
            kolicinaEspreso -= 1;
            Namirnica n = new Namirnica();
            n.Naziv = "Espresso";
            n.Kolicina = kolicinaEspreso;
            n.Cijena = kolicinaEspreso * 2;
            racun.Racun = racun.Racun - 2;


            string espr;

            try
            {
                e_meni.DAO.DAO d = new e_meni.DAO.DAO("localhost", "mydb", "root", "0000");

                d.AzurirajNamirnicu(n);
                int x = kolicinaEspreso + 1;
                listBoxNarudzba.Items.Remove(Convert.ToString(x) + "x " + n.Naziv + " " + Convert.ToString(2 * x) + " KM");

                espr = Convert.ToString(n.Kolicina) + "x " + n.Naziv + " " + Convert.ToString(2 * n.Kolicina) + " KM";
                listBoxNarudzba.Items.Add(espr);



                if (kolicinaEspreso == 0)
                {
                    oduzmiEspreso.Visible = false;
                    listBoxNarudzba.Items.Remove(espr);
                    d.IzbrisiNamirnicu(d.VratiNamirnicaID(n.Naziv));

                }
            }

            catch (Exception izuzetak)
            {

            }
            RACUN.Text = Convert.ToString(racun.Racun) + " KM";
        }

        private void kafa_Load(object sender, EventArgs e)
        {
            popuniListuNarudzbe();
        }

        private void dodajMakiato_Click(object sender, EventArgs e)
        {
            if (kolicinaMakiato == 0) oduzmiMakiato.Visible = true;
            kolicinaMakiato += 1;
            Namirnica n = new Namirnica("Macchiato", 0, 0);
            n.Kolicina = kolicinaMakiato;
            n.Cijena = kolicinaMakiato * 2;
            racun.Racun = racun.Racun + 2;

            string listBoxItem;

            try
            {
                e_meni.DAO.DAO d = new e_meni.DAO.DAO("localhost", "mydb", "root", "0000");
                if (d.NamirnicaPostoji(n.Naziv))
                {
                    d.AzurirajNamirnicu(n);

                    int x = kolicinaMakiato - 1;

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



               
            }

            catch (Exception izuzetak)
            {

            }
        }

        private void oduzmiMakiato_Click(object sender, EventArgs e)
        {
            kolicinaMakiato -= 1;
            Namirnica n = new Namirnica();
            n.Naziv = "Macchiato";
            n.Kolicina = kolicinaMakiato;
            n.Cijena = kolicinaMakiato * 2;
            racun.Racun = racun.Racun - 2;

            try
            {
                e_meni.DAO.DAO d = new e_meni.DAO.DAO("localhost", "mydb", "root", "0000");

                d.AzurirajNamirnicu(n);
                int x = kolicinaMakiato + 1;
                listBoxNarudzba.Items.Remove(Convert.ToString(x) + "x " + n.Naziv + " " + Convert.ToString(2 * x) + " KM");

                string xxx = Convert.ToString(n.Kolicina) + "x " + n.Naziv + " " + Convert.ToString(2 * n.Kolicina) + " KM";
                listBoxNarudzba.Items.Add(xxx);



                if (kolicinaMakiato == 0)
                {
                    oduzmiMakiato.Visible = false;
                    listBoxNarudzba.Items.Remove(xxx);
                    d.IzbrisiNamirnicu(d.VratiNamirnicaID(n.Naziv));

                }
            }

            catch (Exception izuzetak)
            {

            }
            RACUN.Text = Convert.ToString(racun.Racun) + " KM";
        }

        private void dodajKapucino_Click(object sender, EventArgs e)
        {
            if (kolicinaKapucino == 0) oduzmiKapucino.Visible = true;
            kolicinaKapucino += 1;
            Namirnica n = new Namirnica("Cappuchino", 0, 0);
            n.Kolicina = kolicinaKapucino;
            n.Cijena = kolicinaKapucino * 3;
            racun.Racun = racun.Racun + 3;

            string listBoxItem;

            try
            {
                e_meni.DAO.DAO d = new e_meni.DAO.DAO("localhost", "mydb", "root", "0000");
                if (d.NamirnicaPostoji(n.Naziv))
                {
                    d.AzurirajNamirnicu(n);

                    int x = kolicinaKapucino - 1;

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

        private void oduzmiKapucino_Click(object sender, EventArgs e)
        {
            kolicinaKapucino -= 1;
            Namirnica n = new Namirnica();
            n.Naziv = "Cappuchino";
            n.Kolicina = kolicinaKapucino;
            n.Cijena = kolicinaKapucino * 3;
            racun.Racun = racun.Racun - 3;
          try
            {
                e_meni.DAO.DAO d = new e_meni.DAO.DAO("localhost", "mydb", "root", "0000");

                d.AzurirajNamirnicu(n);
                int x = kolicinaKapucino + 1;
                listBoxNarudzba.Items.Remove(Convert.ToString(x) + "x " + n.Naziv + " " + Convert.ToString(3 * x) + " KM");

                string kap = Convert.ToString(n.Kolicina) + "x " + n.Naziv + " " + Convert.ToString(3 * n.Kolicina) + " KM";
                listBoxNarudzba.Items.Add(kap);



                if (kolicinaKapucino == 0)
                {
                    oduzmiKapucino.Visible = false;
                    listBoxNarudzba.Items.Remove(kap);
                    d.IzbrisiNamirnicu(d.VratiNamirnicaID(n.Naziv));

                }
            }

            catch (Exception izuzetak)
            {

            }
            RACUN.Text = Convert.ToString(racun.Racun) + " KM";
        }

        

      
                

        private void hrana_Click(object sender, EventArgs e)
        {
            hrana p = new hrana();
            p.Show();
            this.Hide();
        }

        private void slatko_Click(object sender, EventArgs e)
        {
            slatko s = new slatko();
            s.Show();
            this.Hide();
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

                kolicinaEspreso = d.VratiKolicinuNamirnice("Espresso");
                kolicinaMakiato = d.VratiKolicinuNamirnice("Macchiato");
                kolicinaKapucino = d.VratiKolicinuNamirnice("Cappuchino");
                kolicinaBosanska = d.VratiKolicinuNamirnice("Bosanska kahva");

                if (kolicinaEspreso == 0) oduzmiEspreso.Visible = false;
                if (kolicinaMakiato == 0) oduzmiMakiato.Visible = false;
                if (kolicinaKapucino == 0) oduzmiKapucino.Visible = false;


            }
            catch (Exception izuzetak)
            {

            }
        }
    }
    }

