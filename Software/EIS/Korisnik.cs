using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EIS {
    public class Korisnik : Osoba{ 
        public string Username { get; set; }
        public string Lozinka { get; set; }

        /// <summary>
        /// Metoda koja provjerava je li zadana lozinka jednaka lozinki korisnika.
        /// </summary>
        /// <param name="lozinka"></param>
        /// <returns>Vraća true ako su lozinke jednake, inače vraća false.</returns>
        public bool ProvjeriLozinku(string lozinka) {
            return Lozinka == lozinka;
        }
    }
}
