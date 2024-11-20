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
        ManejadorCliente ml;
        int IdUsuario = 0;
        string MetodoPago = "TARJETA DE CREDITO";

        public FrmComprar_Boletos()
        {
            InitializeComponent();
            ml = new ManejadorCliente();
            ml.InicializarFormulario(cmbProductos, cmbPeliculas, cmbHorarios, pnlAsientos, btnConfirmar, pnlResumen, lblSala, lblHorario, lblUser, lblTotal);
            IdUsuario = ManejadorLogin.UserId;
            if(ManejadorLogin.Tipo.Equals("Cliente"))
            {
                groupBox1.Visible = true;
                grbAlimentos.Visible = false;
            }
            if (ManejadorLogin.Tipo.Equals("Invitado"))
            {
                groupBox1.Visible = true;
                grbAlimentos.Visible = false;
            }
            if (ManejadorLogin.Tipo.Equals("Taquillero"))
            {
                groupBox1.Visible = true;
                grbAlimentos.Visible = true;
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnConfirmar_Click(object sender, EventArgs e)
        {
            try
            {
                ml.Resumen(lblHorario,
                           cmbHorarios,
                           cmbPeliculas,
                           pnlAsientos,
                           pnlResumen,
                           lblSala,
                           lblTotal);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al confirmar la venta: {ex.Message}",
                               "Error",
                               MessageBoxButtons.OK,
                               MessageBoxIcon.Error);
            }
        }
    }
}
