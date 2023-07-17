using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EIS {
    public class Objekt {
        public int Id { get; set; }
        public string Naziv { get; set; }
        public string Adresa { get; set; }
        public int Velicina { get; set; }
        public int Potrosnja { get; set; }
        public int VrstaEnergenta { get; set; }
        public int Vlasnik { get; set; }
        public int DioSkupa { get; set; }
    }
}
