using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace e_meni.Klase
{
    public class Namirnica
    {
        private string naziv;
        private int kolicina;
        private double cijena;
        private int id;

        public Namirnica(string naziv, int kol, double cijena)
        {
            this.naziv = naziv;
            this.kolicina = kol;
            this.cijena = cijena;
        }

        public Namirnica() { }

        public string Naziv
        {
            get { return naziv; }
            set { naziv = value; }
        }

        public double Cijena
        {
            get { return cijena; }
            set { cijena = value; }
        }

        public int Kolicina
        {
            get { return kolicina; }
            set { kolicina = value; }
        }

        public int ID
        {
            get { return id; }
            set { id = value; }
        }

    }
}
