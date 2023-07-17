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
    public partial class FrmObjekti : Form {
        public FrmObjekti() {
            InitializeComponent();
        }

        private void FrmObjekti_Load(object sender, EventArgs e) {
            PrikaziObjekte();
        }

        /// <summary>
        /// Metoda koja dohvaća objekte iz repozitorija objekata koristeći RepozitorijObjekata.DohvatiObjekte metodu i prikazuje ih u DataGridView komponenti (dgvObjekti).
        /// </summary>
        private void PrikaziObjekte() {
            List<Objekt> objekti = RepozitorijObjekata.DohvatiObjekte();
            dgvObjekti.DataSource = objekti;
        }

        /// <summary>
        /// etoda koja se poziva prilikom klika na gumb "Azuriraj". Dohvaća odabrani objekt iz DataGridView-a i otvara formu FrmAzuriraj za ažuriranje tog objekta.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAzuriraj_Click(object sender, EventArgs e) {
            Objekt odabraniObjekt = dgvObjekti.CurrentRow.DataBoundItem as Objekt;
            if (odabraniObjekt != null) {
                FrmAzuriraj frmAzuriraj = new FrmAzuriraj(odabraniObjekt);
                frmAzuriraj.ShowDialog();
            }
        }

        /// <summary>
        /// Metoda koja se poziva prilikom promjene teksta u TextBox komponenti txtSearch. Pretražuje objekte na temelju unesenog teksta i ažurira DataGridView s filtriranim objektima.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtSearch_TextChanged(object sender, EventArgs e) {
            string pretrazivanje = txtSearch.Text;

            List<Objekt> objekti = RepozitorijObjekata.DohvatiObjekte();
            List<Objekt> filtriraniObjekti = objekti.Where(o => o.Naziv.Contains(pretrazivanje)).ToList();

            dgvObjekti.DataSource = filtriraniObjekti;
        }

        /// <summary>
        /// Metoda koja se poziva prilikom klika na gumb "Delete". Dohvaća odabrani objekt iz DataGridView-a i briše ga iz repozitorija objekata koristeći RepozitorijObjekata.ObrisiObjekt metodu. Nakon brisanja, ponovno prikazuje objekte.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnDelete_Click(object sender, EventArgs e) {
            Objekt odabraniObjekt = dgvObjekti.CurrentRow.DataBoundItem as Objekt;
            RepozitorijObjekata.ObrisiObjekt(odabraniObjekt);
            PrikaziObjekte();
        }

        private void btnDodaj_Click(object sender, EventArgs e) {
            FrmUnos frmUnos = new FrmUnos();
            frmUnos.ShowDialog();
        }

        private void btnOsvjezi_Click(object sender, EventArgs e) {
            PrikaziObjekte();
        }

        private void btnIzvjesce_Click(object sender, EventArgs e) {
            FrmIzvjestaj frmizvjestaj = new FrmIzvjestaj();
            frmizvjestaj.ShowDialog();
        }
    }
}
