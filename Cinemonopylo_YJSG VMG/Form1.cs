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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            groupBox1.Enabled = true;
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
    }
}
