using Manejador;
using Presentacion_TallerAutomotiz;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Cinemonopylo_YJSG_VMG
{
    public partial class FrmAgregarSalas : Form
    {
        ManejadorAdministrador ma;
        public FrmAgregarSalas()
        {
            InitializeComponent();
            ma = new ManejadorAdministrador();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
           MessageBox.Show(ma.AgregarSala(txtNombre, txtUbi));
            txtNombre.Clear();
            txtUbi.Clear();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
