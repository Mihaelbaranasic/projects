using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EIS {
    public class Izvjesce {
        public int Id { get; set; }
        public string Naziv { get; set; }
        public float UkupnaPotrosnja { get; set; }
        public int Regija { get; set; }
        public float UkupnaCijena { get; set; }

        /// <summary>
        /// Konstruktor koji prima instancu klase SkupObjekata i inicijalizira svojstva izvješća (Id, Naziv, UkupnaPotrosnja, Regija, UkupnaCijena) koristeći metode IzracunajUkupnuPotrosnju i IzracunajUkupnuCijenu objekta objekti.
        /// </summary>
        /// <param name="objekti"></param>
        public Izvjesce(SkupObjekata objekti) {
            Id = objekti.Id;
            Naziv = objekti.Naziv;
            UkupnaPotrosnja = objekti.IzracunajUkupnuPotrosnju();
            Regija = objekti.Regija;
            UkupnaCijena = objekti.IzracunajUkupnuCijenu();
        }
    }
}
