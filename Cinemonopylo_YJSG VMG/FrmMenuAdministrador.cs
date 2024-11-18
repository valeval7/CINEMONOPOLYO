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
    public partial class FrmMenuAdministrador : Form
    {
        public FrmMenuAdministrador()
        {
            InitializeComponent();
        }

        private void btnPeliculas_Click(object sender, EventArgs e)
        {
            Peliculas a = new Peliculas();
            a.MdiParent = this;
            a.Show();
        }

        private void btnSalas_Click(object sender, EventArgs e)
        {
            FrmAgregarSalas a = new FrmAgregarSalas();
            a.MdiParent = this;
            a.Show();
        }

        private void btnUsuarios_Click(object sender, EventArgs e)
        {
            FrmUsuarios a = new FrmUsuarios();
            a.MdiParent = this;
            a.Show();
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
