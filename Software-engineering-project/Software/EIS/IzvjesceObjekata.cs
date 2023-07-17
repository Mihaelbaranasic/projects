using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EIS {
    public class IzvjesceObjekata {
        private Objekt objekt;

        public IzvjesceObjekata(Objekt objekt) {
            this.objekt = objekt;
        }

        public int Id { get; set; }
        public string Naziv { get; set; }
        public float Potrosnja { get; set; }
        public int Regija { get; set; }
        public float UkupnaCijena { get; set; }

        public List<IzvjesceObjekata> GenerirajIzvjescaObjekata() {
            List<IzvjesceObjekata> izvjesca = new List<IzvjesceObjekata>();

            List<Objekt> objekti = RepozitorijObjekata.DohvatiObjekte();

            foreach (Objekt objekt in objekti) {
                float ukupnaPotrosnja = objekt.Potrosnja * objekt.Velicina;
                float ukupnaCijena = ukupnaPotrosnja * RepozitorijEnergenata.DohvatiEnergent(objekt.VrstaEnergenta).Cijena;

                IzvjesceObjekata izvjesce = new IzvjesceObjekata(objekt) {
                    Potrosnja = ukupnaPotrosnja,
                    UkupnaCijena = ukupnaCijena
                };

                izvjesca.Add(izvjesce);
            }

            return izvjesca;
        }

    }
}
