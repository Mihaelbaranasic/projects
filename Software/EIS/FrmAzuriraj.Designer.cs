namespace EIS {
    partial class FrmAzuriraj {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            this.txtAdresa = new System.Windows.Forms.TextBox();
            this.txtPotrosnja = new System.Windows.Forms.TextBox();
            this.lblAdresa = new System.Windows.Forms.Label();
            this.lblPotrosnja = new System.Windows.Forms.Label();
            this.cboEnergent = new System.Windows.Forms.ComboBox();
            this.lblVrsta = new System.Windows.Forms.Label();
            this.txtVlasnik = new System.Windows.Forms.TextBox();
            this.lblVlasnik = new System.Windows.Forms.Label();
            this.btnSpremi = new System.Windows.Forms.Button();
            this.btnOdustani = new System.Windows.Forms.Button();
            this.txtVelicina = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // txtAdresa
            // 
            this.txtAdresa.Location = new System.Drawing.Point(254, 72);
            this.txtAdresa.Name = "txtAdresa";
            this.txtAdresa.Size = new System.Drawing.Size(120, 22);
            this.txtAdresa.TabIndex = 1;
            // 
            // txtPotrosnja
            // 
            this.txtPotrosnja.Location = new System.Drawing.Point(254, 203);
            this.txtPotrosnja.Name = "txtPotrosnja";
            this.txtPotrosnja.Size = new System.Drawing.Size(120, 22);
            this.txtPotrosnja.TabIndex = 2;
            // 
            // lblAdresa
            // 
            this.lblAdresa.AutoSize = true;
            this.lblAdresa.Location = new System.Drawing.Point(251, 39);
            this.lblAdresa.Name = "lblAdresa";
            this.lblAdresa.Size = new System.Drawing.Size(51, 16);
            this.lblAdresa.TabIndex = 4;
            this.lblAdresa.Text = "Adresa";
            // 
            // lblPotrosnja
            // 
            this.lblPotrosnja.AutoSize = true;
            this.lblPotrosnja.Location = new System.Drawing.Point(251, 170);
            this.lblPotrosnja.Name = "lblPotrosnja";
            this.lblPotrosnja.Size = new System.Drawing.Size(64, 16);
            this.lblPotrosnja.TabIndex = 5;
            this.lblPotrosnja.Text = "Potrošnja";
            // 
            // cboEnergent
            // 
            this.cboEnergent.FormattingEnabled = true;
            this.cboEnergent.Location = new System.Drawing.Point(27, 69);
            this.cboEnergent.Name = "cboEnergent";
            this.cboEnergent.Size = new System.Drawing.Size(174, 24);
            this.cboEnergent.TabIndex = 6;
            // 
            // lblVrsta
            // 
            this.lblVrsta.AutoSize = true;
            this.lblVrsta.Location = new System.Drawing.Point(24, 39);
            this.lblVrsta.Name = "lblVrsta";
            this.lblVrsta.Size = new System.Drawing.Size(102, 16);
            this.lblVrsta.TabIndex = 7;
            this.lblVrsta.Text = "Vrsta energenta";
            // 
            // txtVlasnik
            // 
            this.txtVlasnik.Location = new System.Drawing.Point(27, 203);
            this.txtVlasnik.Name = "txtVlasnik";
            this.txtVlasnik.ReadOnly = true;
            this.txtVlasnik.Size = new System.Drawing.Size(174, 22);
            this.txtVlasnik.TabIndex = 9;
            // 
            // lblVlasnik
            // 
            this.lblVlasnik.AutoSize = true;
            this.lblVlasnik.Location = new System.Drawing.Point(24, 157);
            this.lblVlasnik.Name = "lblVlasnik";
            this.lblVlasnik.Size = new System.Drawing.Size(51, 16);
            this.lblVlasnik.TabIndex = 10;
            this.lblVlasnik.Text = "Vlasnik";
            // 
            // btnSpremi
            // 
            this.btnSpremi.Location = new System.Drawing.Point(197, 284);
            this.btnSpremi.Name = "btnSpremi";
            this.btnSpremi.Size = new System.Drawing.Size(75, 23);
            this.btnSpremi.TabIndex = 13;
            this.btnSpremi.Text = "Spremi";
            this.btnSpremi.UseVisualStyleBackColor = true;
            this.btnSpremi.Click += new System.EventHandler(this.btnSpremi_Click);
            // 
            // btnOdustani
            // 
            this.btnOdustani.Location = new System.Drawing.Point(357, 284);
            this.btnOdustani.Name = "btnOdustani";
            this.btnOdustani.Size = new System.Drawing.Size(75, 23);
            this.btnOdustani.TabIndex = 14;
            this.btnOdustani.Text = "Odustani";
            this.btnOdustani.UseVisualStyleBackColor = true;
            this.btnOdustani.Click += new System.EventHandler(this.btnOdustani_Click);
            // 
            // txtVelicina
            // 
            this.txtVelicina.Location = new System.Drawing.Point(413, 71);
            this.txtVelicina.Name = "txtVelicina";
            this.txtVelicina.Size = new System.Drawing.Size(148, 22);
            this.txtVelicina.TabIndex = 15;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(410, 39);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(55, 16);
            this.label1.TabIndex = 16;
            this.label1.Text = "Veličina";
            // 
            // FrmAzuriraj
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(573, 369);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtVelicina);
            this.Controls.Add(this.btnOdustani);
            this.Controls.Add(this.btnSpremi);
            this.Controls.Add(this.lblVlasnik);
            this.Controls.Add(this.txtVlasnik);
            this.Controls.Add(this.lblVrsta);
            this.Controls.Add(this.cboEnergent);
            this.Controls.Add(this.lblPotrosnja);
            this.Controls.Add(this.lblAdresa);
            this.Controls.Add(this.txtPotrosnja);
            this.Controls.Add(this.txtAdresa);
            this.Name = "FrmAzuriraj";
            this.Text = "Ažuriraj podatke";
            this.Load += new System.EventHandler(this.FrmAzuriraj_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtAdresa;
        private System.Windows.Forms.TextBox txtPotrosnja;
        private System.Windows.Forms.Label lblAdresa;
        private System.Windows.Forms.Label lblPotrosnja;
        private System.Windows.Forms.ComboBox cboEnergent;
        private System.Windows.Forms.Label lblVrsta;
        private System.Windows.Forms.TextBox txtVlasnik;
        private System.Windows.Forms.Label lblVlasnik;
        private System.Windows.Forms.Button btnSpremi;
        private System.Windows.Forms.Button btnOdustani;
        private System.Windows.Forms.TextBox txtVelicina;
        private System.Windows.Forms.Label label1;
    }
}