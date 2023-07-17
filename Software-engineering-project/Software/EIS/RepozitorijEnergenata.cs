using DBLayer;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EIS {
    public static class RepozitorijEnergenata {

        /// <summary>
        /// Dohvaća energetski resurs iz baze podataka na temelju ID-a. Izvršava SQL upit za dohvaćanje energetskog resursa s odgovarajućim ID-om. Vraća objekt Energent koji sadrži podatke o energetskom resursu.
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Objekt Energent s podacima o energetskom resursu ili null ako energetski resurs nije pronađen.</returns>
        public static Energent DohvatiEnergent(int id) {
            Energent energent = null;
            string sql = $"SELECT * FROM Energenti WHERE Id = {id}";
            DB.SetConfiguration("IPS23_mbaranasi21", "mbaranasi21", "VHUfX?xA");
            DB.OpenConnection();
            var reader = DB.GetDataReader(sql);
            if (reader.HasRows) {
                reader.Read();
                energent = StvoriEnergent(reader);
                reader.Close();
            }
            DB.CloseConnection();
            return energent;
        }

        /// <summary>
        /// Dohvaća sve energetske resurse iz baze podataka. Izvršava SQL upit za dohvaćanje svih energetskih resursa. Vraća listu objekata Energent koja sadrži podatke o energetskim resursima.
        /// </summary>
        /// <returns>Lista objekata Energent s podacima o energetskim resursima.</returns>
        public static List<Energent> DohvatiEnergente() {
            List<Energent> energenti = new List<Energent>();
            string sql = "SELECT * FROM Energenti";
            DB.SetConfiguration("IPS23_mbaranasi21", "mbaranasi21", "VHUfX?xA");
            DB.OpenConnection();
            var reader = DB.GetDataReader(sql);
            while (reader.Read()) {
                Energent energent = StvoriEnergent(reader);
                energenti.Add(energent);
            }
            reader.Close();
            DB.CloseConnection();
            return energenti;
        }

        /// <summary>
        /// Stvara objekt Energent na temelju podataka iz SqlDataReader objekta. Parsira vrijednosti iz readera i postavlja ih na odgovarajuća svojstva objekta Energent. Vraća stvoreni objekt.
        /// </summary>
        /// <param name="reader"></param>
        /// <returns>Objekt Energent s podacima o energetskom resursu.</returns>
        private static Energent StvoriEnergent(SqlDataReader reader) {
            int id = int.Parse(reader["Id"].ToString());
            string naziv = reader["Naziv"].ToString();
            int.TryParse(reader["MjernaJedinica"].ToString(), out int jedinica);
            float.TryParse(reader["Cijena"].ToString(), out float cijena);
            var energent = new Energent {
                Id = id,
                Naziv = naziv,
                MjernaJedinica = jedinica,
                Cijena = cijena
            };
            return energent;
        }
    }
}
