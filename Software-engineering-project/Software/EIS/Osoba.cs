﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EIS {
    public abstract class Osoba : object {
        public int Id { get; set; }
        public string Ime { get; set; }
        public string Prezime { get; set; }
        public string Email { get; set; }
        public int VrstaKorisnika { get; set; }
        public override string ToString() {
            return Ime + " " + Prezime;
        }
    }
}
