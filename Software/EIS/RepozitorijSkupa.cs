using DBLayer;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EIS {
    public class RepozitorijSkupa {

        /// <summary>
        /// Dohvaća podatke o određenom skupu objekata iz baze podataka. Izvršava SQL upit za dohvaćanje podataka koristeći zadani ID skupa. Kreira i vraća objekt SkupObjekata na temelju rezultata upita.
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Objekt SkupObjekata s podacima o skupu objekata ili null ako skup nije pronađen.</returns>
        public static SkupObjekata DohvatiSkup(int id) {
            SkupObjekata skup = null;
            string sql = $"SELECT * FROM SkupObjekata WHERE Id = {id}";
            DB.SetConfiguration("IPS23_mbaranasi21", "mbaranasi21", "VHUfX?xA");
            DB.OpenConnection();
            var reader = DB.GetDataReader(sql);
            if (reader.HasRows) {
                reader.Read();
                skup = StvoriSkup(reader);
                reader.Close();
            }
            DB.CloseConnection();
            return skup;
        }

        /// <summary>
        /// Dohvaća sve skupove objekata iz baze podataka. Izvršava SQL upit za dohvaćanje podataka o svim skupovima. Za svaki rezultat upita kreira objekt SkupObjekata i dodaje ga u listu skupova. Na kraju vraća listu svih skupova objekata.
        /// </summary>
        /// <returns>Lista objekata SkupObjekata s podacima o svim skupovima objekata.</returns>
        public static List<SkupObjekata> DohvatiSkupove() {
            List<SkupObjekata> skupovi = new List<SkupObjekata>();
            string sql = "SELECT * FROM SkupObjekata";
            DB.SetConfiguration("IPS23_mbaranasi21", "mbaranasi21", "VHUfX?xA");
            DB.OpenConnection();
            var reader = DB.GetDataReader(sql);
            while (reader.Read()) {
                SkupObjekata skup = StvoriSkup(reader);
                skupovi.Add(skup);
            }
            reader.Close();
            DB.CloseConnection();
            return skupovi;
        }

        /// <summary>
        /// Stvara objekt SkupObjekata na temelju podataka iz SqlDataReader objekta. Parsira vrijednosti iz readera i postavlja ih na odgovarajuća svojstva objekta SkupObjekata. 
        /// </summary>
        /// <param name="reader"></param>
        /// <returns>Objekt SkupObjekata s podacima o skupu objekata.</returns>
        private static SkupObjekata StvoriSkup(SqlDataReader reader) {
            int id = int.Parse(reader["Id"].ToString());
            string naziv = reader["Naziv"].ToString();
            int.TryParse(reader["Regija"].ToString(), out int regija);
            var skup = new SkupObjekata {
                Id = id,
                Naziv = naziv,
                Regija = regija,
            };
            return skup;
        }
    }
}
