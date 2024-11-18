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
        int IdUsuario = 0;

        public FrmComprar_Boletos()
        {
            InitializeComponent();
            manejador.InicializarFormulario(cmbProductos, cmbPeliculas, cmbHorarios, pnlAsientos, btnConfirmar, pnlResumen, lblSala, lblHorario);
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
            manejador.GuardarVenta(int.Parse(lblHorario.Text), IdUsuario);
        }
    }
}
