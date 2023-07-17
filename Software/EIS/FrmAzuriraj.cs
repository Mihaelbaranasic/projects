using DBLayer;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EIS {
    public partial class FrmAzuriraj : Form {
        private Objekt objekt;
        public FrmAzuriraj(Objekt odabraniObjekt) {
            InitializeComponent();
            objekt = odabraniObjekt;
        }

        /// <summary>
        /// Metoda koja se poziva prilikom učitavanja forme. Poziva PostaviTekst metodu za postavljanje naslova forme na temelju naziva objekta. Dohvaća energente iz repozitorija energenata koristeći RepozitorijEnergenata.DohvatiEnergente metodu i postavlja ih kao izvor podataka za ComboBox komponentu cboEnergent. Postavlja vrijednosti polja forme na temelju podataka objekta.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FrmAzuriraj_Load(object sender, EventArgs e) {
            PostaviTekst();
            var energenti = RepozitorijEnergenata.DohvatiEnergente();
            cboEnergent.DataSource = energenti;
            txtAdresa.Text = objekt.Adresa.ToString();
            txtPotrosnja.Text = objekt.Potrosnja.ToString();
            txtVlasnik.Text = FrmPrijava.LogiraniKorisnik.ToString();
            txtVelicina.Text = objekt.Velicina.ToString();
        }
        private void PostaviTekst() {
            Text = objekt.Naziv;
        }

        private void btnOdustani_Click(object sender, EventArgs e) {
            Close();
        }

        /// <summary>
        /// Metoda koja se poziva prilikom klika na gumb "Spremi". Dohvaća odabrani energent iz ComboBox-a cboEnergent i logiranog korisnika iz klase FrmPrijava. Ažurira podatke objekta na temelju unesenih vrijednosti u TextBox-ovima. Koristi RepozitorijObjekata.AzurirajObjekt metodu za ažuriranje objekta u repozitoriju. Nakon toga, zatvara formu.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSpremi_Click(object sender, EventArgs e) {
            var energent = cboEnergent.SelectedItem as Energent;
            var vlasnik = FrmPrijava.LogiraniKorisnik;
            objekt.Adresa = txtAdresa.Text;
            objekt.Potrosnja = int.Parse(txtPotrosnja.Text);
            objekt.Velicina = int.Parse(txtVelicina.Text);
            RepozitorijObjekata.AzurirajObjekt(objekt, energent, vlasnik);
            Close();
        }
    }
}
