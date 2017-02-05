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
    public partial class pizza : Form
    {
        private int kolicinaMargarita = 0;
        private int kolicinaKapricosa = 0;
        private int kolicinaFungi = 0;
        private int kolicinaMexicana = 0;


        public pizza()
        {
            InitializeComponent();
        }
        
        public void dodajMargarita_Click(object sender, EventArgs e)
        {
            if (kolicinaMargarita == 0) oduzmiMargarita.Visible = true;
            kolicinaMargarita += 1;
            Namirnica n = new Namirnica("Margarita", 0, 0);
            n.Kolicina = kolicinaMargarita;
            n.Cijena = kolicinaMargarita * 3;
            racun.Racun = racun.Racun + 3;

            string listBoxItem;
             
            try
            {
                e_meni.DAO.DAO d = new e_meni.DAO.DAO("localhost", "mydb", "root", "0000");
                if (d.NamirnicaPostoji(n.Naziv))
                {
                    d.AzurirajNamirnicu(n);
                  
                   int x = kolicinaMargarita - 1;
                   
                    string item = Convert.ToString(x) + "x " + n.Naziv + " " + Convert.ToString(3*x) + " KM";
                   

                    listBoxNarudzba.Items.Remove(item);
                    
                }
                else
                {
                    d.DodajNamirnicu(n);

                }
                
             
             
                listBoxItem = Convert.ToString(n.Kolicina) + "x " + n.Naziv + " " + Convert.ToString(3*n.Kolicina) + " KM";
                listBoxNarudzba.Items.Add(listBoxItem);
                RACUN.Text = Convert.ToString(racun.Racun) + " KM"; 


                 
               // listBoxUkupno.Items.Add(Convert.ToString(  n.Cijena) + " KM");
            }

            catch(Exception izuzetak)
            {
                
            }

            }

        private void nazad_pica_Click(object sender, EventArgs e)
        {
            hrana h = new hrana();
            h.Show();
            this.Hide();
        }

        private void Narudzba_TextChanged(object sender, EventArgs e)
        {

        }

        private void oduzmiMargarita_Click(object sender, EventArgs e)
        {
            kolicinaMargarita -= 1;
            Namirnica n = new Namirnica();
            n.Naziv = "Margarita";
            n.Kolicina = kolicinaMargarita;
            n.Cijena = kolicinaMargarita * 3;
            racun.Racun = racun.Racun-3;
           

            string marg;

            try
            {
                e_meni.DAO.DAO d = new e_meni.DAO.DAO("localhost", "mydb", "root", "0000");

                d.AzurirajNamirnicu(n);
                int x = kolicinaMargarita + 1;
                listBoxNarudzba.Items.Remove(Convert.ToString(x) + "x " + n.Naziv + " " + Convert.ToString(3*x) + " KM");

                marg = Convert.ToString(n.Kolicina) + "x " + n.Naziv + " " + Convert.ToString(3*n.Kolicina) + " KM";
                listBoxNarudzba.Items.Add(marg);
               
               

                if (kolicinaMargarita == 0)
                {
                    oduzmiMargarita.Visible = false;
                    listBoxNarudzba.Items.Remove(marg);
                    d.IzbrisiNamirnicu(d.VratiNamirnicaID(n.Naziv));
                    
                }
            }

            catch (Exception izuzetak)
            {
                
            }
            RACUN.Text = Convert.ToString(racun.Racun) + " KM";

        }

        private void listBoxNarudzba_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void pizza_Load(object sender, EventArgs e)
        {
            popuniListuNarudzbe();
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void dodajKapri_Click(object sender, EventArgs e)
        {
            if (kolicinaKapricosa == 0) oduzmiKapri.Visible = true;
            kolicinaKapricosa += 1;
            Namirnica n = new Namirnica("Capricciosa", 0, 0);
            n.Kolicina = kolicinaKapricosa;
            n.Cijena = kolicinaKapricosa * 5;
            racun.Racun = racun.Racun + 5;

            string listBoxItem;

            try
            {
                e_meni.DAO.DAO d = new e_meni.DAO.DAO("localhost", "mydb", "root", "0000");
                if (d.NamirnicaPostoji(n.Naziv))
                {
                    d.AzurirajNamirnicu(n);

                    int x = kolicinaKapricosa - 1;

                    string item = Convert.ToString(x) + "x " + n.Naziv + " " + Convert.ToString(5 * x) + " KM";


                    listBoxNarudzba.Items.Remove(item);

                }
                else
                {
                    d.DodajNamirnicu(n);

                }



                listBoxItem = Convert.ToString(n.Kolicina) + "x " + n.Naziv + " " + Convert.ToString(5* n.Kolicina) + " KM";
                listBoxNarudzba.Items.Add(listBoxItem);

                RACUN.Text = Convert.ToString(racun.Racun) + " KM";



            }

            catch (Exception izuzetak)
            {

            }
        }

        private void oduzmiKapri_Click(object sender, EventArgs e)
        {
            kolicinaKapricosa -= 1;
            Namirnica n = new Namirnica();
            n.Naziv = "Capricciosa";
            n.Kolicina = kolicinaKapricosa;
            n.Cijena = kolicinaKapricosa * 5;
            racun.Racun = racun.Racun-5;

            string kapri;

            try
            {
                e_meni.DAO.DAO d = new e_meni.DAO.DAO("localhost", "mydb", "root", "0000");

                d.AzurirajNamirnicu(n);
                int x = kolicinaKapricosa + 1;
                listBoxNarudzba.Items.Remove(Convert.ToString(x) + "x " + n.Naziv + " " + Convert.ToString(5 * x) + " KM");

                kapri = Convert.ToString(n.Kolicina) + "x " + n.Naziv + " " + Convert.ToString(5 * n.Kolicina) + " KM";
                listBoxNarudzba.Items.Add(kapri);



                if (kolicinaKapricosa == 0)
                {
                    oduzmiKapri.Visible = false;
                    listBoxNarudzba.Items.Remove(kapri);
                    d.IzbrisiNamirnicu(d.VratiNamirnicaID(n.Naziv));

                }
            }

            catch (Exception izuzetak)
            {

            }
            RACUN.Text = Convert.ToString(racun.Racun) + " KM";

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

       

        

        private void dodajMexicana_Click(object sender, EventArgs e)
        {
            if (kolicinaMexicana == 0) oduzmiMexicana.Visible = true;
            kolicinaMexicana += 1;
            Namirnica n = new Namirnica("Mexicana", 0, 0);
            n.Kolicina = kolicinaMexicana;
            n.Cijena = kolicinaMexicana * 6;
            racun.Racun = racun.Racun + 6;

            string listBoxItem;

            try
            {
                e_meni.DAO.DAO d = new e_meni.DAO.DAO("localhost", "mydb", "root", "0000");
                if (d.NamirnicaPostoji(n.Naziv))
                {
                    d.AzurirajNamirnicu(n);

                    int x = kolicinaMexicana - 1;

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

        private void oduzmiMexicana_Click(object sender, EventArgs e)
        {
            kolicinaMexicana -= 1;
            Namirnica n = new Namirnica();
            n.Naziv = "Mexicana";
            n.Kolicina = kolicinaMexicana;
            n.Cijena = kolicinaMexicana * 6;
            racun.Racun = racun.Racun - 6;

            string mex;

            try
            {
                e_meni.DAO.DAO d = new e_meni.DAO.DAO("localhost", "mydb", "root", "0000");

                d.AzurirajNamirnicu(n);
                int x = kolicinaMexicana + 1;
                listBoxNarudzba.Items.Remove(Convert.ToString(x) + "x " + n.Naziv + " " + Convert.ToString(6 * x) + " KM");

                mex = Convert.ToString(n.Kolicina) + "x " + n.Naziv + " " + Convert.ToString(6 * n.Kolicina) + " KM";
                listBoxNarudzba.Items.Add(mex);



                if (kolicinaMexicana == 0)
                {
                    oduzmiMexicana.Visible = false;
                    listBoxNarudzba.Items.Remove(mex);
                    d.IzbrisiNamirnicu(d.VratiNamirnicaID(n.Naziv));

                }
            }

            catch (Exception izuzetak)
            {

            }
            RACUN.Text = Convert.ToString(racun.Racun) + " KM";
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
            RACUN.Text = Convert.ToString(racun.Racun)+ " KM";
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

                
                kolicinaKapricosa = d.VratiKolicinuNamirnice("Capricciosa");
                kolicinaMargarita = d.VratiKolicinuNamirnice("Margarita");
                kolicinaMexicana = d.VratiKolicinuNamirnice("Mexicana");
                
                if (kolicinaKapricosa == 0) oduzmiKapri.Visible = false;
                if (kolicinaMargarita == 0) oduzmiMargarita.Visible = false;
                
                if (kolicinaMexicana == 0) oduzmiMexicana.Visible = false;

            }



            catch (Exception izuzetak)
            {

            }
}
    }
}
