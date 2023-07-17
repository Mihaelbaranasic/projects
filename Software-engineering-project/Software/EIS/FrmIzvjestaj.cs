using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EIS {
    public partial class FrmIzvjestaj : Form {
        public FrmIzvjestaj() {
            InitializeComponent();
        }

        /// <summary>
        /// Metoda koja generira izvješće na temelju dostupnih skupova objekata. Dohvaća skupove objekata iz repozitorija koristeći RepozitorijSkupa.DohvatiSkupove metodu. Iterira kroz svaki skup i provjerava ako ukupna potrošnja skupa nije jednaka 0. Ako nije, stvara novo izvješće (Izvjesce) na temelju skupa i dodaje ga u listu izvješća.
        /// </summary>
        /// <returns>Vraća generiranu listu izvješća.</returns>
        private List<Izvjesce> GenerirajIzvjesce() {
            var skupovi = RepozitorijSkupa.DohvatiSkupove();
            var izvjesce = new List<Izvjesce>();
            foreach (var skup in skupovi) {
                if(skup.IzracunajUkupnuPotrosnju() != 0) {
                    var noviSkup = new Izvjesce(skup);
                    izvjesce.Add(noviSkup);
                }
                
            }
            return izvjesce;
        }
        private void FrmIzvjestaj_Load(object sender, EventArgs e) {
            var izvjesce = GenerirajIzvjesce();
            dgvIzvjesce.DataSource = izvjesce;

            dgvIzvjesce.Columns["Id"].DisplayIndex = 0;
            dgvIzvjesce.Columns["Naziv"].DisplayIndex = 1;
            dgvIzvjesce.Columns["Regija"].DisplayIndex = 2;
            dgvIzvjesce.Columns["UkupnaPotrosnja"].DisplayIndex = 3;
            dgvIzvjesce.Columns["UkupnaCijena"].DisplayIndex = 4;
        }

        private void btnZatvori_Click(object sender, EventArgs e) {
            Close();
        }
    }
}
