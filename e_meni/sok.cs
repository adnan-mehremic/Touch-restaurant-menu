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
    public partial class sok : Form
    {
        public sok()
        {
            InitializeComponent();
        }
        private int kolicinaKola = 0;
        private int kolicinaLimun = 0;
        private int kolicinaNaran = 0;
        private int kolicinaSprite = 0;

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

        private void dodajKolu_Click(object sender, EventArgs e)
        {
            if (kolicinaKola == 0) oduzmiKolu.Visible = true;
            kolicinaKola += 1;
            Namirnica n = new Namirnica("Coca-Cola", 0, 0);
            n.Kolicina = kolicinaKola;
            n.Cijena = kolicinaKola * 3;
            racun.Racun = racun.Racun + 3;

            string listBoxItem;

            try
            {
                e_meni.DAO.DAO d = new e_meni.DAO.DAO("localhost", "mydb", "root", "0000");
                if (d.NamirnicaPostoji(n.Naziv))
                {
                    d.AzurirajNamirnicu(n);

                    int x = kolicinaKola - 1;

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

        private void oduzmiKolu_Click(object sender, EventArgs e)
        {
            kolicinaKola -= 1;
            Namirnica n = new Namirnica();
            n.Naziv = "Coca-Cola";
            n.Kolicina = kolicinaKola;
            n.Cijena = kolicinaKola * 3;
            racun.Racun = racun.Racun - 3;


           

            try
            {
                e_meni.DAO.DAO d = new e_meni.DAO.DAO("localhost", "mydb", "root", "0000");

                d.AzurirajNamirnicu(n);
                int x = kolicinaKola + 1;
                listBoxNarudzba.Items.Remove(Convert.ToString(x) + "x " + n.Naziv + " " + Convert.ToString(3 * x) + " KM");

                string marg = Convert.ToString(n.Kolicina) + "x " + n.Naziv + " " + Convert.ToString(3 * n.Kolicina) + " KM";
                listBoxNarudzba.Items.Add(marg);



                if (kolicinaKola == 0)
                {
                    oduzmiKolu.Visible = false;
                    listBoxNarudzba.Items.Remove(marg);
                    d.IzbrisiNamirnicu(d.VratiNamirnicaID(n.Naziv));

                }
            }

            catch (Exception izuzetak)
            {

            }
            RACUN.Text = Convert.ToString(racun.Racun) + " KM";
        }

        private void dodajLimun_Click(object sender, EventArgs e)
        {
            if (kolicinaLimun == 0) oduzmiLimun.Visible = true;
            kolicinaLimun += 1;
            Namirnica n = new Namirnica("Limunada", 0, 0);
            n.Kolicina = kolicinaLimun;
            n.Cijena = kolicinaLimun * 4;
            racun.Racun = racun.Racun + 4;

            string listBoxItem;

            try
            {
                e_meni.DAO.DAO d = new e_meni.DAO.DAO("localhost", "mydb", "root", "0000");
                if (d.NamirnicaPostoji(n.Naziv))
                {
                    d.AzurirajNamirnicu(n);

                    int x = kolicinaLimun - 1;

                    string item = Convert.ToString(x) + "x " + n.Naziv + " " + Convert.ToString(4 * x) + " KM";


                    listBoxNarudzba.Items.Remove(item);

                }
                else
                {
                    d.DodajNamirnicu(n);

                }



                listBoxItem = Convert.ToString(n.Kolicina) + "x " + n.Naziv + " " + Convert.ToString(4 * n.Kolicina) + " KM";
                listBoxNarudzba.Items.Add(listBoxItem);
                RACUN.Text = Convert.ToString(racun.Racun) + " KM";



                // listBoxUkupno.Items.Add(Convert.ToString(  n.Cijena) + " KM");
            }

            catch (Exception izuzetak)
            {

            }
        }

        private void oduzmiLimun_Click(object sender, EventArgs e)
        {
            kolicinaLimun -= 1;
            Namirnica n = new Namirnica();
            n.Naziv = "Limunada";
            n.Kolicina = kolicinaLimun;
            n.Cijena = kolicinaLimun * 4;
            racun.Racun = racun.Racun - 4;


            

            try
            {
                e_meni.DAO.DAO d = new e_meni.DAO.DAO("localhost", "mydb", "root", "0000");

                d.AzurirajNamirnicu(n);
                int x = kolicinaLimun + 1;
                listBoxNarudzba.Items.Remove(Convert.ToString(x) + "x " + n.Naziv + " " + Convert.ToString(4 * x) + " KM");

                string marg = Convert.ToString(n.Kolicina) + "x " + n.Naziv + " " + Convert.ToString(4 * n.Kolicina) + " KM";
                listBoxNarudzba.Items.Add(marg);



                if (kolicinaLimun == 0)
                {
                    oduzmiLimun.Visible = false;
                    listBoxNarudzba.Items.Remove(marg);
                    d.IzbrisiNamirnicu(d.VratiNamirnicaID(n.Naziv));

                }
            }

            catch (Exception izuzetak)
            {

            }
            RACUN.Text = Convert.ToString(racun.Racun) + " KM";
        }

        

       

        private void dodajNaran_Click(object sender, EventArgs e)
        {

            if (kolicinaNaran == 0) oduzmiNaran.Visible = true;
            kolicinaNaran += 1;
            Namirnica n = new Namirnica("Cijeđena narandža", 0, 0);
            n.Kolicina = kolicinaNaran;
            n.Cijena = kolicinaNaran * 4;
            racun.Racun = racun.Racun + 4;

            string listBoxItem;

            try
            {
                e_meni.DAO.DAO d = new e_meni.DAO.DAO("localhost", "mydb", "root", "0000");
                if (d.NamirnicaPostoji(n.Naziv))
                {
                    d.AzurirajNamirnicu(n);

                    int x = kolicinaNaran - 1;

                    string item = Convert.ToString(x) + "x " + n.Naziv + " " + Convert.ToString(4 * x) + " KM";


                    listBoxNarudzba.Items.Remove(item);

                }
                else
                {
                    d.DodajNamirnicu(n);

                }



                listBoxItem = Convert.ToString(n.Kolicina) + "x " + n.Naziv + " " + Convert.ToString(4 * n.Kolicina) + " KM";
                listBoxNarudzba.Items.Add(listBoxItem);
                RACUN.Text = Convert.ToString(racun.Racun) + " KM";

            }

            catch (Exception izuzetak)
            {

            }
        }

        private void oduzmiNaran_Click(object sender, EventArgs e)
        {
            kolicinaNaran -= 1;
            Namirnica n = new Namirnica();
            n.Naziv = "Cijeđena narandža";
            n.Kolicina = kolicinaNaran;
            n.Cijena = kolicinaNaran * 4;
            racun.Racun = racun.Racun - 4;

            try
            {
                e_meni.DAO.DAO d = new e_meni.DAO.DAO("localhost", "mydb", "root", "0000");

                d.AzurirajNamirnicu(n);
                int x = kolicinaNaran + 1;
                listBoxNarudzba.Items.Remove(Convert.ToString(x) + "x " + n.Naziv + " " + Convert.ToString(4 * x) + " KM");

                string marg = Convert.ToString(n.Kolicina) + "x " + n.Naziv + " " + Convert.ToString(4 * n.Kolicina) + " KM";
                listBoxNarudzba.Items.Add(marg);

                if (kolicinaNaran == 0)
                {
                    oduzmiNaran.Visible = false;
                    listBoxNarudzba.Items.Remove(marg);
                    d.IzbrisiNamirnicu(d.VratiNamirnicaID(n.Naziv));

                }
            }

            catch (Exception izuzetak)
            {

            }
            RACUN.Text = Convert.ToString(racun.Racun) + " KM";
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

        private void sok_Load(object sender, EventArgs e)
        {
            popuniListuNarudzbe();
        }

        private void PosaljiNarudzbu_Click(object sender, EventArgs e)
        {
            posaljiNarudzbu pn = new posaljiNarudzbu();
            pn.Show();
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

                kolicinaKola = d.VratiKolicinuNamirnice("Coca-Cola");
                kolicinaLimun = d.VratiKolicinuNamirnice("Limunada");
                kolicinaNaran = d.VratiKolicinuNamirnice("Cijeđena narandža");
                kolicinaSprite = d.VratiKolicinuNamirnice("Sprite");

                if (kolicinaKola == 0) oduzmiKolu.Visible = false;

                if (kolicinaLimun == 0) oduzmiLimun.Visible = false;
                if (kolicinaNaran == 0) oduzmiNaran.Visible = false;


            }



            catch (Exception izuzetak)
            {

            }
        }
    }
}
