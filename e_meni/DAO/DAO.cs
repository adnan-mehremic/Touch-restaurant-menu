using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

using MySql.Data.MySqlClient;
using System.Collections;
using System.IO;
using e_meni.Klase;

namespace e_meni.DAO
{
    public class DAO
    {
        private MySqlConnection dataConnection = new MySqlConnection();

        public DAO(string server, string dbname, string username, string password)
        {
            dataConnection.ConnectionString = "Server=" + server + ";Database=" + dbname + ";Uid=" + username + ";Pwd=" + password + ";Charset=utf8;";
        }

        ~DAO()
        {
            dataConnection.Close();
        }

        public bool DodajNamirnicu(Namirnica n)
        {
            try
            {
                if (dataConnection.State != System.Data.ConnectionState.Open) dataConnection.Open();
                MySqlCommand namirnica = new MySqlCommand("Insert into namirnica(naziv, kolicina, cijena) " + "values(@naziv, @kolicina, @cijena);", dataConnection);
                namirnica.Parameters.AddWithValue("@naziv", (Object)n.Naziv);
                namirnica.Parameters.AddWithValue("@kolicina", (Object)n.Kolicina);
                namirnica.Parameters.AddWithValue("@cijena", (Object)n.Cijena);
                namirnica.ExecuteNonQuery();
                dataConnection.Close();
                return true;
            }

            catch (MySqlException)
            {
                throw new Exception("Nije moguće dodati namirnicu u bazu.");
            }
        }

        public List<Namirnica> VratiSveNamirnice()
        {

            try
            {
                if (dataConnection.State != System.Data.ConnectionState.Open) dataConnection.Open();
                List<Namirnica> namirnice = new List<Namirnica>();
                MySqlCommand dataCommand = new MySqlCommand();
                dataCommand.Connection = dataConnection;
                dataCommand.CommandText = "SELECT * FROM namirnica;";

                MySqlDataReader dataReader = dataCommand.ExecuteReader();

                

                while (dataReader.Read())
                {
                    Namirnica n = new Namirnica();
                    n.Naziv = dataReader.GetString(1);
                    n.Kolicina = dataReader.GetInt16(2);
                    n.Cijena = dataReader.GetDouble(3);
                    namirnice.Add(n);
                }
                dataReader.Close();
                dataConnection.Close();
                return namirnice;
            }
            catch (MySqlException izuzetak)
            {
                throw new Exception(izuzetak.Message);
            }
        }

        public bool NamirnicaPostoji(String naziv)
        {
            try
            {
                if (dataConnection.State != System.Data.ConnectionState.Open) dataConnection.Open();
                MySqlCommand dataCommand = new MySqlCommand();
                dataCommand.Connection = dataConnection;
                dataCommand.CommandText = "SELECT count(*) FROM  namirnica  WHERE naziv = '" + naziv + "';";
                MySqlDataReader dataReader = dataCommand.ExecuteReader();
                dataReader.Read();
                int broj = dataReader.GetInt32(0);
                dataReader.Close();
                dataConnection.Close();
                if (broj > 0) return true;
                else return false;
            }
            catch (MySqlException izuzetak)
            {
                throw new Exception(izuzetak.Message);
            }

        }

        public bool AzurirajNamirnicu(Namirnica namirnica)
        {
            try
            {
                if (dataConnection.State != System.Data.ConnectionState.Open) dataConnection.Open();
                MySqlCommand dataCommand = new MySqlCommand();
                dataCommand.Connection = dataConnection;
                MemoryStream m = new MemoryStream();
                MySqlCommand prijava = new MySqlCommand("Update namirnica set kolicina=@kolicina  where naziv= '" + namirnica.Naziv + "'", dataConnection);
                prijava.Parameters.AddWithValue("@kolicina", (Object)namirnica.Kolicina);
                prijava.ExecuteNonQuery();

                prijava = new MySqlCommand("Update namirnica set cijena=@cijena  where naziv= '" + namirnica.Naziv + "'", dataConnection);
                prijava.Parameters.AddWithValue("@cijena", (Object)namirnica.Cijena);
                prijava.ExecuteNonQuery();

                dataConnection.Close();
                return true;
            }

            catch (MySqlException)
            {
                throw new Exception("Nije moguće azurirati namirnicu.");
            }
        }

        public bool IzbrisiNamirnicu(int id)
        {
            try
            {
                if (dataConnection.State != System.Data.ConnectionState.Open) dataConnection.Open();
                MySqlCommand dataCommand = new MySqlCommand();
                dataCommand.Connection = dataConnection;

                dataCommand.CommandText = "DELETE FROM namirnica WHERE idNamirnica=" + id + ";";
                

                return dataCommand.ExecuteNonQuery() > 0;

            }
            catch (MySqlException izuzetak)
            {
                throw new Exception(izuzetak.Message);
            }
        }

