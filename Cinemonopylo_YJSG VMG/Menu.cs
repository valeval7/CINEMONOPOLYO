using Manejador;
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
    public partial class Menu : Form
    {
        public Menu()
        {
            InitializeComponent();
            groupBox1.Enabled = true;
            if (ManejadorLogin.Tipo.Equals("Cliente"))
            {
                btnClientes.Visible= true;
                btnTaquilla.Visible = false;
                btnAdministrar.Visible = false;
            }
            if (ManejadorLogin.Tipo.Equals("Taquillero"))
            {
                btnClientes.Visible = false;
                btnTaquilla.Visible = true;
                btnAdministrar.Visible = false;
            }
            if (ManejadorLogin.Tipo.Equals("Invitado"))
            {
                btnClientes.Visible = true;
                btnTaquilla.Visible = false;
                btnAdministrar.Visible = false;
            }
            if (ManejadorLogin.Tipo.Equals("Administrador"))
            {
                btnClientes.Visible = false;
                btnTaquilla.Visible = true;
                btnAdministrar.Visible = true;
            }

        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnClientes_Click(object sender, EventArgs e)
        {
            FrmComprar_Boletos a = new FrmComprar_Boletos();
            a.Show();
            groupBox1.Enabled = false;
        }

        private void btnTaquilla_Click(object sender, EventArgs e)
        {
            FrmMenuTaquilla a = new FrmMenuTaquilla();
            a.Show();
            groupBox1.Enabled = false;
        }

        private void btnAdministrar_Click(object sender, EventArgs e)
        {
            FrmMenuAdministrador a = new FrmMenuAdministrador();
            a.Show();
            groupBox1.Enabled = false;
        }
    }
}
