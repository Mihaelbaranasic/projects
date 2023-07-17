using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EIS {
    public class SkupObjekata {
        public int Id { get; set; }
        public string Naziv { get; set; }
        public float UkupnaPotrosnja { get; set; }
        public int Regija { get; set; }
        public float UkupnaCijena { get; set; }

        /// <summary>
        /// Računa ukupnu potrošnju objekata u skupu na temelju podataka iz Repozitorija objekata. Iterira kroz sve objekte i sumira njihovu potrošnju ako su dio trenutnog skupa objekata.
        /// </summary>
        /// <returns>Ukupna potrošnja objekata u skupu.</returns>
        public int IzracunajUkupnuPotrosnju() {
            List<Objekt> objekti = RepozitorijObjekata.DohvatiObjekte();
            int ukupnaPotrosnja = 0;

            foreach (Objekt objekt in objekti) {
                if (objekt.DioSkupa == this.Id) {
                    ukupnaPotrosnja += objekt.Potrosnja;
                }
            }

            return ukupnaPotrosnja;
        }

        /// <summary>
        /// Računa ukupnu cijenu potrošnje objekata u skupu na temelju podataka iz Repozitorija energetskih resursa. Koristi rezultat metode IzracunajUkupnuPotrosnju() kako bi dobila ukupnu potrošnju objekata. Za svaki energetski resurs računa cijenu na temelju potrošnje objekata i cijene resursa te ih sumira.
        /// </summary>
        /// <returns>Ukupna cijena potrošnje objekata u skupu.</returns>
        public float IzracunajUkupnuCijenu() {
            int ukupnaPotrosnja = IzracunajUkupnuPotrosnju();
            float ukupnaCijena = 0;

            List<Energent> energenti = RepozitorijEnergenata.DohvatiEnergente();
            foreach (Energent energent in energenti) {
                float cijenaEnergenta = energent.Cijena * ukupnaPotrosnja;
                ukupnaCijena += cijenaEnergenta;
            }

            return ukupnaCijena;
        }
    }
}
