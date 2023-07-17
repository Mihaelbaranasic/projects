using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace EIS {
    public partial class FrmUnos : Form {
        private Objekt objekt = new Objekt();
        public FrmUnos() {
            InitializeComponent();
        }

        /// <summary>
        /// Metoda koja se poziva prilikom učitavanja forme. Dohvaća dostupne energente i skupove objekata te ih postavlja kao izvor podataka za odgovarajuće ComboBox komponente. Također postavlja prikaz logiranog korisnika u TextBox komponenti.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FrmUnos_Load(object sender, EventArgs e) {
            var energenti = RepozitorijEnergenata.DohvatiEnergente();
            cboEnergent.DataSource = energenti;
            var skupovi = RepozitorijSkupa.DohvatiSkupove();
            cboSkup.DataSource = skupovi;
            cboSkup.DisplayMember = "Naziv";
            txtVlasnik.Text = FrmPrijava.LogiraniKorisnik.ToString();
        }

        /// <summary>
        /// Metoda koja se poziva prilikom klika na gumb "Spremi". Provjerava jesu li svi potrebni podaci uneseni. Ako nisu, prikazuje poruku upozorenja. Ako su podaci ispravno uneseni, dohvaća selektirani energent i skup objekata, te dodaje objekt u repozitorij objekata koristeći RepozitorijObjekata.DodajObjekt metodu. Na kraju zatvara formu.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSpremi_Click(object sender, EventArgs e) {
            if(txtAdresa.Text == "" || txtNaziv.Text == "" || txtPotrosnja.Text == "" || txtVelicina.Text == "" || txtVlasnik.Text == "") {
                MessageBox.Show("Molim popunite sve podatke!", "Problem",
                MessageBoxButtons.OK, MessageBoxIcon.Error);
            } else {
                var energent = cboEnergent.SelectedItem as Energent;
                var vlasnik = FrmPrijava.LogiraniKorisnik;
                objekt.Adresa = txtAdresa.Text;
                objekt.Potrosnja = int.Parse(txtPotrosnja.Text);
                objekt.Velicina = int.Parse(txtVelicina.Text);
                objekt.Naziv = txtNaziv.Text;
                var skup = cboSkup.SelectedItem as SkupObjekata;
                RepozitorijObjekata.DodajObjekt(objekt, energent, vlasnik, skup);
                Close();
            } 
        }
        private void btnOdustani_Click(object sender, EventArgs e) {
            Close();
        }
    }
}
