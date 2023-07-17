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
    public partial class FrmPrijava : Form {
        public static Korisnik LogiraniKorisnik { get; set; }
        public FrmPrijava() {
            InitializeComponent();
        }

        /// <summary>
        /// Metoda koja se poziva prilikom klika na gumb "Login". Provjerava jesu li uneseni korisničko ime i lozinka. Ako nisu, prikazuje poruku upozorenja. Ako su podaci uneseni, provjerava korisnika u repozitoriju korisnika koristeći RepozitorijKorisnika.DajKorisnika metodu. Ako korisnik postoji i lozinka je ispravna, otvara formu FrmObjekti. Inače, prikazuje poruku o pogrešnim podacima.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnLogin_Click(object sender, EventArgs e) {
            LogiraniKorisnik = RepozitorijKorisnika.DajKorisnika(txtUsername.Text);
            if (txtUsername.Text == "") {
                MessageBox.Show("Korisničko ime nije uneseno!", "Problem",
                MessageBoxButtons.OK, MessageBoxIcon.Error);
            } else if (txtPassword.Text == "") {
                MessageBox.Show("Lozinka nije unesena!", "Problem", MessageBoxButtons.OK,
                MessageBoxIcon.Error);
            } else {
                if (LogiraniKorisnik != null && LogiraniKorisnik.ProvjeriLozinku(txtPassword.Text)) {
                    FrmObjekti frmObjekti = new FrmObjekti();
                    Hide();
                    frmObjekti.ShowDialog();
                    Close();
                } else {
                    MessageBox.Show("Krivi podaci!", "Problem", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                }
            }
        }
    }
}
