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
    public partial class FrmIzvjesce : Form {
        public FrmIzvjesce() {
            InitializeComponent();
        }

        private void FrmIzvjesce_Load(object sender, EventArgs e) {
            SkupObjekata skupObjekata = new SkupObjekata();
            List<IzvjesceObjekata> izvjesca = skupObjekata.GenerirajIzvjescaObjekata();
            dgvIzvjesce.DataSource = izvjesca;
            
        }
    }
}
