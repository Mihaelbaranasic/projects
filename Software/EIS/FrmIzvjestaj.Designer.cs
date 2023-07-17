namespace EIS {
    partial class FrmIzvjestaj {
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
            this.dgvIzvjesce = new System.Windows.Forms.DataGridView();
            this.btnZatvori = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvIzvjesce)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvIzvjesce
            // 
            this.dgvIzvjesce.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvIzvjesce.Location = new System.Drawing.Point(36, 12);
            this.dgvIzvjesce.Name = "dgvIzvjesce";
            this.dgvIzvjesce.RowHeadersWidth = 51;
            this.dgvIzvjesce.RowTemplate.Height = 24;
            this.dgvIzvjesce.Size = new System.Drawing.Size(718, 360);
            this.dgvIzvjesce.TabIndex = 0;
            // 
            // btnZatvori
            // 
            this.btnZatvori.Location = new System.Drawing.Point(640, 388);
            this.btnZatvori.Name = "btnZatvori";
            this.btnZatvori.Size = new System.Drawing.Size(99, 50);
            this.btnZatvori.TabIndex = 1;
            this.btnZatvori.Text = "Zatvori";
            this.btnZatvori.UseVisualStyleBackColor = true;
            this.btnZatvori.Click += new System.EventHandler(this.btnZatvori_Click);
            // 
            // FrmIzvjestaj
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btnZatvori);
            this.Controls.Add(this.dgvIzvjesce);
            this.Name = "FrmIzvjestaj";
            this.Text = "FrmIzvjestaj";
            this.Load += new System.EventHandler(this.FrmIzvjestaj_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvIzvjesce)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvIzvjesce;
        private System.Windows.Forms.Button btnZatvori;
    }
}