        public bool IzbrisiNamirnicuNaziv(string naziv)
        {
            try
            {
                if (dataConnection.State != System.Data.ConnectionState.Open) dataConnection.Open();
                MySqlCommand dataCommand = new MySqlCommand();
                dataCommand.Connection = dataConnection;

                dataCommand.CommandText = "DELETE FROM namirnica WHERE naziv = " + naziv + ";";


                return dataCommand.ExecuteNonQuery() > 0;

            }
            catch (MySqlException izuzetak)
            {
                throw new Exception(izuzetak.Message);
            }
        }

        public bool IzbrisiNamirnice()
        {
            try
            {
                if (dataConnection.State != System.Data.ConnectionState.Open) dataConnection.Open();
                MySqlCommand dataCommand = new MySqlCommand();
                dataCommand.Connection = dataConnection;

                dataCommand.CommandText = "DELETE FROM namirnica";


                return dataCommand.ExecuteNonQuery() > 0;

            }
            catch (MySqlException izuzetak)
            {
                throw new Exception(izuzetak.Message);
            }
        }

        public int VratiNamirnicaID(string naziv)
        {

            try
            {
                if (dataConnection.State != System.Data.ConnectionState.Open) dataConnection.Open();
                MySqlCommand dataCommand = new MySqlCommand();
                dataCommand.Connection = dataConnection;
                dataCommand.CommandText = "SELECT * FROM namirnica WHERE naziv = '" + naziv + "';";

                MySqlDataReader dataReader = dataCommand.ExecuteReader();

                Namirnica n = new Namirnica();
                while (dataReader.Read())
                {
                    n.ID = dataReader.GetInt16(0);
                    n.Naziv = dataReader.GetString(1);
                    n.Kolicina = dataReader.GetInt16(2);
                    n.Cijena = dataReader.GetDouble(3);
                }
                dataReader.Close();
                dataConnection.Close();
                return n.ID;
            }
            catch (MySqlException izuzetak)
            {
                throw new Exception(izuzetak.Message);
            }
        }

        public double VratiCijenuNamirnice(string naziv)
        {

            try
            {
                if (dataConnection.State != System.Data.ConnectionState.Open) dataConnection.Open();
                MySqlCommand dataCommand = new MySqlCommand();
                dataCommand.Connection = dataConnection;
                dataCommand.CommandText = "SELECT * FROM cijenanamirnice WHERE nazivNamirnice = '" + naziv + "';";

                MySqlDataReader dataReader = dataCommand.ExecuteReader();

                double cijena = 0;
                while (dataReader.Read())
                {
                    cijena = dataReader.GetDouble(1);
                }
                dataReader.Close();
                dataConnection.Close();
                return cijena;
            }
            catch (MySqlException izuzetak)
            {
                throw new Exception(izuzetak.Message);
            }
        }

        public int VratiKolicinuNamirnice(string naziv)
        {

            try
            {
                if (dataConnection.State != System.Data.ConnectionState.Open) dataConnection.Open();
                MySqlCommand dataCommand = new MySqlCommand();
                dataCommand.Connection = dataConnection;
                dataCommand.CommandText = "SELECT * FROM namirnica WHERE naziv = '" + naziv + "';";

                MySqlDataReader dataReader = dataCommand.ExecuteReader();

                int kolicina = 0;
                while (dataReader.Read())
                {
                    kolicina = dataReader.GetInt16(2);
                }
                dataReader.Close();
                dataConnection.Close();
                return kolicina;
            }
            catch (MySqlException izuzetak)
            {
                throw new Exception(izuzetak.Message);
            }
        }

        public Namirnica VratiNamirnicu(string naziv)
        {

            try
            {
                if (dataConnection.State != System.Data.ConnectionState.Open) dataConnection.Open();
                MySqlCommand dataCommand = new MySqlCommand();
                dataCommand.Connection = dataConnection;
                dataCommand.CommandText = "SELECT * FROM namirnica WHERE naziv = '" + naziv + "';";

                MySqlDataReader dataReader = dataCommand.ExecuteReader();

                Namirnica n = new Namirnica();
                while (dataReader.Read())
                {
                    n.ID = dataReader.GetInt16(0);
                    n.Naziv = dataReader.GetString(1);
                    n.Kolicina = dataReader.GetInt16(2);
                    n.Cijena = dataReader.GetDouble(3);
                }
                dataReader.Close();
                dataConnection.Close();
                return n;
            }
            catch (MySqlException izuzetak)
            {
                throw new Exception(izuzetak.Message);
            }
        }

        public bool NamirnicePostoje()
        {
            try
            {
                if (dataConnection.State != System.Data.ConnectionState.Open) dataConnection.Open();
                MySqlCommand dataCommand = new MySqlCommand();
                dataCommand.Connection = dataConnection;
                dataCommand.CommandText = "SELECT count(*) FROM  namirnica;";
                MySqlDataReader dataReader = dataCommand.ExecuteReader();
                dataReader.Read();
                int broj = dataReader.GetInt32(0);
                dataReader.Close();
                dataConnection.Close();
                if (broj > 0) return true;
                else return false;
            }
            catch (MySqlException izuzetak)
            {
                throw new Exception(izuzetak.Message);
            }

        }
    }
}
