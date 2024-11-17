using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Manejador;

namespace Cinemonopylo_YJSG_VMG
{
    public partial class FrmComprar_Boletos : Form
    {
        ManejadorCliente manejador = new ManejadorCliente();
        public FrmComprar_Boletos()
        {
            InitializeComponent();
            manejador.InicializarFormulario(cmbPeliculas, cmbHorarios, pnlAsientos, btnConfirmar, pnlResumen);
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
