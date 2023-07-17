using DBLayer;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EIS {
    public static class RepozitorijObjekata {
        public static Korisnik vlasnik = FrmPrijava.LogiraniKorisnik;

        /// <summary>
        /// Dohvaća podatke o određenom objektu iz baze podataka. Izvršava SQL upit za dohvaćanje podataka koristeći zadani ID objekta i ID trenutno prijavljenog korisnika kako bi dohvatio samo one objekte nad kojima korisnik ima ovlasti ili ako je administrator sve objekte. Kreira i vraća objekt Objekt na temelju rezultata upita.
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Objekt objekt s podacima o objektu ili null ako objekt nije pronađen.</returns>
        public static Objekt DohvatiObjekt(int id) {
            Objekt objekt = null;
            string sql;
            if (vlasnik.Id == 1) {
                sql = $"SELECT * FROM Objekt WHERE Id = {id}";
            } else {
                sql = $"SELECT * FROM Objekt WHERE Id = {id} AND Korisnik = {vlasnik.Id}";
            }
            DB.SetConfiguration("IPS23_mbaranasi21", "mbaranasi21", "VHUfX?xA");
            DB.OpenConnection();
            var reader = DB.GetDataReader(sql);
            if (reader.HasRows) {
                reader.Read();
                objekt = StvoriObjekt(reader);
                reader.Close();
            }
            DB.CloseConnection();
            return objekt;
        }

        /// <summary>
        /// Dohvaća sve objekte iz baze podataka. Izvršava SQL upit za dohvaćanje podataka o svim objektima s obzirom na ID trenutno prijavljenog korisnika (zbog istog razloga kao i kod metode DohvatiObjekt). Za svaki rezultat upita kreira objekt Objekt i dodaje ga u listu objekata. Na kraju vraća listu svih objekata.
        /// </summary>
        /// <returns>Lista objekata Objekt s podacima o svim objektima.</returns>
        public static List<Objekt> DohvatiObjekte() {
            List<Objekt> objekti = new List<Objekt>();
            string sql;
            if (vlasnik.Id == 1) {
                sql = "SELECT * FROM Objekt";
            } else {
                sql = $"SELECT * FROM Objekt WHERE Vlasnik = {vlasnik.Id}";
            }
            DB.SetConfiguration("IPS23_mbaranasi21", "mbaranasi21", "VHUfX?xA");
            DB.OpenConnection();
            var reader = DB.GetDataReader(sql);
            while (reader.Read()) {
                Objekt objekt = StvoriObjekt(reader);
                objekti.Add(objekt);
            }
            reader.Close();
            DB.CloseConnection();
            return objekti;
        }


        /// <summary>
        /// Stvara objekt Objekt na temelju podataka iz SqlDataReader objekta. Parsira vrijednosti iz readera i postavlja ih na odgovarajuća svojstva objekta Objekt. Vraća stvoreni objekt.
        /// </summary>
        /// <param name="reader"></param>
        /// <returns>Objekt Objekt s podacima o objektu.</returns>
        private static Objekt StvoriObjekt(SqlDataReader reader) {
            int id = int.Parse(reader["Id"].ToString());
            string naziv = reader["Naziv"].ToString();
            string adresa = reader["Adresa"].ToString();
            int.TryParse(reader["Potrosnja"].ToString(), out int potrosnja);
            int.TryParse(reader["Vlasnik"].ToString(), out int vlasnik);
            int.TryParse(reader["VrstaEnergenta"].ToString(), out int vrsta);
            int.TryParse(reader["DioSkupa"].ToString(), out int skup);
            int.TryParse(reader["Velicina"].ToString(), out int velicina);
            var objekt = new Objekt {
                Id = id,
                Naziv = naziv,
                Adresa = adresa,
                Potrosnja = potrosnja,
                Vlasnik = vlasnik,
                VrstaEnergenta = vrsta,
                DioSkupa = skup,
                Velicina = velicina
            };
            return objekt;
        }

        /// <summary>
        /// Ažurira podatke objekta u bazi podataka. Izvršava SQL upit za ažuriranje podataka o objektu koristeći zadane objekte Objekt, Energent i Korisnik. Podaci objekta se ažuriraju na temelju ID-ja objekta i ID-ja vlasnika objekta.
        /// </summary>
        /// <param name="objekt"></param>
        /// <param name="energent"></param>
        /// <param name="korisnik"></param>
        public static void AzurirajObjekt(Objekt objekt, Energent energent, Korisnik korisnik) {
            string sql = $"UPDATE Objekt SET Naziv = '{objekt.Naziv}', Adresa = '{objekt.Adresa}', Velicina = {objekt.Velicina}, VrstaEnergenta = {energent.Id}, Vlasnik = {korisnik.Id} WHERE Id = {objekt.Id} AND Vlasnik = {korisnik.Id}";
            DB.SetConfiguration("IPS23_mbaranasi21", "mbaranasi21", "VHUfX?xA");
            DB.OpenConnection();
            DB.ExecuteCommand(sql);
            DB.CloseConnection();
        }

        /// <summary>
        /// Briše objekt iz baze podataka. Izvršava SQL upit za brisanje objekta koristeći ID objekta.
        /// </summary>
        /// <param name="objekt"></param>
        public static void ObrisiObjekt(Objekt objekt) {
            string sql = $"DELETE FROM Objekt WHERE Id={objekt.Id}";
            DB.SetConfiguration("IPS23_mbaranasi21", "mbaranasi21", "VHUfX?xA");
            DB.OpenConnection();
            DB.ExecuteCommand(sql);
            DB.CloseConnection();
        }

        /// <summary>
        /// Dodaje novi objekt u bazu podataka. Izvršava SQL upit za dodavanje novog objekta koristeći zadane objekte Objekt, Energent, Korisnik i SkupObjekata. Novi objekt se dodaje s odgovarajućim vrijednostima svojstava.
        /// </summary>
        /// <param name="objekt"></param>
        /// <param name="energent"></param>
        /// <param name="korisnik"></param>
        /// <param name="skup"></param>
        public static void DodajObjekt(Objekt objekt, Energent energent, Korisnik korisnik, SkupObjekata skup) {
            string sql = $"INSERT INTO Objekt (Naziv, Adresa, Velicina, Potrosnja, VrstaEnergenta, Vlasnik, DioSkupa) VALUES ('{objekt.Naziv}', '{objekt.Adresa}',{objekt.Velicina}, {objekt.Potrosnja}, {energent.Id}, {korisnik.Id}, {skup.Id})";
            DB.SetConfiguration("IPS23_mbaranasi21", "mbaranasi21", "VHUfX?xA");
            DB.OpenConnection();
            DB.ExecuteCommand(sql);
            DB.CloseConnection();
        }
    }
}
