using DBLayer;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace EIS {
    public class RepozitorijKorisnika {

        /// <summary>
        /// Dohvaća korisnika iz baze podataka na temelju korisničkog imena. Izvršava SQL upit za dohvaćanje korisnika s odgovarajućim korisničkim imenom. Vraća objekt Korisnik koji sadrži podatke o korisniku.
        /// </summary>
        /// <param name="username"></param>
        /// <returns>Objekt Korisnik s podacima o korisniku ili null ako korisnik nije pronađen.</returns>
        public static Korisnik DajKorisnika(string username) {
            string sql = $"SELECT * FROM Korisnik WHERE Username = '{username}'";
            return DohvatiKorisnika(sql);
        }

        /// <summary>
        /// Dohvaća korisnika iz baze podataka na temelju ID-a. Izvršava SQL upit za dohvaćanje korisnika s odgovarajućim ID-om. Vraća objekt Korisnik koji sadrži podatke o korisniku.
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Objekt Korisnik s podacima o korisniku ili null ako korisnik nije pronađen.</returns>
        public static Korisnik DajKorisnika(int id) {
            string sql = $"SELECT * FROM Korisnik WHERE Id = {id}";
            return DohvatiKorisnika(sql);
        }

        /// <summary>
        /// Dohvaća korisnika iz baze podataka na temelju SQL upita. Izvršava SQL upit za dohvaćanje korisnika s zadanim SQL izrazom. Vraća objekt Korisnik koji sadrži podatke o korisniku.
        /// </summary>
        /// <param name="sql"></param>
        /// <returns>Objekt Korisnik s podacima o korisniku ili null ako korisnik nije pronađen.</returns>
        private static Korisnik DohvatiKorisnika(string sql) {
            DB.SetConfiguration("IPS23_mbaranasi21", "mbaranasi21", "VHUfX?xA");
            DB.OpenConnection();
            var reader = DB.GetDataReader(sql);
            Korisnik korisnik = null;
            if (reader.HasRows == true) {
                reader.Read();
                korisnik = CreateObject(reader);
                reader.Close();
            }
            DB.CloseConnection();
            return korisnik;
        }

        /// <summary>
        /// Stvara objekt Korisnik na temelju podataka iz SqlDataReader objekta. Parsira vrijednosti iz readera i postavlja ih na odgovarajuća svojstva objekta Korisnik. Vraća stvoreni objekt.
        /// </summary>
        /// <param name="reader"></param>
        /// <returns>Objekt Korisnik s podacima o korisniku.</returns>
        private static Korisnik CreateObject(SqlDataReader reader) {
            int id = int.Parse(reader["Id"].ToString());
            string ime = reader["Ime"].ToString();
            string prezime = reader["Prezime"].ToString();
            string mail = reader["Email"].ToString();
            int.TryParse(reader["VrstaKorisnika"].ToString (), out int vrsta);
            string korime = reader["Username"].ToString();
            string lozinka = reader["Lozinka"].ToString();
            var korisnik = new Korisnik {
                Id = id,
                Ime = ime,
                Prezime = prezime,
                Email = mail,
                VrstaKorisnika = vrsta,
                Username = korime,
                Lozinka = lozinka
            };
            return korisnik;
        }
    }
}
