using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace EIS {
    public class Energent {
        public int Id { get; set; }
        public string Naziv { get; set; }
        public int MjernaJedinica {get; set;}
        public float Cijena { get; set; }
        public override string ToString() {
            return Naziv;
        }
    }
}
